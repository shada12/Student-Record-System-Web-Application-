<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="AddCourse.aspx.cs" Inherits="AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    

    <h3>Add New Courses</h3>

    <br />
    <br />

    <table>
        <tr>
            <td>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelCoursenNumber" runat="server" Text="Course Number:"></asp:Label>
                
            </td>


            <td>&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxCourseNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseNumber" runat="server" ControlToValidate="TextBoxCourseNumber" Display="Dynamic" ErrorMessage="Required!" ForeColor="#990000">Required!</asp:RequiredFieldValidator>
            </td>

        </tr>

        <tr>
            <td>
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="LabelCourseName" runat="server" Text="Course Name:"></asp:Label>
            </td>

            <td>
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBoxCourseName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCourseName" runat="server" ControlToValidate="TextBoxCourseName" Display="Dynamic" ErrorMessage="Required!" ForeColor="#990000">Required!</asp:RequiredFieldValidator>

            </td>
        </tr>

    </table>
    <br />
                <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="#CC0000"></asp:Label>
    <br />

    <asp:Button ID="ButtonSubmitCourseInformation" runat="server" Text="Submit Course Information" OnClick="ButtonSubmitCourseInformation_Click" />

    <h3>The following courses are currently in the system:</h3>

    <asp:Table CssClass="table" ID="TableCourses" runat="server">       
        
<asp:TableRow>
           
        </asp:TableRow>
    </asp:Table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

