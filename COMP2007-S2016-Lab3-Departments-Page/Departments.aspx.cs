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
                //create a session variable and stored as default
                Session["SortColumn"] = "DepartmentID";
                Session["SortDirection"] = "ASC";
                // Get the department data
                this.GetDepartments();

            }
        }

        protected void GetDepartments()
        {
            // connect to EF
            using (DefaultConnection db = new DefaultConnection())
            {
                string sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                // query the Students Table using EF and LINQ
                var Departments = (from allDepartments in db.Departments
                                select allDepartments);

                // bind the result to the GridView
                DepartmentsGridView.DataSource = Departments.AsQueryable().OrderBy(sortString).ToList();
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
        /// <summary>
        /// This handler takes care of paging
        /// </summary>
        /// @Param (object) sender
        /// @Param (GridViewPageEventArgs) e
        /// @returns (void)
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DepartmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page number
            DepartmentsGridView.PageIndex = e.NewPageIndex;

            //refresh the grid
            this.GetDepartments();
        }
        /// <summary>
        /// This handler set the no. of records to be displayed
        /// </summary>
        /// @Param (object)
        /// @Param (EventArgs) e
        /// @returns (void)
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the page size
            DepartmentsGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);
            //refresh the grid
            this.GetDepartments();

        }
        /// <summary>
        /// This handler handles sorting
        /// </summary>
        /// @Param (object)
        /// @Param (GridViewSotEventArgs) e
        /// @returns (void)
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DepartmentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //refresh the grid
            this.GetDepartments();

            //create a toggle for the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
        /// <summary>
        /// This method adds the caret to the headers of the table..
        /// </summary>
        /// @Param (object)
        /// @Param (GridViewRowEventArgs) e
        /// @Param (void)
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DepartmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header) // if header row has been clicked
                {
                    LinkButton linkbutton = new LinkButton();

                    for (int index = 0; index < DepartmentsGridView.Columns.Count - 1; index++)
                    {
                        if (DepartmentsGridView.Columns[index].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "ASC")
                            {
                                linkbutton.Text = " <i class='fa fa-caret-up fa-lg'></i>";
                            }
                            else
                            {
                                linkbutton.Text = " <i class='fa fa-caret-down fa-lg'></i>";
                            }

                            e.Row.Cells[index].Controls.Add(linkbutton);
                        }
                    }
                }
            }
        }
      }
   }
 
