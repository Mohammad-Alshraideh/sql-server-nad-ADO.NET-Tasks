using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static SqlConnection connection = new SqlConnection("data source=DESKTOP-TR88135;database=testDB;integrated security=SSPI");

        protected void Page_Load(object sender, EventArgs e)
        {
            
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

           string filename =  Session["filename"].ToString();

      
            SqlCommand command = new SqlCommand($"insert into testTable values('{TextBox1.Text}' , '{TextBox2.Text}' , '{TextBox3.Text}' , '{TextBox4.Text}' , '{TextBox5.Text}' , '{filename}');", connection);
            connection.Open();
            command.ExecuteNonQuery();
            SqlCommand print = new SqlCommand("select * from testTable order by id asc", connection);
        
           
           
            SqlDataReader read = print.ExecuteReader();
            string table = "<table class='table table-stripped'><tr><td>ID</td><td>Name</td><td>Age</td><td>Country</td><td>Phon Number</td><td>Address</td><td>img</td>";
            while(read.Read())
            {
 


                table += 
                    $"<tr>" +
                  $"<td>{read[0]}</td>" +
                  $"<td>{read[1]}</td>" +
                  $"<td>{read[2]}</td>" +
                  $"<td>{read[3]}</td>" +
                  $"<td>{read[4]}</td>" +
                  $"<td>{read[5]}</td>" +
                   $"<td><img style='width:100px' src='{read[6]}'></img></td>" +
                    $"</tr>";
 
            }
            table += "</table>";
            tableContainer.InnerHtml = table;
            connection.Close();

            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
          if(FileUpload1.HasFile)
            {
                Session["filename"] = FileUpload1.FileName;
                string fullPath = Server.MapPath("images") + "\\" + FileUpload1.FileName;
                FileUpload1.SaveAs(fullPath);
            }
        }
    }
}
