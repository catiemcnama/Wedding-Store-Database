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
    public partial class FRMsearch : Form
    {
        Database db = new Database();
        CustomerDBAccess CDBA;
        List<Customer> Results = new List<Customer>();
        Customer temp = new Customer();
        public FRMsearch(Database db)
        {
            this.db = db;
            CDBA = new CustomerDBAccess(db);
            InitializeComponent();
        }

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            //once Searchbtn is clicked we run through a switch to see what has been selected in the combobox to determine how we will search
            switch (Searchcb.SelectedIndex)
            {
                case 0:
                    try
                    {
                        int id = Convert.ToInt32(textBox1.Text);
                        temp = CDBA.getCustomerbyID(id);
                        Results.Clear();
                        Results.Add(temp);
                        displayCustomer(Results);
                        break;

                    }
                    catch { }
                    break;

                case 1:
                    try
                    {
                        string FN = textBox1.Text;
                        temp = CDBA.getCustomerbyFirstName(FN);
                        Results.Clear();
                        Results.Add(temp);
                        displayCustomer(Results);
                        break;
                    }
                    catch { }
                    break;
            }
        }
        public void displayCustomer(List<Customer> CustomerResults)
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("CustomerID");
            tbl.Columns.Add("Title");
            tbl.Columns.Add("First Name");
            tbl.Columns.Add("Surname");
            tbl.Columns.Add("Telephone Number");
            tbl.Columns.Add("email");
            tbl.Columns.Add("Address");
            this.DGVSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (Customer cust in CustomerResults)
            {
                tbl.Rows.Add(cust.customerID, cust.title, cust.FN, cust.SN, cust.TN, cust.email, cust.address);
            }
            DGVSearch.DataSource = tbl;
        }

        private void FRMsearch_Load(object sender, EventArgs e)
        {
            Searchcb.Text = "Search by ID";
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            NewCustomer ecust = new NewCustomer(db, temp);
            ecust.isEdit = true;
            this.Hide();
            ecust.Show();
        }
        
        private void Deletebtn_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?", "Notification", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Customer temp = new Customer();
                temp.FN = DGVSearch.CurrentRow.Cells[2].Value.ToString();
                CDBA.deleteCustomer(temp);

                DGVSearch.Rows.RemoveAt(DGVSearch.CurrentCell.RowIndex);


                DGVSearch.Update();
                DGVSearch.Refresh();
            }
        }

        private void makeorderbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            
            FRMbookingform bf = new FRMbookingform(db, temp);
            bf.Show();
        }

        private void DGVSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Deletebtn.Enabled = true;
                makeorderbtn.Enabled = true;

                Selectedtitlelbl.Text = DGVSearch.CurrentRow.Cells[1].Value.ToString();
                selectedNamelbl.Text = DGVSearch.CurrentRow.Cells[2].Value.ToString();
                selectedLNamelbl.Text = DGVSearch.CurrentRow.Cells[3].Value.ToString();
                selectedemaillbl.Text = DGVSearch.CurrentRow.Cells[4].Value.ToString();
                SelectedTNlbl.Text = DGVSearch.CurrentRow.Cells[5].Value.ToString();
                SelectedAddresslbl.Text = DGVSearch.CurrentRow.Cells[6].Value.ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Please click on a search result.");
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Rentbtn_Click(object sender, EventArgs e)
        {
            this.Close();

            FRMRental RF = new FRMRental(db, temp);
            RF.Show();

        }
    }
}
