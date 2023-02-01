using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp7
{
    public partial class Form3 : Form
    {

        public int nesilSay = 0;
        public int nesilSayisi = 0;

        Bitmap imageMale;
        Bitmap imageFemale;

        List<Point> lines1 = new List<Point>();
        List<Point> lines2 = new List<Point>();
        int p1, p2, p3, p4;

        List<Person> PersonList_1 = new List<Person>();
        List<Person> PersonList_2 = new List<Person>();
        List<Person> PersonList_3 = new List<Person>();
        List<Person> PersonList_4 = new List<Person>();
        List<Person> PersonList_full = new List<Person>();
        List<Person> ChildlessPerson = new List<Person>();
        List<String> istenenKanList = new List<String>();
        public Form3(List<Person> tmp1, List<Person> tmp2, List<Person> tmp3, List<Person> tmp4, List<Person> tmp5)
        {

            imageMale = new Bitmap(@".\male.png");
            imageFemale = new Bitmap(@".\female.png");



            PersonList_1 = tmp1;
            PersonList_2 = tmp2;
            PersonList_3 = tmp3;
            PersonList_4 = tmp4;
            PersonList_full = tmp5;

            InitializeComponent();

        }
        public void BeforeToPlace()
        {
            for (int i = 1; i < PersonList_1.Count; i++)
            {
                PersonList_1[0].ToPlace(PersonList_1[i]);
            }
            for (int i = 0; i < PersonList_1.Count; i++)
            {
                PersonList_2[0].ToPlaceNew(PersonList_1[i]);
                PersonList_3[0].ToPlaceNew(PersonList_1[i]);
                PersonList_4[0].ToPlaceNew(PersonList_1[i]);

            }

            for (int i = 1; i < PersonList_2.Count; i++)
            {
                PersonList_2[0].ToPlace(PersonList_2[i]);

            }
            for (int i = 0; i < PersonList_2.Count; i++)
            {
                PersonList_1[0].ToPlaceNew(PersonList_2[i]);
                PersonList_3[0].ToPlaceNew(PersonList_2[i]);
                PersonList_4[0].ToPlaceNew(PersonList_2[i]);

            }

            for (int i = 1; i < PersonList_3.Count; i++)
            {
                PersonList_3[0].ToPlace(PersonList_3[i]);

            }
            for (int i = 0; i < PersonList_3.Count; i++)
            {
                PersonList_1[0].ToPlaceNew(PersonList_3[i]);
                PersonList_2[0].ToPlaceNew(PersonList_3[i]);
                PersonList_4[0].ToPlaceNew(PersonList_3[i]);

            }

            for (int i = 1; i < PersonList_4.Count; i++)
            {
                PersonList_4[0].ToPlace(PersonList_4[i]);

            }
            for (int i = 0; i < PersonList_4.Count; i++)
            {
                PersonList_1[0].ToPlaceNew(PersonList_4[i]);
                PersonList_2[0].ToPlaceNew(PersonList_4[i]);
                PersonList_3[0].ToPlaceNew(PersonList_4[i]);
            }




        }

        private void Form3_Load(object sender, EventArgs e)
        {
            BeforeToPlace();
            drawNext(800, 100, PersonList_1[0], panel1);
            p1 = lines1.Count;
            tabPage1.Text = PersonList_1[0].Surname + " Ailesi";



            drawNext(800, 100, PersonList_2[0], panel2);
            p2 = lines1.Count;
            tabPage2.Text = PersonList_2[0].Surname + " Ailesi";


            drawNext(800, 100, PersonList_3[0], panel3);
            p3 = lines1.Count;
            tabPage3.Text = PersonList_3[0].Surname + " Ailesi";


            drawNext(800, 100, PersonList_4[0], panel4);
            p4 = lines1.Count;
            tabPage4.Text = PersonList_4[0].Surname + " Ailesi";


        }


        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            lines1.Clear();
            lines2.Clear();
            drawNext(800, 100, PersonList_1[0], panel1);
            p1 = lines1.Count;
            tabPage1.Text = PersonList_1[0].Surname + " Ailesi";



            drawNext(800, 100, PersonList_2[0], panel2);
            p2 = lines1.Count;
            tabPage2.Text = PersonList_2[0].Surname + " Ailesi";


            drawNext(800, 100, PersonList_3[0], panel3);
            p3 = lines1.Count;
            tabPage3.Text = PersonList_3[0].Surname + " Ailesi";


            drawNext(800, 100, PersonList_4[0], panel4);
            p4 = lines1.Count;
            tabPage4.Text = PersonList_4[0].Surname + " Ailesi";


        }
        private void button2_Click(object sender, EventArgs e)
        {
            string KanGisiris = Interaction.InputBox("Kan Grubunu Giriniz.", "Bilgi Girişi", "", 800, 400);
            string istenenKan = KanGisiris;

            istenenKanList.Add(istenenKan + " Grubu insanlar");
            istenenKanList.Add("----------------");
            for (int j = 0; j < PersonList_full.Count; j++)
            {
                String[] mevcutKanList = PersonList_full[j].Blood.ToString().Split("(");
                String mevcutKan = mevcutKanList[0];
                if (mevcutKan == istenenKan && istenenKanList.Contains(PersonList_full[j].Name + " " + PersonList_full[j].Surname) == false)
                {
                    istenenKanList.Add(PersonList_full[j].Name + " " + PersonList_full[j].Surname);
                }
            }

            listBox1.Items.Clear();

            for (int j = 0; j < istenenKanList.Count; j++)
                listBox1.Items.Add(istenenKanList[j]);

            istenenKanList.Clear();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            listBox1.Items.Add("Ayni isme sahip olanların Yaşları ve İsimleri");
            listBox1.Items.Add("--------------------------------------------");
            listBox1.Items.Add("");


            String arananIsim;
            List<String> isimler = new List<string>();
            for (int i = 0; i < PersonList_full.Count; i++)
            {
                int sayac = 0;

                arananIsim = PersonList_full[i].Name.ToString();
                if (isimler.Contains(arananIsim) == false)
                    isimler.Add(arananIsim);
                else if (isimler.Contains(arananIsim) == true)
                    continue;

                for (int j = 0; j < PersonList_full.Count; j++)
                {
                    if (arananIsim == PersonList_full[j].Name.ToString() && PersonList_full[i].Id1 != PersonList_full[j].Id1)
                    {

                        String[] yasList2 = PersonList_full[i].DateOfBirth.Split("/");
                        int yas2 = 2022 - Convert.ToInt32(yasList2[2]);

                        if (sayac == 0)
                        {
                            listBox1.Items.Add("");
                            listBox1.Items.Add(PersonList_full[i].Name + " " + PersonList_full[i].Surname + " Yaş : " + yas2);
                            sayac++;
                        }
                        String[] yasList = PersonList_full[j].DateOfBirth.Split("/");
                        int yas = 2022 - Convert.ToInt32(yasList[2]);

                        listBox1.Items.Add(PersonList_full[j].Name + " " + PersonList_full[j].Surname + " Yaş : " + yas);

                        //     Console.WriteLine(arananIsim + " e sahip kişiler:  " + PersonList_full[j].Name.ToString() + " " + PersonList_full[j].Surname.ToString() + " " + yas + " yasindadir.");
                    }
                }

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (tabControl1.SelectedIndex == 0)
            {
                nesilSay = 0;
                nesilSayisi = 0;
                Tree(PersonList_1[0]);
                listBox1.Items.Add(PersonList_1[0].Surname + " Ailesi " + nesilSayisi + " Nesilden oluşmaktadır.");
                listBox1.Items.Add("");
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                nesilSay = 0;
                nesilSayisi = 0;
                Tree(PersonList_2[0]);
                listBox1.Items.Add(PersonList_2[0].Surname + " Ailesi " + nesilSayisi + " Nesilden oluşmaktadır.");
                listBox1.Items.Add("");

            }
            else if (tabControl1.SelectedIndex == 2)
            {

                nesilSay = 0;
                nesilSayisi = 0;
                Tree(PersonList_3[0]);
                listBox1.Items.Add(PersonList_3[0].Surname + " Ailesi " + nesilSayisi + " Nesilden oluşmaktadır.");
                listBox1.Items.Add("");
            }
            else if (tabControl1.SelectedIndex == 3)
            {

                nesilSay = 0;
                nesilSayisi = 0;
                Tree(PersonList_4[0]);
                listBox1.Items.Add(PersonList_4[0].Surname + " Ailesi " + nesilSayisi + " Nesilden oluşmaktadır.");
                listBox1.Items.Add("");

            }





        }


        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);

            Graphics graphics = e.Graphics;
            for (int i = 0; i < p1; i++)
            {
                graphics.DrawLine(pen, lines1[i], lines2[i]);

            }
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);

            Graphics graphics = e.Graphics;
            for (int i = p1; i < p2; i++)
            {
                graphics.DrawLine(pen, lines1[i], lines2[i]);

            }
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);

            Graphics graphics = e.Graphics;
            for (int i = p2; i < p3; i++)
            {
                graphics.DrawLine(pen, lines1[i], lines2[i]);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            string isim = Interaction.InputBox("İsim ve Soyisim Bilgisini Giriniz.", "Bilgi Girişi", "", 800, 400);

            foreach (Person person in PersonList_full)
            {
                if (person.Name + " " + person.Surname == isim)
                {
                    nesilSay = 0;
                    nesilSayisi = 0;
                    Tree(person);
                    listBox1.Items.Add(person.Name + " " + person.Surname + " Kişisinden sonra " + (nesilSayisi-1) + " Nesil gelmektedir.");
                    listBox1.Items.Add("");

                }
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                ataBul(PersonList_1);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                ataBul(PersonList_2);
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                ataBul(PersonList_3);

            }
            else if (tabControl1.SelectedIndex == 3)
            {
                ataBul(PersonList_4);

            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Black, 5);
            Graphics graphics = e.Graphics;

            for (int i = p3; i < p4; i++)
            {
                graphics.DrawLine(pen, lines1[i], lines2[i]);
            }
        }

        void ataBul(List<Person> tmp)
        {
            List<string> idler = new List<string>();
            idler.Clear();

            listBox1.Items.Clear();

            String meslek;
            for (int i = 0; i < tmp.Count; i++)
            {
                meslek = tmp[i].Job.ToString();
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (tmp[j].Job.ToString() == meslek)
                    {
                        //bu kişi ilk person un dedesi veya babası mı
                        if (tmp[i].Dad.ToString() == tmp[j].Name.ToString() && idler.Contains(tmp[j].Id1) == false) //babasıdır
                        {

                            //Console.WriteLine(tmp[i].Name + " babasının meslegini devam ettiriyor. Meslek: " + tmp[i].Job);

                            listBox1.Items.Add(tmp[j].Name + " " + tmp[j].Surname + " babasının meslegini devam ettiriyor.");
                            listBox1.Items.Add("Meslek: " + tmp[i].Job);
                            listBox1.Items.Add("");

                            idler.Add(tmp[j].Id1);
                        }

                        for (int k = 0; k < tmp.Count; k++)
                        {
                            if (tmp[k].Name.ToString() == tmp[i].Dad.ToString()) //eger bu nesnedeki kişi i nin babasıysa // K, İ NİN BABASI
                            {
                                for (int m = 0; m < tmp.Count; m++)
                                {
                                    if (tmp[m].Name.ToString() == tmp[k].Dad.ToString() && idler.Contains(tmp[m].Id1) == false) //eger bu nesnedeki kişi k nın babasıtsa // M, K NIN BABASIDIR. // M, İ NİN DEDESİDİR
                                    {
                                        if (tmp[m].Job.ToString() == meslek) //dedesinin meslegini yapıyor
                                        {
                                            //Console.WriteLine(tmp[i].Name + " dedesinin meslegini devam ettiriyor. Meslek: " + tmp[i].Job);
                                            listBox1.Items.Add(tmp[i].Name + " " + tmp[i].Surname + " dedesininden mesleği devam ettiriyor.");
                                            listBox1.Items.Add(" Meslek: " + tmp[i].Job);
                                            listBox1.Items.Add("");

                                            idler.Add(tmp[m].Id1);

                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChildlessTree(PersonList_1[0]);
            ChildlessTree(PersonList_2[0]);
            ChildlessTree(PersonList_3[0]);
            ChildlessTree(PersonList_4[0]);
            listBox1.Items.Clear();
            
            foreach(Person p in ChildlessPerson)
            {
                listBox1.Items.Add(p.Name+" "+p.Surname);

            }


        }

        void ChildlessTree(Person person)
        {


            if (person.children.Count != 0)
            {
                foreach (Person Child in person.children)
                {
                    ChildlessTree(Child);
                }

            }
            else
            {
                if (ChildlessPerson.Contains(person) == false)
                {
                    for (int i = 0; i < ChildlessPerson.Count; i++)
                    {
                        if (ChildlessPerson[i].Yas() <= person.Yas())
                        {
                            ChildlessPerson.Insert(i, person);
                            break;
                        }
                    }
                    ChildlessPerson.Add(person);
                }
                
            }


        }


        void Tree(Person person)
        {
            nesilSay += 1;

            if (person.children.Count != 0)
            {
                foreach (Person Child in person.children)
                {
                    Tree(Child);
                }

            }
            else
            {
                if (nesilSay > nesilSayisi)
                    nesilSayisi = nesilSay;

                nesilSay = 0;
            }

        }


        int drawNext(int x, int y, Person person, Panel panel)
        {

            int tmpx = 0, tmpy = 0;
            Label labelM = new System.Windows.Forms.Label();
            panel.Controls.Add(labelM);
            labelM.Location = new System.Drawing.Point(x, y);
            labelM.Name = person.Name;
            labelM.Size = new System.Drawing.Size(150, 90);
            labelM.TabIndex = 0;
            labelM.Text = person.Name + " " + person.Surname + "\n" + person.Blood + "\n" + person.Job;
            labelM.TextAlign = ContentAlignment.MiddleRight;
            if (person.Gender == "Erkek")
            {
                labelM.Image = imageMale;
                labelM.ImageAlign = ContentAlignment.MiddleLeft;
                labelM.BackColor = System.Drawing.Color.LightBlue;
            }
            else
            {
                labelM.Image = imageFemale;
                labelM.ImageAlign = ContentAlignment.MiddleLeft;
                labelM.BackColor = System.Drawing.Color.HotPink;
            }



            if ("" != person.Spouse)
            {
                x += labelM.Size.Width + 50;
                Label labelU = new System.Windows.Forms.Label();
                panel.Controls.Add(labelU);
                labelU.Location = new System.Drawing.Point(x, y);
                labelU.Name = person.partner.Name;
                labelU.Size = new System.Drawing.Size(150, 90);
                labelU.TabIndex = 0;
                labelU.Text = person.partner.Name + " " + person.partner.Surname + "\n" + person.partner.Blood + "\n" + person.partner.Job;
                labelU.TextAlign = ContentAlignment.MiddleRight;


                if (person.Gender == "Erkek")
                {
                    labelU.Image = imageFemale;
                    labelU.ImageAlign = ContentAlignment.MiddleLeft;
                    labelU.BackColor = System.Drawing.Color.HotPink;
                }
                else
                {
                    labelU.Image = imageMale;
                    labelU.ImageAlign = ContentAlignment.MiddleLeft;
                    labelU.BackColor = System.Drawing.Color.LightBlue;
                }
                Point point1 = new Point(labelM.Location.X + 150, labelM.Location.Y + 45);
                Point point2 = new Point(labelU.Location.X, labelU.Location.Y + 45);
                tmpx = point2.X - (point2.X - point1.X) / 2;
                tmpy = point2.Y;

                lines1.Add(point1);
                lines2.Add(point2);

            }

            y += 150;


            int sayac = 0;

            if (person.children.Count != 0)
            {
                Point point1 = new Point(tmpx, tmpy);
                Point point2 = new Point(tmpx, tmpy + 76);

                lines1.Add(point1);
                lines2.Add(point2);

                foreach (Person Child in person.children)
                {
                    sayac++;
                    if (Child.Spouse != "")
                        sayac++;
                }

                x -= sayac * 110;

                Point point11 = new Point(tmpx, tmpy + 75);

                foreach (Person Child in person.children)
                {
                    Point point22 = new Point(x + 85, tmpy + 75);

                    lines1.Add(point11);
                    lines2.Add(point22);

                    lines1.Add(point22);
                    Point point3 = new Point(x + 85, tmpy + 110);
                    lines2.Add(point3);

                    x += drawNext(x, y, Child, panel);
                    x += 100 * sayac;

                    if (Child.Spouse != "")
                    {
                        x += 50 * sayac;
                    }

                }

            }

            return 65 * sayac;

        }


    }

}
