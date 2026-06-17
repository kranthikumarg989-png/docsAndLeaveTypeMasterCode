Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class rptUpdatedandNU
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (82)
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

    Protected Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        Dim opt
        opt = RadioButtonList1.SelectedValue

        Session("kpidesigU") = Trim(ddldesigr.SelectedValue)
        Session("kpiempU") = Trim(txtempidr.Text)
        Session("kpisectU") = Trim(ddlsectrpt.SelectedValue)
        Session("kpideptU") = ddldeptr.SelectedValue.Trim
        Session("kpiyrU") = ddlyr.SelectedValue.Trim
        Session("kpimonU") = ddlmon.SelectedValue.Trim
        Session("KpimthndayU") = opt

        If rdvalue = "Dept" And ddldeptr.SelectedValue <> "" Then
            Session("kpiRptbyU") = "D"
        ElseIf rdvalue = "Sect" And ddlsectrpt.SelectedValue <> "" Then
            Session("kpiRptbyU") = "S"
        ElseIf rdvalue = "Desig" And ddldesigr.SelectedValue <> "" Then
            Session("kpiRptbyU") = "Desi"
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            Session("kpiRptbyU") = "E"
        Else
            Session("kpiRptbyU") = "O"
        End If
        Dim sqltext
        If opt = "U" Then
            Response.Redirect("rptupdatedlist.aspx")
        ElseIf opt = "NU" Then

            '''' Delete from Temp table before entering new record
            MyGlobal.Con_Str()

            Dim con As New SqlConnection(constr)
            con.Open()
            Cmd = New SqlCommand("delete from kpi_tempreport", con)
            Cmd.ExecuteNonQuery()

            If Session("kpiRptbyU") = "D" Then
                sqltext = "select * from empmaster where departmentcode = '" & ddldeptr.SelectedValue & "' and resigned = 'N' AND DESIGNATION <> 'oPERATOR'"
            ElseIf Session("kpiRptbyU") = "S" Then
                sqltext = "select * from empmaster where sectioncode = '" & ddlsectrpt.SelectedValue & "' and resigned = 'N' AND DESIGNATION <> 'oPERATOR'"
            ElseIf Session("kpiRptbyU") = "Desi" Then
                sqltext = "select * from empmaster where designation = '" & ddldesigr.SelectedValue & "' and resigned = 'N' AND DESIGNATION <> 'oPERATOR'"
            ElseIf Session("kpiRptbyU") = "E" Then
                sqltext = "select * from empmaster where empcode= '" & txtempidr.Text & "' and resigned = 'N' AND DESIGNATION <> 'oPERATOR'"
            ElseIf Session("kpiRptbyU") = "O" Then
                sqltext = "select * from empmaster where resigned = 'N' AND DESIGNATION <> 'oPERATOR'"
            End If

            Dim ds1 As DataSet
            Dim dr, dr1 As DataRow
            Dim i
            Dim emp
            DS = GetNotUpdatedList(sqltext)
            If DS.Tables(0).Rows.Count <> 0 Then

                For i = 0 To DS.Tables(0).Rows.Count - 1
                    dr = DS.Tables(0).Rows(i)
                    emp = dr("empcode").ToString
                    ds1 = chkavail(emp)
                    If ds1.Tables(0).Rows.Count <> 0 Then
                        dr1 = ds1.Tables(0).Rows(0)
                    Else
                        Try
                            MyGlobal.Open_Con()
                            MyGlobal.Con_Str()
                            Call MyGlobal.dbSp_open("hrmis_kpi_tempreport")
                            Cmd.Parameters.AddWithValue("@empcode", emp)
                            Cmd.Parameters.AddWithValue("@updated", "No")
                            Cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MessageBox(ex.Message)
                            Exit Sub
                        End Try

                    End If

                Next
            End If

            Response.Redirect("rptnotupdatedlist.aspx")
            End If

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Function GetNotUpdatedList(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function
    Function chkavail(ByVal emp As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT slno, empcode, yr, mnth, total, grade, status FROM  kpi_grade_result WHERE  empcode = '" & emp & "' and mnth = '" & ddlmon.SelectedValue.Trim & "' and yr = '" & ddlyr.SelectedValue & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "emp")
        con.Close()
        Return ds
    End Function
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged

        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
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
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        Dim opt
        opt = RadioButtonList1.SelectedValue
        If opt = "mth" Then
            ddlmon.Enabled = True
            ddlyr.Enabled = True

        ElseIf opt = "yr" Then
            ddlmon.Enabled = False
            ddlyr.Enabled = True

        End If
    End Sub
End Class