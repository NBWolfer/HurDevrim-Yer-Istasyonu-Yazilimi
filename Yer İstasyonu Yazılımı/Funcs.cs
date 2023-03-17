﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yer_İstasyonu_Yazılımı
{
    public class Funcs
    {
        public static void TabloDuzen(DataGridView dgw)
        { 
            string headers = "<PAKET-NUMARASI>, <UYDU-STATUSU>, <HATA-KODU>, <GONDERME-SAATI>, <BASINC1>, <BASINC2>, <YUKSEKLIK1>, <YUKSEKLIK2>, <IRTIFA-FARKI>, <INIS-HIZI>, <SICAKLIK>, <PIL-GERILIMI>, <GPS1-LATITUDE>, <GPS1-LONGITUDE>, <GPS1-ALTITUDE>, <GPS2-LATITUDE>, <GPS2-LONGITUDE>, <GPS2-ALTITUDE>, <PITCH>, <ROLL>, <YAW>, <TAKIM-NO>";
            string[] parts = headers.Split(new char[] { '<', '>', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] output = parts.Select(p => p.Trim()).ToArray();
            int index = 0;
            dgw.ColumnCount = output.Length;
            foreach (string item in output)
            {
                    dgw.Columns[index++].HeaderText = item;
            }
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
    }
}
