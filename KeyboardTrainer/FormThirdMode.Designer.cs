namespace KeyboardTrainer
{
    partial class FormThirdMode
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
            this.components = new System.ComponentModel.Container();
            this.timerSpawnButtons = new System.Windows.Forms.Timer(this.components);
            this.timerMoveButtons = new System.Windows.Forms.Timer(this.components);
            this.labelText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerSpawnButtons
            // 
            this.timerSpawnButtons.Interval = 800;
            this.timerSpawnButtons.Tick += new System.EventHandler(this.timerSpawnButtons_Tick);
            // 
            // timerMoveButtons
            // 
            this.timerMoveButtons.Interval = 550;
            this.timerMoveButtons.Tick += new System.EventHandler(this.timerMoveButtons_Tick);
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.labelText.Location = new System.Drawing.Point(369, 172);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(293, 18);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Нажимте любую клавишу, чтобы начать.";
            // 
            // FormThirdMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 711);
            this.Controls.Add(this.labelText);
            this.Name = "FormThirdMode";
            this.Text = "Третий режим";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormThirdMode_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerSpawnButtons;
        private System.Windows.Forms.Timer timerMoveButtons;
        private System.Windows.Forms.Label labelText;
    }
}