Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class DomWasteConsignment
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (140)
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

        thisdate = DateTime.Now.ToShortDateString()
        MyApp.GetfiscalYear()

        Dim wasteconsign As String
        If Not IsPostBack Then
            If Session("domwasteconsign") <> "" Then
                wasteconsign = Session("domwasteconsign")
                editconsign(wasteconsign)
            Else
                wasteconsign = ""
            End If
        End If

    End Sub
    Public Sub editconsign(ByVal record As String)
        
        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = GetWasteDetails(record)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            recordno.Text = dr1("recordno").ToString
            dateapplied.Text = Format(Convert.ToDateTime(dr1("dateapplied")), "dd/MM/yy")
            dept.Text = dr1("dept").ToString
            empcode.Text = dr1("empcode").ToString
            empname.Text = dr1("empname").ToString
            sect.Text = dr1("sect").ToString
            majortype.Text = dr1("majortype").ToString
        End If
    End Sub
    Function GetWasteDetails(ByVal record As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select *, empname from Safety_domesticwasteconsignment , empmaster where recordno = '" & record & "' and empmaster.empcode = Safety_domesticwasteconsignment.empcode ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "DWC")
        con.Close()
        Return ds
    End Function

    Function HODcheck() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select empname from empmaster where departmentcode = '9005' and category = 'Department Head' and resigned <> 'Y' ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "HOD")
        con.Close()
        Return ds
    End Function
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub dwc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dwc.Click


        Dim totalwt As Decimal

        Dim fd1 As String
        fd1 = dateapplied.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = datedispossal.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim dt
        Dim dispossaltime
        dispossaltime = ddlihr.Text + ":" + ddlimin.Text + " " + Convert.ToString(ddliam.SelectedValue)
        dt = td & " " & dispossaltime


        Dim ds As New DataSet
        Dim dr1 As DataRow
        Dim HODcheckedby
        ds = HODcheck()
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            HODcheckedby = dr1("empcode").ToString
        Else
            HODcheckedby = "-"

        End If
        Dim istat = 0
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Dim quantity As String = DirectCast(GridView1.Rows(i).FindControl("quantity"), TextBox).Text
                Dim remarks As String = DirectCast(GridView1.Rows(i).FindControl("remarks"), TextBox).Text
                Dim controlspec As Decimal = GridView1.Rows(i).Cells(2).Text

                If quantity = "" Then
                    quantity = "0"

                End If

                totalwt = (quantity * controlspec)
                If (quantity > controlspec) Then
                    istat = istat + 1
                End If

                Call MyGlobal.dbSp_open("safety_WCboth")
                Cmd.Parameters.AddWithValue("@recordno", recordno.Text)
                Cmd.Parameters.AddWithValue("@quantity", quantity)
                Cmd.Parameters.AddWithValue("@remarks", remarks)
                '  Cmd.Parameters.AddWithValue("@controlspec", controlspec)
                Cmd.Parameters.AddWithValue("@total", totalwt)
                Cmd.Parameters.AddWithValue("@majortype", majortype.Text)
                Cmd.ExecuteNonQuery()
                'Dim l
                'l = Cmd.ExecuteNonQuery()
                'If l > 0 Then
                '    messagebox("success6767")
                'Else
                '    messagebox("failure")
                'End If

            Catch ex As SqlException
                messagebox(ex.Message)
            End Try
        Next

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Call MyGlobal.dbSp_open("safety_DWC")
            Cmd.Parameters.AddWithValue("@recordno", recordno.Text)
            Cmd.Parameters.AddWithValue("@fd", fd)
            Cmd.Parameters.AddWithValue("@dept", dept.Text)
            Cmd.Parameters.AddWithValue("@empcode", empcode.Text)
            Cmd.Parameters.AddWithValue("@sect", sect.Text)
            Cmd.Parameters.AddWithValue("@majortype", majortype.Text)
            Cmd.Parameters.AddWithValue("@td", td)
            Cmd.Parameters.AddWithValue("@personincharge", personincharge.selectedvalue)
            Cmd.Parameters.AddWithValue("@dt", dt)
            Cmd.Parameters.AddWithValue("@HODcheckedby", HODcheckedby)
            Cmd.Parameters.AddWithValue("@empcheckby", Session("empcode"))
            Cmd.ExecuteNonQuery()

            messagebox("updated sucessfully")
            Session("detreq") = recordno.Text
            Response.Redirect("requestordetailsdw.aspx")

        Catch ex As SqlException
            messagebox(ex.Message)
        End Try

    End Sub
    'Public Sub getReqDet(ByVal sender As Object, ByVal e As CommandEventArgs)
    '    Dim appno
    '    appno = e.CommandArgument
    '    Session("domwasteconsign") = appno
    '    Response.Redirect("requestordetails.aspx")
    'End Sub
End Class