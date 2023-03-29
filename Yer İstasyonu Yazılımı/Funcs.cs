using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yer_İstasyonu_Yazılımı
{
    public class Funcs
    {
        public static void TabloDuzen(DataGridView dgw)
        {
            string headers = "<PAKET-NUMARASI>, <UYDU-STATUSU>, <HATA-KODU>, <GONDERME-TARİHİ>, <BASINC1>, <BASINC2>, <YUKSEKLIK1>, <YUKSEKLIK2>, <IRTIFA-FARKI>, <INIS-HIZI>, <SICAKLIK>, <PIL-GERILIMI>, <GPS1-LATITUDE>, <GPS1-LONGITUDE>, <GPS1-ALTITUDE>, <GPS2-LATITUDE>, <GPS2-LONGITUDE>, <GPS2-ALTITUDE>, <PITCH>, <ROLL>, <YAW>, <TAKIM-NO>";
            List<string> data = new List<string>();

            int start = headers.IndexOf("<");
            while (start >= 0)
            {
                int end = headers.IndexOf(">", start);
                if (end > start)
                {
                    string item = headers.Substring(start + 1, end - start - 1);
                    if (string.IsNullOrEmpty(item))
                    {
                        data.Add(" ");
                    }
                    else
                    {
                        data.Add(item);
                    }
                }
                start = headers.IndexOf("<", end);
            }

            int index = 0;
            dgw.ColumnCount = data.ToArray().Length;
            foreach (string item in data.ToArray())
            {
                dgw.Columns[index++].HeaderText = item;
            }
        }

        public static List<string> DataSplit(string packet)
        {
            List<string> data = new List<string>();

            int start = packet.IndexOf("<");
            while (start >= 0)
            {
                int end = packet.IndexOf(">", start);
                if (end > start)
                {
                    string item = packet.Substring(start + 1, end - start - 1);
                    if (string.IsNullOrEmpty(item))
                    {
                        data.Add("0");
                    }
                    else
                    {
                        data.Add(item);
                    }
                }
                start = packet.IndexOf("<", end);
            }

            return data;
        }


        public static void AddRow(DataGridView dgw, string[] outputs)
        {
            DataGridViewRow dgvr = new DataGridViewRow();
            dgvr.CreateCells(dgw, outputs);
            
            dgw.Invoke(new Action(() => { dgw.Rows.Add(dgvr); })); 
        }

        public static string ARAS(string param)
        {
            char[] code = DataSplit(param)[3].ToCharArray();
            string err = "";
            if (code[0]==1)
            {
                err += "Uydunun iniş hızı 12-14 m/sn dışında !";
            }
            if (code[1]==1) 
            {
                err += " Görev Yükünün iniş hızı 6-8 m/sn dışında !";
            }
            if (code[2]==1)
            {
                err += " Taşıyıcı konum verisine ulaşılamıyor !";
            }
            if (code[3]==1)
            {
                err += " Görev Yükünün konum verisine ulaşılamıyr !";
            }
            if (code[4]==1)
            {
                err += " Ayrılma gerçekleşmedi !";
            }
            return err + " "+"<"+DataSplit(param)[3]+">";
        }
        public async static Task<DataTable> ReadCSV(string filePath) => await Task.Run(() =>
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                //first line to create header
                string firstLine = lines[0];
                string[] headerLabels = firstLine.Split(',');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }
                //For Data
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] dataWords = lines[i].Split(',');
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < dataWords.Length - 1; j++)
                    {
                        dr[j] = dataWords[j];
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        });
        public static GMarkerGoogle AddMarker(double lat, double lon)
        {
            GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng(lat, lon),GMarkerGoogleType.blue_pushpin);
            return marker;
        }
    }
}
