using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simpsons.DBtables;
using Simpsons.DBAccesss;

namespace Simpsons
{
    public partial class FRMItemAdd : Form
    {
        Stock Item = new Stock();
        int count = 1;
        public FRMItemAdd(Stock Item) //constructor, entry point into the class
        {
            InitializeComponent();
            this.Item = Item;           
        }

        private void FRMItemAdd_Load(object sender, EventArgs e)
        {
            //display item image
            label1.Text = Item.type + ", " + Item.name;
            textBox1.Text = count.ToString();

            switch(Item.name)
            {
                case "White pumps":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/White pumps.jpeg";
                    break;
                case "White Heels":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/White Heels.jpeg";
                    break;
                case "White Strappy Heels":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/White Strappy Heels.jpeg";
                    break;
                case "White loafers":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/White loafers.jpeg";
                    break;
                case "White pumps with heel cut out":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/White pumps with heel cut out.jpeg";
                    break;
                case "Sparkly White Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Sparkly White Dress.jpeg";
                    break;
                case "Elegant Floral Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Elegant Floral Dress.jpeg";
                    break;
                case "Long Sleeve Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Long Sleeve Dress.jpeg";
                    break;
                case "Cream Sequence Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Cream Sequence Dress.jpeg";
                    break;
                case "Silk White Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Silk White Dress.jpeg";
                    break;
                case "Elegant Blue Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Elegant Blue Dress.jpeg";
                    break;
                case "Yellow Silk Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Yellow Silk Dress.jpeg";
                    break;
                case "Sequenced Pink Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Sequenced Pink Dress.jpeg";
                    break;
                case "Green Mesh Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Green Mesh Dress.jpeg";
                    break;
                case "Purple Floral Dress":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Purple Floral Dress.jpeg";
                    break;
                case "Navy Blue Suit":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Navy Blue Suit.jpeg";
                    break;
                case "Plain Black Suit":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Plain Black Suit.jpeg";
                    break;
                case "White Suit":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/White Suit.jpeg";
                    break;
                case "Green Checkered Suit":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Green Checkered Suit.jpeg";
                    break;
                case "Blue Suit":
                    pictureBox1.ImageLocation = AppContext.BaseDirectory + "pictures/Blue Suit.jpeg";
                    break;
             }
        }

        private void lblMinus_Click(object sender, EventArgs e)
        {
            if(count >0)
            {
                count--;
            }
            textBox1.Text = count.ToString();
        }

        private void lblPlus_Click(object sender, EventArgs e)
        {
            if(count < Item.quantity)
            {
                count++;
            }
            textBox1.Text = count.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Item.cost = Item.cost + (Item.cost / 10);
                Item.name += " + 10% (alterations)";
            }

            for (int i=0; i < count;i++)
            {               
                GlobalDetails.Orderitems.Add(Item);
            }

            FRMbookingform.isAdd = true;
            this.Hide();
        }
    }
}
