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
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                // Get the department data
                this.GetDepartments();
            }
        }

        protected void GetDepartments()
        {
            // connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                

                // query the Students Table using EF and LINQ
                var Departments = (from allDepartments in db.Departments
                                select allDepartments);

                // bind the result to the GridView
                DepartmentsGridView.DataSource = Departments.ToList();
                DepartmentsGridView.DataBind();
            }
        }
        /// <summary>
        /// This handler deletes the department using EF 
        /// @Param (object) sender
        /// @Param (GridViewDeleteEventArgs) e
        /// @returns (void)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store the row which is clicked
            int selectedRow = e.RowIndex;

            //get the selected department id using department datakey 
            int DepartmentID = Convert.ToInt32(DepartmentsGridView.DataKeys[selectedRow].Values["DepartmentID"]);
            // using ef to find the selected department 
            using (DefaultConnection db = new DefaultConnection())
            {
                //create object of department class and store the query
                Department deletedDepartment = (from departmentRecords in db.Departments
                                               where departmentRecords.DepartmentID == DepartmentID
                                               select departmentRecords).FirstOrDefault();

                //remove the selected department from the db
                db.Departments.Remove(deletedDepartment);
                // save my changes back to the database
                db.SaveChanges();

                //refresh the grid
                this.GetDepartments();
            }
        }
    }
}