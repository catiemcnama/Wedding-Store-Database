using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Simpsons.DBtables;
using System.Windows.Forms;

namespace Simpsons.DBAccesss
{
    public class CustomerDBAccess
    {
        private Database DB;

        public CustomerDBAccess( Database DB)
        {
            this.DB = DB;    
        }

        public void insertCustomer(Customer temp)
        {
            DB.Cmd = DB.Con.CreateCommand();
            DB.Cmd.CommandText = "INSERT INTO CustomerTBL (Title, FirstName, Surname, TelNo, Email, Address)" + "VALUES('" + temp.title + "', '" + temp.FN + "', '" + temp.SN + "', '" + temp.TN + "', '" + temp.email + "', '" + temp.address + "')";
            DB.Cmd.ExecuteNonQuery();
        }

        public void deleteCustomer(Customer temp)
        {
            DB.Cmd = DB.Con.CreateCommand();
            DB.Cmd.CommandText = "DELETE CustomerTBL where FirstName = '" + temp.FN + "'";
            DB.Cmd.ExecuteNonQuery();
            MessageBox.Show("Customer successfully deleted.", "Success", MessageBoxButtons.OK , MessageBoxIcon.Information);
        }
        public void updateCustomer(Customer temp)
        {
            DB.Cmd = DB.Con.CreateCommand();
            DB.Cmd.CommandText = "UPDATE CustomerTBL SET Title='" + temp.title + "', FirstName='" + temp.FN + "', Surname='" + temp.SN + "', TelNo='" + temp.TN + "', Email='" + temp.email + "', Address='" + temp.address + "' WHERE CustomerID =" + temp.customerID;
            DB.Cmd.ExecuteNonQuery();
        }
        public Customer getCustomerbyID(int id)
        {
            Customer newCustomer = new Customer();
            DB.Cmd = DB.Con.CreateCommand();
            DB.Cmd.CommandText = "SELECT * FROM CustomerTBL WHERE CustomerID = " + id ;
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                newCustomer = getCustomerFromReader(DB.Rdr);
            }
            DB.Rdr.Close();
            return newCustomer;
        }

        public Customer getCustomerbyFirstName(string name)
        {
            Customer newCustomer = new Customer();
            DB.Cmd = DB.Con.CreateCommand();
            DB.Cmd.CommandText = "SELECT * FROM CustomerTBL WHERE FirstName = '" + name + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();

            while (DB.Rdr.Read())
            {
                newCustomer = getCustomerFromReader(DB.Rdr);
            }
            DB.Rdr.Close();
            return newCustomer;
        }
        public Customer getCustomerFromReader(SqlDataReader reader)
        {
            Customer newCustomer = new Customer();
            newCustomer.customerID = reader.GetInt32(0);
            newCustomer.title = reader.GetString(1);
            newCustomer.FN = reader.GetString(2);
            newCustomer.SN = reader.GetString(3);
            newCustomer.TN = reader.GetString(4);
            newCustomer.email = reader.GetString(5);
            newCustomer.address = reader.GetString(6);
            return newCustomer;
        }
    }
}
