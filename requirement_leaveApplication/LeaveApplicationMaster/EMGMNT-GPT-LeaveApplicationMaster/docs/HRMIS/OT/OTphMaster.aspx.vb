Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Partial Public Class OTphMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (68)
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
    Protected Sub SubmitPH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitPH.Click
        Dim fd1 As String
        fd1 = phfromdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = phtodate.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim hd1 As String
        hd1 = phdate.Text.Trim
        Dim strdate3() As String = hd1.Split("/"c)
        hd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        Dim hdp As Date
        hdp = CDate(hd1)
        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Call MyGlobal.dbSp_open("TMS_PH_OT")
            Cmd.Parameters.AddWithValue("@phfromdate", fd)
            Cmd.Parameters.AddWithValue("@phtodate", td)
            Cmd.Parameters.AddWithValue("@phdate", hdp)
            Cmd.Parameters.AddWithValue("@categorydate", categorydate.SelectedValue)
            Cmd.Parameters.AddWithValue("@cby", Session("empcode"))
            Cmd.ExecuteNonQuery()

            LblMsg.Text = "OT PH MASTER TABLE HAS BEEN ADDED WITH NEW DATA"
            phdate.Text = ""

            '''' check in trans_shiftfinal whether any record exist for this PH
            '''' get records from trans_shiftfinal table

            Dim dsPR As DataSet
            Dim drPR As DataRow
            Dim dsshift As DataSet
            Dim drshift As DataRow

            '''' update trans_shiftfinal table if PH fall under that particular date

            Dim j
            Dim myshift
            Dim grp
            dsPR = GetShift(hdp)
            If dsPR.Tables(0).Rows.Count <> 0 Then
                For j = 0 To dsPR.Tables(0).Rows.Count - 1
                    drPR = dsPR.Tables(0).Rows(j)
                    If Not drPR("shiftcode") Is System.DBNull.Value Then
                        myshift = drPR("shiftcode").ToString
                    Else
                        myshift = ""
                    End If
                    grp = drPR("groupcode").ToString
                    'myshift = "PH" & myshift
                    myshift = "PH"
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    DS = Open_PHMASTER(Con, DAP, 2, "update trans_shiftfinal set shiftcode='" & myshift & "' where shiftdate='" & hdp & "' and groupcode = '" & grp & "'")
                    MyGlobal.db_close()
                Next
            End If

            'dsshift = chkPRRecExist(hdp)
            'If dsshift.Tables(0).Rows.Count <> 0 Then
            '    drshift = dsshift.Tables(0).Rows(0)
            '    If Not drshift("groupcode") Is System.DBNull.Value Then
            '        mygrp = drpr1("groupcode").ToString

            '    End If
            'End If
        Catch ex As SqlException
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
            ' phfromdate.Text = ""
            ' phtodate.Text = ""
            ' phdate.Text = ""
            ' categorydate.SelectedValue = "-1"
        End Try
        MyGlobal.db_close()
        OTmaster.DataBind()
    End Sub
    Public Sub delroc(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To OTmaster.Rows.Count - 1
            Dim sno As String = OTmaster.Rows(i).Cells(0).Text
            Dim status As CheckBox = DirectCast(OTmaster.Rows(i).FindControl("CheckBox1"), CheckBox)

            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If status.Checked = True Then
                DS = Open_PHMASTER(Con, DAP, 2, "delete TMS_PHMASTER where sno = '" & sno & "'")
                LblMsg.Text = "RECORD/S DELETED"
                LblMsg.ForeColor = Drawing.Color.Red
            End If
            MyGlobal.db_close()
        Next
        OTmaster.DataBind()
    End Sub

    Function GetShift(ByVal fd As Date) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT shiftdate,shiftcode,groupcode FROM trans_shiftfinal WHERE  (shiftdate = '" & fd & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "Shift")
        con.Close()
        Return ds
    End Function

    Function chkPRRecExist(ByVal vfd As Date) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from trans_productionrequest where fromdate <='" & vfd & "' and todate >='" & vfd & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "Pr")
        con.Close()
        Return ds
    End Function
End Class


