namespace QuanLyPhongTra
{
    partial class fSeparate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSeparate));
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbTableFirst = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFood = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.mnFoodCount = new System.Windows.Forms.NumericUpDown();
            this.btnComfird = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTabeTabeSecond = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mnFoodCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(578, 42);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(527, 298);
            this.lsvBill.TabIndex = 1;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 179;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn giá";
            this.columnHeader3.Width = 72;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng tiền";
            this.columnHeader4.Width = 85;
            // 
            // cbTableFirst
            // 
            this.cbTableFirst.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTableFirst.FormattingEnabled = true;
            this.cbTableFirst.Location = new System.Drawing.Point(734, 6);
            this.cbTableFirst.Name = "cbTableFirst";
            this.cbTableFirst.Size = new System.Drawing.Size(86, 27);
            this.cbTableFirst.TabIndex = 2;
            this.cbTableFirst.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChangedcbTableFirst);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 30);
            this.label1.TabIndex = 8;
            this.label1.Text = "Danh mục:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(574, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 30);
            this.label2.TabIndex = 9;
            this.label2.Text = "Thông tin bill bàn tách :";
            // 
            // cbFood
            // 
            this.cbFood.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFood.FormattingEnabled = true;
            this.cbFood.Location = new System.Drawing.Point(154, 114);
            this.cbFood.Name = "cbFood";
            this.cbFood.Size = new System.Drawing.Size(295, 32);
            this.cbFood.TabIndex = 10;
            // 
            // cbCategory
            // 
            this.cbCategory.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(154, 50);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(295, 32);
            this.cbCategory.TabIndex = 11;
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 30);
            this.label3.TabIndex = 12;
            this.label3.Text = "Tên món:";
            // 
            // mnFoodCount
            // 
            this.mnFoodCount.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnFoodCount.Location = new System.Drawing.Point(154, 172);
            this.mnFoodCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.mnFoodCount.Name = "mnFoodCount";
            this.mnFoodCount.Size = new System.Drawing.Size(78, 32);
            this.mnFoodCount.TabIndex = 13;
            this.mnFoodCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnComfird
            // 
            this.btnComfird.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComfird.Location = new System.Drawing.Point(216, 267);
            this.btnComfird.Name = "btnComfird";
            this.btnComfird.Size = new System.Drawing.Size(148, 60);
            this.btnComfird.TabIndex = 14;
            this.btnComfird.Text = "Xác nhận tách";
            this.btnComfird.UseVisualStyleBackColor = true;
            this.btnComfird.Click += new System.EventHandler(this.btnComfird_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(246, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tách đến bàn:";
            // 
            // cbTabeTabeSecond
            // 
            this.cbTabeTabeSecond.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTabeTabeSecond.FormattingEnabled = true;
            this.cbTabeTabeSecond.Location = new System.Drawing.Point(370, 172);
            this.cbTabeTabeSecond.Name = "cbTabeTabeSecond";
            this.cbTabeTabeSecond.Size = new System.Drawing.Size(79, 32);
            this.cbTabeTabeSecond.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(27, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 30);
            this.label5.TabIndex = 17;
            this.label5.Text = "Số lượng tách:";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(932, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 30);
            this.label6.TabIndex = 18;
            this.label6.Text = "Trạng thái:";
            // 
            // txbStatus
            // 
            this.txbStatus.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStatus.Location = new System.Drawing.Point(1019, 6);
            this.txbStatus.Name = "txbStatus";
            this.txbStatus.ReadOnly = true;
            this.txbStatus.Size = new System.Drawing.Size(86, 27);
            this.txbStatus.TabIndex = 19;
            // 
            // fSeparate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 359);
            this.Controls.Add(this.txbStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTabeTabeSecond);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnComfird);
            this.Controls.Add(this.mnFoodCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.cbFood);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTableFirst);
            this.Controls.Add(this.lsvBill);
            this.Font = new System.Drawing.Font("Calibri", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fSeparate";
            this.Text = "Tách bàn";
            ((System.ComponentModel.ISupportInitialize)(this.mnFoodCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ComboBox cbTableFirst;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFood;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown mnFoodCount;
        private System.Windows.Forms.Button btnComfird;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTabeTabeSecond;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbStatus;
    }
}