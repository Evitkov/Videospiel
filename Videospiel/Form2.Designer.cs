namespace Videospiel
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
            this.txtBox = new System.Windows.Forms.TextBox();
            this.btRestart = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBox
            // 
            this.txtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox.Location = new System.Drawing.Point(40, 49);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(244, 40);
            this.txtBox.TabIndex = 0;
            this.txtBox.Text = "GAME OVER";
            this.txtBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btRestart
            // 
            this.btRestart.Location = new System.Drawing.Point(240, 126);
            this.btRestart.Name = "btRestart";
            this.btRestart.Size = new System.Drawing.Size(59, 30);
            this.btRestart.TabIndex = 1;
            this.btRestart.Text = "Restart";
            this.btRestart.UseVisualStyleBackColor = true;
            this.btRestart.Click += new System.EventHandler(this.btRestart_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(140, 126);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(83, 30);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close Game";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 216);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btRestart);
            this.Controls.Add(this.txtBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.Button btRestart;
        private System.Windows.Forms.Button btClose;
    }
}