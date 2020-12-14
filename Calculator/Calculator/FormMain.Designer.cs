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
            this.labelResult = new System.Windows.Forms.Label();
            this.plusButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.stateNum = new System.Windows.Forms.Label();
            this.statesList = new System.Windows.Forms.ListBox();
            this.undo = new System.Windows.Forms.Button();
            this.repeat = new System.Windows.Forms.Button();
            this.EmptyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workNumBox
            // 
            this.workNumBox.CausesValidation = false;
            this.workNumBox.Location = new System.Drawing.Point(283, 46);
            this.workNumBox.Name = "workNumBox";
            this.workNumBox.Size = new System.Drawing.Size(100, 20);
            this.workNumBox.TabIndex = 0;
            this.workNumBox.Text = "0";
            this.workNumBox.TextChanged += new System.EventHandler(this.workNumBox_TextChanged);
            this.workNumBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.workNumBox_KeyPress);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(305, 428);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(59, 13);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "labelResult";
            // 
            // plusButton
            // 
            this.plusButton.Location = new System.Drawing.Point(172, 131);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(75, 23);
            this.plusButton.TabIndex = 2;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.plusButton_Click);
            // 
            // minusButton
            // 
            this.minusButton.Location = new System.Drawing.Point(253, 131);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(75, 23);
            this.minusButton.TabIndex = 3;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.minusButton_Click);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Location = new System.Drawing.Point(334, 131);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(75, 23);
            this.multiplyButton.TabIndex = 4;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.multiplyButton_Click);
            // 
            // divideButton
            // 
            this.divideButton.Location = new System.Drawing.Point(415, 131);
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
            this.stateNum.Location = new System.Drawing.Point(546, 22);
            this.stateNum.Name = "stateNum";
            this.stateNum.Size = new System.Drawing.Size(24, 13);
            this.stateNum.TabIndex = 6;
            this.stateNum.Text = "0/0";
            // 
            // statesList
            // 
            this.statesList.FormattingEnabled = true;
            this.statesList.Location = new System.Drawing.Point(549, 46);
            this.statesList.Name = "statesList";
            this.statesList.Size = new System.Drawing.Size(120, 95);
            this.statesList.TabIndex = 7;
            this.statesList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.statesList_MouseDoubleClick);
            // 
            // undo
            // 
            this.undo.Location = new System.Drawing.Point(171, 46);
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(75, 23);
            this.undo.TabIndex = 8;
            this.undo.Text = "UnDo";
            this.undo.UseVisualStyleBackColor = true;
            this.undo.Click += new System.EventHandler(this.undo_Click);
            // 
            // repeat
            // 
            this.repeat.Location = new System.Drawing.Point(415, 46);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(75, 23);
            this.repeat.TabIndex = 9;
            this.repeat.Text = "Repeat";
            this.repeat.UseVisualStyleBackColor = true;
            this.repeat.Click += new System.EventHandler(this.repeat_Click);
            // 
            // EmptyButton
            // 
            this.EmptyButton.Location = new System.Drawing.Point(12, 46);
            this.EmptyButton.Name = "EmptyButton";
            this.EmptyButton.Size = new System.Drawing.Size(75, 23);
            this.EmptyButton.TabIndex = 10;
            this.EmptyButton.Text = "Original";
            this.EmptyButton.UseVisualStyleBackColor = true;
            this.EmptyButton.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 799);
            this.Controls.Add(this.EmptyButton);
            this.Controls.Add(this.repeat);
            this.Controls.Add(this.undo);
            this.Controls.Add(this.statesList);
            this.Controls.Add(this.stateNum);
            this.Controls.Add(this.divideButton);
            this.Controls.Add(this.multiplyButton);
            this.Controls.Add(this.minusButton);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.workNumBox);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox workNumBox;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Label stateNum;
        private System.Windows.Forms.ListBox statesList;
        private System.Windows.Forms.Button undo;
        private System.Windows.Forms.Button repeat;
        private System.Windows.Forms.Button EmptyButton;
    }
}

