using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    internal class Carro
    {
        public static int counter = 1;
        public int ID;

        public Carro()
        {
            this.ID = counter;
        }

        /// <summary>
        /// Registra uma instância do carro, adicionando um ao contador que é passado ao ID, e depois adiciona alguns itens ao ListView
        /// <summary>
        public void Registrar_carro(ListView listView1, string txtboxplaca)
        {

            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.SubItems[1].Text==txtboxplaca && lvi.SubItems[6].Text=="sim")
                {
                    MessageBox.Show("Veículo já registrado");
                    return;
                }              
            }

            counter++;
            ListViewItem item = new ListViewItem(Convert.ToString(this.ID));
            item.SubItems.Add(txtboxplaca);
            item.SubItems.Add(Convert.ToString(DateTime.Now));
            item.SubItems.Add("Estacionado");
            item.SubItems.Add("Estacionado");
            item.SubItems.Add("0,00");
            item.SubItems.Add("sim");
            listView1.Items.Add(item);            
            Form1.vagas--;

        }

    }
}
