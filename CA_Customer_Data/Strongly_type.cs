/*
 Q.use table customer complete following task

1.disply customer data (strongly tpye)
2.accept id from user & delete particular customer
3.create object of the customer & store data in customer table
4.write search method with parameter id
5.write search method with parameter string (Name, mobile)
6.accept id & name from user & update the records
*/
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CA_Customer_Data
{
    internal class Strongly_type
    {
        private string _connectionString;

        public Strongly_type(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }

        public SqlConnection getconnection()
        {
            SqlConnection sqlconn = new SqlConnection();
            sqlconn.ConnectionString = _connectionString;
            return sqlconn;
        }

        public int AddData(Customers c)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            int record = 0;

            try
            {
                sqlconn = getconnection();
                sqlcmd = new SqlCommand("Storedata", sqlconn);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                //sqlcmd.Parameters.Add("@pid", SqlDbType.Int).Value = c.Id;
                sqlcmd.Parameters.Add("@pname", SqlDbType.NVarChar).Value = c.Name;
                sqlcmd.Parameters.AddWithValue("@paddress", SqlDbType.NVarChar).Value = c.Address;
                sqlcmd.Parameters.Add("@pmobilenumber", SqlDbType.NVarChar).Value = c.Mobile_No;
                sqlconn.Open();
                record = sqlcmd.ExecuteNonQuery();
                Console.WriteLine("Rows  Affected = " + record);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlconn.Close();
            }
            return record;
        }

        public void PrintCustomer()
        {
            SqlConnection sqlconn = getconnection();
            SqlCommand sqlcmd = new SqlCommand("Select * From New_Customer_Data", sqlconn);
            sqlconn.Open();

            Console.WriteLine("Connected");

            SqlDataReader reader = sqlcmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3}", reader["Id"], reader["Name"], reader["Address"], reader["Mobile_No"]);
                }
            }

        }

        public Customers SearchCustomerId(int id)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            Customers p = null;

            try
            {
                sqlconn = getconnection();
                sqlconn.Open();
                sqlcmd = new SqlCommand("select * from New_Customer_Data where id=@pid", sqlconn);
                sqlcmd.Parameters.AddWithValue("@pid", id);
                SqlDataReader rdr = sqlcmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        p = new Customers();
                        p.Id = Convert.ToInt32(rdr["Id"]);
                        p.Name = rdr["Name"].ToString();
                        p.Address = rdr["Address"].ToString();
                        p.Mobile_No = rdr["Mobile_No"].ToString();
                        break;
                    }
                }
            }

            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return p;
        }

        public List<Customers> SearchCustomerName(String name)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            List<Customers> pl = null;

            try
            {
                sqlconn = getconnection();
                sqlconn.Open();
                sqlcmd = new SqlCommand("select * from New_Customer_Data where name=@pid", sqlconn);
                sqlcmd.Parameters.AddWithValue("@pid", name);
                SqlDataReader rdr = sqlcmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    pl = new List<Customers>();
                    while (rdr.Read())
                    {
                        Customers p = new Customers();
                        p.Id = Convert.ToInt32(rdr["Id"]);
                        p.Name = rdr["Name"].ToString();
                        p.Address = rdr["Address"].ToString();
                        p.Mobile_No = rdr["Mobile_No"].ToString();
                        pl.Add(p);
                    }
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);
            }
            finally
            {
                sqlconn.Close();
            }

            return pl;
        }

        public int DelCustomer(int id)
        {
            SqlConnection sqlconn = null;
            SqlCommand sqlcmd;
            int no = 0;

            using (sqlconn = getconnection())
            {
                try
                {
                    sqlconn.Open();
                    sqlcmd = new SqlCommand("delete from New_Customer_Data where id = @pid", sqlconn);
                    sqlcmd.Parameters.AddWithValue("@pid", id);
                    no = sqlcmd.ExecuteNonQuery();
                }
                catch (SqlException se) 
                {
                    Console.WriteLine(se.Message);  
                }
                return no;

            }
        }

        public List<Customers> GetCustomers() 
        {
            var cl = new List<Customers>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("ShowList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        cl.Add(new Customers() 
                        {
                            Id = rdr.GetInt32("Id"),
                            Name = rdr.GetString("Name"),
                            Address = rdr.GetString("Address"),
                            Mobile_No = rdr.GetString("Mobile_No")
                        });
                    }
                }
            }
            catch (Exception ex) 
            {
                throw ex; 
            }

            return cl;
        }
    }
}

  