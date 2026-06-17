Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO.Path
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class OverallManpowersummary
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Private Sub OverallManpowersummary_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        ''    check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (52)
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
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        GenTable()

    End Sub

    Private Sub GenTable()
        Dim Rows
        Dim Columns
        Dim dsrev As DataSet
        Dim drrev As DataRow

        dsrev = GetDesignationCount()

        Dim dssec As DataSet
        Dim drsec As DataRow

        dssec = Getsectcount()
        Dim columncount, rowcount

        If dsrev.Tables(0).Rows.Count > 0 Then
            drrev = dsrev.Tables(0).Rows(0)
            Rows = drrev("desigtotal").ToString + 2
        Else
            lblmsg.Text = "Designation records are not available"
            Exit Sub
        End If

        If dssec.Tables(0).Rows.Count > 0 Then
            drsec = dssec.Tables(0).Rows(0)
            Columns = drsec("secttotal").ToString + 2
        Else
            lblmsg.Text = "sectionrecords are not available"
            Exit Sub
        End If

        CreateDynamicTable(Rows, Columns)

        lblmsg.Text = MyerrorMsg
        lblmsg.ForeColor = Drawing.Color.Red

    End Sub
    ' Rows property to hold the Rows in the ViewState
    Protected Property Rows() As Integer
        Get
            If Not ViewState("Rows") Is Nothing Then
                Return CInt(Fix(ViewState("Rows")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Rows") = value
        End Set
    End Property
    ' Columns property to hold the Columns in the ViewState
    Protected Property Columns() As Integer
        Get
            If Not ViewState("Columns") Is Nothing Then
                Return CInt(Fix(ViewState("Columns")))
            Else
                Return 0
            End If
        End Get
        Set(ByVal value As Integer)
            ViewState("Columns") = value
        End Set
    End Property
    Private Sub CreateDynamicTable(ByVal Rows As Integer, ByVal columns As Integer)

        Dim desig
        Dim sect
        Dim dept
        Dim deptcount
        Dim dd As DataSet
        Dim ddr As DataRow
        Dim NEWDEPTLIST As New ArrayList
        dd = Getdeptcount()
        If dd.Tables(0).Rows.Count > 0 Then
            ddr = dd.Tables(0).Rows(0)
            deptcount = ddr("dept").ToString
        Else
            deptcount = 0
        End If


        Dim FD As DataSet
        Dim FDR As DataRow
        FD = GetALLcount()

        If FD.Tables(0).Rows.Count > 0 Then
            For s As Integer = 0 To FD.Tables(0).Rows.Count - 1
                FDR = FD.Tables(0).Rows(s)
                NEWDEPTLIST.Add(FDR("departmentcode").ToString)
            Next
        Else
            lblmsg.Text = "dEPT records records are not available"
            Exit Sub
        End If


        Dim ds1 As DataSet
        Dim dr1 As DataRow

        ds1 = Getsectdept()
        Dim SectionList As New ArrayList
        Dim DeptList As New ArrayList


        If ds1.Tables(0).Rows.Count > 0 Then
            For s As Integer = 0 To ds1.Tables(0).Rows.Count - 1
                dr1 = ds1.Tables(0).Rows(s)
                SectionList.Add(dr1("sectioncode").ToString)

                DeptList.Add(dr1("departmentcode").ToString)
            Next
        Else
            lblmsg.Text = "Section records records are not available"
            Exit Sub
        End If



        Dim ds2 As DataSet
        Dim dr2 As DataRow

        ds2 = GetDesignation()
        Dim DesigList As New ArrayList
        Dim designame As New ArrayList

        Dim lenArray = 0
        Dim k As Integer = 0

        If ds2.Tables(0).Rows.Count > 0 Then
            For de As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                dr2 = ds2.Tables(0).Rows(de)
                DesigList.Add(dr2("desigcode").ToString)
                designame.Add(dr2("designationname").ToString)
                lenArray = lenArray + 1
            Next
        Else
            lblmsg.Text = "section not available"
            Exit Sub
        End If

        Dim dsm As DataSet
        dsm = getMpcountbysect()


        PlaceHolder1.Controls.Clear()

        Dim tblRows As Integer = Rows
        Dim tblCols As Integer = columns + deptcount + 1

        Dim tbl As Table = New Table()
        PlaceHolder1.Controls.Add(tbl)

        tbl.BorderWidth = 1
        tbl.BorderStyle = BorderStyle.Solid
        tbl.BorderColor = Drawing.Color.Black
        tbl.CellPadding = 1
        tbl.CellSpacing = 0


        Dim curdept = DeptList.Item(0)
        Dim mydept
        Dim se = 0
        Dim mmcount
        Dim XX = 0

        For i As Integer = 0 To tblCols - 3
            Dim z = 0
            Dim yy = 0
            Dim stat = 0
            Dim tr As TableRow = New TableRow()


            mydept = DeptList.Item(se)

            For j As Integer = 0 To tblRows - 1
                If i <> tblCols - 3 Then  ''''''''''' A
                    If curdept = mydept Then
                        Dim tc As TableCell = New TableCell()
                        Dim label As New Label
                        If j = 0 Then
                            If i = 0 Then
                                label.Text = "Dept"
                            End If
                            If i > 0 Then
                                label.Text = DeptList.Item(se)
                                label.ID = "R" & i & "C" & j
                            End If

                            tc.HorizontalAlign = HorizontalAlign.Center
                            tc.ControlStyle.Font.Bold = True
                            tc.Controls.Add(label)
                            tc.BackColor = Drawing.Color.Beige
                            tr.Cells.Add(tc)
                            tc.BorderWidth = 1
                            tc.HorizontalAlign = HorizontalAlign.Center
                            tc.VerticalAlign = VerticalAlign.Middle

                            tc.ControlStyle.BackColor = Drawing.Color.Beige
                            tc.Font.Bold = True

                        ElseIf j = 1 Then

                            If i = 0 Then
                                label.Text = "sect"
                                tc.HorizontalAlign = HorizontalAlign.Center
                                tc.ControlStyle.Font.Bold = True
                                tc.Controls.Add(label)
                                tc.BackColor = Drawing.Color.Beige
                                tr.Cells.Add(tc)
                                tc.BorderWidth = 1
                                tc.HorizontalAlign = HorizontalAlign.Center
                                tc.VerticalAlign = VerticalAlign.Middle
                                tc.ControlStyle.ForeColor = Drawing.Color.White
                                tc.ControlStyle.BackColor = Drawing.Color.SteelBlue
                                tc.Font.Bold = True
                            End If
                            If i > 0 Then
                                label.Text = SectionList.Item(se)
                                label.ID = "R" & i & "C" & j
                                tc.HorizontalAlign = HorizontalAlign.Center
                                tc.ControlStyle.Font.Bold = True
                                tc.Controls.Add(label)
                                tc.BackColor = Drawing.Color.Beige
                                tr.Cells.Add(tc)
                                tc.BorderWidth = 1
                                tc.HorizontalAlign = HorizontalAlign.Center
                                tc.ControlStyle.ForeColor = Drawing.Color.White
                                tc.ControlStyle.BackColor = Drawing.Color.SteelBlue
                                tc.Font.Bold = True
                            End If


                        ElseIf j > 1 Then
                            If i = 0 Then
                                If k <> lenArray Then
                                    label.Text = DesigList.Item(k)
                                    label.ID = designame.Item(k)
                                    tc.Controls.Add(label)
                                    tr.Cells.Add(tc)
                                    tc.BorderWidth = 1
                                    tc.HorizontalAlign = HorizontalAlign.Center
                                    tc.VerticalAlign = VerticalAlign.Middle
                                    tc.ControlStyle.ForeColor = Drawing.Color.White
                                    tc.ControlStyle.BackColor = Drawing.Color.SteelBlue
                                    k = k + 1
                                End If

                            Else
                                ''''''''''''''''''''''''''''''''''''''''' Get Manpower details ''''''''''''''''''''' #2
                                MyGlobal.Open_Con()
                                MyGlobal.Con_Str()

                                Dim mcount = 0

                                For Each drmp As DataRow In dsm.Tables(0).Select("sectioncode='" & SectionList.Item(se).ToString() & "' and designation='" & designame.Item(j - 2).ToString() & "'")
                                    mcount += 1
                                    label.Text = mcount
                                    tc.Controls.Add(label)
                                    tr.Cells.Add(tc)
                                    tc.BorderWidth = 1
                                    tc.ControlStyle.ForeColor = Drawing.Color.White
                                    tc.ControlStyle.BackColor = Drawing.Color.SteelBlue

                                Next

                                If mcount = 0 Then
                                    label.Text = ""
                                    tc.Controls.Add(label)
                                    tc.BorderWidth = 1
                                    tc.ControlStyle.ForeColor = Drawing.Color.White
                                    tc.ControlStyle.BackColor = Drawing.Color.LightBlue
                                    tr.Cells.Add(tc)
                                End If



                                MyGlobal.db_close()
                            End If
                        End If
                    Else
                        z = 1
                        Dim scount = 0
                        stat = "1"
                        Dim tc As TableCell = New TableCell()
                        Dim label As New Label
                        '  For Each dro As DataRow In dso.Tables(0).Select("departmentcode='" & DeptList.Item(xx).ToString() & "' and designation='" & designame.Item(yy).ToString() & "'")
                        If j = 0 Then
                            label.Text = "TOTAL"
                            tc.Controls.Add(label)
                            tc.BorderWidth = 1
                            tc.ControlStyle.ForeColor = Drawing.Color.Black
                            tc.ControlStyle.BackColor = Drawing.Color.LightGray
                            tr.Cells.Add(tc)
                        ElseIf j = 1 Then
                            label.Text = ""
                            tc.Controls.Add(label)
                            tc.BorderWidth = 1
                            tc.ControlStyle.ForeColor = Drawing.Color.Black
                            tc.ControlStyle.BackColor = Drawing.Color.LightGray
                            tr.Cells.Add(tc)

                        ElseIf j > 1 Then

                            Dim dso As DataSet
                            dso = getMpcountbydept(DeptList.Item(se - 1).ToString(), designame.Item(j - 2).ToString())
                            Dim dro As DataRow
                            dro = dso.Tables(0).Rows(0)
                            If dso.Tables(0).Rows.Count > 0 Then
                                ' MsgBox(DeptList.Item(i - 1).ToString() & "-" & designame.Item(j - 2).ToString & "-" & dro("mpdept").ToString)
                                label.Text = dro("mpdept").ToString
                                tc.Controls.Add(label)
                                tc.BorderWidth = 1
                                tc.ControlStyle.ForeColor = Drawing.Color.Black
                                tc.ControlStyle.BackColor = Drawing.Color.LightGray
                                tr.Cells.Add(tc)
                            Else

                                scount += 1
                                label.Text = 0
                                tc.Controls.Add(label)
                                tc.BorderWidth = 1
                                tc.ControlStyle.ForeColor = Drawing.Color.Black
                                tc.ControlStyle.BackColor = Drawing.Color.LightGray
                                tr.Cells.Add(tc)

                            End If
                        End If
                        ' Next
                        'yy += 1
                    End If
                    If stat = "1" Then
                        yy += 1
                    End If

                Else
                    ''''''''''''''''''''' overall total in last row
                    z = 1
                    Dim scount = 0
                    Dim tc As TableCell = New TableCell()
                    Dim label As New Label
                    If j = 0 Then
                        label.Text = "Overall"
                        tc.Controls.Add(label)
                        tc.BorderWidth = 1
                        tc.ControlStyle.ForeColor = Drawing.Color.Yellow
                        tc.ControlStyle.BackColor = Drawing.Color.OrangeRed
                        tr.Cells.Add(tc)
                    ElseIf j = 1 Then
                        label.Text = "TOTAL"
                        tc.Controls.Add(label)
                        tc.BorderWidth = 1
                        tc.ControlStyle.ForeColor = Drawing.Color.Yellow
                        tc.ControlStyle.BackColor = Drawing.Color.OrangeRed
                        tr.Cells.Add(tc)
                    ElseIf j > 1 Then

                        Dim dso1 As DataSet
                        dso1 = Getmpcount(designame.Item(j - 2).ToString())
                        Dim dro1 As DataRow
                        dro1 = dso1.Tables(0).Rows(0)
                        If dso1.Tables(0).Rows.Count > 0 Then
                            label.Text = dro1("mpdept").ToString
                            tc.Controls.Add(label)
                            tc.BorderWidth = 1
                            tc.ControlStyle.ForeColor = Drawing.Color.Yellow
                            tc.ControlStyle.BackColor = Drawing.Color.OrangeRed
                            tr.Cells.Add(tc)
                        Else

                            scount += 1
                            label.Text = 0
                            tc.Controls.Add(label)
                            tc.BorderWidth = 1
                            tc.ControlStyle.ForeColor = Drawing.Color.Yellow
                            tc.ControlStyle.BackColor = Drawing.Color.OrangeRed
                            tr.Cells.Add(tc)

                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''
                End If  ''''''''''' A
            Next j
            If stat = "1" Then
                XX += 1
            End If

            curdept = mydept
            se = (se + 1) - z
            tbl.Rows.Add(tr)

        Next i

        ViewState("dynamictable") = True
    End Sub
    Function getMpcountbysect() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Hrmis_Mpcount", con)
        Command.CommandType = CommandType.StoredProcedure
        'Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empsystems")
        con.Close()
        Return ds
    End Function
    Function getMpcountbydept(ByVal dept As String, ByVal desig As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Hrmis_Mpcount1", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@DEPT", dept)
        Command.Parameters.AddWithValue("@desig", desig)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empsystems")
        con.Close()
        Return ds
    End Function
    Function GetDesignationCount() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select count(*) as Desigtotal from designation", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Function Getsectcount() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select count(*) as secttotal from sectionmaster", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Function GetDesignation() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("hrmis_getdesig", con)
        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "desig")
        con.Close()
        Return ds
    End Function
    Function Getsectdept() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("hrmis_getsect", con)
        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "sect")
        con.Close()
        Return ds
    End Function
    Function Getdeptcount() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("hrmis_getdept", con)
        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "sect")
        con.Close()
        Return ds
    End Function
    Function GetALLcount() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("HRMIS_GETDEPTNAME ", con)
        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "sect")
        con.Close()
        Return ds
    End Function
    Function Getmpcount(ByVal desig As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Hrmis_Mpcountall", con)
        Command.Parameters.AddWithValue("@desig", desig)
        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "sect")
        con.Close()
        Return ds
    End Function
End Class