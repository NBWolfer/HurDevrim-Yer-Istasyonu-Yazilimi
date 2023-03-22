using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using System.IO.Ports;
using GMap.NET.MapProviders;
using System.Threading;
using System.Text;

namespace Yer_İstasyonu_Yazılımı
{
    public partial class AnaEkran : Form
    {

        public AnaEkran()
        {
            InitializeComponent();
        }
        private bool IsConnected = true;
        private void AnaEkran_Load(object sender, EventArgs e)
        {
            //Funcs.TabloDuzen(dataGridView1);
            TimerTrigger();
            foreach(string port in ports)
            {
                cmBPorts.Items.Add(port);
            }
            listBox1.Items.Add("Bağlı Değil");
        }
        private void TimerTrigger()
        {
            if (IsConnected)
            {
                timerX.Interval = 1000; // buradaki timer lar seriport fonksiyonunun içine yerleşecek
                timerX.Start();
                timerGraphs.Interval = 1000;
                timerGraphs.Start();
                timerMap.Interval = 1000;
                timerMap.Start();
            }
        }

        // Top-Side Creation
        int movem;
        int Mouse_x;
        int Mouse_y;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            movem = 0;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            movem = 1;
            Mouse_x = e.X;
            Mouse_y = e.Y;
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(movem == 1)
            {
                this.SetDesktopLocation(MousePosition.X-Mouse_x, MousePosition.Y-Mouse_y);
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Parameters Table CSV Processes
        private async void csvSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV file (*.csv)|*.csv";
                saveFileDialog1.Title = "Save a CSV File";

                // Show the file dialog on a separate thread using Task.Run
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Create the file stream to write to the file
                    StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile());
                    for(int i =0; i< dataGridView1.Columns.Count; i++)
                    {
                        sw.Write(dataGridView1.Columns[i].HeaderText);
                        if(i != dataGridView1.Columns.Count - 1)
                            sw.Write(',');
                    }
                    sw.Write('\n');
                    // Loop through the rows and columns of the DataGridView, writing each cell's value to the file separated by commas
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            sw.Write(dataGridView1.Rows[i].Cells[j].Value);

