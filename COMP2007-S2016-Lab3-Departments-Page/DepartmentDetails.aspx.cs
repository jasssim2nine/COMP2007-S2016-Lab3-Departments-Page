using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// using statements that are required to connect to EF DB
using COMP2007_S2016_Lab3_Departments_Page.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_S2016_Lab3_Departments_Page
{
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Departments.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //use EF connect to database server
            using (DefaultConnection db = new DefaultConnection())
            {
                Department newDepartment = new Department();
                newDepartment.Name = NameTextBox.Text;
                newDepartment.Budget = Convert.ToInt32(BudgetTextBox.Text);

                db.Departments.Add(newDepartment);

                //save our changes
                db.SaveChanges();

                //redirect back to the updated department page
                Response.Redirect("~/Departments.aspx");

            }
        }
    }
}