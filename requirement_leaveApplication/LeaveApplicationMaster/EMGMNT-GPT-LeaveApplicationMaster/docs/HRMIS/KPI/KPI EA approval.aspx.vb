Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class KPI_EA_approval
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (79)
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
        'Session("empcode") = "014543"
        ' Session("_edept") = "9000"
        If Not IsPostBack Then
            ' GetHeadDept()
        End If
    End Sub
    Public Sub UpdateKPIApproval(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rb1"), RadioButtonList).SelectedValue
            Dim total As String = DirectCast(GridView1.Rows(i).FindControl("txttotal"), TextBox).Text
            Dim grade As String = DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If status = "EAApprove" Then
                DS = Open_KPIGrade(Con, DAP, 2, "update kpi_grade_result set status = '" & status & "' ,total = '" & total & "' ,grade = '" & grade & "' ,approvedby = '" & Session("empcode") & "' ,approveddate = getdate() where slno = '" & slno & "'")
            End If
        Next
        BindGrid()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        bINDgRID()
    End Sub
    Private Sub BindGrid()

        Dim opn
        Dim Dept As String
        Dept = ddldeptr.SelectedValue.Trim
        Dim sect As String
        sect = ddlsectrpt.SelectedValue.Trim
        Dim ecode As String
        ecode = txtempidr.Text.Trim
        Dim desig As String
        desig = ddldesigr.SelectedValue.Trim
        'Dim lvl As String
        'lvl = ddllevel.SelectedValue.Trim
        Dim myval

        If rdoptions.SelectedValue = "Dept" And ddldeptr.SelectedValue = "-1" Then
            lblmsg.text = "Please select Department"
            Exit Sub

        ElseIf rdoptions.SelectedValue = "Sect" And (ddlsectrpt.SelectedValue = "-1" Or ddldeptr.SelectedValue = "-1") Then
            lblmsg.text = "Please select Department & Section"
            Exit Sub

        ElseIf rdoptions.SelectedValue = "Emp" And txtempidr.Text = "" Then
            lblmsg.text = "Please Keyin empcode"
            Exit Sub
        ElseIf rdoptions.SelectedValue = "Desig" And ddldesigr.SelectedValue = "-1" Then
            lblmsg.text = "Please select Designation"
            Exit Sub
        End If

        If rdoptions.SelectedValue = "Dept" And ddldeptr.SelectedValue <> "-1" Then
            myval = ddldeptr.SelectedValue.Trim
            opn = "Dept"
            sect = ""
        ElseIf rdoptions.SelectedValue = "Sect" And ddlsectrpt.SelectedValue <> "-1" Then
            myval = ddldeptr.SelectedValue.Trim
            opn = "sect"
            sect = ddlsectrpt.SelectedValue.Trim
        ElseIf rdoptions.SelectedValue = "Emp" And txtempidr.Text <> "" Then
            myval = txtempidr.Text.Trim
            opn = "emp"
            sect = ""
        ElseIf rdoptions.SelectedValue = "Desig" And ddldesigr.SelectedValue <> "-1" Then
            myval = ddldesigr.SelectedValue.Trim
            opn = "desig"
            sect = ""
        ElseIf rdoptions.SelectedValue = "all" Then
            myval = ""
            opn = "all"
            sect = ""
        End If

        'Bind Grid view

        MyGlobal.Con_Str()
        Dim ds1 As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("KPI_GetEmpID_fetch_new", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@dept", myval)
        Command.Parameters.AddWithValue("@sect", sect)
        Command.Parameters.AddWithValue("@Operation", opn)
        Command.Parameters.AddWithValue("@yr", ddlyr.SelectedValue.Trim)
        Command.Parameters.AddWithValue("@mon", ddlmon.SelectedValue.Trim)

        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "OTRec")
        GridView1.DataSource = ds1
        GridView1.DataBind()
        GridView1.Visible = True
        con.Close()
    End Sub

    Protected Sub calculateTotal(ByVal Sender As Object, ByVal e As System.EventArgs)
        'Dim weight As TextBox
        Dim weight As Double
        Dim total As TextBox
        Dim totVal As Double

        Dim rno
        Dim grade

        For i As Integer = 0 To GridView1.Rows.Count - 1
            'weight = DirectCast(GridView1.Rows(i).FindControl("pweight"), TextBox)
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            total = DirectCast(GridView1.Rows(i).FindControl("txttotal"), TextBox)
            grade = DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text

            If total.Text <> "" Then

                totVal = Double.Parse(total.Text.Trim)

                If totVal >= 100 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "A"
                ElseIf totVal <= 0 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "E"
                ElseIf totVal > 0 And totVal < 51 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "E"
                ElseIf totVal > 50 And totVal < 61 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "D"
                ElseIf totVal > 60 And totVal < 71 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "C"
                ElseIf totVal > 70 And totVal < 86 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "B"
                ElseIf totVal > 85 And totVal < 101 Then
                    DirectCast(GridView1.Rows(i).FindControl("lblgrade"), Label).Text = "A"
                End If

            End If

        Next
    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = True
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        End If
        GridView1.Visible = False
    End Sub
End Class