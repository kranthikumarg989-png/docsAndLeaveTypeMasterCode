Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PrReportview
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim bLeapYear As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (238)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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
        bindOTGrid()
    End Sub

    Private Sub bindOTGrid()

        Dim rptby
        Dim Dept As String
        Dept = Session("Prdept")
        Dim sect As String
        sect = Session("Prsect")
        Dim ecode As String
        ecode = Session("premp")
        Dim desig As String
        desig = Session("Prdesig")
        Dim grp As String
        grp = Session("Prgrp")
        Dim myval
        Dim cate As String
        cate = Session("Prcate")
        myval = ""
        rptby = Session("PrRptby")
        Dim fromd As String = Session("Prfromd")
        Dim tod As String = Session("Prtod")

        Dim fromff As String = Session("fromff")
        Dim toff As String = Session("toff")


        '  status = LTrim(RTrim(Session("Otstatus")))

        lbldetails.Text = " " & fromff & "~" & toff
        If rptby = "emp" Then ' Then
            myval = ecode
        ElseIf rptby = "dept" Then ' Then
            myval = Dept
        ElseIf rptby = "desig" Then ' Then
            myval = desig
        ElseIf rptby = "sect" Then ' Then
            myval = sect
        ElseIf rptby = "O" Then ' Then
            myval = "O"
        End If


        'Bind Grid view
        Try
            MyGlobal.Con_Str()
            Dim ds1 As New DataSet()
            Dim con As New SqlConnection(constr)
            con.Open()
            Dim Command As New SqlCommand
            If grp <> "ag" Then
              
                Command = New SqlCommand("PR_Fetch_new", con)
                Command.CommandType = CommandType.StoredProcedure

                Command.Parameters.AddWithValue("@myval", myval)
                Command.Parameters.AddWithValue("@from", fromd)
                Command.Parameters.AddWithValue("@to", tod)
                Command.Parameters.AddWithValue("@Operation", rptby)
                Command.Parameters.AddWithValue("@grp", grp)
                Command.Parameters.AddWithValue("@cat", cate)


                Dim DataAdap = New SqlDataAdapter(Command)
                DataAdap.Fill(ds1, "OTRec")
            Else

                Command = New SqlCommand("PR_Fetch_newallgroup", con)
                Command.CommandType = CommandType.StoredProcedure

                Command.Parameters.AddWithValue("@myval", myval)
                Command.Parameters.AddWithValue("@from", fromd)
                Command.Parameters.AddWithValue("@to", tod)
                Command.Parameters.AddWithValue("@Operation", rptby)
                Command.Parameters.AddWithValue("@cat", cate)

                Dim DataAdap = New SqlDataAdapter(Command)
                DataAdap.Fill(ds1, "OTRec")
            End If
            GridView2.DataSource = ds1
            GridView2.DataBind()
            GridView2.Visible = True

            Con.Close()

        Catch ex As Exception
            MessageBox(ex.Message)
        End Try


    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Private Sub GridView2_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowCreated

        Dim fm = Session("fmonth")

        If fm = "09" Or fm = "04" Or fm = "06" Or fm = "11" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(17).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(17).Visible = False

            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(17).Visible = False
            End If

        ElseIf fm = "02" Then
            LeapYearCheck()

            If bLeapYear = True Then

                If e.Row.RowType = DataControlRowType.Header Then
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.DataRow Then
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.Footer Then
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
            Else
                If e.Row.RowType = DataControlRowType.Header Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.DataRow Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.Footer Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If

            End If

        Else

        End If
    End Sub
    Private Sub LeapYearCheck()

        Dim fyear = Session("fyear")

        bLeapYear = Date.IsLeapYear(fyear)

    End Sub

    Private Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        Dim fm = Session("fmonth")

        If fm = "09" Or fm = "04" Or fm = "06" Or fm = "11" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(17).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(17).Visible = False
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(17).Visible = False
            End If

        ElseIf fm = "02" Then
            LeapYearCheck()

            If bLeapYear = True Then

                If e.Row.RowType = DataControlRowType.Header Then
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.DataRow Then
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.Footer Then
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
            Else
                If e.Row.RowType = DataControlRowType.Header Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.DataRow Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If
                If e.Row.RowType = DataControlRowType.Footer Then
                    e.Row.Cells(15).Visible = False
                    e.Row.Cells(16).Visible = False
                    e.Row.Cells(17).Visible = False
                End If

            End If

        Else


        End If
    End Sub
End Class