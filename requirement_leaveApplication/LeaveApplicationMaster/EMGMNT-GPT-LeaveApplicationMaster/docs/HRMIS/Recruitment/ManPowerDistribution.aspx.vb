Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security
Partial Public Class ManPowerDistribution
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String
    Dim Stat As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '   Session("empcode") = "014543"

    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click


        Try
            MyGlobal.Con_Str()
            MyGlobal.Open_Con()
            Dim con As New SqlConnection(constr)
            con.Open()
            Cmd = New SqlCommand("INSERT INTO [hrmis].[dbo].[EMS_mancounttemp]([Dept],[Sect],[opt],[staff],[total]) values('" & dept_ddl.SelectedValue.Trim & "','" & mcno_ddl.SelectedValue.Trim.Trim & "','" & opt.Text & "','" & staff.Text & "','" & mptotal.Text & "')", con)
            Cmd.ExecuteNonQuery()

        Catch ex As Exception
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Red

        End Try
        GridView2.DataBind()
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub


    Protected Sub opt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt.TextChanged
        Dim o As Integer
        Dim s As Integer
        Dim tot As Integer
        o = opt.Text
        s = staff.Text
        tot = (o + s)
        mptotal.Text = tot
    End Sub

    Protected Sub staff_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles staff.TextChanged
        Dim o As Integer
        Dim s As Integer
        Dim tot As Integer
        o = opt.Text
        s = staff.Text
        tot = (o + s)
        mptotal.Text = tot
    End Sub
    Protected Sub ADDManpower(ByVal sender As System.Object, ByVal e As System.EventArgs)


    
        Dim j
        Dim scount
        Dim dept, sect
        Dim opt1, staff1, total
        dsdata = getsmsdet()
        Dim dp As DataRow
        If dsdata.Tables(0).Rows.Count > 0 Then
            scount = dsdata.Tables(0).Rows.Count
            For j = 0 To scount - 1
                dp = dsdata.Tables(0).Rows(j)
                dept = dp("dept").ToString
                sect = dp("sect").ToString
                opt1 = dp("opt").ToString
                staff1 = dp("staff").ToString
                total = dp("total").ToString

                Try
                    MyGlobal.Con_Str()
                    MyGlobal.Open_Con()
                  

                    Call MyGlobal.dbSp_open("ems_mancount_ins")
                    ' Cmd = New SqlCommand("ems_mancount_ins", con)
                    Cmd.Parameters.AddWithValue("@dept", dept)
                    Cmd.Parameters.AddWithValue("@sect", sect)
                    Cmd.Parameters.AddWithValue("@staff", staff1)
                    Cmd.Parameters.AddWithValue("@opt", opt1)
                    Cmd.Parameters.AddWithValue("@total", total)
                    Cmd.Parameters.AddWithValue("@cby", Session("empcode"))
                    ' Cmd.CommandType = CommandType.StoredProcedure
                    Cmd.ExecuteNonQuery()

                    lblmsg.Text = "Record Saved"
                    lblmsg.ForeColor = Drawing.Color.Green
                Catch ex As Exception
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Red
                    Exit Sub
                End Try
            Next
            dept_ddl.SelectedValue = "-1"
            opt.Text = 0
            staff.Text = 0
            mptotal.Text = 0

            MyGlobal.Con_Str()
            Dim con As New SqlConnection(constr)
            con.Open()
            Cmd = New SqlCommand("delete from EMS_mancounttemp", con)
            Cmd.ExecuteNonQuery()

            GridView2.DataBind()
        End If

    End Sub
    Function getsmsdet() As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con()

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from ems_mancounttemp", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "SM")
        con.Close()
        Return ds
    End Function

    Protected Sub dept_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dept_ddl.SelectedIndexChanged
        opt.Text = 0
        staff.Text = 0
        mptotal.Text = 0
    End Sub

    Protected Sub mcno_ddl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mcno_ddl.SelectedIndexChanged
        opt.Text = 0
        staff.Text = 0
        mptotal.Text = 0
    End Sub
End Class