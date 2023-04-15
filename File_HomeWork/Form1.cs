using File_HomeWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace File_HomeWork
{

    public partial class Form1 : Form
    {
        public int listLenght;

        public string[] values;

        Table tab;
        DataTable tablo = new DataTable();


        public Form1()
        {
            tab = new Table();
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e) { }


        private void label1_Click(object sender, EventArgs e) { }

        //Text box'ları dosya içine yazma işlemi
        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\HP\\Desktop\\Dosya\\text.txt", true);


            if (txtName.Text.Length == 0 || txtLeng.Text.Length == 0 || txtPop.Text.Length == 0)
            {//Textbox'ların doluluğunu kontrol ediyorum
                using (writer)
                {
                    writer.WriteLine("null,null,null");

                }
                tablo.Rows.Add("null", "null", "null");
                dataGridView1.DataSource = tablo;
            }
            else
            {
                //Dosya içine yazma işlemi
                using (writer)
                {
                    writer.WriteLine(txtName.Text + "," + txtPop.Text + "," + txtLeng.Text);
                }

                listLenght++;
                tablo.Rows.Add(txtName.Text, txtLeng.Text, txtPop.Text);
                dataGridView1.DataSource = tablo;
            }
        }

        //Dosyanın son dizisini silme işlemi 
        private void button2_Click_1(object sender, EventArgs e)
        {
            List<string> lines = File.ReadAllLines("C:\\Users\\HP\\Desktop\\Dosya\\text.txt").ToList();

            File.WriteAllLines("C:\\Users\\HP\\Desktop\\Dosya\\text.txt", lines.GetRange(0, lines.Count - 1).ToArray());

        }

        //Grid view içerisini temizleme işlemi
        private void button4_Click_1(object sender, EventArgs e)
        {
            int selectedIndex = dataGridView1.CurrentCell.RowIndex;

            for (int i = 0; i < listLenght; i++)
            {

                if (selectedIndex > -1)
                {
                    dataGridView1.Rows.RemoveAt(selectedIndex);
                    dataGridView1.Refresh();
                }


            }
            listLenght = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Dosyadan okuma işlemi 
            string[] lines = File.ReadAllLines("C:\\Users\\HP\\Desktop\\Dosya\\Text.txt");


            tab.ListClear(); //Listeyi temizliyoruz
            foreach (string line in lines)
            { // Dosyadan okuyarak diziye atadığımız stringleri, name pop ve lenght olarak sınıflandırıyoruz
                values = line.Split(',');
                string name = values[0];
                string pop = values[1];
                string lenght = values[2];

                ThisIsClass cla = new ThisIsClass(name, pop, lenght);
                tab.ListlAdd(cla);
            }

            // her biri için ayrı açtığım listeleri farklı dizilere atama işlemi 
            string[] nam = tab.namelList();
            string[] poi = tab.poplList();
            string[] len = tab.lenglList();

            for (int i = 0; i < nam.Length; i++)
            {
                listLenght++;
                tablo.Rows.Add(nam[i], poi[i], len[i]);

            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

            //Ana satırlarımızı oluşturduk
            tablo.Columns.Add("Name", typeof(string));
            tablo.Columns.Add("population", typeof(string));
            tablo.Columns.Add("Lenght", typeof(string));
            dataGridView1.DataSource = tablo;

        }
    }

}