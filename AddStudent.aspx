<%@ Page Title="" Language="C#" MasterPageFile="~/ACMasterPage.master" AutoEventWireup="true" CodeFile="AddStudent.aspx.cs" Inherits="AddStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


     <h3>Add Student Records</h3>

    <br />
    <br />

     <table>

        <tr>
            <td class="auto-style1">&nbsp;&nbsp;&nbsp;
                        
                       <asp:Label ID="LabelCourse" runat="server" Text="Course:"></asp:Label>
            </td>
            <td class="auto-style1"> &nbsp; &nbsp;&nbsp;
                <asp:DropDownList ID="DropDownListCourses"  AutoPostBack="True" runat="server" style="width:17.8rem;" OnSelectedIndexChanged="DropDownListCourses_SelectedIndexChanged" >
                    <asp:ListItem Value="-1">Select a Course</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDropList" runat="server" ControlToValidate="DropDownListCourses" Display="Dynamic" ErrorMessage="Required!" ForeColor="#990000">Required!</asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <br />
                &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelStudentNumber" runat="server" Text="Student Number:"></asp:Label>
            </td>
            <td>
                <br />   &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBoxStudentNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStudentNumber" runat="server" ControlToValidate="TextBoxStudentNumber" Display="Dynamic" ErrorMessage="Required!" ForeColor="#990000">Required!</asp:RequiredFieldValidator>
            </td>
             
              
              
        </tr>
           
        <tr>
            <td>
                <br />
                &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelStudentName" runat="server" Text="Student Name:"></asp:Label>
            </td>

            <td>
                <br /> &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBoxStudentName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStudentName" runat="server" ControlToValidate="TextBoxStudentName" Display="Dynamic" ErrorMessage="Required!" ForeColor="#990000">Required!</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpValidator"
                    ValidationExpression="[a-zA-Z]+\s+[a-zA-Z]+" ControlToValidate="TextBoxStudentName" CssClass="error" Display="Dynamic" ErrorMessage="Must be in first_name last_name!" runat="server" ForeColor="#990000" />

            </td>
        </tr>
        <tr>
            <td>
                <br />
                &nbsp;&nbsp;&nbsp;
                        <asp:Label ID="LabelGrade" runat="server" Text="Grade (0-100):"></asp:Label>
            </td>
            <td>
                <br /> &nbsp; &nbsp;&nbsp;
                <asp:TextBox ID="TextBoxGrade" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorGrade" runat="server" ControlToValidate="TextBoxGrade" Display="Dynamic" ErrorMessage="Required!" ForeColor="#990000">Required!</asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidatorGrade" runat="server" ControlToValidate="TextBoxGrade" Display="Dynamic" ErrorMessage="Grade must be an integer from 0 to 100 " ForeColor="#990000" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>

                 </td>
        </tr>
    </table>

    <br />
    <asp:Label ID="LabelErrorMessage" runat="server" ForeColor="#CC0000"></asp:Label>
    <br />


    <asp:Button ID="ButtonAddToCourse" runat="server" Text="Save" OnClick="ButtonAddToCourse_Click"  />

    <h3>The selected course have the following students records:</h3>

    <asp:Table CssClass="table" ID="TableStudents" runat="server">
    </asp:Table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

