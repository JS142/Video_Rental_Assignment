using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Rental_Assignment
{
    public class DataGridClass
    {
        private SqlConnection DB_Conection = new SqlConnection();
        private SqlCommand Cmd = new SqlCommand();
        private SqlDataReader Data_Reader;
        private SqlDataAdapter da = new SqlDataAdapter();
        string QueryString;
        public string ConnString = @"Data Source=DESKTOP-49FNQNG;Initial Catalog=VideoRental_SQL;Integrated Security=True";

        public DataGridClass()
        {
            string ConnString = @"Data Source=DESKTOP-49FNQNG;Initial Catalog=VideoRental_SQL;Integrated Security=True";
            DB_Conection.ConnectionString = ConnString;
        }
        //code to fill customer data in DGV from database

        public DataTable FillCustomer_Data()
        {
            DataTable table = new DataTable();
            QueryString = "select * From Customer";
            using (da = new SqlDataAdapter(QueryString, DB_Conection))
            {
                DB_Conection.Open();
                da.Fill(table);
                DB_Conection.Close();
            }
            return table;
        }

        //code to fill movie data in DGV from database
        public DataTable FillMovies_Data()
        {
            DataTable table = new DataTable();
            QueryString = "select * From Movies";
            using (da = new SqlDataAdapter(QueryString, DB_Conection))
            {
                DB_Conection.Open();
                da.Fill(table);
                DB_Conection.Close();
            }
            return table;
        }

        //code to fill rental datain DGV from database
        public DataTable FillRental_Data()
        {
            DataTable table = new DataTable();
            QueryString = "select * From All_Rented_view";
            using (da = new SqlDataAdapter(QueryString, DB_Conection))
            {
                DB_Conection.Open();
                da.Fill(table);
                DB_Conection.Close();
            }
            return table;
        }

    }
}
