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
    public partial class FRMbookingform : Form
    {
        private Database db;
        private StockDBAccess SDBA;
        string SQLCommand;
        DataTable tbl = new DataTable();
        List<Stock> results = new List<Stock>();
        List<string> SearchItems = new List<string>();
        double total = 0.0;
        public static bool isAdd = false;


        private Customer Cust;
        public FRMbookingform(Database db, Customer editCustomer)
        {
            InitializeComponent();
            this.db = db;
            this.Cust = editCustomer;
            this.SDBA = new StockDBAccess(db);
        }

    

        private void FRMbookingform_Load(object sender, EventArgs e)
        {
            this.db = db;

            label1.Text = "Title: " + Cust.title.ToString();
            label2.Text = "First Name:" + Cust.FN.ToString();
            label3.Text = "Surname:" + Cust.SN.ToString();
            label4.Text = "Email:" + Cust.email.ToString();
            label5.Text = "Telephone Number:" + Cust.TN.ToString();
            label6.Text = "Address:" + Cust.address.ToString();
            displayAll(results = SDBA.getStock());
        }

        public void displayAll(List<Stock> StockResults)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("StockID");
            tbl.Columns.Add("Type");
            tbl.Columns.Add("Gender");
            tbl.Columns.Add("Size");
            tbl.Columns.Add("Condition");
            tbl.Columns.Add("Name");
            tbl.Columns.Add("Cost");
            tbl.Columns.Add("Shoe Size");
            tbl.Columns.Add("Quantity");
            this.BookingfrmDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (Stock cust in StockResults)
            {
                tbl.Rows.Add(cust.SID, cust.type, cust.gender, cust.size, cust.condition, cust.name, cust.cost, cust.shoesize, cust.quantity);
            }
            BookingfrmDGV.DataSource = tbl;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SearchItems.Clear();
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            SearchItems.Clear();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            SearchItems.Clear();
        }

        private void filterResults(string tag, CheckBox c)
        {
            string Search = tag;
            DataTable tbl = new DataTable();
            tbl.Columns.Add("StockID");
            tbl.Columns.Add("Type");
            tbl.Columns.Add("Gender");
            tbl.Columns.Add("Size");
            tbl.Columns.Add("Condition");
            tbl.Columns.Add("Name");
            tbl.Columns.Add("Cost");
            tbl.Columns.Add("Shoe Size");
            tbl.Columns.Add("Quantity");
            if (c.Checked == true)
            {
                for (int i = 0; i < results.Count; i++)
                {
                    if (results[i].size == Search)
                    {
                        tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);
                    }
                    else
                    {
                        results.Remove(results[i]);
                    }
                }
            }
            else
            {
                results.Clear();
                results = SDBA.getStock();
                for (int i = 0; i < results.Count; i++)
                {
                    tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);
                }
                BookingfrmDGV.DataSource = tbl;
            }
            BookingfrmDGV.DataSource = tbl;
        }

        private void button1_Click(object sender, EventArgs e) 
        {
           if(Smallcb.Checked == false && Mediumcb.Checked == false && Largecb.Checked == false)
            {
                MessageBox.Show("You must select a size!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Malecb.Checked == false && Femalecb.Checked == false)
            {
                MessageBox.Show("You must select a gender!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Shoescb.Checked == false && Weddingdresscb.Checked == false && BridesmaidDresscb.Checked == false && GroomsSuitcb.Checked == false)
            {
                MessageBox.Show("You must select a type of clothing!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            displayAll(results = SDBA.getStock());
            results.Clear();
            results = SDBA.getStock();

            DataTable tbl = new DataTable();
            tbl.Columns.Add("StockID");
            tbl.Columns.Add("Type");
            tbl.Columns.Add("Gender");
            tbl.Columns.Add("Size");
            tbl.Columns.Add("Condition");
            tbl.Columns.Add("Name");
            tbl.Columns.Add("Cost");
            tbl.Columns.Add("Shoe Size");
            
            int i = 0;

                while (i < results.Count)
                {

                if (Smallcb.Checked == true && results[i].size == "Small")
                {
                    if (Malecb.Checked == true && results[i].gender == "M")
                    {
                        if(Shoescb.Checked == true && results[i].type == "Shoes")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (Weddingdresscb.Checked == true && results[i].type == "Wedding Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (BridesmaidDresscb.Checked == true && results[i].type == "Bridesmaid Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (GroomsSuitcb.Checked == true && results[i].type == "Grooms Suit")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);
                        }
                    }
                }


                if (Smallcb.Checked == true && results[i].size == "Small")
                {
                    if (Femalecb.Checked == true && results[i].gender == "F")
                    {
                        if (Shoescb.Checked == true && results[i].type == "Shoes")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (Weddingdresscb.Checked == true && results[i].type == "Wedding Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (BridesmaidDresscb.Checked == true && results[i].type == "Bridesmaid Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (GroomsSuitcb.Checked == true && results[i].type == "Grooms Suit")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }
                    }
                }

                if (Mediumcb.Checked == true && results[i].size == "Medium")
                {
                    if (Malecb.Checked == true && results[i].gender == "M")
                    {

                        if (Shoescb.Checked == true && results[i].type == "Shoes")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (Weddingdresscb.Checked == true && results[i].type == "Wedding Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (BridesmaidDresscb.Checked == true && results[i].type == "Bridesmaid Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (GroomsSuitcb.Checked == true && results[i].type == "Grooms Suit")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }
                    }
                }


                if (Mediumcb.Checked == true && results[i].size == "Medium")
                {
                    if (Femalecb.Checked == true && results[i].gender == "F")
                    {

                        if (Shoescb.Checked == true && results[i].type == "Shoes")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (Weddingdresscb.Checked == true && results[i].type == "Wedding Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (BridesmaidDresscb.Checked == true && results[i].type == "Bridesmaid Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (GroomsSuitcb.Checked == true && results[i].type == "Grooms Suit")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }
                    }
                }

                if (Largecb.Checked == true && results[i].size == "Large")
                {
                    if (Malecb.Checked == true && results[i].gender == "M")
                    {

                        if (Shoescb.Checked == true && results[i].type == "Shoes")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (Weddingdresscb.Checked == true && results[i].type == "Wedding Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (BridesmaidDresscb.Checked == true && results[i].type == "Bridesmaid Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (GroomsSuitcb.Checked == true && results[i].type == "Grooms Suit")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }
                    }
                }


                if (Largecb.Checked == true && results[i].size == "Large")
                {
                    if (Femalecb.Checked == true && results[i].gender == "F")
                    {

                        if (Shoescb.Checked == true && results[i].type == "Shoes")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (Weddingdresscb.Checked == true && results[i].type == "Wedding Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (BridesmaidDresscb.Checked == true && results[i].type == "Bridesmaid Dress")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }

                        if (GroomsSuitcb.Checked == true && results[i].type == "Grooms Suit")
                        {
                            tbl.Rows.Add(results[i].SID, results[i].type, results[i].gender, results[i].size, results[i].condition, results[i].name, results[i].cost, results[i].shoesize, results[i].quantity);

                        }
                    }
                },
                i++;
                }

            BookingfrmDGV.DataSource = tbl;
            results.Clear();

        } 

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            total = 0.00;
            for(int i =0; i < GlobalDetails.Orderitems.Count;i++)
            {
                listBox1.Items.Add(GlobalDetails.Orderitems[i].name);
                total = total + Convert.ToDouble(GlobalDetails.Orderitems[i].cost);
            }
            lblTotal.Text = "£"+total.ToString();
        }

        private void BookingfrmDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to add this to your basket?", "Notification", MessageBoxButtons.YesNo,
              MessageBoxIcon.Information);

            string[] productDetails = { "", "", "", "", ""};

            if (dr == DialogResult.Yes)
            {

                Stock item = new Stock();
                
                foreach(Stock r in results)
                {
                    if(r.SID == Convert.ToInt32(BookingfrmDGV.CurrentRow.Cells[0].Value))
                    {
                        FRMItemAdd iAdd = new FRMItemAdd(r);
                        iAdd.Show();
                    }
                }
            }
        }

        private void SelectAllbtn_Click(object sender, EventArgs e)
        {
            Smallcb.Checked = true;
            Mediumcb.Checked = true;
            Largecb.Checked = true;
            Femalecb.Checked = true;
            Malecb.Checked = true;
            Shoescb.Checked = true;
            Weddingdresscb.Checked = true;
            BridesmaidDresscb.Checked = true;
            GroomsSuitcb.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Smallcb.Checked = true;
            Mediumcb.Checked = true;
            Largecb.Checked = true;
            Femalecb.Checked = true;
            Malecb.Checked = true;
            Shoescb.Checked = true;
            Weddingdresscb.Checked = true;
            BridesmaidDresscb.Checked = true;
            GroomsSuitcb.Checked = true;
        }

        decimal totalCost = 0.0M;

        private void FRMbookingform_Activated(object sender, EventArgs e)
        {

            if (isAdd == true)
            {

                for (int i = 0; i < GlobalDetails.Orderitems.Count; i++)
                {
                    string itemDetailsName = GlobalDetails.Orderitems[i].name;
                    string itemDetailSZ = GlobalDetails.Orderitems[i].size;
                    string itemDetailCost = GlobalDetails.Orderitems[i].cost.ToString();
                    listBox1.Items.Add(itemDetailsName + ", " + itemDetailSZ + ", £" + itemDetailCost);
                    totalCost += GlobalDetails.Orderitems[i].cost;

                }
                    GlobalDetails.Orderitems.Clear(); 
                
            }

            label7.Text = "£" + totalCost.ToString();
            isAdd = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
                listBox1.Items.Clear();
            
        }
    }
}
