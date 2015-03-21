namespace Imprisoned_Hope
{
    partial class Form1
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
            this.newGame_btn = new System.Windows.Forms.PictureBox();
            this.loadGame_btn = new System.Windows.Forms.PictureBox();
            this.optins_btn = new System.Windows.Forms.PictureBox();
            this.exit_btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.newGame_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadGame_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optins_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // newGame_btn
            // 
            this.newGame_btn.BackColor = System.Drawing.Color.Transparent;
            this.newGame_btn.BackgroundImage = global::Imprisoned_Hope.Properties.Resources.New_Game;
            this.newGame_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.newGame_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newGame_btn.Location = new System.Drawing.Point(721, 397);
            this.newGame_btn.Name = "newGame_btn";
            this.newGame_btn.Size = new System.Drawing.Size(350, 68);
            this.newGame_btn.TabIndex = 0;
            this.newGame_btn.TabStop = false;
            this.newGame_btn.Click += new System.EventHandler(this.newGame_btn_Click);
            // 
            // loadGame_btn
            // 
            this.loadGame_btn.BackColor = System.Drawing.Color.Transparent;
            this.loadGame_btn.BackgroundImage = global::Imprisoned_Hope.Properties.Resources.Load_Game;
            this.loadGame_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loadGame_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadGame_btn.Location = new System.Drawing.Point(721, 471);
            this.loadGame_btn.Name = "loadGame_btn";
            this.loadGame_btn.Size = new System.Drawing.Size(392, 67);
            this.loadGame_btn.TabIndex = 1;
            this.loadGame_btn.TabStop = false;
            this.loadGame_btn.Click += new System.EventHandler(this.loadGame_btn_Click);
            // 
            // optins_btn
            // 
            this.optins_btn.BackColor = System.Drawing.Color.Transparent;
            this.optins_btn.BackgroundImage = global::Imprisoned_Hope.Properties.Resources.Options;
            this.optins_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.optins_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optins_btn.Location = new System.Drawing.Point(721, 544);
            this.optins_btn.Name = "optins_btn";
            this.optins_btn.Size = new System.Drawing.Size(295, 63);
            this.optins_btn.TabIndex = 2;
            this.optins_btn.TabStop = false;
            this.optins_btn.Click += new System.EventHandler(this.optins_btn_Click);
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_btn.BackgroundImage = global::Imprisoned_Hope.Properties.Resources.Exit;
            this.exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_btn.Location = new System.Drawing.Point(721, 613);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(170, 57);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.TabStop = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Imprisoned_Hope.Properties.Resources.imageedit_2_9998475305;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1262, 682);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.optins_btn);
            this.Controls.Add(this.loadGame_btn);
            this.Controls.Add(this.newGame_btn);
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1278, 720);
            this.Name = "Form1";
            this.Text = "Imprisoned Hope";
            ((System.ComponentModel.ISupportInitialize)(this.newGame_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadGame_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optins_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit_btn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox newGame_btn;
        private System.Windows.Forms.PictureBox loadGame_btn;
        private System.Windows.Forms.PictureBox optins_btn;
        private System.Windows.Forms.PictureBox exit_btn;
    }
}

