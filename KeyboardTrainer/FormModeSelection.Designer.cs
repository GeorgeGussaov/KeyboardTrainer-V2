namespace KeyboardTrainer
{
    partial class FormModeSelection
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
            this.buttonFirstMode = new System.Windows.Forms.Button();
            this.buttonSecondMode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFirstMode
            // 
            this.buttonFirstMode.Location = new System.Drawing.Point(154, 95);
            this.buttonFirstMode.Name = "buttonFirstMode";
            this.buttonFirstMode.Size = new System.Drawing.Size(465, 72);
            this.buttonFirstMode.TabIndex = 0;
            this.buttonFirstMode.Text = "Первый режим";
            this.buttonFirstMode.UseVisualStyleBackColor = true;
            this.buttonFirstMode.Click += new System.EventHandler(this.buttonFirstMode_Click);
            // 
            // buttonSecondMode
            // 
            this.buttonSecondMode.Location = new System.Drawing.Point(154, 242);
            this.buttonSecondMode.Name = "buttonSecondMode";
            this.buttonSecondMode.Size = new System.Drawing.Size(465, 72);
            this.buttonSecondMode.TabIndex = 1;
            this.buttonSecondMode.Text = "Второй режим";
            this.buttonSecondMode.UseVisualStyleBackColor = true;
            this.buttonSecondMode.Click += new System.EventHandler(this.buttonSecondMode_Click);
            // 
            // FormModeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSecondMode);
            this.Controls.Add(this.buttonFirstMode);
            this.Name = "FormModeSelection";
            this.Text = "Выбор режима";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFirstMode;
        private System.Windows.Forms.Button buttonSecondMode;
    }
}

