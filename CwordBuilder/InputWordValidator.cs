using CwordCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CwordBuilder
{
    class InputWordValidator
    {
        private List<Element> elements;

        private string word;
        private int errorIndex;

        private delegate void Validator();

        private List<Validator> validators;

        public string Errors { get; private set; }

        public InputWordValidator(List<Element> elements)
        {
            this.elements = elements;
            validators = new List<Validator>()
            {
                TryAddExistWord,
                MinLenValidator,
                MaxLenValidator,
                SymbolsValidator,
                GapValidator,
            };
        }

        public bool Validate(string word)
        {
            Errors = "";
            errorIndex = 1;
            this.word = word;
            foreach( var validator in validators) 
            {
                validator();
            }
            return Errors == "";
        }

        private void AddError(string error)
        {
            Errors += string.Format("\n\n {0}) {1}", errorIndex++, error);
        }

        private void TryAddExistWord()
        {
            if (elements.Exists(element => element.word == word))
                AddError("Cлово уже существует в списке слов. Дубли не допускаются");
        }

        private void MinLenValidator()
        {
            if (word.Length < 3) AddError("Длина слова должна быть больше или равна 3.");
        }

        private void MaxLenValidator()
        {
            if (word.Length > 20) AddError("Длина слова должна быть меньше или равна 20.");
        }

        private void SymbolsValidator()
        {
            if (!Regex.IsMatch(word, @"^[а-яёa-z1-9]*$"))
            {
                AddError("Все символы должны вводиться в нижнем регистре. Допускаются тольк цифры, русские и ангийские символы.");
            }
        }

        private void GapValidator()
        {
            if (Regex.IsMatch(word, @"[ \t\n]"))
            {
                AddError("Символы пробела, перехода на новую строку и др. не допускаются.");
            }
        }
    }
}
