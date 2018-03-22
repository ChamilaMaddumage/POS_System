namespace Services.Payments
{
    partial class ChequeGRN
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
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxBank = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewBankAccount = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ChequeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChequeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxChqAmount = new System.Windows.Forms.TextBox();
            this.textBoxCheqNo = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelDocID = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBoxTotalAmount = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.Location = new System.Drawing.Point(219, 177);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.Size = new System.Drawing.Size(209, 79);
            this.richTextBoxNote.TabIndex = 160;
            this.richTextBoxNote.Text = "";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(353, 259);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 153;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxBank
            // 
            this.textBoxBank.Location = new System.Drawing.Point(219, 153);
            this.textBoxBank.Name = "textBoxBank";
            this.textBoxBank.Size = new System.Drawing.Size(209, 20);
            this.textBoxBank.TabIndex = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(187, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cheque Payments";
            // 
            // dataGridViewBankAccount
            // 
            this.dataGridViewBankAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBankAccount.Location = new System.Drawing.Point(443, 106);
            this.dataGridViewBankAccount.Name = "dataGridViewBankAccount";
            this.dataGridViewBankAccount.RowHeadersVisible = false;
            this.dataGridViewBankAccount.Size = new System.Drawing.Size(150, 176);
            this.dataGridViewBankAccount.TabIndex = 161;
            this.dataGridViewBankAccount.Visible = false;
            this.dataGridViewBankAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBankAccount_CellClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ChequeNo,
            this.ChequeAmount,
            this.Bank,
            this.Note});
            this.dataGridView1.Location = new System.Drawing.Point(1, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(765, 213);
            this.dataGridView1.TabIndex = 159;
            // 
            // ChequeNo
            // 
            this.ChequeNo.HeaderText = "Cheque No";
            this.ChequeNo.Name = "ChequeNo";
            this.ChequeNo.Width = 200;
            // 
            // ChequeAmount
            // 
            this.ChequeAmount.HeaderText = "ChequeAmount";
            this.ChequeAmount.Name = "ChequeAmount";
            this.ChequeAmount.Width = 150;
            // 
            // Bank
            // 
            this.Bank.HeaderText = "Bank";
            this.Bank.Name = "Bank";
            this.Bank.Width = 170;
            // 
            // Note
            // 
            this.Note.HeaderText = "Note";
            this.Note.Name = "Note";
            this.Note.Width = 205;
            // 
            // textBoxChqAmount
            // 
            this.textBoxChqAmount.Location = new System.Drawing.Point(219, 130);
            this.textBoxChqAmount.Name = "textBoxChqAmount";
            this.textBoxChqAmount.Size = new System.Drawing.Size(209, 20);
            this.textBoxChqAmount.TabIndex = 151;
            // 
            // textBoxCheqNo
            // 
            this.textBoxCheqNo.Location = new System.Drawing.Point(219, 106);
            this.textBoxCheqNo.Name = "textBoxCheqNo";
            this.textBoxCheqNo.Size = new System.Drawing.Size(209, 20);
            this.textBoxCheqNo.TabIndex = 148;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label20.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label20.Location = new System.Drawing.Point(6, 127);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(187, 20);
            this.label20.TabIndex = 155;
            this.label20.Text = "Amount :";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label21.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label21.Location = new System.Drawing.Point(6, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(187, 20);
            this.label21.TabIndex = 156;
            this.label21.Text = "Cheq No:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.Location = new System.Drawing.Point(0, 503);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 40);
            this.panel2.TabIndex = 152;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(6, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 20);
            this.label3.TabIndex = 157;
            this.label3.Text = "Note :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F);
            this.label25.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label25.Location = new System.Drawing.Point(6, 151);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(187, 20);
            this.label25.TabIndex = 158;
            this.label25.Text = "Bank Account Name :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.labelDocID);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxTotalAmount);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 100);
            this.panel1.TabIndex = 149;
            // 
            // labelDocID
            // 
            this.labelDocID.AutoSize = true;
            this.labelDocID.Location = new System.Drawing.Point(542, 9);
            this.labelDocID.Name = "labelDocID";
            this.labelDocID.Size = new System.Drawing.Size(18, 13);
            this.labelDocID.TabIndex = 148;
            this.labelDocID.Text = "ID";
            this.labelDocID.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Services.Properties.Resources.closeRed;
            this.pictureBox1.Location = new System.Drawing.Point(689, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // textBoxTotalAmount
            // 
            this.textBoxTotalAmount.Location = new System.Drawing.Point(490, 55);
            this.textBoxTotalAmount.Name = "textBoxTotalAmount";
            this.textBoxTotalAmount.Size = new System.Drawing.Size(166, 20);
            this.textBoxTotalAmount.TabIndex = 147;
            this.textBoxTotalAmount.Visible = false;
            // 
            // ChequeGRN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 543);
            this.Controls.Add(this.richTextBoxNote);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxBank);
            this.Controls.Add(this.dataGridViewBankAccount);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxChqAmount);
            this.Controls.Add(this.textBoxCheqNo);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChequeGRN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChequeGRN";
            this.Load += new System.EventHandler(this.ChequeGRN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxNote;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxBank;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewBankAccount;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxChqAmount;
        private System.Windows.Forms.TextBox textBoxCheqNo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelDocID;
        private System.Windows.Forms.TextBox textBoxTotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChequeAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Note;
    }
}