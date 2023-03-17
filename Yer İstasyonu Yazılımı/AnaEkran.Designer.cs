namespace Yer_İstasyonu_Yazılımı
{
    partial class AnaEkran
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaEkran));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.csvload = new System.Windows.Forms.Button();
            this.csvSave = new System.Windows.Forms.Button();
            this.lblPaketNum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnTestSim = new System.Windows.Forms.Button();
            this.glControl = new OpenTK.GLControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBandRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.Label();
            this.connectCom = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timerX = new System.Windows.Forms.Timer(this.components);
            this.openFileD = new System.Windows.Forms.OpenFileDialog();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.timerGraphs = new System.Windows.Forms.Timer(this.components);
            this.gMap = new GMap.NET.WindowsForms.GMapControl();
            this.timerMap = new System.Windows.Forms.Timer(this.components);
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(1477, 970);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grafikler";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(14, 16);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(431, 408);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(602, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Daha sonra port ile yapılacak";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.csvload);
            this.tabPage1.Controls.Add(this.csvSave);
            this.tabPage1.Controls.Add(this.lblPaketNum);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage1.Size = new System.Drawing.Size(1477, 970);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Genel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // csvload
            // 
            this.csvload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.csvload.Location = new System.Drawing.Point(14, 769);
            this.csvload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.csvload.Name = "csvload";
            this.csvload.Size = new System.Drawing.Size(128, 36);
            this.csvload.TabIndex = 13;
            this.csvload.Text = ".csv yükle";
            this.csvload.UseVisualStyleBackColor = true;
            this.csvload.Click += new System.EventHandler(this.csvload_Click);
            // 
            // csvSave
            // 
            this.csvSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.csvSave.Location = new System.Drawing.Point(14, 719);
            this.csvSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.csvSave.Name = "csvSave";
            this.csvSave.Size = new System.Drawing.Size(128, 36);
            this.csvSave.TabIndex = 12;
            this.csvSave.Text = ".csv kaydet";
            this.csvSave.UseVisualStyleBackColor = true;
            this.csvSave.Click += new System.EventHandler(this.csvSave_Click);
            // 
            // lblPaketNum
            // 
            this.lblPaketNum.AutoSize = true;
            this.lblPaketNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblPaketNum.Location = new System.Drawing.Point(200, 657);
            this.lblPaketNum.Name = "lblPaketNum";
            this.lblPaketNum.Size = new System.Drawing.Size(20, 22);
            this.lblPaketNum.TabIndex = 2;
            this.lblPaketNum.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(10, 657);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 22);
            this.label7.TabIndex = 1;
            this.label7.Text = "Toplam Paket Sayısı :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 15);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.ShowCellToolTips = false;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.ShowRowErrors = false;
            this.dataGridView1.Size = new System.Drawing.Size(1449, 598);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(11, 73);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1485, 996);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnTestSim);
            this.tabPage3.Controls.Add(this.glControl);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage3.Size = new System.Drawing.Size(1477, 970);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Durum";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnTestSim
            // 
            this.btnTestSim.Location = new System.Drawing.Point(562, 35);
            this.btnTestSim.Name = "btnTestSim";
            this.btnTestSim.Size = new System.Drawing.Size(75, 23);
            this.btnTestSim.TabIndex = 1;
            this.btnTestSim.Text = "Test";
            this.btnTestSim.UseVisualStyleBackColor = true;
            this.btnTestSim.Click += new System.EventHandler(this.btnTestSim_Click);
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.LightBlue;
            this.glControl.Location = new System.Drawing.Point(16, 19);
            this.glControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(509, 685);
            this.glControl.TabIndex = 0;
            this.glControl.VSync = false;
            this.glControl.Load += new System.EventHandler(this.glControl_Load);
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.comboBox1);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.txtBandRate);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.Port);
            this.tabPage4.Controls.Add(this.connectCom);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Size = new System.Drawing.Size(1477, 970);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Seçenekler";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(114, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(129, 33);
            this.comboBox1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(812, 43);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Takım Bilgileri:";
            // 
            // txtBandRate
            // 
            this.txtBandRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBandRate.Location = new System.Drawing.Point(114, 36);
            this.txtBandRate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBandRate.Name = "txtBandRate";
            this.txtBandRate.Size = new System.Drawing.Size(129, 32);
            this.txtBandRate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(17, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Band Rate :";
            // 
            // Port
            // 
            this.Port.AutoSize = true;
            this.Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Port.Location = new System.Drawing.Point(65, 89);
            this.Port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(46, 20);
            this.Port.TabIndex = 5;
            this.Port.Text = "Port :";
            // 
            // connectCom
            // 
            this.connectCom.Location = new System.Drawing.Point(115, 148);
            this.connectCom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectCom.Name = "connectCom";
            this.connectCom.Size = new System.Drawing.Size(128, 36);
            this.connectCom.TabIndex = 4;
            this.connectCom.Text = "Bağlan";
            this.connectCom.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.panel1.Controls.Add(this.btnMinimize);
            this.panel1.Controls.Add(this.btnQuit);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1928, 44);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnMinimize.Location = new System.Drawing.Point(1790, 9);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(61, 27);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.Text = "Küçült";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.FlatAppearance.BorderSize = 0;
            this.btnQuit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Purple;
            this.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnQuit.Location = new System.Drawing.Point(1867, 9);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(42, 27);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Çık";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Historic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(11, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(332, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "HürDevrim Yer İstasyonu Yazılımı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(1676, 187);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kamera";
            // 
            // timerX
            // 
            this.timerX.Tick += new System.EventHandler(this.timerX_Tick);
            // 
            // openFileD
            // 
            this.openFileD.FileName = "openFileD";
            // 
            // timerGraphs
            // 
            this.timerGraphs.Tick += new System.EventHandler(this.timerGraphs_Tick);
            // 
            // gMap
            // 
            this.gMap.Bearing = 0F;
            this.gMap.CanDragMap = false;
            this.gMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMap.GrayScaleMode = false;
            this.gMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMap.LevelsKeepInMemory = 5;
            this.gMap.Location = new System.Drawing.Point(1500, 657);
            this.gMap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gMap.MarkersEnabled = true;
            this.gMap.MaxZoom = 2;
            this.gMap.MinZoom = 2;
            this.gMap.MouseWheelZoomEnabled = false;
            this.gMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMap.Name = "gMap";
            this.gMap.NegativeMode = false;
            this.gMap.PolygonsEnabled = true;
            this.gMap.RetryLoadTile = 0;
            this.gMap.RoutesEnabled = false;
            this.gMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMap.ShowTileGridLines = false;
            this.gMap.Size = new System.Drawing.Size(408, 412);
            this.gMap.TabIndex = 10;
            this.gMap.TabStop = false;
            this.gMap.Zoom = 0D;
            this.gMap.Load += new System.EventHandler(this.gMap_Load);
            // 
            // timerMap
            // 
            this.timerMap.Tick += new System.EventHandler(this.timerMap_Tick);
            // 
            // AnaEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumPurple;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.gMap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AnaEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HürDevrim";
            this.Load += new System.EventHandler(this.AnaEkran_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label Port;
        private System.Windows.Forms.Button connectCom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBandRate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Label label5;
        private OpenTK.GLControl glControl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblPaketNum;
        private System.Windows.Forms.Button csvload;
        private System.Windows.Forms.Button csvSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnTestSim;
        private System.Windows.Forms.Timer timerX;
        private System.Windows.Forms.OpenFileDialog openFileD;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Timer timerGraphs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private GMap.NET.WindowsForms.GMapControl gMap;
        private System.Windows.Forms.Timer timerMap;
    }
}

