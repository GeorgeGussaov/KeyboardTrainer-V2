namespace KeyboardTrainer
{
    partial class FormFirstMode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelText = new System.Windows.Forms.Label();
            this.textBoxTrainingField = new System.Windows.Forms.TextBox();
            this.labelCntError = new System.Windows.Forms.Label();
            this.labelCurrentWord = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelText.Location = new System.Drawing.Point(12, 9);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(1060, 285);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "TextFromFile";
            // 
            // textBoxTrainingField
            // 
            this.textBoxTrainingField.Location = new System.Drawing.Point(450, 297);
            this.textBoxTrainingField.Name = "textBoxTrainingField";
            this.textBoxTrainingField.Size = new System.Drawing.Size(173, 20);
            this.textBoxTrainingField.TabIndex = 1;
            this.textBoxTrainingField.TextChanged += new System.EventHandler(this.textBoxTrainingField_TextChanged);
            // 
            // labelCntError
            // 
            this.labelCntError.AutoSize = true;
            this.labelCntError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.labelCntError.Location = new System.Drawing.Point(33, 300);
            this.labelCntError.Name = "labelCntError";
            this.labelCntError.Size = new System.Drawing.Size(144, 17);
            this.labelCntError.TabIndex = 2;
            this.labelCntError.Text = "Количество ошибок:";
            // 
            // labelCurrentWord
            // 
            this.labelCurrentWord.AutoSize = true;
            this.labelCurrentWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.labelCurrentWord.Location = new System.Drawing.Point(757, 300);
            this.labelCurrentWord.Name = "labelCurrentWord";
            this.labelCurrentWord.Size = new System.Drawing.Size(112, 17);
            this.labelCurrentWord.TabIndex = 3;
            this.labelCurrentWord.Text = "Текущее слово:";
            // 
            // FormFirstMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 711);
            this.Controls.Add(this.labelCurrentWord);
            this.Controls.Add(this.labelCntError);
            this.Controls.Add(this.textBoxTrainingField);
            this.Controls.Add(this.labelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormFirstMode";
            this.Text = "Первый режим";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TextBox textBoxTrainingField;
        private System.Windows.Forms.Label labelCntError;
        private System.Windows.Forms.Label labelCurrentWord;
    }
}