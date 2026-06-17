Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class Disposal_Entry
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (139)
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
        _eid = Session("empcode")

    End Sub

    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub items_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles items.SelectedIndexChanged
        Dim stdmeasure
        'Dim major
        Dim tot1
        Dim tot2
        Dim result As Decimal
        'Dim availableqty As Decimal

        Try
            GetDEdetails(items.SelectedValue)
            Dim dr, dr1, dr2 As DataRow
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    control.Text = dr("controlspec").ToString
                    stdmeasure = dr("stdmeasurement").ToString
                    If dr("stdmeasurement") Is System.DBNull.Value Then
                        stdmeasure = 0
                    Else
                        stdmeasure = dr("stdmeasurement").ToString
                    End If

                End If
            End If

            GetDEsubtotal1(items.SelectedValue)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr1 = dsdata.Tables(0).Rows(0)

                    tot1 = dr1("tot1").ToString
                End If
            End If

            GetDEsubtotal2(items.SelectedValue)

            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr2 = dsdata.Tables(0).Rows(0)

                    tot2 = dr2("tot2").ToString
                End If
            End If


            result = (tot1 / stdmeasure) - (tot2)

            If result < 0 Then
                availableqty.Text = 0
            Else
                availableqty.Text = result
            End If

        Catch ex As Exception
            messagebox(ex.Message)
        End Try
        GridView1.DataBind()
    End Sub
    Public Sub delrec(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim item As String = GridView1.Rows(i).Cells(0).Text
            Dim status As CheckBox = DirectCast(GridView1.Rows(i).FindControl("del"), CheckBox)
            Dim DS As DataSet
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If status.Checked = True Then
                DS = Open_safetyDE(Con, DAP, 2, "delete Safety_dispossaldetails where items = '" & item & "'")
                LblMsg.Text = "RECORD/S DELETED"
                LblMsg.ForeColor = Drawing.Color.Red
            End If
            MyGlobal.db_close()
        Next
        GridView1.DataBind()
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fd1 As String
        fd1 = DateTime.Now
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim recno As Integer
        GetRno()
        recno = posid

        SqlDataSource3.InsertParameters.Add("recno", recno)
        SqlDataSource3.InsertParameters.Add("empcode", Session("empcode"))
        SqlDataSource3.InsertParameters.Add("dateapplied", fd)
        SqlDataSource3.InsertParameters.Add("dept", Session("_edept"))
        SqlDataSource3.InsertParameters.Add("sect", Session("_esect"))
        SqlDataSource3.InsertParameters.Add("majortype", "Schedule Waste")
        SqlDataSource3.InsertParameters.Add("status", "S")
        SqlDataSource3.Insert()

        GetDEdata(Session("empcode"))
        If recstatus = True Then
            Dim rcount As Integer
            Dim item As String
            Dim code As String
            Dim dr As DataRow
            Dim i As Integer = 0
            If dsdata.Tables(0).Rows.Count > 0 Then
                rcount = dsdata.Tables(0).Rows.Count
                For i = 0 To rcount - 1
                    dr = dsdata.Tables(0).Rows(i)
                    'recno = dr("recordno").ToString
                    item = dr("item").ToString
                    code = dr("code").ToString
                    InsertDEdata(recno, item, code)
                Next
                DelDEdata(Session("empcode"))
            End If
        End If



        'If control.Text <> "" And availableqty.Text <> "" Then
        '    Try
        '        MyGlobal.Open_Con()
        '        MyGlobal.Con_Str()

        '        Call MyGlobal.dbSp_open("safety_DEscreen")
        '        Cmd.Parameters.AddWithValue("@control", control.Text)
        '        Cmd.Parameters.AddWithValue("@availableqty", availableqty.Text)
        '        Cmd.Parameters.AddWithValue("@dispqty", dispqty.Text)
        '        Cmd.Parameters.AddWithValue("@major", "Schedule Waste")

        '        Cmd.ExecuteNonQuery()
        '        messagebox(control)

        '        LblMsg.Text = "NEW ENTRY ADDED"
        '        control.Text = ""
        '        availableqty.Text = ""
        '        dispqty.Text = ""
        '        messagebox("NEW ENTRY ADDED")
        '    Catch ex As SqlException
        '        messagebox(ex.Message)
        '        LblMsg.Text = ex.Message
        '        LblMsg.ForeColor = Drawing.Color.Green

        '    End Try
        '    MyGlobal.db_close()
        '    GridView1.DataBind()
        'End If
    End Sub
End Class