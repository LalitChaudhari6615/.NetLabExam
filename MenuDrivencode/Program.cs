using Microsoft.Data.SqlClient;
using System.Data;

namespace MenuDrivenDatabaseProgram
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Update");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. View Data");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Update();
                        break;
                    case "2":
                        Delete();
                        break;
                    case "3":
                        DataReader();
                        break;                    
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }
     
        static void Update()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Module;
            Integrated Security=True";
            cn.Open();

            try
            {
                Console.Write("Enter the Student rollno ID to update: ");
                int Rollno = int.Parse(Console.ReadLine());

                Console.Write("Enter the new Name: ");
                string newName = Console.ReadLine();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE students SET name = @NewName WHERE rollno = @Rollno";
                cmd.Parameters.AddWithValue("@NewName", newName);
                cmd.Parameters.AddWithValue("@Rollno", Rollno);


                Console.WriteLine(cmd.ExecuteNonQuery());


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void Delete()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Module;
              Integrated Security=True";
            cn.Open();

            try
            {
                Console.Write("Enter the student rollno to delete: ");
                int Rollno = int.Parse(Console.ReadLine());

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM students WHERE rollno = @Rollno";
                cmd.Parameters.AddWithValue("@Rollno", Rollno);


                Console.WriteLine(cmd.ExecuteNonQuery());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
        static void DataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Module;
           Integrated Security=True";
            cn.Open();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from students";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    Console.Write(dr["rollno"] + " ");
                    Console.Write(dr["name"] + " ");
                    Console.Write(dr["marks"] + " ");
                   
                    Console.WriteLine();
                }
                dr.Close();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }

    class Students
    {
        public string name { get; set; }
        public int rollno { get; set; }
        public int marks { get; set; }     
    }
}