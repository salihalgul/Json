using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Emojilerim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Category> GetEmojiList()
        {
            string jsonContent = File.ReadAllText("smiley_content.json");
            JavaScriptSerializer tercuman=new JavaScriptSerializer();
           

            return tercuman.Deserialize<List<Category>>(jsonContent);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = GetEmojiList();
            DisplayEmojilist(list);
        }

        private void DisplayEmojilist(List<Category> list)
        {
            foreach (Category c in list)
            {
                Label can = new Label() {Text = c.category};
                can.AutoSize = false;
                can.Width = this.ClientSize.Width;
                can.Font=new Font(FontFamily.GenericMonospace,20);
                can.TextAlign = ContentAlignment.MiddleCenter;
                can.Margin=new Padding(0,20,0,20);
                flowLayoutPanel1.SetFlowBreak(can,true);
                flowLayoutPanel1.Controls.Add(can);
                DisplayItems(c);
            }
        }

        private void DisplayItems(Category c)
        {
            foreach (Item item in c.items)
            {
                Button canan = new Button();
                canan.Text = item.art + Environment.NewLine + item.name;
                canan.Font=new Font(FontFamily.GenericMonospace,14);
                canan.Padding=new Padding(5);
                canan.Width = flowLayoutPanel1.ClientSize.Width / 2 - 10;
                canan.Height = 80;
                canan.Click +=Buttooon_click ;
                flowLayoutPanel1.Controls.Add(canan);
            }
            Label empty = new Label() { Text = " " };
            flowLayoutPanel1.SetFlowBreak(empty, true);


        }

       

        private void Buttooon_click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button) sender;
            string[] infos = clickedBtn.Text.Split('\n');
            Clipboard.SetText(infos[0]);
            MessageBox.Show(clickedBtn.Text + "has copied to Clipboard");

        }
    }
}
