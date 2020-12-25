namespace Calculator
{
    partial class FormMain
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

        private void InitializeComponent()
        {
            this.workNumBox = new System.Windows.Forms.TextBox();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.stateNum = new System.Windows.Forms.Label();
            this.statesList = new System.Windows.Forms.ListBox();
            this.undoButton = new System.Windows.Forms.Button();
            this.repeatButton = new System.Windows.Forms.Button();
            this.EmptyButton = new System.Windows.Forms.Button();
            this.numbersListBox = new System.Windows.Forms.ListBox();
            this.addNumber = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteLastButton = new System.Windows.Forms.Button();
            this.deleteAllButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_Load = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.squareButton = new System.Windows.Forms.Button();
            this.powerNButton = new System.Windows.Forms.Button();
            this.logNButton = new System.Windows.Forms.Button();
            this.factButton = new System.Windows.Forms.Button();
            this.rootButton = new System.Windows.Forms.Button();
            this.medianaButton = new System.Windows.Forms.Button();
            this.standartDeviationButton = new System.Windows.Forms.Button();
            this.rootNButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // workNumBox
            // 
            this.workNumBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.workNumBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.workNumBox.CausesValidation = false;
            this.workNumBox.Location = new System.Drawing.Point(81, 27);
            this.workNumBox.Name = "workNumBox";
            this.workNumBox.Size = new System.Drawing.Size(100, 20);
            this.workNumBox.TabIndex = 0;
            this.workNumBox.Text = "0";
            this.workNumBox.TextChanged += new System.EventHandler(this.workNumBox_TextChanged);
            this.workNumBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.workNumBox_KeyPress);
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(0, 73);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(75, 23);
            this.plusButton.TabIndex = 2;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(81, 73);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(75, 23);
            this.minusButton.TabIndex = 3;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Location = new System.Drawing.Point(0, 102);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(75, 23);
            this.multiplyButton.TabIndex = 4;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButton_Click);
            // 
            // divideButton
            // 
            this.divideButton.Location = new System.Drawing.Point(81, 102);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(75, 23);
            this.divideButton.TabIndex = 5;
            this.divideButton.Text = "/";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new System.EventHandler(this.divideButton_Click);
            // 
            // stateNum
            // 
            this.stateNum.AutoSize = true;
            this.stateNum.Location = new System.Drawing.Point(282, 34);
            this.stateNum.Name = "stateNum";
            this.stateNum.Size = new System.Drawing.Size(24, 13);
            this.stateNum.TabIndex = 6;
            this.stateNum.Text = "0/0";
            // 
            // statesList
            // 
            this.statesList.FormattingEnabled = true;
            this.statesList.Location = new System.Drawing.Point(243, 53);
            this.statesList.Name = "statesList";
            this.statesList.Size = new System.Drawing.Size(75, 95);
            this.statesList.TabIndex = 7;
            this.statesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.statesList_MouseDoubleClick);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(0, 27);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 23);
            this.undoButton.TabIndex = 8;
            this.undoButton.Text = "UnDo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // repeatButton
            // 
            this.repeatButton.Location = new System.Drawing.Point(187, 24);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(75, 23);
            this.repeatButton.TabIndex = 9;
            this.repeatButton.Text = "Repeat";
            this.repeatButton.UseVisualStyleBackColor = true;
            this.repeatButton.Click += new System.EventHandler(this.repeatButton_Click);
            // 
            // EmptyButton
            // 
            this.EmptyButton.Location = new System.Drawing.Point(399, 12);
            this.EmptyButton.Name = "EmptyButton";
            this.EmptyButton.Size = new System.Drawing.Size(10, 10);
            this.EmptyButton.TabIndex = 10;
            this.EmptyButton.Text = "Original                        ";
            this.EmptyButton.UseVisualStyleBackColor = true;
            this.EmptyButton.Visible = false;
            // 
            // numbersListBox
            // 
            this.numbersListBox.FormattingEnabled = true;
            this.numbersListBox.Location = new System.Drawing.Point(0, 284);
            this.numbersListBox.Name = "numbersListBox";
            this.numbersListBox.Size = new System.Drawing.Size(318, 238);
            this.numbersListBox.TabIndex = 11;
            // 
            // addNumber
            // 
            this.addNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.addNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.addNumber.Location = new System.Drawing.Point(81, 258);
            this.addNumber.Name = "addNumber";
            this.addNumber.Size = new System.Drawing.Size(100, 20);
            this.addNumber.TabIndex = 12;
            this.addNumber.Text = "0";
            this.addNumber.TextChanged += new System.EventHandler(this.addNumber_TextChanged);
            this.addNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addNumber_KeyPress);
            this.addNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.addNumber_KeyUp);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 258);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 13;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteLastButton
            // 
            this.deleteLastButton.Location = new System.Drawing.Point(187, 258);
            this.deleteLastButton.Name = "deleteLastButton";
            this.deleteLastButton.Size = new System.Drawing.Size(34, 23);
            this.deleteLastButton.TabIndex = 14;
            this.deleteLastButton.Text = "C";
            this.deleteLastButton.UseVisualStyleBackColor = true;
            this.deleteLastButton.Click += new System.EventHandler(this.deleteLastButton_Click);
            // 
            // deleteAllButton
            // 
            this.deleteAllButton.Location = new System.Drawing.Point(227, 258);
            this.deleteAllButton.Name = "deleteAllButton";
            this.deleteAllButton.Size = new System.Drawing.Size(34, 23);
            this.deleteAllButton.TabIndex = 15;
            this.deleteAllButton.Text = "CE";
            this.deleteAllButton.UseVisualStyleBackColor = true;
            this.deleteAllButton.Click += new System.EventHandler(this.deleteAllButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(318, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Save,
            this.menu_Load});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // menu_Save
            // 
            this.menu_Save.Name = "menu_Save";
            this.menu_Save.Size = new System.Drawing.Size(100, 22);
            this.menu_Save.Text = "Save";
            this.menu_Save.Click += new System.EventHandler(this.menu_Save_Click);
            // 
            // menu_Load
            // 
            this.menu_Load.Name = "menu_Load";
            this.menu_Load.Size = new System.Drawing.Size(100, 22);
            this.menu_Load.Text = "Load";
            this.menu_Load.Click += new System.EventHandler(this.menu_Load_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text files(*.txt)|*.txt";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text files(*.txt)|*.txt";
            // 
            // squareButton
            // 
            this.squareButton.Location = new System.Drawing.Point(162, 73);
            this.squareButton.Name = "squareButton";
            this.squareButton.Size = new System.Drawing.Size(75, 23);
            this.squareButton.TabIndex = 17;
            this.squareButton.Text = "Sqr";
            this.squareButton.UseVisualStyleBackColor = true;
            this.squareButton.Click += new System.EventHandler(this.squareButton_Click);
            // 
            // powerNButton
            // 
            this.powerNButton.Location = new System.Drawing.Point(162, 102);
            this.powerNButton.Name = "powerNButton";
            this.powerNButton.Size = new System.Drawing.Size(75, 23);
            this.powerNButton.TabIndex = 18;
            this.powerNButton.Text = "PwrN";
            this.powerNButton.UseVisualStyleBackColor = true;
            this.powerNButton.Click += new System.EventHandler(this.powerNButton_Click);
            // 
            // logNButton
            // 
            this.logNButton.Location = new System.Drawing.Point(0, 131);
            this.logNButton.Name = "logNButton";
            this.logNButton.Size = new System.Drawing.Size(75, 23);
            this.logNButton.TabIndex = 19;
            this.logNButton.Text = "LogN";
            this.logNButton.UseVisualStyleBackColor = true;
            this.logNButton.Click += new System.EventHandler(this.logNButton_Click);
            // 
            // factButton
            // 
            this.factButton.Location = new System.Drawing.Point(81, 131);
            this.factButton.Name = "factButton";
            this.factButton.Size = new System.Drawing.Size(75, 23);
            this.factButton.TabIndex = 20;
            this.factButton.Text = "N!";
            this.factButton.UseVisualStyleBackColor = true;
            this.factButton.Click += new System.EventHandler(this.factButton_Click);
            // 
            // rootButton
            // 
            this.rootButton.Location = new System.Drawing.Point(162, 131);
            this.rootButton.Name = "rootButton";
            this.rootButton.Size = new System.Drawing.Size(75, 23);
            this.rootButton.TabIndex = 21;
            this.rootButton.Text = "Root";
            this.rootButton.UseVisualStyleBackColor = true;
            this.rootButton.Click += new System.EventHandler(this.rootButton_Click);
            // 
            // medianaButton
            // 
            this.medianaButton.Location = new System.Drawing.Point(0, 160);
            this.medianaButton.Name = "medianaButton";
            this.medianaButton.Size = new System.Drawing.Size(75, 23);
            this.medianaButton.TabIndex = 22;
            this.medianaButton.Text = "Md";
            this.medianaButton.UseVisualStyleBackColor = true;
            this.medianaButton.Click += new System.EventHandler(this.medianaButton_Click);
            // 
            // standartDeviationButton
            // 
            this.standartDeviationButton.Location = new System.Drawing.Point(81, 160);
            this.standartDeviationButton.Name = "standartDeviationButton";
            this.standartDeviationButton.Size = new System.Drawing.Size(75, 23);
            this.standartDeviationButton.TabIndex = 23;
            this.standartDeviationButton.Text = "StD";
            this.standartDeviationButton.UseVisualStyleBackColor = true;
            this.standartDeviationButton.Click += new System.EventHandler(this.standartDeviationButton_Click);
            // 
            // rootNButton
            // 
            this.rootNButton.Location = new System.Drawing.Point(162, 160);
            this.rootNButton.Name = "rootNButton";
            this.rootNButton.Size = new System.Drawing.Size(75, 23);
            this.rootNButton.TabIndex = 24;
            this.rootNButton.Text = "RootN";
            this.rootNButton.UseVisualStyleBackColor = true;
            this.rootNButton.Click += new System.EventHandler(this.rootNButton_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 525);
            this.Controls.Add(this.rootNButton);
            this.Controls.Add(this.standartDeviationButton);
            this.Controls.Add(this.medianaButton);
            this.Controls.Add(this.rootButton);
            this.Controls.Add(this.factButton);
            this.Controls.Add(this.logNButton);
            this.Controls.Add(this.powerNButton);
            this.Controls.Add(this.squareButton);
            this.Controls.Add(this.deleteAllButton);
            this.Controls.Add(this.deleteLastButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.addNumber);
            this.Controls.Add(this.numbersListBox);
            this.Controls.Add(this.EmptyButton);
            this.Controls.Add(this.repeatButton);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.statesList);
            this.Controls.Add(this.stateNum);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.workNumBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox workNumBox;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Label stateNum;
        private System.Windows.Forms.ListBox statesList;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button repeatButton;
        private System.Windows.Forms.Button EmptyButton;
        private System.Windows.Forms.ListBox numbersListBox;
        private System.Windows.Forms.TextBox addNumber;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteLastButton;
        private System.Windows.Forms.Button deleteAllButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menu_Save;
        private System.Windows.Forms.ToolStripMenuItem menu_Load;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button squareButton;
        private System.Windows.Forms.Button powerNButton;
        private System.Windows.Forms.Button logNButton;
        private System.Windows.Forms.Button factButton;
        private System.Windows.Forms.Button rootButton;
        private System.Windows.Forms.Button medianaButton;
        private System.Windows.Forms.Button standartDeviationButton;
        private System.Windows.Forms.Button rootNButton;
    }
}

