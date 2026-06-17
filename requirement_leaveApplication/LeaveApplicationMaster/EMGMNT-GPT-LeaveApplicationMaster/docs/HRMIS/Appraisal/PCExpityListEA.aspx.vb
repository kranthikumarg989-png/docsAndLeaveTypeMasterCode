Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PCExpityListEA
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode
    Dim thisdate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()

        thisdate = Date.Now
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (162)
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
        ' If Session("empcode") = "005000" Then
        GridV.Visible = False
        'Label4.Visible = False
        ' Else
        ' GridV.Visible = True
        ' Label4.Visible = True
        '  End If
        If Not IsPostBack Then
            BindGrid()
        End If

    End Sub
    Protected Sub Appraisal_view(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("optempappEA") = e.CommandArgument
        Response.Redirect("OperatorAppraisalViewEA.aspx")
    End Sub
    Protected Sub Appraisal_view1(ByVal sender As Object, ByVal e As CommandEventArgs)
        Session("empappl") = e.CommandArgument
        Response.Redirect("EAappraisal.aspx")
    End Sub
    Protected Sub UpdateAppraisal(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim gridview1 As GridView
        For i As Integer = 0 To GridV.Rows.Count - 1
            Dim slno As String = GridV.Rows(i).Cells(0).Text
            Dim emp As String = GridV.Rows(i).Cells(1).Text
            Dim stats As String = DirectCast(GridV.Rows(i).FindControl("radiobuttonlist1"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If stats <> "" Then
                DS = MyGlobal.Open_appraisal(Con, DAP, 2, "update app_operatorappraisal set confirmd = '" & stats & "' , status ='A' where rno='" & slno & "'")
                Call MyGlobal.dbSp_open("insert_appraisal_ea")
                Cmd.Parameters.AddWithValue("@empcode", emp)
                Cmd.Parameters.AddWithValue("@appraisal", "Y")
                Cmd.Parameters.AddWithValue("@status", "EA")
                Cmd.Parameters.AddWithValue("@prob ", "")
                Cmd.Parameters.AddWithValue("@atype", "P")
                Cmd.Parameters.AddWithValue("@confirm", stats)
                Cmd.ExecuteNonQuery()
                MyGlobal.db_close()
            End If
        Next
        GridV.DataBind()
    End Sub

    Protected Sub searchgrid2(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click

        Dim str
        str = txtsearch2.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To gridview1.Rows.Count - 1
                Dim lbn As String = DirectCast(gridview1.Rows(n).FindControl("LAB1"), Label).Text
                Dim empname As String = gridview1.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    gridview1.Rows(n).Focus()
                    gridview1.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    gridview1.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If

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
        Command = New SqlCommand("hrmis_appraisal_alert_EA1", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@dept", myval)
        Command.Parameters.AddWithValue("@sect", sect)
        Command.Parameters.AddWithValue("@Operation", opn)


        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "OTRec")
        GridView1.DataSource = ds1
        GridView1.DataBind()
        gridview1.Visible = True

        Label5.Visible = True
        txtsearch2.Visible = True
        ImageButton1.Visible = True
        If rdoptions.SelectedValue = "all" Then
            GridV.Visible = True
        Else
            GridV.Visible = False
        End If
        con.Close()
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
        gridview1.Visible = False
        GridV.Visible = False
        'Label5.Visible = False
        'txtsearch2.Visible = False
        'ImageButton1.Visible = False

    End Sub

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        BindGrid()

    End Sub

    Private Sub ddldeptr_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddldeptr.SelectedIndexChanged
        GridV.Visible = False
    End Sub
End Class