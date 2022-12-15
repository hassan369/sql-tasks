using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source=  DESKTOP-HIMQ0KV\\SQLEXPRESS; database=upload; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand("Select * from costmer", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                // Iterating Data  
                string table = "<table class=\"auto-style1\" id=\"table1\" runat=\"server\"><tr><td>image</td><td>name</td><td>age</td></tr>";

                while (sdr.Read())
                {
                    table += $"<tr><td><img class=\"img\" src=\"{sdr[3]}\" ID=\"Image1\" runat=\"server\" /></td><td>{sdr[1]}</td><td>{sdr[2]}</td></tr>";
                }

                table += "</table>";
                Label4.Text = table;
            }
            catch (Exception S)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + S);
                Label1.Text = "OOPs, something went wrong.\n" + S;
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }


        }


        public void uploadToDatabase(string srcP)
        {

            SqlConnection con = null;
            try
            {
                // Creating Connection  
                con = new SqlConnection("data source = DESKTOP-HIMQ0KV\\SQLEXPRESS; database=upload; integrated security=SSPI");
                // writing sql query  
                SqlCommand cm = new SqlCommand("insert into costmer  ( name, age, srcPath)values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + "Images/" + Path.GetFileName(FileUpload1.FileName) + "')", con);
                // Opening Connection  
                con.Open();
                // Executing the SQL query  
                cm.ExecuteNonQuery();
                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");
                Label1.Text = "Record Inserted Successfully";
            }
            catch (Exception A)
            {
                Console.WriteLine("OOPs, something went wrong." + A);
                Label1.Text = "OOPs, something went wrong." + A;
            }
            // Closing the connection  
            finally
            {
                con.Close();
            }
        }



        protected void UploadFile(object sender, EventArgs e)
        {



            
            try
            {
                string folderPath = Server.MapPath("~/Images/");

                //Check whether Directory (Folder) exists.
                if (!Directory.Exists(folderPath))
                {
                    //If Directory (Folder) does not exists Create it.
                    Directory.CreateDirectory(folderPath);
                }
                
                //Save the File to the Directory (Folder).
                string fullPath = folderPath + Path.GetFileName(FileUpload1.FileName);
                string srcPath = "/Images/" + Path.GetFileName(FileUpload1.FileName);

                FileUpload1.SaveAs(fullPath);
                Image1.ImageUrl = srcPath;


                uploadToDatabase(srcPath);




                //Display the Picture in Image control.
                //Image1.ImageUrl = "~/Files/" + Path.GetFileName(FileUpload1.FileName);
                //SqlConnection cc = new SqlConnection("data source = DESKTOP-V50HPE1\\SQLEXPRESS; database = batool ; integrated security=SSPI");

                ////SqlCommand comand = new SqlCommand("select * from name_and_password", cc);
                //cc.Open();
                //string query = "insert into name_and_password (name,password) values ('" + TextBox1.Text + "','" + "Files/" + Path.GetFileName(FileUpload1.FileName) + "') ";
                //SqlCommand cmd = new SqlCommand(query, cc);
                //cmd.ExecuteNonQuery();
                //cc.Close();
            }
            catch (SqlException q)
            {
                Response.Write(q.Message);
            }

        }



    }
}