namespace Typy_trójkątów
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonMiłejZabawy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.labelMessage.Location = new System.Drawing.Point(56, 23);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(629, 225);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = resources.GetString("labelMessage.Text");
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMessage.Click += new System.EventHandler(this.labelMessage_Click);
            // 
            // buttonMiłejZabawy
            // 
            this.buttonMiłejZabawy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.buttonMiłejZabawy.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.buttonMiłejZabawy.Location = new System.Drawing.Point(225, 262);
            this.buttonMiłejZabawy.Name = "buttonMiłejZabawy";
            this.buttonMiłejZabawy.Size = new System.Drawing.Size(281, 63);
            this.buttonMiłejZabawy.TabIndex = 1;
            this.buttonMiłejZabawy.Text = "Miłej Zabawy !";
            this.buttonMiłejZabawy.UseVisualStyleBackColor = false;
            this.buttonMiłejZabawy.Click += new System.EventHandler(this.buttonMiłejZabawy_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 396);
            this.ControlBox = false;
            this.Controls.Add(this.buttonMiłejZabawy);
            this.Controls.Add(this.labelMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "O projekcie";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonMiłejZabawy;
    }
}