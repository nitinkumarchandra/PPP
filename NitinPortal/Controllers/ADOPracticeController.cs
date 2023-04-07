using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace NitinPortal.Controllers
{
    public class ADOPracticeController : Controller
    {
        public IActionResult Index()
        {
            CreateTable();
            return View();
        }

        public void CreateTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-94NN4I6;Initial Catalog=NitinPortal;Integrated Security=True;TrustServerCertificate=True;");
                SqlCommand cm = new SqlCommand("Create Table ADOPractice(Id int Primary key identity(1,1) not null, Name varchar(100), Email varchar(50), [Join Date] varchar(100))", con);

                con.Open();
                cm.ExecuteNonQuery();

                TempData["success"] = "Table created Successfully";
            }
            catch (Exception e)
            {
                TempData["successnot"] = "OOPs, something went wrong." + e;
            }
            finally
            {
                con.Close();
            }
        }

        public void update()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("Data Source=DESKTOP-94NN4I6;Initial Catalog=NitinPortal;Integrated Security=True;TrustServerCertificate=True;");
                SqlCommand updated = new SqlCommand("alter table ADOPractice add Address varchar(200)", con);
                con.Open();
                updated.ExecuteNonQuery();

                TempData["success"] = "Table Updated Successfully";


            }
            catch (Exception e)
            {
                TempData["successnot"] = "OOPs, something went wrong." + e;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
