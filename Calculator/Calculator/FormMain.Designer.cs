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

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.workNum = new System.Windows.Forms.TextBox();
            this.labelResult = new System.Windows.Forms.Label();
            this.plusButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // workNum
            // 
            this.workNum.CausesValidation = false;
            this.workNum.Location = new System.Drawing.Point(283, 46);
            this.workNum.Name = "WorkNum";
            this.workNum.Size = new System.Drawing.Size(100, 20);
            this.workNum.TabIndex = 0;
            this.workNum.Text = "0";
            this.workNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.workNum_KeyPress);
            this.workNum.TextChanged += new System.EventHandler(this.workNum_TextChanged);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(224, 418);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(35, 13);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 799);
            this.Controls.Add(this.plusButton);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.workNum);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox workNum;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button plusButton;
    }
}