                            if (j != dataGridView1.Columns.Count - 1)
                                sw.Write(",");
                        }
                        sw.Write("\n");
                    }

                    // Close the file stream
                    sw.Close();

                    MessageBox.Show("Dosya kaydedildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exceptionObject)
            {
                MessageBox.Show("Dosya kaydedilemedi: " + exceptionObject.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void csvload_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Locale = new System.Globalization.CultureInfo("tr-TR");
                        dataTable.ExtendedProperties["CharSet"] = "utf8";
                        string[] headers = (await reader.ReadLineAsync()).Split(',');
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);
                        }

                        while (!reader.EndOfStream)
                        {
                            string[] rows = (await reader.ReadLineAsync()).Split(',');
                            await Task.Run(() =>
                            {
                                DataRow dataRow = dataTable.NewRow();
                                for (int i = 0; i < headers.Length; i++)
                                {
                                    dataRow[i] = rows[i];
                                }
                                dataTable.Rows.Add(dataRow);
                            });
                        }
                        dataGridView1.Invoke((MethodInvoker)delegate { dataGridView1.DataSource = dataTable; });
                    }
                }
                else
                {
                    throw new Exception("Dosya Açılamadı!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Bir hata oluştu: " + err.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Graphs/Charts
        int time = 0;
        private async void timerGraphs_Tick(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                int dataCount = chAltidute.Series[0].Points.Count;
                Random r = new Random();
                int temp = r.Next(0, 100);
                int interval = 1;
                time++;
                if (dataCount > 10)
                {
                    interval = 5;
                }
                if (dataCount > 50)
                {
                    interval = 10;
                }
                if (dataCount > 100)
                {
                    interval = 30;
                }

                chAltidute.Invoke(new Action(() =>
                {
                    chAltidute.ChartAreas[0].AxisX.Interval = interval;
                    chAltidute.ChartAreas[0].AxisX.Title = "Zaman(sn)";
                    chAltidute.ChartAreas[0].AxisY.Title = "Yükseklik(m)";
                    chAltidute.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 16);

                    chAltidute.Series[0].Points.AddXY(time, r.Next(0, 100)); //Funcs.parameters[6]); // Veriyi grafiğe ekle
                    chAltidute.Series[1].Points.AddXY(time, r.Next(0, 100)); //Funcs.parameters[7]); // Veriyi grafiğe ekle
                    chAltidute.Invalidate();
                    chAltidute.ResetAutoValues(); // Grafiği otomatik olarak yeniden boyutlandırın ve ayarlayın
                }));
                chBatteryVolt.Invoke(new Action(() =>
                {
                    chBatteryVolt.ChartAreas[0].AxisX.Interval = interval;
                    chBatteryVolt.ChartAreas[0].AxisX.Title = "Zaman(sn)";
                    chBatteryVolt.ChartAreas[0].AxisY.Title = "Volt(V)";
                    chBatteryVolt.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12);

                    chBatteryVolt.Series[0].Points.AddXY(time, r.Next(0, 12)); // Funcs.parameters[11]);
                    chBatteryVolt.Invalidate();
                    chBatteryVolt.ResetAutoValues();
                }));
                chPressure.Invoke(new Action(() =>
                {
                    chPressure.ChartAreas[0].AxisX.Interval = interval;
                    chPressure.ChartAreas[0].AxisX.Title = "Zaman(sn)";
                    chPressure.ChartAreas[0].AxisY.Title = "Paskal";
                    chPressure.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12);

                    chPressure.Series[0].Points.AddXY(time, r.Next(700, 900)); // Func.parameters[4]);
                    chPressure.Series[1].Points.AddXY(time, r.Next(700, 900)); // Func.parameters[5]);
                    chPressure.Invalidate();
                    chPressure.ResetAutoValues();
                }));
                chTempurature.Invoke(new Action(() =>
                {
                    chTempurature.ChartAreas[0].AxisX.Interval = interval;
                    chTempurature.ChartAreas[0].AxisX.Title = "Zaman(sn)";
                    chTempurature.ChartAreas[0].AxisY.Title = "Derece(℃)";
                    chTempurature.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12);

                    chTempurature.Series[0].Points.AddXY(time, r.Next(25, 35)); // Func.parameters[10]);
                    chTempurature.Invalidate();
                    chTempurature.ResetAutoValues();
                }));
                chSpeed.Invoke(new Action(() =>
                {
                    chSpeed.ChartAreas[0].AxisX.Interval = interval;
                    chSpeed.ChartAreas[0].AxisX.Title = "Zaman(sn)";
                    chSpeed.ChartAreas[0].AxisY.Title = "Hız(m/sn)";
                    chSpeed.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial",12);

                    chSpeed.Series[0].Points.AddXY(time, r.Next(-25, 0)); // Func.parameters[9]);
                    chSpeed.Invalidate();
                    chSpeed.ResetAutoValues();
                }));
                chPackageNum.Invoke(new Action(() =>
                {
                    chPackageNum.ChartAreas[0].AxisX.Interval = interval;
                    chPackageNum.ChartAreas[0].AxisX.Title = "Zaman(sn)";
                    chPackageNum.ChartAreas[0].AxisY.Title = "Paket Sayısı(Adet)";
                    chPackageNum.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 12);

                    chPackageNum.Series[0].Points.AddXY(time, time);
                    chPackageNum.Invalidate();
                    chPackageNum.ResetAutoValues();
                }));
            });
        }

        // Simulation Drawing
        float x = 0, y = 0, z = 0;
        private void glControl_Paint(object sender, PaintEventArgs e)
        {
            float step = 1.0f;
            float topla = step;
            float radius = 5.0f;
            float dikey1 = radius;
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.ClearColor(Color.LightBlue);
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(1.04f, 4 / 3, 1, 10000);
            Matrix4 lookat = Matrix4.LookAt(25, 0, 0, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookat);
            GL.Viewport(0, 0, glControl.Width, glControl.Height);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            GL.Rotate(x, 1.0, 0.0, 0.0);//ÖNEMLİ
            GL.Rotate(z, 0.0, 1.0, 0.0);
            GL.Rotate(y, 0.0, 0.0, 1.0);

            Cylinder(step, topla, radius, 3, -5);
            Cylinder(0.01f, topla, 0.5f, 9, 9.7f);
            Cylinder(0.01f, topla, 0.1f, 5, dikey1 + 5);
            Cone(0.01f, 0.01f, radius, 3.0f, 3, 5);
            Cone(0.01f, 0.01f, radius, 2.0f, -5.0f, -10.0f);
            Propeller(9.0f, 11.0f, 0.2f, 0.5f);

            GL.Begin(BeginMode.Lines);

            GL.Color3(Color.FromArgb(250, 0, 0));
            GL.Vertex3(-30.0, 0.0, 0.0);
            GL.Vertex3(30.0, 0.0, 0.0);


            GL.Color3(Color.FromArgb(0, 0, 0));
            GL.Vertex3(0.0, 30.0, 0.0);
            GL.Vertex3(0.0, -30.0, 0.0);

            GL.Color3(Color.FromArgb(0, 0, 250));
            GL.Vertex3(0.0, 0.0, 30.0);
            GL.Vertex3(0.0, 0.0, -30.0);

            GL.End();
            //GraphicsContext.CurrentContext.VSync = true;
            glControl.SwapBuffers();
        }
        private void glControl_Load(object sender, EventArgs e)
        {
            GL.ClearColor(0.0f, 0.0f, 0.0f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
        }
        private void Cylinder(float step, float topla, float radius, float dikey1, float dikey2)
        {
            float eski_step = 0.1f;
            GL.Begin(BeginMode.Quads);//Y EKSEN CIZIM DAİRENİN
            while (step <= 360)
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(255, 255, 255));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 0, 0));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(255, 255, 255));


                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 2) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 2) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
            GL.Begin(BeginMode.Lines);
            step = eski_step;
            topla = step;
            while (step <= 180)// UST KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));


                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);

                GL.Vertex3(ciz1_x, dikey1, ciz1_y);
                GL.Vertex3(ciz2_x, dikey1, ciz2_y);
                step += topla;
            }
            step = eski_step;
            topla = step;
            while (step <= 180)//ALT KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));

                float ciz1_x = (float)(radius * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey2, ciz1_y);

                float ciz2_x = (float)(radius * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
        }
        private void Propeller(float yukseklik, float uzunluk, float kalinlik, float egiklik)
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(Color.Red);
            GL.Vertex3(uzunluk, yukseklik, kalinlik);
            GL.Vertex3(uzunluk, yukseklik + egiklik, -kalinlik);
            GL.Vertex3(0.0, yukseklik + egiklik, -kalinlik);
            GL.Vertex3(0.0, yukseklik, kalinlik);

            GL.Color3(Color.Red);
            GL.Vertex3(-uzunluk, yukseklik + egiklik, kalinlik);
            GL.Vertex3(-uzunluk, yukseklik, -kalinlik);
            GL.Vertex3(0.0, yukseklik, -kalinlik);
            GL.Vertex3(0.0, yukseklik + egiklik, kalinlik);

            GL.Color3(Color.White);
            GL.Vertex3(kalinlik, yukseklik, -uzunluk);
            GL.Vertex3(-kalinlik, yukseklik + egiklik, -uzunluk);
            GL.Vertex3(-kalinlik, yukseklik + egiklik, 0.0);//+
            GL.Vertex3(kalinlik, yukseklik, 0.0);//-

            GL.Color3(Color.White);
            GL.Vertex3(kalinlik, yukseklik + egiklik, +uzunluk);
            GL.Vertex3(-kalinlik, yukseklik, +uzunluk);
            GL.Vertex3(-kalinlik, yukseklik, 0.0);
            GL.Vertex3(kalinlik, yukseklik + egiklik, 0.0);
            GL.End();

        }
        private void Cone(float step, float topla, float radius1, float radius2, float dikey1, float dikey2)
        {
            float eski_step = 0.1f;
            GL.Begin(BeginMode.Lines);//Y EKSEN CIZIM DAİRENİN
            while (step <= 360)
            {
                if (step < 45)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 90)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 135)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 180)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 225)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 270)
                    GL.Color3(1.0, 0.0, 0.0);
                else if (step < 315)
                    GL.Color3(1.0, 1.0, 1.0);
                else if (step < 360)
                    GL.Color3(1.0, 0.0, 0.0);


                float ciz1_x = (float)(radius1 * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius1 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey1, ciz1_y);

                float ciz2_x = (float)(radius2 * Math.Cos(step * Math.PI / 180F));
                float ciz2_y = (float)(radius2 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();

            GL.Begin(BeginMode.Lines);
            step = eski_step;
            topla = step;
            while (step <= 180)// UST KAPAK
            {
                if (step < 45)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 90)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 135)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 180)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 225)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 270)
                    GL.Color3(Color.FromArgb(250, 250, 200));
                else if (step < 315)
                    GL.Color3(Color.FromArgb(255, 1, 1));
                else if (step < 360)
                    GL.Color3(Color.FromArgb(250, 250, 200));


                float ciz1_x = (float)(radius2 * Math.Cos(step * Math.PI / 180F));
                float ciz1_y = (float)(radius2 * Math.Sin(step * Math.PI / 180F));
                GL.Vertex3(ciz1_x, dikey2, ciz1_y);

                float ciz2_x = (float)(radius2 * Math.Cos((step + 180) * Math.PI / 180F));
                float ciz2_y = (float)(radius2 * Math.Sin((step + 180) * Math.PI / 180F));
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);

                GL.Vertex3(ciz1_x, dikey2, ciz1_y);
                GL.Vertex3(ciz2_x, dikey2, ciz2_y);
                step += topla;
            }
            GL.End();
        }
        private async void timerX_Tick(object sender, EventArgs e)
        {
            await Task.Run(() => { 
                if (z < 180)
                {
                    z += 1;
                }
                else
                {
                    z = 0;
                }
                glControl.Invoke(new Action(() =>
                {
                    glControl.Invalidate();
                }));
            });
        }

        // Serial Port
        private string[] ports = SerialPort.GetPortNames();
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           
                string data="";
                try
                {
                    data = serialPort.ReadLine();

                }
                catch {
                    MessageBox.Show("Veri alma/işleme hatası !","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                Invoke(new Action(() =>
                {
                    listBox1.Items[1]=data;
                    Funcs.AddRow(dataGridView1, data);
                }));
        }
        private void connectCom_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                IsConnected = false;
            }
            serialPort.PortName = cmBPorts.Text == null ? "COM6" : cmBPorts.Text; // seri portun adı
            serialPort.BaudRate = txtBandRate.Text == null ? 9600 : Convert.ToInt32(txtBandRate.Text); // baud rate
            serialPort.Parity = Parity.None; // parity ayarı
            serialPort.DataBits = 8; // data bits
            serialPort.StopBits = StopBits.One; // stop bits
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            serialPort.Open();
            IsConnected = true;
            TimerTrigger();
            listBox1.Items[0]="Bağlandı";
        }
        private void btnPortScan_Click(object sender, EventArgs e)
        {
            ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cmBPorts.Items.Add(port);
            }
        }

        // Map
        double lat = 30, lng = 25;
        private GMarkerGoogle marker;
        private void gMap_Load(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMap.MapProvider = GoogleKoreaSatelliteMapProvider.Instance;
            gMap.Position = new PointLatLng(39.921033, 32.852894);
            gMap.MinZoom = 1;
            gMap.MaxZoom = 15;
            gMap.Zoom = 10;
            gMap.ShowCenter = false;
            marker = Funcs.AddMarker(lat, lng);//Funcs.AddMarker(Convert.ToDouble(Funcs.parameters[13]), Convert.ToDouble(Funcs.parameters[14]));
            GMapOverlay gMapOverlay = new GMapOverlay();
            gMapOverlay.Markers.Add(marker);
            gMap.Overlays.Add(gMapOverlay);
        }
        private void timerMap_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            double lat = r.NextDouble();
            double lng = r.NextDouble();
            PointLatLng point = new PointLatLng(marker.Position.Lat + lat, marker.Position.Lng + lng);
            marker.Position = point;
            gMap.Position = point;
            //marker.Position = new PointLatLng(Convert.ToDouble(Funcs.parameters[13]), Convert.ToDouble(Funcs.parameters[14]));
            //gMap.Position = new PointLatLng(Convert.ToDouble(Funcs.parameters[13]), Convert.ToDouble(Funcs.parameters[14]));
        }
    }
}