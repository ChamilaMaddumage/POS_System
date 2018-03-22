namespace Services
{
    partial class Banking
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelBalance = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridViewBankAccount = new System.Windows.Forms.DataGridView();
            this.labelDoc_No = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonNewBankAccount = new System.Windows.Forms.Button();
            this.textBoxAccountDoc_No = new System.Windows.Forms.TextBox();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAccountNo = new System.Windows.Forms.TextBox();
            this.dateTimePickerTranBanking = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonBankOut = new System.Windows.Forms.RadioButton();
            this.radioButtonBankIn = new System.Windows.Forms.RadioButton();
            this.buttonBankClear = new System.Windows.Forms.Button();
            this.buttonBankSave = new System.Windows.Forms.Button();
            this.textBoxDirection = new System.Windows.Forms.TextBox();
            this.textBoxNote = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelBankingFromTo = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewBanking = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewCheques = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBanking)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheques)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.labelBalance);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.dataGridViewBankAccount);
            this.groupBox2.Controls.Add(this.labelDoc_No);
            this.groupBox2.Controls.Add(this.textBoxSearch);
            this.groupBox2.Controls.Add(this.buttonDelete);
            this.groupBox2.Controls.Add(this.buttonNewBankAccount);
            this.groupBox2.Controls.Add(this.textBoxAccountDoc_No);
            this.groupBox2.Controls.Add(this.textBoxAccount);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxAccountNo);
            this.groupBox2.Controls.Add(this.dateTimePickerTranBanking);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.radioButtonBankOut);
            this.groupBox2.Controls.Add(this.radioButtonBankIn);
            this.groupBox2.Controls.Add(this.buttonBankClear);
            this.groupBox2.Controls.Add(this.buttonBankSave);
            this.groupBox2.Controls.Add(this.textBoxDirection);
            this.groupBox2.Controls.Add(this.textBoxNote);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.labelBankingFromTo);
            this.groupBox2.Controls.Add(this.textBoxAmount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(38, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 349);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bank Account";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Cash Balance :";
            // 
            // labelBalance
            // 
            this.labelBalance.AutoSize = true;
            this.labelBalance.Location = new System.Drawing.Point(433, 35);
            this.labelBalance.Name = "labelBalance";
            this.labelBalance.Size = new System.Drawing.Size(46, 13);
            this.labelBalance.TabIndex = 36;
            this.labelBalance.Text = "Balance";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Services.Properties.Resources.refresh_animated;
            this.pictureBox1.Location = new System.Drawing.Point(351, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dataGridViewBankAccount
            // 
            this.dataGridViewBankAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBankAccount.Location = new System.Drawing.Point(351, 85);
            this.dataGridViewBankAccount.Name = "dataGridViewBankAccount";
            this.dataGridViewBankAccount.RowHeadersVisible = false;
            this.dataGridViewBankAccount.Size = new System.Drawing.Size(150, 200);
            this.dataGridViewBankAccount.TabIndex = 10;
            this.dataGridViewBankAccount.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBankAccount_CellClick);
            // 
            // labelDoc_No
            // 
            this.labelDoc_No.AutoSize = true;
            this.labelDoc_No.Location = new System.Drawing.Point(377, 16);
            this.labelDoc_No.Name = "labelDoc_No";
            this.labelDoc_No.Size = new System.Drawing.Size(47, 13);
            this.labelDoc_No.TabIndex = 17;
            this.labelDoc_No.Text = "Doc_No";
            this.labelDoc_No.Click += new System.EventHandler(this.labelDoc_No_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(433, 61);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(68, 20);
            this.textBoxSearch.TabIndex = 14;
            this.textBoxSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyUp);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(233, 309);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonNewBankAccount
            // 
            this.buttonNewBankAccount.Location = new System.Drawing.Point(314, 309);
            this.buttonNewBankAccount.Name = "buttonNewBankAccount";
            this.buttonNewBankAccount.Size = new System.Drawing.Size(75, 23);
            this.buttonNewBankAccount.TabIndex = 9;
            this.buttonNewBankAccount.Text = "New Act";
            this.buttonNewBankAccount.UseVisualStyleBackColor = true;
            this.buttonNewBankAccount.Click += new System.EventHandler(this.buttonNewBankAccount_Click);
            // 
            // textBoxAccountDoc_No
            // 
            this.textBoxAccountDoc_No.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAccountDoc_No.Location = new System.Drawing.Point(151, 61);
            this.textBoxAccountDoc_No.Name = "textBoxAccountDoc_No";
            this.textBoxAccountDoc_No.Size = new System.Drawing.Size(180, 22);
            this.textBoxAccountDoc_No.TabIndex = 0;
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAccount.Location = new System.Drawing.Point(151, 89);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(180, 22);
            this.textBoxAccount.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label9.Location = new System.Drawing.Point(351, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Search :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAccountNo
            // 
            this.textBoxAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAccountNo.Location = new System.Drawing.Point(152, 116);
            this.textBoxAccountNo.Name = "textBoxAccountNo";
            this.textBoxAccountNo.Size = new System.Drawing.Size(180, 22);
            this.textBoxAccountNo.TabIndex = 2;
            // 
            // dateTimePickerTranBanking
            // 
            this.dateTimePickerTranBanking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTranBanking.Location = new System.Drawing.Point(152, 203);
            this.dateTimePickerTranBanking.Name = "dateTimePickerTranBanking";
            this.dateTimePickerTranBanking.Size = new System.Drawing.Size(180, 22);
            this.dateTimePickerTranBanking.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(11, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "Transaction Date :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonBankOut
            // 
            this.radioButtonBankOut.AutoSize = true;
            this.radioButtonBankOut.Location = new System.Drawing.Point(207, 33);
            this.radioButtonBankOut.Name = "radioButtonBankOut";
            this.radioButtonBankOut.Size = new System.Drawing.Size(52, 17);
            this.radioButtonBankOut.TabIndex = 10;
            this.radioButtonBankOut.TabStop = true;
            this.radioButtonBankOut.Text = "Credit";
            this.radioButtonBankOut.UseVisualStyleBackColor = true;
            this.radioButtonBankOut.CheckedChanged += new System.EventHandler(this.radioButtonBankOut_CheckedChanged);
            // 
            // radioButtonBankIn
            // 
            this.radioButtonBankIn.AutoSize = true;
            this.radioButtonBankIn.Location = new System.Drawing.Point(151, 33);
            this.radioButtonBankIn.Name = "radioButtonBankIn";
            this.radioButtonBankIn.Size = new System.Drawing.Size(50, 17);
            this.radioButtonBankIn.TabIndex = 10;
            this.radioButtonBankIn.TabStop = true;
            this.radioButtonBankIn.Text = "Debit";
            this.radioButtonBankIn.UseVisualStyleBackColor = true;
            this.radioButtonBankIn.CheckedChanged += new System.EventHandler(this.radioButtonBankIn_CheckedChanged);
            // 
            // buttonBankClear
            // 
            this.buttonBankClear.Location = new System.Drawing.Point(395, 309);
            this.buttonBankClear.Name = "buttonBankClear";
            this.buttonBankClear.Size = new System.Drawing.Size(75, 23);
            this.buttonBankClear.TabIndex = 10;
            this.buttonBankClear.Text = "Clear";
            this.buttonBankClear.UseVisualStyleBackColor = true;
            this.buttonBankClear.Click += new System.EventHandler(this.buttonBankClear_Click);
            // 
            // buttonBankSave
            // 
            this.buttonBankSave.Location = new System.Drawing.Point(152, 309);
            this.buttonBankSave.Name = "buttonBankSave";
            this.buttonBankSave.Size = new System.Drawing.Size(75, 23);
            this.buttonBankSave.TabIndex = 7;
            this.buttonBankSave.Text = "Save";
            this.buttonBankSave.UseVisualStyleBackColor = true;
            this.buttonBankSave.Click += new System.EventHandler(this.buttonBankSave_Click);
            // 
            // textBoxDirection
            // 
            this.textBoxDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDirection.Location = new System.Drawing.Point(151, 144);
            this.textBoxDirection.Name = "textBoxDirection";
            this.textBoxDirection.Size = new System.Drawing.Size(181, 22);
            this.textBoxDirection.TabIndex = 3;
            // 
            // textBoxNote
            // 
            this.textBoxNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNote.Location = new System.Drawing.Point(151, 233);
            this.textBoxNote.Multiline = true;
            this.textBoxNote.Name = "textBoxNote";
            this.textBoxNote.Size = new System.Drawing.Size(181, 60);
            this.textBoxNote.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label10.Location = new System.Drawing.Point(11, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 24);
            this.label10.TabIndex = 5;
            this.label10.Text = "Account Code :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(11, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 24);
            this.label8.TabIndex = 5;
            this.label8.Text = "Account No:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(11, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 24);
            this.label7.TabIndex = 5;
            this.label7.Text = "Bank Account :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelBankingFromTo
            // 
            this.labelBankingFromTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.labelBankingFromTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelBankingFromTo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.labelBankingFromTo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelBankingFromTo.Location = new System.Drawing.Point(11, 144);
            this.labelBankingFromTo.Name = "labelBankingFromTo";
            this.labelBankingFromTo.Size = new System.Drawing.Size(134, 24);
            this.labelBankingFromTo.TabIndex = 5;
            this.labelBankingFromTo.Text = "From :";
            this.labelBankingFromTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAmount.Location = new System.Drawing.Point(151, 173);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(181, 22);
            this.textBoxAmount.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(11, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Amount :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(11, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 24);
            this.label5.TabIndex = 5;
            this.label5.Text = "Note :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewBanking
            // 
            this.dataGridViewBanking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBanking.Location = new System.Drawing.Point(11, 16);
            this.dataGridViewBanking.Name = "dataGridViewBanking";
            this.dataGridViewBanking.Size = new System.Drawing.Size(1026, 271);
            this.dataGridViewBanking.TabIndex = 9;
            this.dataGridViewBanking.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBanking_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewCheques);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(570, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 339);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cheques";
            // 
            // dataGridViewCheques
            // 
            this.dataGridViewCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCheques.Location = new System.Drawing.Point(11, 65);
            this.dataGridViewCheques.Name = "dataGridViewCheques";
            this.dataGridViewCheques.Size = new System.Drawing.Size(504, 254);
            this.dataGridViewCheques.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Search :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 20);
            this.textBox1.TabIndex = 14;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewBanking);
            this.groupBox3.Location = new System.Drawing.Point(38, 414);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1047, 307);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // Banking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1350, 750);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Banking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Banking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Banking_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBankAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBanking)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCheques)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonBankClear;
        private System.Windows.Forms.Button buttonBankSave;
        private System.Windows.Forms.TextBox textBoxDirection;
        private System.Windows.Forms.TextBox textBoxNote;
        private System.Windows.Forms.Label labelBankingFromTo;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonBankOut;
        private System.Windows.Forms.RadioButton radioButtonBankIn;
        private System.Windows.Forms.DateTimePicker dateTimePickerTranBanking;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridViewBanking;
        private System.Windows.Forms.TextBox textBoxAccountNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonNewBankAccount;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewBankAccount;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxAccountDoc_No;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelDoc_No;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewCheques;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelBalance;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}