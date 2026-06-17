Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Spousechildrendetails
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode As String
    Dim rno As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (108)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
        MyApp.GetfiscalYear()
    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        empcode = TextBox1.Text.Trim
        GetEmpVehino(empcode)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                Label1.Text = ""
            Else
                Label1.Text = "EmployeeCode doesnot Exist!!"
                lblename.Text = ""
            End If
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim md1 As String
        md1 = txtppexp.Text.Trim
        Dim mdate() As String
        mdate = md1.Split("/"c)
        md1 = mdate(1) & "/" & mdate(0) & "/" & mdate(2)
        Dim md As Date
        md = CDate(md1)

        Dim cd1 As String
        cd1 = txtvisaexp.Text.Trim
        Dim cpdate() As String
        cpdate = cd1.Split("/"c)
        cd1 = cpdate(1) & "/" & cpdate(0) & "/" & cpdate(2)
        Dim cd As Date
        cd = CDate(cd1)
        Try
            Spousechildren(TextBox1.Text.Trim, txtname.Text.Trim, txtppno.Text.Trim, md, txtrelation.Text.Trim, txtcountry.Text.Trim, cd)
            If recstatus = True Then
                Label1.Text = "Relationship Added"
                txtname.Text = ""
                txtppno.Text = ""
                txtppexp.Text = ""
                txtrelation.Text = ""
                txtcountry.Text = ""
                txtvisaexp.Text = ""
            Else
                Label1.Text = ""
            End If
            GridView1.DataBind()
        Catch ex As Exception
            Label1.Text = ex.Message & " Cannot Save Data"
        End Try
       
    End Sub
End Class