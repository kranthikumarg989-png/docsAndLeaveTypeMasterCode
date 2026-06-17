Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TrainingRpts
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (155)
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
    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldept.Enabled = True
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            ddldesig.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
        ElseIf rdoptions.SelectedValue = "PrgmCategory" Then
            ddldept.Enabled = False
            ddlpc.Enabled = True
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            ddldesig.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
        ElseIf rdoptions.SelectedValue = "Training" Then
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = True
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            ddldesig.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = True
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            ddldesig.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
        ElseIf rdoptions.SelectedValue = "Dept&Desig" Then
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = True
            ddl1.Enabled = True
            ddlsect.Enabled = False
            ddldesig.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = True
            ddldesig.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
            ddldesig.Enabled = True
        ElseIf rdoptions.SelectedValue = "Method" Then
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            CmbMethod.Enabled = True
            CmbType.Enabled = False
            ddldesig.Enabled = False
        ElseIf rdoptions.SelectedValue = "Type" Then
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = True
            ddldesig.Enabled = False
        Else
            ddldept.Enabled = False
            ddlpc.Enabled = False
            ddltr.Enabled = False
            TextBox1.Enabled = False
            ddl2.Enabled = False
            ddl1.Enabled = False
            ddlsect.Enabled = False
            ddldesig.Enabled = False
            CmbMethod.Enabled = False
            CmbType.Enabled = False
        End If

    End Sub


    Protected Sub showtTrainingReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showtTrainingReport.Click

        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        ddldept.Enabled = False
        ddlpc.Enabled = False
        ddltr.Enabled = False
        TextBox1.Enabled = False
        ddl2.Enabled = False
        ddl1.Enabled = False
        ddlsect.Enabled = False
        ddldesig.Enabled = False

        Session("trdept") = ddldept.SelectedValue.Trim
        Session("trpc") = ddlpc.Text.Trim
        Session("trtr") = ddltr.SelectedValue.Trim
        Session("tremp") = TextBox1.Text.Trim
        Session("trsect") = ddlsect.SelectedValue.Trim
        Session("trdesig") = ddldesig.SelectedValue.Trim
        Session("trdesig1") = ddl1.SelectedValue.Trim
        Session("trdept1") = ddl2.SelectedValue.Trim

        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td

        If rdvalue = "Dept" And ddldept.SelectedValue <> "" Then
            Session("trstat") = "D"
        ElseIf rdvalue = "Sect" And ddlsect.SelectedValue <> "" Then
            Session("trstat") = "S"
        ElseIf rdvalue = "Desig" And ddldesig.SelectedValue <> "" Then
            Session("trstat") = "Desi"
        ElseIf rdvalue = "Emp" And TextBox1.Text <> "" Then
            Session("trstat") = "E"
        ElseIf rdvalue = "Dept&Desig" And ddl1.SelectedValue <> "" And ddl2.SelectedValue <> "" Then
            Session("trstat") = "DD"
        ElseIf rdvalue = "PrgmCategory" And ddlpc.SelectedValue <> "" Then
            Session("trstat") = "P"
        ElseIf rdvalue = "Training" And ddltr.SelectedValue <> "" Then
            Session("trstat") = "T"
        ElseIf rdvalue = "Method" And ddltr.SelectedValue <> "" Then
            Session("trstat") = "M"
        ElseIf rdvalue = "Type" And ddltr.SelectedValue <> "" Then
            Session("trstat") = "Y"
        Else
            Session("trstat") = "O"
        End If

        Response.Redirect("TRreportsbyselection.aspx")


    End Sub

End Class