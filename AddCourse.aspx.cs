using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRecordDal;

public partial class AddCourse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
      
        btnHome.Click += (s, a) => Response.Redirect("Default.aspx");


        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");

        if (!IsPostBack)
        {

            topMenu.Items.Add(new ListItem("Add Student Records"));

        }
     
        topMenu.Click += (s, a) => Response.Redirect("AddStudent.aspx");

      

        using (StudentRecordEntities entityContext = new StudentRecordEntities())
        {
            List<Course> courses = entityContext.Courses.ToList<Course>();
            showCourseInfo(courses);
        }
    }

    protected void homeButtonClicked(object s, EventArgs e)
    {
        Response.Redirect("AddStudent.aspx");

    }
    

    protected void ButtonSubmitCourseInformation_Click(object sender, EventArgs e)
    {

        string courseNumber = TextBoxCourseNumber.Text;
 
        string courseName = TextBoxCourseName.Text;

        
        using (StudentRecordEntities entityContext = new StudentRecordEntities())
        {
            Course course = new Course();
            course.Code = courseNumber;
            course.Title = courseName;

         

            var cours = (from c in entityContext.Courses
                          where c.Code == courseNumber
                         select c).FirstOrDefault<Course>();
            if (cours != null)
            {
                LabelErrorMessage.Text = "Course with this code already exist";
            }

            else
            {
                entityContext.Courses.Add(course);
                entityContext.SaveChanges();
                LabelErrorMessage.Text = "";

            }          
        }


        using (StudentRecordEntities entityContext = new StudentRecordEntities())
        {
            List<Course> courses =
               entityContext.Courses.ToList<Course>();
            showCourseInfo(courses);
        }

        
    }

    private void showCourseInfo(List<Course> courses)
    {


        for (int i = TableCourses.Rows.Count - 1; i > 0; i--)
        {
            TableCourses.Rows.RemoveAt(i);
        }


        TableRow firstRow = new TableRow();
        TableCell firstRowCell = new TableCell();
        firstRowCell.Text = "Code";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);

        firstRowCell = new TableCell();
        firstRowCell.Text = "Course Title";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);
        TableCourses.Rows.Add(firstRow);

        if (courses == null || courses.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No Course in the system yet";
            lastRowCell.ForeColor = System.Drawing.Color.Blue;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);

            TableCourses.Rows.Add(lastRow);
        }
        else
        {

            foreach (Course course in courses)
            {

                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = course.Code;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = course.Title;
                row.Cells.Add(cell);

                TableCourses.Rows.Add(row);

            }
        }
    }
}