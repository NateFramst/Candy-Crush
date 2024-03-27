namespace Candy_Crush
{
    partial class HomeScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.LeaveLavel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(0, 45);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(542, 46);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Candy Crush";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(208, 265);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(117, 47);
            this.startButton.TabIndex = 1;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // LeaveLavel
            // 
            this.LeaveLavel.AutoSize = true;
            this.LeaveLavel.Location = new System.Drawing.Point(158, 332);
            this.LeaveLavel.Name = "LeaveLavel";
            this.LeaveLavel.Size = new System.Drawing.Size(207, 26);
            this.LeaveLavel.TabIndex = 2;
            this.LeaveLavel.Text = "Press Escape to Exit";
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LeaveLavel);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.titleLabel);
            this.Font = new System.Drawing.Font("Old English Text MT", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "HomeScreen";
            this.Size = new System.Drawing.Size(542, 369);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HomeScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HomeScreen_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label LeaveLavel;
    }
}
