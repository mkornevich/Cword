namespace CwordBuilder.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.removeActionBtn = new System.Windows.Forms.Button();
            this.addActionBtn = new System.Windows.Forms.Button();
            this.questionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.elementsListBox = new System.Windows.Forms.ListBox();
            this.drawPanel = new System.Windows.Forms.Panel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генераторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.infoLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.removeActionBtn);
            this.panel1.Controls.Add(this.addActionBtn);
            this.panel1.Controls.Add(this.questionTextBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.wordTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.elementsListBox);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 761);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(240, 431);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 27);
            this.button1.TabIndex = 14;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.StoreSelectedElementAction);
            // 
            // removeActionBtn
            // 
            this.removeActionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.removeActionBtn.Location = new System.Drawing.Point(4, 431);
            this.removeActionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.removeActionBtn.Name = "removeActionBtn";
            this.removeActionBtn.Size = new System.Drawing.Size(108, 27);
            this.removeActionBtn.TabIndex = 13;
            this.removeActionBtn.Text = "Удалить";
            this.removeActionBtn.UseVisualStyleBackColor = true;
            this.removeActionBtn.Click += new System.EventHandler(this.RemoveSelectedElementAction);
            // 
            // addActionBtn
            // 
            this.addActionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addActionBtn.Location = new System.Drawing.Point(118, 431);
            this.addActionBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addActionBtn.Name = "addActionBtn";
            this.addActionBtn.Size = new System.Drawing.Size(115, 27);
            this.addActionBtn.TabIndex = 12;
            this.addActionBtn.Text = "Добавить";
            this.addActionBtn.UseVisualStyleBackColor = true;
            this.addActionBtn.Click += new System.EventHandler(this.AddNewElementAction);
            // 
            // questionTextBox
            // 
            this.questionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionTextBox.Location = new System.Drawing.Point(5, 537);
            this.questionTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.questionTextBox.Multiline = true;
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.Size = new System.Drawing.Size(336, 221);
            this.questionTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Вопрос";
            // 
            // wordTextBox
            // 
            this.wordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wordTextBox.Location = new System.Drawing.Point(5, 480);
            this.wordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.wordTextBox.Name = "wordTextBox";
            this.wordTextBox.Size = new System.Drawing.Size(336, 22);
            this.wordTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Слово";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Элементы для кроссворда";
            // 
            // elementsListBox
            // 
            this.elementsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.elementsListBox.FormattingEnabled = true;
            this.elementsListBox.ItemHeight = 16;
            this.elementsListBox.Location = new System.Drawing.Point(5, 30);
            this.elementsListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementsListBox.Name = "elementsListBox";
            this.elementsListBox.Size = new System.Drawing.Size(336, 388);
            this.elementsListBox.TabIndex = 6;
            this.elementsListBox.SelectedValueChanged += new System.EventHandler(this.LoadSelectedElementAction);
            // 
            // drawPanel
            // 
            this.drawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawPanel.BackColor = System.Drawing.SystemColors.Control;
            this.drawPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.drawPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawPanel.Location = new System.Drawing.Point(365, 61);
            this.drawPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(901, 728);
            this.drawPanel.TabIndex = 1;
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.генераторToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1278, 28);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMenuItem,
            this.openMenuItem,
            this.saveMenuItem,
            this.saveAsMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // newMenuItem
            // 
            this.newMenuItem.Image = global::CwordBuilder.Properties.Resources.New;
            this.newMenuItem.Name = "newMenuItem";
            this.newMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newMenuItem.Size = new System.Drawing.Size(282, 26);
            this.newMenuItem.Text = "Новый";
            this.newMenuItem.Click += new System.EventHandler(this.CreateNewProjectAction);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Image = global::CwordBuilder.Properties.Resources.Open;
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenuItem.Size = new System.Drawing.Size(282, 26);
            this.openMenuItem.Text = "Открыть";
            this.openMenuItem.Click += new System.EventHandler(this.OpenProjectAction);
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Image = global::CwordBuilder.Properties.Resources.Save;
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(282, 26);
            this.saveMenuItem.Text = "Сохранить";
            this.saveMenuItem.Click += new System.EventHandler(this.SaveProjectAction);
            // 
            // saveAsMenuItem
            // 
            this.saveAsMenuItem.Image = global::CwordBuilder.Properties.Resources.SaveAs;
            this.saveAsMenuItem.Name = "saveAsMenuItem";
            this.saveAsMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsMenuItem.Size = new System.Drawing.Size(282, 26);
            this.saveAsMenuItem.Text = "Сохранить как";
            this.saveAsMenuItem.Click += new System.EventHandler(this.SaveAsProjectAction);
            // 
            // генераторToolStripMenuItem
            // 
            this.генераторToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generateMenuItem});
            this.генераторToolStripMenuItem.Name = "генераторToolStripMenuItem";
            this.генераторToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.генераторToolStripMenuItem.Text = "Проект";
            // 
            // generateMenuItem
            // 
            this.generateMenuItem.Image = global::CwordBuilder.Properties.Resources.Generate;
            this.generateMenuItem.Name = "generateMenuItem";
            this.generateMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.generateMenuItem.Size = new System.Drawing.Size(291, 26);
            this.generateMenuItem.Text = "Генерировать кроссворд";
            this.generateMenuItem.Click += new System.EventHandler(this.FormAndDrawAction);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(118, 24);
            this.aboutToolStripMenuItem.Text = "О программе";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.ShowAboutFormAction);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 797);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1278, 26);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // infoLbl
            // 
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(481, 20);
            this.infoLbl.Text = "Добавляйте или откройте вопросы а затем нажмите генерировать.";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "CWD  кроссворд (*.cwd)|*.cwd|Все файлы (*.*)|*.*";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "CWD  кроссворд (*.cwd)|*.cwd|Все файлы (*.*)|*.*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Результат сгенерированного кроссворда";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 823);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "MainForm";
            this.Text = "CwordBuilder";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button removeActionBtn;
        private System.Windows.Forms.Button addActionBtn;
        private System.Windows.Forms.TextBox questionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox elementsListBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem генераторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel infoLbl;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.ToolStripMenuItem saveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
    }
}

