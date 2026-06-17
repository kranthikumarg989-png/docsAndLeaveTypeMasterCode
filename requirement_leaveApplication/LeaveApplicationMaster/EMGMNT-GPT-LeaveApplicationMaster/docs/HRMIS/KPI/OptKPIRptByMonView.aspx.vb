Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OptKPIRptByMonView
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        bindgrid()

    End Sub
    Private Sub bindgrid()

        Dim qtr
        Dim myval

        Dim opt = LTrim(RTrim(Session("stat")))
        Dim empcode = LTrim(RTrim(Session("kpiemp1")))
        Dim sect = LTrim(RTrim(Session("kpisect1")))
        Dim dept = LTrim(RTrim(Session("kpidept1")))
        Dim yr = LTrim(RTrim(Session("kpiyear1")))
        Dim mth = LTrim(RTrim(Session("kpioption1")))
        Dim emptype = LTrim(RTrim(Session("kpiemptype1")))

        If opt = "Dept" Then
            myval = dept
        ElseIf opt = "sect" Then
            myval = sect
        ElseIf opt = "emp" Then
            myval = empcode
        ElseIf opt = "O" Then
            myval = "O"
        ElseIf opt = "ONS" Then
            myval = "ONS"
        End If

        LBLMON.Text = mth
        If mth = "04" Or mth = "05" Or mth = "06" Or mth = "07" Or mth = "08" Or mth = "09" Then
            qtr = "1stHalf"
        ElseIf mth = "10" Or mth = "11" Or mth = "12" Or mth = "01" Or mth = "02" Or mth = "03" Then
            qtr = "2ndHalf"
        End If

        MyGlobal.Con_Str()
        Dim ds1 As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        If opt = "ONS" Then
            Command = New SqlCommand("KPI_GetOPTrecords_NS", con)
            Command.CommandType = CommandType.StoredProcedure
            Command.Parameters.AddWithValue("@dept", myval)
            Command.Parameters.AddWithValue("@Operation", opt)
            Command.Parameters.AddWithValue("@yr", yr)
            Command.Parameters.AddWithValue("@mon", qtr)

        Else
            If emptype = "NS" Then
                Command = New SqlCommand("KPI_GetOPTrecords_NS", con)
                Command.CommandType = CommandType.StoredProcedure
                Command.Parameters.AddWithValue("@dept", myval)
                Command.Parameters.AddWithValue("@Operation", opt)
                Command.Parameters.AddWithValue("@yr", yr)
                Command.Parameters.AddWithValue("@mon", qtr)
            Else
                Command = New SqlCommand("KPI_GetOPTrecords", con)
                Command.CommandType = CommandType.StoredProcedure
                Command.Parameters.AddWithValue("@dept", myval)
                Command.Parameters.AddWithValue("@Operation", opt)
                Command.Parameters.AddWithValue("@yr", yr)
                Command.Parameters.AddWithValue("@st", emptype)
                Command.Parameters.AddWithValue("@mon", qtr)
            End If

        End If
      
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "OTRec")
        GridView1.DataSource = ds1
        GridView1.DataBind()
        'GridView1.Columns(6).Visible = False
        con.Close()
    End Sub

    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        Dim mth = LTrim(RTrim(Session("kpioption1")))
        If mth = "09" Then
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(3).Visible = True
            End If
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(3).Visible = True
            End If
            If e.Row.RowType = DataControlRowType.Footer Then
                e.Row.Cells(3).Visible = True
            End If
        End If
    End Sub


    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        Dim mth = LTrim(RTrim(Session("kpioption1")))
       


        If mth = "04" Then
            e.Row.Cells(3).Visible = True
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = True
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
        ElseIf mth = "05" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = True
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = True
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False

        ElseIf mth = "06" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = True
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = True
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            ' e.Row.Cells(27).Visible = False
        ElseIf mth = "07" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = True
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = True
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            ' e.Row.Cells(27).Visible = False
        ElseIf mth = "08" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = True
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = True
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            ' e.Row.Cells(27).Visible = False

        ElseIf mth = "09" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = True
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = True
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            '  e.Row.Cells(27).Visible = False

        ElseIf mth = "10" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = True
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = True
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            '  e.Row.Cells(27).Visible = False
        ElseIf mth = "11" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = True
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = True
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            '  e.Row.Cells(27).Visible = False
        ElseIf mth = "12" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = True
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = True
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            '  e.Row.Cells(27).Visible = False
        ElseIf mth = "01" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = True
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = True
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = False
            ' e.Row.Cells(27).Visible = False

        ElseIf mth = "02" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = True
            e.Row.Cells(14).Visible = False

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = True
            e.Row.Cells(26).Visible = False
            '   e.Row.Cells(27).Visible = False

        ElseIf mth = "03" Then
            e.Row.Cells(3).Visible = False
            e.Row.Cells(4).Visible = False
            e.Row.Cells(5).Visible = False
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False
            e.Row.Cells(8).Visible = False
            e.Row.Cells(9).Visible = False
            e.Row.Cells(10).Visible = False
            e.Row.Cells(11).Visible = False
            e.Row.Cells(12).Visible = False
            e.Row.Cells(13).Visible = False
            e.Row.Cells(14).Visible = True

            e.Row.Cells(15).Visible = False
            e.Row.Cells(16).Visible = False
            e.Row.Cells(17).Visible = False
            e.Row.Cells(18).Visible = False
            e.Row.Cells(19).Visible = False
            e.Row.Cells(20).Visible = False
            e.Row.Cells(21).Visible = False
            e.Row.Cells(22).Visible = False
            e.Row.Cells(23).Visible = False
            e.Row.Cells(24).Visible = False
            e.Row.Cells(25).Visible = False
            e.Row.Cells(26).Visible = True
            '  e.Row.Cells(27).Visible = False
       
        End If



    End Sub
End Class