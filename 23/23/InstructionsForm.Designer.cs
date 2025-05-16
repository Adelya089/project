namespace _23
{
    partial class InstructionsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtInstructions;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtInstructions = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // txtInstructions
            this.txtInstructions.BackColor = System.Drawing.Color.White;  // Явно задаем белый фон
            this.txtInstructions.ForeColor = System.Drawing.Color.Black;  // Черный текст
            this.txtInstructions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtInstructions.Location = new System.Drawing.Point(10, 10);
            this.txtInstructions.Margin = new System.Windows.Forms.Padding(10);
            this.txtInstructions.Multiline = true;
            this.txtInstructions.Name = "txtInstructions";
            this.txtInstructions.ReadOnly = true;
            this.txtInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInstructions.Size = new System.Drawing.Size(380, 250);
            this.txtInstructions.TabIndex = 0;

            // InstructionsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;  // Белый фон формы
            this.ClientSize = new System.Drawing.Size(400, 270);
            this.Controls.Add(this.txtInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InstructionsForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Инструкции";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}