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
            if((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetDepartments();   
            }
        }

        protected void GetDepartments()
        {
            //populate the form  with existing data
            int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            //connect to db
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate department object instance with the DepartmentID from the url
                Department updatedDepartment = (from deparment in db.Departments
                                                where deparment.DepartmentID == DepartmentID
                                                select deparment).FirstOrDefault();
                // map the departments data...
                if(updatedDepartment != null)
                {
                    NameTextBox.Text = updatedDepartment.Name;
                    BudgetTextBox.Text = updatedDepartment.Budget.ToString();

                }

            }
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

                int DepartmentID = 0;

                if(Request.QueryString.Count > 0)
                {
                    //get the id from the url
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                    //get the current department from the EF
                    newDepartment = (from department in db.Departments
                                     where department.DepartmentID == DepartmentID
                                     select department).FirstOrDefault();

                }

                //add form data to new department record...
                newDepartment.Name = NameTextBox.Text;
                newDepartment.Budget = Convert.ToDecimal(BudgetTextBox.Text);

                //
                if(DepartmentID==0)
                {
                    db.Departments.Add(newDepartment);
                }
                



                //save our changes & update & inserts.
                db.SaveChanges();

                //redirect back to the updated department page
                Response.Redirect("~/Departments.aspx");

            }
        }
    }
}