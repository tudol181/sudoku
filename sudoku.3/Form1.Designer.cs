
namespace sudoku._3
{
    partial class Sudoku
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Panel1 = new System.Windows.Forms.Panel();
            this.newGameButton = new System.Windows.Forms.Button();
            this.checkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Location = new System.Drawing.Point(237, 15);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(533, 506);
            this.Panel1.TabIndex = 0;
            this.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(14, 15);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(196, 37);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "Start new game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // checkButton
            // 
            this.checkButton.Location = new System.Drawing.Point(14, 80);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(195, 38);
            this.checkButton.TabIndex = 2;
            this.checkButton.Text = "Check solution";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // Sudoku
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(786, 537);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.Panel1);
            this.Name = "Sudoku";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.Button checkButton;
    }
}

