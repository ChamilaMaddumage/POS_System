namespace Services.Payments
{
    partial class Mobile
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
            this.labelDocID = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxMobileAmount = new System.Windows.Forms.TextBox();
            this.textBoxMobileNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.comboBoxServiceName = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelDocID
            // 
            this.labelDocID.AutoSize = true;
            this.labelDocID.Location = new System.Drawing.Point(511, 111);
            this.labelDocID.Name = "labelDocID";
            this.labelDocID.Size = new System.Drawing.Size(18, 13);
            this.labelDocID.TabIndex = 162;
            this.labelDocID.Text = "ID";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(527, 220);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 160;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(527, 191);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 159;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.Location = new System.Drawing.Point(277, 185);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.Size = new System.Drawing.Size(209, 79);
            this.richTextBoxNote.TabIndex = 148;
            this.richTextBoxNote.Text = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe WP", 10.5F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(64, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 20);
            this.label2.TabIndex = 151;
            this.label2.Text = "Note :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe WP", 25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(208, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mobile Payments";
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Location = new System.Drawing.Point(540, 134);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new System.Drawing.Size(124, 20);
            this.textBoxTotalAmount.TabIndex = 161;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Location = new System.Drawing.Point(0, 504);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 40);
            this.panel2.TabIndex = 158;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 100);
            this.panel1.TabIndex = 157;
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            this.Note.Width = 200;
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.Width = 150;
            // 
            // MobileNo
            // 
            this.MobileNo.HeaderText = "Mobile No";
            this.MobileNo.Name = "MobileNo";
            this.MobileNo.Width = 200;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MobileNo,
            this.Amount,
            this.Bank,
            this.Note});
            this.dataGridView1.Location = new System.Drawing.Point(1, 290);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(765, 213);
            this.dataGridView1.TabIndex = 156;
            // 
            // Bank
            // 
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.Width = 170;
            // 
            // textBoxMobileAmount
            // 
            this.textBoxMobileAmount.Location = new System.Drawing.Point(277, 135);
            this.textBoxMobileAmount.Name = "textBoxMobileAmount";
            this.textBoxMobileAmount.Size = new System.Drawing.Size(209, 20);
            this.textBoxMobileAmount.TabIndex = 153;
            // 
            // textBoxMobileNo
            // 
            this.textBoxMobileNo.Location = new System.Drawing.Point(277, 111);
            this.textBoxMobileNo.Name = "textBoxMobileNo";
            this.textBoxMobileNo.Size = new System.Drawing.Size(209, 20);
            this.textBoxMobileNo.TabIndex = 154;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label20.Font = new System.Drawing.Font("Segoe WP", 10.5F);
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(64, 132);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(187, 20);
            this.label20.TabIndex = 149;
            this.label20.Text = "Amount :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label21.Font = new System.Drawing.Font("Segoe WP", 10.5F);
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label21.Location = new System.Drawing.Point(64, 109);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(187, 20);
            this.label21.TabIndex = 150;
            this.label21.Text = "Mobile No:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label25.Font = new System.Drawing.Font("Segoe WP", 10.5F);
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Location = new System.Drawing.Point(64, 156);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(187, 20);
            this.label25.TabIndex = 152;
            this.label25.Text = "Service Name :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxServiceName
            // 
            this.comboBoxServiceName.FormattingEnabled = true;
            this.comboBoxServiceName.Location = new System.Drawing.Point(277, 158);
            this.comboBoxServiceName.Name = "comboBoxServiceName";
            this.comboBoxServiceName.Size = new System.Drawing.Size(209, 21);
            this.comboBoxServiceName.TabIndex = 155;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Services.Properties.Resources.closeRed;
            this.pictureBox1.Location = new System.Drawing.Point(665, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Mobile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 545);
            this.Controls.Add(this.labelDocID);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.richTextBoxNote);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxTotalAmount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxMobileAmount);
            this.Controls.Add(this.textBoxMobileNo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.comboBoxServiceName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mobile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mobile";
            this.Load += new System.EventHandler(this.Mobile_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDocID;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.RichTextBox richTextBoxNote;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobileNo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.TextBox textBoxMobileAmount;
        private System.Windows.Forms.TextBox textBoxMobileNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox comboBoxServiceName;
    }
}