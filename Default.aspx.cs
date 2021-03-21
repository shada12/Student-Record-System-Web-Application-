using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        LinkButton btnHome = (LinkButton)Master.FindControl("btnHome");
        btnHome.Enabled = false;


        BulletedList topMenu = (BulletedList)Master.FindControl("topMenu");

        if (!IsPostBack)
        {

            topMenu.Items.Add(new ListItem("Add Courses"));
            topMenu.Items.Add(new ListItem("Add Student Records"));

        }
        topMenu.Click += topMenu_Click;
    }

    protected void topMenu_Click(object sender, BulletedListEventArgs e)
    {

        if (e.Index == 0)
        {
            Response.Redirect("AddCourse.aspx");
        }
        else if (e.Index == 1)
        {

            Response.Redirect("AddStudent.aspx");
        }
    }
}
