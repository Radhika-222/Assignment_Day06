using System;
using System.Data;
using System.Data.SqlClient;


namespace Assignment_Day06
{
    
    internal class Program
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataReader reader;
        static string constr = "server=DESKTOP-KT3OE9D;database=ProductInventoryDb;trusted_connection=true;";

        static void Main(string[] args)
        {
            string choice;
            do
            {
                Console.WriteLine("Choose Operation");
                Console.WriteLine("1.Select all record from Product table\n 2.Insert into Products table\n 3.Update Product Table\n  4.Delete from Products table\n");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "select * from Products"
                                };
                                con.Open();
                                reader = cmd.ExecuteReader();
                                Console.WriteLine("PId \t  PName \t  Price \t Quantity \t  MfDate \t   ExpDate");
                                while (reader.Read())
                                {
                                    Console.Write(reader[0] + "\t ");
                                    Console.Write(reader[1] + "\t \t  ");
                                    Console.Write(reader[2] + "\t ");
                                    Console.Write(reader[3] + "\t ");
                                    Console.Write(reader[4] + "\t ");
                                    Console.Write(reader[5]);
                                    Console.Write("\n");

                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.ReadKey();
                            }
                            break;
                        }



                    case 2:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "insert into Products(PId,PName,Price,Quantity,MfDate,ExpDate) values(@id,@pname,@price,@quantity,@mfdate,@expdate)"
                                };
                                Console.WriteLine("Enter Product Id:");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));
                                Console.WriteLine("Enter Product Name");
                                cmd.Parameters.AddWithValue("@pname", Console.ReadLine());
                                Console.WriteLine("Enter price Name");
                                cmd.Parameters.AddWithValue("@price", Console.ReadLine());
                                Console.WriteLine("Enter Quantity");
                                cmd.Parameters.AddWithValue("@quantity", Console.ReadLine());

                                Console.WriteLine("Enter manufacuring date");
                                cmd.Parameters.AddWithValue("@mfdate", Console.ReadLine());
                                Console.WriteLine("Enter Expiry date");
                                cmd.Parameters.AddWithValue("@expdate", Console.ReadLine());
                                con.Open();
                                cmd.ExecuteNonQuery();
                                Console.WriteLine("Record Insertion was successful!!!!");


                            }
                            catch (SqlException se)
                            {
                                Console.WriteLine("Server Error!!!" + se.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("End of program");
                                Console.ReadKey();
                            }
                            break;
                        }



                    case 3:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "update products set pname=@pname,price=@price,quantity=@quantity,mfdate=@mfdate,expdate=@expdate where pid=@id"
                                };
                                Console.WriteLine("enter product id to update the record:");
                                int id = int.Parse(Console.ReadLine());
                                cmd.Parameters.AddWithValue("@id", id);
                                Console.WriteLine("enter product new name");
                                cmd.Parameters.AddWithValue("@pname", Console.ReadLine());
                                Console.WriteLine("enter product new price");
                                cmd.Parameters.AddWithValue("@price", Console.ReadLine());
                                Console.WriteLine("enter product new quantity");
                                cmd.Parameters.AddWithValue("@quantity", Console.ReadLine());
                                Console.WriteLine("enter product new mfdate");
                                cmd.Parameters.AddWithValue("@mfdate", Console.ReadLine());
                                Console.WriteLine("enter product new expdate");
                                cmd.Parameters.AddWithValue("@expdate", Console.ReadLine());
                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine($"record update was successful for id {id} !!!!");


                                }
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("end of program");
                               Console.ReadKey();
                            }
                            break;
                        }



                    case 4:
                        {
                            try
                            {
                                con = new SqlConnection(constr);
                                cmd = new SqlCommand
                                {
                                    Connection = con,
                                    CommandText = "Delete from Products where PId=@id"
                                };
                                Console.WriteLine("Enter Product Id:");
                                cmd.Parameters.AddWithValue("@id", int.Parse(Console.ReadLine()));

                                con.Open();
                                int noe = cmd.ExecuteNonQuery();
                                if (noe > 0)
                                {
                                    Console.WriteLine("Deletion was Successful!!!!");
                                }
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine("Error!!!" + ex.Message);
                            }
                            finally
                            {
                                con.Close();
                                Console.WriteLine("End of program");
                                Console.ReadKey();
                            }
                            break;
                        }
                }
                Console.WriteLine("Do you wanna continue press ....y");
                choice = Console.ReadLine();
            } while (choice == "y");

        }
    }
    }



