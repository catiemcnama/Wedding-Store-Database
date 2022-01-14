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
    public class StockDBAccess
    {
        private Database DB;

        public StockDBAccess(Database DB)
        {
            this.DB = DB;
        }
        public List<Stock> getStock()
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Condition ='New'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }

        public List<Stock> getStock(string Type)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='"+Type+"'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }
        public List<Stock> getStock(string Type, string Gender)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='" + Type + "' AND Gender = '"+ Gender + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }
        public List<Stock> getStock(string Type, string Gender, string size)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='" + Type + "' AND Gender = '" + Gender + "' AND Size = '" + size + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }
        public List<Stock> getStock(string Type, string Gender, string size, string condition)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='" + Type + "' AND Gender = '" + Gender + "' AND Size = '" + size + "' AND Condition = '" + condition + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }
        public List<Stock> getStock(string Type, string Gender, string size, string condition, string Name)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='" + Type + "' AND Gender = '" + Gender + "' AND Size = '" + size + "' AND Condition = '" + condition + "' AND Name = '" + Name + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }
        public List<Stock> getStock(string Type, string Gender, string size, string condition, string Name, double Cost)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='" + Type + "' AND Gender = '" + Gender + "' AND Size = '" + size + "' AND Condition = '" + condition + "' AND Name = '" + Name + "' AND Cost = '" + Cost + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }
        public List<Stock> getStock(string Type, string Gender, string size, string condition, string Name, double Cost, int Shoesize)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='" + Type + "' AND Gender = '" + Gender + "' AND Size = '" + size + "' AND Condition = '" + condition + "' AND Name = '" + Name + "' AND Cost = '" + Cost + "' AND Shoesize = '" + Shoesize + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }

        public List<Stock> getStock(string Type, string Gender, string size, string condition, string Name, double Cost, int Shoesize, int Quantity)
        {
            List<Stock> stockList = new List<Stock>();
            Stock Item = new Stock();
            DB.Cmd.CommandText = "SELECT * FROM StockTBL WHERE Type ='" + Type + "' AND Gender = '" + Gender + "' AND Size = '" + size + "' AND Condition = '" + condition + "' AND Name = '" + Name + "' AND Cost = '" + Cost + "' AND Shoesize = '" + Shoesize + "' AND Quantity = '" + Quantity + "'";
            DB.Rdr = DB.Cmd.ExecuteReader();
            while (DB.Rdr.Read())
            {
                Item = getStockFromReader(DB.Rdr);
                stockList.Add(Item);
            }
            DB.Rdr.Close();
            return stockList;
        }
       
        public Stock getStockFromReader(SqlDataReader reader)
        {
            Stock Item = new Stock();
            Item.SID = reader.GetInt32(0);
            Item.type = reader.GetString(1);
            Item.gender = reader.GetString(2);
            Item.size = reader.GetString(3);
            Item.condition = reader.GetString(4);
            Item.name = reader.GetString(5);
            Item.cost = reader.GetDecimal(6);
            Item.shoesize = reader.GetInt32(7);
            Item.quantity = reader.GetInt32(8);
            return Item;
        }
    }
}
