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
    public partial class NewCustomer : Form
    {
        private Database db;
        Customer editCustomer;
        public bool isEdit = false;
        public NewCustomer(Database db, Customer editCustomer)
        {
            InitializeComponent();
            this.db = db;
            this.editCustomer = editCustomer;
        }

        private void CreateAccountbtn_Click(object sender, EventArgs e)
        {
            if (isEdit == true)
            {
                updateRecord();
                return;
            }

            Customer temp = new Customer();
            temp.title = TitlecomboBox.Text;
            temp.FN = Fnametxt.Text;
            temp.SN = Lnametxt.Text;
            temp.email = Emailtxt.Text;
            temp.TN = TelNotxt.Text;
            temp.address = AddressTxt.Text;
            if (temp.CustomerErrors.Count > 0)
            {

                string errobox = string.Join(Environment.NewLine, temp.CustomerErrors);
                MessageBox.Show(errobox, "Problem Occured.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Fix thes \n" + temp.CustomerErrors[0]);
            }
            else
            {
                CustomerDBAccess CDBA = new CustomerDBAccess(db);
                CDBA.insertCustomer(temp);
            }

            MessageBox.Show("Customer successfully created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          
        }

        private void updateRecord()
        {
            if (editCustomer.customerID > 0)
            {
                //Check if its edit or insert customer
                List<string> Changes = new List<string>();
                if (Fnametxt.Text != editCustomer.FN)
                {
                    Changes.Add(editCustomer.FN + "has changed to" + Fnametxt.Text);
                }
                else if (Lnametxt.Text != editCustomer.SN)
                {
                    Changes.Add(editCustomer.SN + "has changed to" + Lnametxt.Text);
                }
                else if (Emailtxt.Text != editCustomer.email)
                {
                    Changes.Add(editCustomer.email + "has changed to" + Emailtxt.Text);
                }
                else if (TelNotxt.Text != editCustomer.email)
                {
                    Changes.Add(editCustomer.email + "has changed to" + TelNotxt.Text);
                }
                else if (AddressTxt.Text != editCustomer.email)
                {
                    Changes.Add(editCustomer.email + "has changed to" + AddressTxt.Text);
                }
                string Message = string.Join(Environment.NewLine, Changes);

                DialogResult diResult = MessageBox.Show("Are you sure you want to change the following details:\n" + Message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (diResult == DialogResult.Yes)
                {
                   //update client detils
                    Customer temp = new Customer();
                    temp.customerID = editCustomer.customerID;
                    temp.title = TitlecomboBox.Text;
                    temp.FN = Fnametxt.Text;
                    temp.SN = Lnametxt.Text;
                    temp.email = Emailtxt.Text;
                    temp.TN = TelNotxt.Text;
                    temp.address = AddressTxt.Text;

                    //create DBAccess and run UPDATE SQL
                    CustomerDBAccess CDBA = new CustomerDBAccess(db);
                    CDBA.updateCustomer(temp);
                    MessageBox.Show("Client details have been updated!");
                    this.Hide();
                    MainMenu MM = new MainMenu(db);
                    MM.Show();
                }
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
