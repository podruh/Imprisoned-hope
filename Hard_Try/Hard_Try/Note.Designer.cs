namespace Imprisoned_Hope
{
    partial class Note
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
            this.txbNote = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNote = new System.Windows.Forms.ComboBox();
            this.showBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbNote
            // 
            this.txbNote.Location = new System.Drawing.Point(13, 40);
            this.txbNote.Multiline = true;
            this.txbNote.Name = "txbNote";
            this.txbNote.Size = new System.Drawing.Size(859, 381);
            this.txbNote.TabIndex = 0;
            this.txbNote.Text = "*Note content*";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(797, 427);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Typ Notu:";
            // 
            // cmbNote
            // 
            this.cmbNote.FormattingEnabled = true;
            this.cmbNote.Items.AddRange(new object[] {
            "Note",
            "Newspapers",
            "Map"});
            this.cmbNote.Location = new System.Drawing.Point(74, 13);
            this.cmbNote.Name = "cmbNote";
            this.cmbNote.Size = new System.Drawing.Size(121, 21);
            this.cmbNote.TabIndex = 3;
            this.cmbNote.Text = "Note";
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(16, 427);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(75, 23);
            this.showBtn.TabIndex = 4;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // Note
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 462);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.cmbNote);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txbNote);
            this.Name = "Note";
            this.Text = "Note";
            this.Load += new System.EventHandler(this.Note_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbNote;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNote;
        private System.Windows.Forms.Button showBtn;
    }
}