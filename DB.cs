using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Rental_Assignment
{
    public class DB
    {
        private SqlConnection DB_Conection  = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataReader Data_Reader;
        private SqlDataAdapter da = new SqlDataAdapter();
        string QueryString;
        public string ConnString = @"Data Source=DESKTOP-49FNQNG;Initial Catalog=VideoRental_SQL;Integrated Security=True";
       
        public int CustomerID, MoviesID, Rental_ID;
        public DB()
        {
            string ConnString = @"Data Source=DESKTOP-49FNQNG;Initial Catalog=VideoRental_SQL;Integrated Security=True";
            DB_Conection .ConnectionString = ConnString;
        }

        
        //code to insert new costomer
        public string CustomerInsert(string FName, string LName, string Phone, string Address)
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;
                QueryString = "Insert into Customer(FirstName,LastName,Address,Phone) Values(@FirstName,@LastName,@Address, @Phone)";
                Command.Parameters.AddWithValue("@FirstName", FName);
                Command.Parameters.AddWithValue("@LastName", LName);
                Command.Parameters.AddWithValue("@Address", Address);
                Command.Parameters.AddWithValue("@Phone", Phone);
                Command.CommandText = QueryString;

                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "Customer Data Inserted Successfully";
            }
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }
        }

        //code to update customer
        public string CustomerUpdate(string firstname, string lastname, string Phone, string Address)
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;
                QueryString = "update Customer set FirstName = @FirstName,LastName = @LastName,Address = @Address, Phone = @Phone where CustID =@CustID";
                Command.Parameters.AddWithValue("@FirstName", firstname);
                Command.Parameters.AddWithValue("@LastName", lastname);
                Command.Parameters.AddWithValue("@Address", Address);
                Command.Parameters.AddWithValue("@Phone", Phone);
                Command.Parameters.AddWithValue("@CustID", CustomerID);
                Command.CommandText = QueryString;
                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "Customer Data Updated Successfully";
            }
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }
        }

        //code to delete customer
        public string CustomerDelete()
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;

                Command.CommandText = "Customer_Delete";
                //Command.CommandType = CommandType.StoredProcedure;

                QueryString = "Delete from Customer where CustID =@CustID";
                Command.Parameters.AddWithValue("@CustID", CustomerID);
                Command.CommandText = QueryString;
                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "Customer Data Deleted Successfully";
            }
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }

        }

        //code to insert movie
        public string MoviesInsert(string rating, string Title, string year, string Rental_Cost, string copies, string plot, string genre)
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;
                QueryString = "Insert into Movies(Title,rating,year,Rental_Cost,copies,plot,genre) Values(@Title,@Rating, @Year,@Rental_cost,@Copies,@Plot,@Genre)";
                Command.Parameters.AddWithValue("@Rating", rating);
                Command.Parameters.AddWithValue("@Title", Title);
                Command.Parameters.AddWithValue("@Year", year);
                Command.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                Command.Parameters.AddWithValue("@Copies", copies);
                Command.Parameters.AddWithValue("@Plot", plot);
                Command.Parameters.AddWithValue("@Genre", genre);
                Command.CommandText = QueryString;

                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "New Movie added Inserted Successfully";
            }
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }
        }

        //code to update movie
        public string updatemovie(string rating, string Title, string year, string Rental_Cost, string copies, string plot, string genre)
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;
                QueryString = "update movies set rating = @rating,title = @title,year = @year, rental_cost = @rental_cost, copies= @copies, plot= @plot, genre= @genre where MovieID =@MovieID";
                Command.Parameters.AddWithValue("@rating", rating);
                Command.Parameters.AddWithValue("@title", Title);
                Command.Parameters.AddWithValue("@year", year);
                Command.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                Command.Parameters.AddWithValue("@Copies", copies);
                Command.Parameters.AddWithValue("@Plot", plot);
                Command.Parameters.AddWithValue("@Genre", genre);
                Command.Parameters.AddWithValue("@MovieID", MoviesID);
                Command.CommandText = QueryString;
                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "Movie data Updated Successfully";
            }
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }
        }

        //code to movie delete
        public string MoviesDelete()
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;
                QueryString = "Delete from Movies where MovieID =@MovieID";
                Command.Parameters.AddWithValue("@MovieID", MoviesID);
                Command.CommandText = QueryString;
                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "Movie Deleted";
            }
            catch (Exception ex)
            {
                // show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }
        }


        //code to view all rented movies
        public DataTable Rental_Load()
        {
            DataTable dt = new DataTable();
            QueryString = "select * From All_Rented_view";
            using (da = new SqlDataAdapter(QueryString, DB_Conection ))
            {
                DB_Conection .Open();
                da.Fill(dt);
                DB_Conection .Close();
            }
            return dt;
        }

        //code to show all rented out movies
        public DataTable FillAll_Rented_out()
        {
            DataTable dt = new DataTable();
            QueryString = "select * From All_Rented_out";
            using (da = new SqlDataAdapter(QueryString, DB_Conection ))
            {
                DB_Conection .Open();
                da.Fill(dt);
                DB_Conection .Close();
            }
            return dt;
        }

        //code to issue new movie to customer

        public string IssueMovie(DateTime Issue_date)
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;
                QueryString = "Insert into RentedMovies(MovieIDFK,CustIDFK,DateRented,DateReturned) values(@MovieID,@CustID,@Issue_date,Null)";
                Command.Parameters.AddWithValue("@CustID", CustomerID);
                Command.Parameters.AddWithValue("@MovieID", MoviesID);
                Command.Parameters.AddWithValue("@Issue_date", Issue_date);
                Command.CommandText = QueryString;
                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "Movies issued to customer";
            }
            catch (Exception ex)
            {
                // code to show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }
        }

        //code to return movie from customer

        public string ReturnMovie(DateTime Return_date)
        {
            try
            {
                Command.Parameters.Clear();
                Command.Connection = DB_Conection ;
                QueryString = "Update RentedMovies set DateReturned=@Return_date where RMID = @RMID";
                Command.Parameters.AddWithValue("@Return_date", Return_date);
                Command.Parameters.AddWithValue("@RMID", Rental_ID);
                Command.CommandText = QueryString;
                //connection opened
                DB_Conection .Open();
                // Executed query
                Command.ExecuteNonQuery();
                return "Movies returned from customer";
            }
            catch (Exception ex)
            {
                // code to show error Message
                return ex.Message;
            }
            finally
            {
                // close connection
                if (DB_Conection  != null)
                {
                    DB_Conection .Close();
                }
            }
        }

        //code to define popular customer

        public DataTable FillPopular_customer_Data()
        {
            DataTable dt = new DataTable();
            QueryString = "select * From Popular_customer";
            using (da = new SqlDataAdapter(QueryString, DB_Conection ))
            {
                DB_Conection .Open();
                da.Fill(dt);
                DB_Conection .Close();
            }
            return dt;
        }


        //code to define popular movie
        public DataTable FillPopular_movie_Data()
        {
            DataTable dt = new DataTable();
            QueryString = "select * From Popular_movie";
            using (da = new SqlDataAdapter(QueryString, DB_Conection ))
            {
                DB_Conection .Open();
                da.Fill(dt);
                DB_Conection .Close();
            }
            return dt;
        }
    }   






        
    
 }          






    









