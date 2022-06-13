using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronXL;
using System.Data;
using System.IO;

namespace WindowsFormsApp4
{
    internal class DataHandling
    {
        /// <summary>
        /// Exporta todos os items do ListView para um arquivo do excel
        /// <summary>
        public void Export(ListView listView1)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            int linha = 2, coluna = 1;

            ws.Cells[1, 1] = listView1.Columns[0].Text;
            ws.Cells[1, 2] = listView1.Columns[1].Text;
            ws.Cells[1, 3] = listView1.Columns[2].Text;
            ws.Cells[1, 4] = listView1.Columns[3].Text;
            ws.Cells[1, 5] = listView1.Columns[4].Text;
            ws.Cells[1, 6] = listView1.Columns[5].Text;
            ws.Cells[1, 7] = listView1.Columns[6].Text;

            foreach (ListViewItem lvi in listView1.Items)
            {
                coluna = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[linha, coluna] = lvs.Text;
                    coluna++;
                }

                linha++;
            }
        }

        /// <summary>
        /// Importa todos os items para um ListView de um arquivo do excel
        /// <summary>
        public void Importar(ListView listView1)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WorkBook workbook = WorkBook.Load(file.FileName);
                    WorkSheet worksheet = workbook.DefaultWorkSheet;
                    DataTable datatable = worksheet.ToDataTable(true);

                    foreach (DataRow row in datatable.Rows)
                    {
                        Carro.counter = Convert.ToInt16(row[0]);
                        ListViewItem item = new ListViewItem(row[0].ToString());
                        for (int i = 1; i < datatable.Columns.Count; i++)
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                        listView1.Items.Add(item);

                    }

                    Carro.counter++;
                }
                catch
                {
                    MessageBox.Show("Feche o excel");
                }
            }


            int estacionados = 0;
            Form1.vagas = 50;

            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.SubItems[6].Text == "sim")
                {
                    estacionados++;

                }
            }
            Form1.vagas -= estacionados;

        }
    }
}
