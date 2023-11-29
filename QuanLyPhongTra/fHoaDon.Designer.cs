namespace QuanLyPhongTra
{
    partial class fHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHoaDon));
            this.pnHD = new System.Windows.Forms.Panel();
            this.dtgvListFood = new System.Windows.Forms.DataGridView();
            this.tenmon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txbDate = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbNameTable = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbFinalPrice = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.blDisCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pdmtHoadon = new System.Drawing.Printing.PrintDocument();
            this.ppdlHoadon = new System.Windows.Forms.PrintPreviewDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.txbSDT = new System.Windows.Forms.TextBox();
            this.pnHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListFood)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnHD
            // 
            this.pnHD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnHD.Controls.Add(this.txbSDT);
            this.pnHD.Controls.Add(this.button2);
            this.pnHD.Controls.Add(this.dtgvListFood);
            this.pnHD.Controls.Add(this.txbDate);
            this.pnHD.Controls.Add(this.panel5);
            this.pnHD.Controls.Add(this.panel3);
            this.pnHD.Controls.Add(this.panel2);
            this.pnHD.Controls.Add(this.label19);
            this.pnHD.Controls.Add(this.label18);
            this.pnHD.Controls.Add(this.label17);
            this.pnHD.Controls.Add(this.label3);
            this.pnHD.Controls.Add(this.label6);
            this.pnHD.Controls.Add(this.label5);
            this.pnHD.Location = new System.Drawing.Point(576, 12);
            this.pnHD.Name = "pnHD";
            this.pnHD.Size = new System.Drawing.Size(668, 900);
            this.pnHD.TabIndex = 0;
            // 
            // dtgvListFood
            // 
            this.dtgvListFood.BackgroundColor = System.Drawing.SystemColors.Menu;
            this.dtgvListFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvListFood.ColumnHeadersVisible = false;
            this.dtgvListFood.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tenmon,
            this.dongia,
            this.soluong,
            this.tongtien});
            this.dtgvListFood.Location = new System.Drawing.Point(23, 227);
            this.dtgvListFood.Name = "dtgvListFood";
            this.dtgvListFood.RowHeadersVisible = false;
            this.dtgvListFood.RowHeadersWidth = 62;
            this.dtgvListFood.RowTemplate.Height = 28;
            this.dtgvListFood.Size = new System.Drawing.Size(618, 436);
            this.dtgvListFood.TabIndex = 31;
            // 
            // tenmon
            // 
            this.tenmon.DataPropertyName = "Tên món";
            this.tenmon.HeaderText = "Tên món";
            this.tenmon.MinimumWidth = 8;
            this.tenmon.Name = "tenmon";
            this.tenmon.Width = 160;
            // 
            // dongia
            // 
            this.dongia.DataPropertyName = "Đơn giá";
            this.dongia.HeaderText = "Đơn giá";
            this.dongia.MinimumWidth = 8;
            this.dongia.Name = "dongia";
            this.dongia.Width = 103;
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "SL";
            this.soluong.HeaderText = "Số lượng";
            this.soluong.MinimumWidth = 8;
            this.soluong.Name = "soluong";
            this.soluong.Width = 41;
            // 
            // tongtien
            // 
            this.tongtien.DataPropertyName = "T.Tiền";
            this.tongtien.HeaderText = "Tổng tiền";
            this.tongtien.MinimumWidth = 8;
            this.tongtien.Name = "tongtien";
            this.tongtien.Width = 103;
            // 
            // txbDate
            // 
            this.txbDate.BackColor = System.Drawing.SystemColors.Menu;
            this.txbDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbDate.Font = new System.Drawing.Font("Calibri", 10F);
            this.txbDate.Location = new System.Drawing.Point(187, 685);
            this.txbDate.Name = "txbDate";
            this.txbDate.Size = new System.Drawing.Size(145, 25);
            this.txbDate.TabIndex = 32;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.txbNameTable);
            this.panel5.Location = new System.Drawing.Point(153, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(350, 156);
            this.panel5.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "236 Hoàng Quốc Việt - Bắc Từ Liêm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phòng trà MTA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(234, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "---------------------------------------------";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(85, 99);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "PHIẾU THANH TOÁN";
            // 
            // txbNameTable
            // 
            this.txbNameTable.BackColor = System.Drawing.SystemColors.Menu;
            this.txbNameTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txbNameTable.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNameTable.Location = new System.Drawing.Point(125, 127);
            this.txbNameTable.Name = "txbNameTable";
            this.txbNameTable.Size = new System.Drawing.Size(100, 20);
            this.txbNameTable.TabIndex = 8;
            this.txbNameTable.Text = "Bàn số";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbFinalPrice);
            this.panel3.Controls.Add(this.lbTotalPrice);
            this.panel3.Controls.Add(this.blDisCount);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(341, 674);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(310, 92);
            this.panel3.TabIndex = 28;
            // 
            // lbFinalPrice
            // 
            this.lbFinalPrice.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lbFinalPrice.Location = new System.Drawing.Point(101, 61);
            this.lbFinalPrice.Name = "lbFinalPrice";
            this.lbFinalPrice.Size = new System.Drawing.Size(199, 23);
            this.lbFinalPrice.TabIndex = 35;
            this.lbFinalPrice.Text = "label21";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.Font = new System.Drawing.Font("Calibri", 10F);
            this.lbTotalPrice.Location = new System.Drawing.Point(107, 12);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(193, 24);
            this.lbTotalPrice.TabIndex = 34;
            this.lbTotalPrice.Text = "label20";
            // 
            // blDisCount
            // 
            this.blDisCount.Font = new System.Drawing.Font("Calibri", 10F);
            this.blDisCount.Location = new System.Drawing.Point(101, 35);
            this.blDisCount.Name = "blDisCount";
            this.blDisCount.Size = new System.Drawing.Size(199, 24);
            this.blDisCount.TabIndex = 33;
            this.blDisCount.Text = "label7";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 10F);
            this.label10.Location = new System.Drawing.Point(3, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 24);
            this.label10.TabIndex = 11;
            this.label10.Text = "Tổng cộng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 24);
            this.label11.TabIndex = 12;
            this.label11.Text = "Giảm giá:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 24);
            this.label12.TabIndex = 14;
            this.label12.Text = "Còn lại:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(153, 761);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 139);
            this.panel2.TabIndex = 27;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(90, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 29);
            this.label13.TabIndex = 17;
            this.label13.Text = "Người thu tiền";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(117, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(108, 29);
            this.label15.TabIndex = 19;
            this.label15.Text = "Thu Ngân";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(332, 24);
            this.label9.TabIndex = 9;
            this.label9.Text = "---------------------------------------------";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(90, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(166, 29);
            this.label14.TabIndex = 20;
            this.label14.Text = "Xin hẹn gặp lại!";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(-1, 109);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(351, 29);
            this.label16.TabIndex = 21;
            this.label16.Text = "Chân thành và cảm ơn quý khách!";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(274, 176);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 24);
            this.label19.TabIndex = 25;
            this.label19.Text = "Đơn giá";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(92, 176);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(39, 24);
            this.label18.TabIndex = 24;
            this.label18.Text = "Tên";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(423, 176);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(27, 24);
            this.label17.TabIndex = 23;
            this.label17.Text = "SL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(523, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "T.tiền";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(21, 645);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(630, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------------------------------";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(630, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "---------------------------------------------------------------------------------" +
    "-------------------------------------------------------";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(851, 928);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 30);
            this.button1.TabIndex = 33;
            this.button1.Text = "In hóa đơn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // pdmtHoadon
            // 
            this.pdmtHoadon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdmtHoadon_PrintPage);
            // 
            // ppdlHoadon
            // 
            this.ppdlHoadon.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdlHoadon.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdlHoadon.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdlHoadon.Enabled = true;
            this.ppdlHoadon.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdlHoadon.Icon")));
            this.ppdlHoadon.Name = "ppdlHoadon";
            this.ppdlHoadon.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(509, 775);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 30);
            this.button2.TabIndex = 34;
            this.button2.Text = "Tích điểm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txbSDT
            // 
            this.txbSDT.Location = new System.Drawing.Point(509, 817);
            this.txbSDT.Name = "txbSDT";
            this.txbSDT.Size = new System.Drawing.Size(124, 26);
            this.txbSDT.TabIndex = 35;
            // 
            // fHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 1050);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnHD);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fHoaDon";
            this.Text = "fHoaDon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnHD.ResumeLayout(false);
            this.pnHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvListFood)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnHD;
        private System.Windows.Forms.TextBox txbNameTable;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dtgvListFood;
        private System.Windows.Forms.TextBox txbDate;
        private System.Drawing.Printing.PrintDocument pdmtHoadon;
        private System.Windows.Forms.PrintPreviewDialog ppdlHoadon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenmon;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn tongtien;
        private System.Windows.Forms.Label lbFinalPrice;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label blDisCount;
        private System.Windows.Forms.TextBox txbSDT;
        private System.Windows.Forms.Button button2;
    }
}