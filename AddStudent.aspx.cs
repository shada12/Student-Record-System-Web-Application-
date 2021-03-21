using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentRecordDal;

public partial class AddStudent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");

        btnHome.Click += (s, a) => Response.Redirect("Default.aspx");


        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");

        if (!IsPostBack)
        {

            topMenu.Items.Add(new ListItem("Add Courses"));

        }
      
        topMenu.Click += (s, a) => Response.Redirect("AddCourse.aspx");
        if (!IsPostBack)
        {
            using (StudentRecordEntities entityContext = new StudentRecordEntities())
            {
                List<Course> courses = entityContext.Courses.ToList<Course>();
             

                foreach (Course course in courses)
                {
                    ListItem item = new ListItem(course.Code + "-" + course.Title, course.Code);

                    DropDownListCourses.Items.Add(item);

                }

            }
        }
    }

    protected void homeButtonClicked(object s, EventArgs e)
    {
        Response.Redirect("AddCourse.aspx");

    }


    protected void DropDownListCourses_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (DropDownListCourses.SelectedValue != "-1")
        {
            string selectedCourseID = DropDownListCourses.SelectedValue;
            using (StudentRecordEntities entityContext = new StudentRecordEntities())
            {

                var studentsInSelectedCourse = (from a in entityContext.AcademicRecords
                                                where a.CourseCode == selectedCourseID
                                                select a).ToList<AcademicRecord>();


                showCourseInfo(studentsInSelectedCourse);

            }

        }
    }


    protected void ButtonAddToCourse_Click(object sender, EventArgs e)
    {

        if (DropDownListCourses.SelectedValue != "-1")
        {
            string selectedCourseID = DropDownListCourses.SelectedValue;

            string studentNumber = TextBoxStudentNumber.Text;
            string studentName = TextBoxStudentName.Text;
            int studentGrade = Convert.ToInt32(TextBoxGrade.Text);

            using (StudentRecordEntities entityContext = new StudentRecordEntities())
            {

                var course = (from c in entityContext.Courses
                              where c.Code == selectedCourseID
                              select c).FirstOrDefault<Course>();


                Student student = new Student();

                AcademicRecord academicRecord = new AcademicRecord();

                student.Id = studentNumber;
                student.Name = studentName;

                academicRecord.Grade = studentGrade;
                academicRecord.StudentId = studentNumber;
                academicRecord.CourseCode = course.Code;

               // academicRecord.Course = course;

                var CheckStudent = (from s in entityContext.Students
                                    where s.Id == studentNumber
                                    select s).FirstOrDefault<Student>();

                if (CheckStudent != null)
                {
                    LabelErrorMessage.Text = "Student with this ID already exist in Student table";
                }
                else
                {

                    academicRecord.Course = course;
                    academicRecord.Student = student;

                    entityContext.Students.Add(student);

                    entityContext.SaveChanges();
                    LabelErrorMessage.Text = "";
                }


                course.AcademicRecords.Add(academicRecord);//

                var academicRecrd = (from a in entityContext.AcademicRecords
                                     where a.StudentId == studentNumber && a.CourseCode == course.Code
                                     select a).FirstOrDefault<AcademicRecord>();
                if (academicRecrd != null)
                {
                    LabelErrorMessage.Text = "The system already has a record of this student for the selected course";
                }
                else
                {

                    entityContext.AcademicRecords.Add(academicRecord);
                    entityContext.SaveChanges();
                    LabelErrorMessage.Text = "";
                }

                using (StudentRecordEntities studentsCourse = new StudentRecordEntities())
                {

                    var studentsInSelectedCourse = (from a in entityContext.AcademicRecords
                                                    where a.CourseCode == selectedCourseID
                                                    select a).ToList<AcademicRecord>();


                    showCourseInfo(studentsInSelectedCourse);

                }
            }
        }
    }

    private void showCourseInfo(List<AcademicRecord> academicRecords)
    {

        for (int i = TableStudents.Rows.Count - 1; i > 0; i--)
        {
            TableStudents.Rows.RemoveAt(i);
        }


        TableRow firstRow = new TableRow();
        TableCell firstRowCell = new TableCell();
        firstRowCell.Text = "ID";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);

        firstRowCell = new TableCell();
        firstRowCell.Text = "Name";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);
        TableStudents.Rows.Add(firstRow);

        firstRowCell = new TableCell();
        firstRowCell.Text = "Grade";
        firstRowCell.BackColor = System.Drawing.Color.SkyBlue;
        firstRow.Cells.Add(firstRowCell);
        TableStudents.Rows.Add(firstRow);


        if (academicRecords == null || academicRecords.Count == 0)
        {
            TableRow lastRow = new TableRow();
            TableCell lastRowCell = new TableCell();
            lastRowCell.Text = "No Students in this course yet";
            lastRowCell.ForeColor = System.Drawing.Color.Blue;
            lastRowCell.ColumnSpan = 3;
            lastRowCell.HorizontalAlign = HorizontalAlign.Center;
            lastRow.Cells.Add(lastRowCell);

            TableStudents.Rows.Add(lastRow);
        }
        else
        {

            foreach (AcademicRecord academicRecord in academicRecords)
            {

                TableRow row = new TableRow();
                TableCell cell = new TableCell();

                cell.Text = academicRecord.CourseCode;
                row.Cells.Add(cell);

                cell = new TableCell();

                StudentRecordEntities entityContext = new StudentRecordEntities();
                var studnt = (from a in entityContext.Students
                              where a.Id == academicRecord.StudentId
                              select a).FirstOrDefault<Student>();

                cell.Text = studnt.Name;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.Text = academicRecord.Grade.ToString();
                row.Cells.Add(cell);

                TableStudents.Rows.Add(row);

            }
        }
    }
}