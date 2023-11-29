namespace QuanLyPhongTra
{
    partial class fthongKe
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedBarSeriesView stackedBarSeriesView1 = new DevExpress.XtraCharts.StackedBarSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            DevExpress.XtraCharts.ChartTitle chartTitle2 = new DevExpress.XtraCharts.ChartTitle();
            DevExpress.XtraCharts.XYDiagram xyDiagram2 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series3 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ChartTitle chartTitle3 = new DevExpress.XtraCharts.ChartTitle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fthongKe));
            this.chartControlBieuDoCot = new DevExpress.XtraCharts.ChartControl();
            this.chartControlPie = new DevExpress.XtraCharts.ChartControl();
            this.panelControlPie = new DevExpress.XtraEditors.PanelControl();
            this.panelControlCot = new DevExpress.XtraEditors.PanelControl();
            this.chartControlCotDoanhThu = new DevExpress.XtraCharts.ChartControl();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnAA = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlBieuDoCot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPie)).BeginInit();
            this.panelControlPie.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCot)).BeginInit();
            this.panelControlCot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCotDoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControlBieuDoCot
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControlBieuDoCot.Diagram = xyDiagram1;
            this.chartControlBieuDoCot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControlBieuDoCot.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartControlBieuDoCot.Location = new System.Drawing.Point(2, 2);
            this.chartControlBieuDoCot.Name = "chartControlBieuDoCot";
            series1.Name = "DoanhThuCuaBan";
            series1.View = stackedBarSeriesView1;
            this.chartControlBieuDoCot.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControlBieuDoCot.Size = new System.Drawing.Size(1752, 591);
            this.chartControlBieuDoCot.TabIndex = 0;
            chartTitle1.Text = "THỐNG KÊ DOANH THU THEO BÀN";
            chartTitle1.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.chartControlBieuDoCot.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // chartControlPie
            // 
            this.chartControlPie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControlPie.Location = new System.Drawing.Point(1297, 2);
            this.chartControlPie.Name = "chartControlPie";
            series2.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
            series2.Name = "DoanhThu";
            series2.View = pieSeriesView1;
            this.chartControlPie.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series2};
            this.chartControlPie.Size = new System.Drawing.Size(453, 591);
            this.chartControlPie.TabIndex = 0;
            chartTitle2.Text = "THỐNG KÊ SỐ LƯỢT MUA";
            this.chartControlPie.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle2});
            // 
            // panelControlPie
            // 
            this.panelControlPie.Controls.Add(this.btnAA);
            this.panelControlPie.Controls.Add(this.chartControlPie);
            this.panelControlPie.Controls.Add(this.chartControlCotDoanhThu);
            this.panelControlPie.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlPie.Location = new System.Drawing.Point(0, 0);
            this.panelControlPie.Name = "panelControlPie";
            this.panelControlPie.Size = new System.Drawing.Size(1756, 595);
            this.panelControlPie.TabIndex = 5;
            // 
            // panelControlCot
            // 
            this.panelControlCot.Controls.Add(this.btnNext);
            this.panelControlCot.Controls.Add(this.chartControlBieuDoCot);
            this.panelControlCot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlCot.Location = new System.Drawing.Point(0, 0);
            this.panelControlCot.Name = "panelControlCot";
            this.panelControlCot.Size = new System.Drawing.Size(1756, 595);
            this.panelControlCot.TabIndex = 6;
            this.panelControlCot.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControlCot_Paint);
            // 
            // chartControlCotDoanhThu
            // 
            this.chartControlCotDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            xyDiagram2.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram2.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControlCotDoanhThu.Diagram = xyDiagram2;
            this.chartControlCotDoanhThu.Legend.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Right;
            this.chartControlCotDoanhThu.Location = new System.Drawing.Point(2, 5);
            this.chartControlCotDoanhThu.Name = "chartControlCotDoanhThu";
            series3.Name = "SoLuotMua";
            this.chartControlCotDoanhThu.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series3};
            this.chartControlCotDoanhThu.Size = new System.Drawing.Size(1289, 641);
            this.chartControlCotDoanhThu.TabIndex = 1;
            chartTitle3.Text = "THỐNG KÊ SỐ LƯỢT MUA ";
            this.chartControlCotDoanhThu.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle3});
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Location = new System.Drawing.Point(51, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(112, 34);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Trang sau";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click_1);
            // 
            // btnAA
            // 
            this.btnAA.Appearance.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAA.Appearance.Options.UseFont = true;
            this.btnAA.Location = new System.Drawing.Point(55, 12);
            this.btnAA.Name = "btnAA";
            this.btnAA.Size = new System.Drawing.Size(112, 34);
            this.btnAA.TabIndex = 2;
            this.btnAA.Text = "Trang trước";
            this.btnAA.Click += new System.EventHandler(this.btnAA_Click);
            // 
            // fthongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1756, 595);
            this.Controls.Add(this.panelControlPie);
            this.Controls.Add(this.panelControlCot);
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("fthongKe.IconOptions.SvgImage")));
            this.Name = "fthongKe";
            this.Text = "Thống kê doanh thu theo bàn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fthongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlBieuDoCot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControlPie)).EndInit();
            this.panelControlPie.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControlCot)).EndInit();
            this.panelControlCot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControlCotDoanhThu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControlBieuDoCot;
        private DevExpress.XtraCharts.ChartControl chartControlPie;
        private DevExpress.XtraEditors.PanelControl panelControlPie;
        private DevExpress.XtraEditors.PanelControl panelControlCot;
        private DevExpress.XtraCharts.ChartControl chartControlCotDoanhThu;
        private DevExpress.XtraEditors.SimpleButton btnAA;
        private DevExpress.XtraEditors.SimpleButton btnNext;
    }
}