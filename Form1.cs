using System;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ExcelApp = Microsoft.Office.Interop.Excel;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        Form3 Agac;
        public Form1()
        {

            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string filePath;
            string fileName;

            DataTable dataTab;

            OpenFileDialog file = new OpenFileDialog();

            file.Filter = "Excel Dosyasi | *.xls; *.xlsx; *.xls; *.csv;";

            if (file.ShowDialog() == DialogResult.OK)
            {
                filePath = file.FileName;
                /*DOSYA SEÇ*/

                fileName = file.SafeFileName;
                /*DOSYANIN ADI*/

                ExcelApp.Application App = new ExcelApp.Application();

                if (App == null)
                { /* EXCEL VAR MI*/

                    MessageBox.Show(" -EXCEL YOK- ");

                    return;
                }

                /*EXCELİ AÇ*/
                ExcelApp.Workbook Book = App.Workbooks.Open(filePath);


                /////////BİRİNCİ SAYFA///////

                ExcelApp._Worksheet page = Book.Sheets[1];
                /*SATIR BUL*/

                ExcelApp.Range temp = page.UsedRange;

                int rowCount = temp.Rows.Count;

                int coulmnCount = temp.Columns.Count;

                dataTab = ToDataTable(temp, rowCount, coulmnCount);

                dataGridView1.DataSource = dataTab;
                dataGridView1.Refresh();


                /////////İKİNCİ SAYFA///////

                ExcelApp._Worksheet page2 = Book.Sheets[2];
                ExcelApp.Range temp2 = page2.UsedRange;

                rowCount = temp2.Rows.Count;
                coulmnCount = temp2.Columns.Count;

                dataTab = ToDataTable(temp2, rowCount, coulmnCount);

                dataGridView2.DataSource = dataTab;
                dataGridView2.Refresh();


                /////////UCUNCU SAYFA///////

                ExcelApp._Worksheet page3 = Book.Sheets[3];
                ExcelApp.Range temp3 = page3.UsedRange;

                rowCount = temp3.Rows.Count;
                coulmnCount = temp3.Columns.Count;

                dataTab = ToDataTable(temp3, rowCount, coulmnCount);

                dataGridView3.DataSource = dataTab;
                dataGridView3.Refresh();



                /////////DORDUNCU SAYFA///////


                ExcelApp._Worksheet page4 = Book.Sheets[4];
                ExcelApp.Range temp4 = page4.UsedRange;

                rowCount = temp4.Rows.Count;
                coulmnCount = temp4.Columns.Count;

                dataTab = ToDataTable(temp4, rowCount, coulmnCount);

                dataGridView4.DataSource = dataTab;
                dataGridView4.Refresh();

                /*quit*/
                App.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(App);
                button2.Enabled = true;


            }

            else
            {
                MessageBox.Show("  Dosya Secilmedi!!!  ");
            }

            DataGridViewRow row;

            List<Person> PersonList_1 = new List<Person>();
            List<Person> PersonList_2 = new List<Person>();
            List<Person> PersonList_3 = new List<Person>();
            List<Person> PersonList_4 = new List<Person>();
            List<Person> PersonList_full = new List<Person>();


            //-------------BİRİNCİ SAYFA
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i = i + 1)
            {
                row = this.dataGridView1.Rows[i];
                Person person1 = new Person(
                    row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString(),
                    row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString(),
                    row.Cells[8].Value.ToString(),
                    row.Cells[9].Value.ToString(),
                    row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(),
                    row.Cells[12].Value.ToString()
                    );

                PersonList_1.Add(person1);
                PersonList_full.Add(person1);
            }


            //------------İKİNCİ SAYFA
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i = i + 1)
            {
                row = this.dataGridView2.Rows[i];
                Person person2 = new Person(
                    row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString(),
                    row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString(),
                    row.Cells[8].Value.ToString(),
                    row.Cells[9].Value.ToString(),
                    row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(),
                    row.Cells[12].Value.ToString()
                    );

                PersonList_2.Add(person2);
                PersonList_full.Add(person2);
            }


            //-------------UCUNCU SAYFA
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i = i + 1)
            {
                row = this.dataGridView3.Rows[i];
                Person person3 = new Person(
                    row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString(),
                    row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString(),
                    row.Cells[8].Value.ToString(),
                    row.Cells[9].Value.ToString(),
                    row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(),
                    row.Cells[12].Value.ToString()
                    );

                PersonList_3.Add(person3);
                PersonList_full.Add(person3);
            }


            //-------------DORDUNCU SAYFA
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i = i + 1)
            {
                row = this.dataGridView4.Rows[i];
                Person person4 = new Person(
                    row.Cells[0].Value.ToString(),
                    row.Cells[1].Value.ToString(),
                    row.Cells[2].Value.ToString(),
                    row.Cells[3].Value.ToString(),
                    row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString(),
                    row.Cells[6].Value.ToString(),
                    row.Cells[7].Value.ToString(),
                    row.Cells[8].Value.ToString(),
                    row.Cells[9].Value.ToString(),
                    row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(),
                    row.Cells[12].Value.ToString()
                    );

                PersonList_4.Add(person4);
                PersonList_full.Add(person4);
            }


            Agac = new Form3(PersonList_1, PersonList_2, PersonList_3, PersonList_4, PersonList_full);

        }





        public DataTable ToDataTable(ExcelApp.Range range, int row, int col)
        {
            DataTable dataTable = new DataTable();

            for (int i = 1; i <= row; i = i + 1)
            {
                if (i == 1)
                {
                    for (int j = 1; j <= col; j = j + 1)
                    {

                        if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null) /* BOS MU SUTUNLAR */

                            dataTable.Columns.Add(range.Cells[i, j].Value2.ToString());
                        else

                            dataTable.Columns.Add(j.ToString() + ".Sutun");
                    }
                    continue;
                }

                var newLine = dataTable.NewRow();
                //SİRALA
                for (int j = 1; j <= col; j = j + 1)
                {
                    if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null) //BOS MU
                    {
                        newLine[j - 1] = range.Cells[i, j].Value2.ToString();
                    }

                    else
                    {
                        newLine[j - 1] = String.Empty;
                    }
                }

                dataTable.Rows.Add(newLine);

            }

            return dataTable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        private void button2_Click(object sender, EventArgs e)
        {

            Agac.ShowDialog();
        }
    }

}