Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class domesticwastereport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (231)
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

        If rb1.SelectedValue = "4" Then
            supplier.Enabled = False
            items.Enabled = False
            'DropDownList1.Enabled = False
            'DropDownList2.Enabled = False

            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
        End If
    End Sub
    Protected Sub show_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles show.Click

        If rb1.SelectedValue = "2" Then              'supplier
            If supplier.SelectedValue = "-1" Then
                MessageBox("Select Supplier")
                supplier.Focus()
                Exit Sub
            End If

            Session("supplier") = "SELECT *,Safety_dispossaldetails.consignmentno AS Expr1, Safety_dispossaldetails.dispossalqty AS Expr2, Safety_dispossal.datedispossal AS Expr3,Safety_dispossaldetails.suppliername AS Expr4,Safety_dispossaldetails.major AS Expr5,Safety_dispossaldetails.items AS Expr6,Safety_dispossaldetails.pono AS Expr7 FROM Safety_dispossal INNER JOIN Safety_dispossaldetails ON Safety_dispossal.requestno = Safety_dispossaldetails.requestno WHERE (Safety_dispossaldetails.suppliername = '" & supplier.SelectedItem.Text.Trim & "')"
            Response.Redirect("domesticwastereportsuppliergrid.aspx")

        Else
            If fromdate.Text = "From date" Or fromdate.Text = "" Then
                MessageBox("Select From Date")
                fromdate.Text = ""
                fromdate.Focus()
                Exit Sub
            End If

            If todate.Text = "To date" Or todate.Text = "" Then
                MessageBox("Select To Date")
                todate.Text = ""
                todate.Focus()
                Exit Sub
            End If

            Dim fd1 As String                 'Date conversion
            fd1 = fromdate.Text.Trim
            Dim strdate() As String = fd1.Split("/"c)
            fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            Dim fd As Date
            fd = CDate(fd1)
            Session("allfromd") = fd

            Dim td1 As String
            td1 = todate.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            Dim td As Date
            td = CDate(td1)
            Session("alltod") = td

            If rb1.SelectedValue = "3" Then               'items
                If items.SelectedValue = "-1" Then
                    MessageBox("Select Item")
                    items.Focus()
                    Exit Sub
                End If
                Session("msr") = "select measurement from safety_schedulemaster where Item='" & items.SelectedItem.Text.Trim & "'"
                Session("items") = "SELECT *,Safety_dispossaldetails.consignmentno AS Expr1, Safety_dispossaldetails.dispossalqty AS Expr2, Safety_dispossal.datedispossal AS Expr3,Safety_dispossaldetails.suppliername AS Expr4,Safety_dispossaldetails.pono AS Expr5 FROM Safety_dispossal INNER JOIN Safety_dispossaldetails ON Safety_dispossal.requestno = Safety_dispossaldetails.requestno WHERE (Safety_dispossaldetails.items = '" & items.SelectedItem.Text.Trim & "') and (Safety_dispossal.datedispossal >='" & fd & "' and Safety_dispossal.datedispossal <='" & td & "')"
                Response.Redirect("domesticwastereportgrid.aspx")


            ElseIf rb1.SelectedValue = "0" Then                 'by department
                Response.Redirect("")


            ElseIf rb1.SelectedValue = "1" Then                  'by overall department(weight)
                getdeptsum()
                Response.Redirect("SchedDomWasteByDeptWeightRpt.aspx")


            ElseIf rb1.SelectedValue = "4" Then                  'by overall
                getoverallsum()

                Response.Redirect("SchedDomWasteOverallRpt.aspx")


            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged
        If rb1.SelectedValue = "2" Then
            supplier.Enabled = True
            supplier.Focus()
            items.Enabled = False
            'DropDownList1.Enabled = False
            'DropDownList2.Enabled = False
            fromdate.Text = ""
            todate.Text = ""
            fromdate.Enabled = False
            todate.Enabled = False
        ElseIf rb1.SelectedValue = "3" Then
            supplier.Enabled = False
            items.Enabled = True
            items.Focus()
            'DropDownList1.Enabled = False
            'DropDownList2.Enabled = False
            fromdate.Enabled = True
            todate.Enabled = True
        ElseIf rb1.SelectedValue = "4" Or rb1.SelectedValue = "1" Then
            supplier.Enabled = False
            items.Enabled = False
            'DropDownList1.Enabled = False
            'DropDownList2.Enabled = False
            fromdate.Enabled = True
            todate.Enabled = True
        ElseIf rb1.SelectedValue = "0" Then
            supplier.Enabled = False
            items.Enabled = False
            'DropDownList1.Enabled = True
            'DropDownList2.Enabled = True
            fromdate.Enabled = True
            todate.Enabled = True
            'DropDownList1.Focus()
        End If
    End Sub
    Private Sub getdeptsum()

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()


        Dim con As New SqlConnection(constr)
        con.Open()
        Cmd = New SqlCommand("delete from sdw_rptbyweight_temp", con)
        Cmd.ExecuteNonQuery()

        Dim totweightD
        Dim totweightS

        Dim fd1 As String
        fd1 = fromdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd

        Dim td1 As String
        td1 = todate.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td

        Dim dept
        Dim ds As DataSet
        Dim dr As DataRow
        MyGlobal.Con_Str()
        MyGlobal.Open_Con()
        ds = Open_Department(Con, DAP, 2, "select departmentcode from department")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim i
            For i = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                'dr = ds.Tables(0).Rows(0)
                dept = dr("departmentcode").ToString

                'messagebox(dept)

                'Dim dssafety As DataSet
                'Dim dr3 As DataRow
                'Dim major
                'MyGlobal.Con_Str()
                'MyGlobal.Open_Con()
                'dssafety = Open_DomwasteCons(con, DAP, 2, "select majortype from Safety_domesticwasteconsignment")
                'If dssafety.Tables(0).Rows.Count > 0 Then
                '    dr3 = dssafety.Tables(0).Rows(0)
                '    major = dr3("majortype").ToString
                'End If

                '  If major = "Domestic Waste" Then

                getSWDsum_DWdet(dept, fd, td)
                'Dim dsdata As DataSet
                Dim dr1 As DataRow
                MyGlobal.Con_Str()
                If recstatus = True Then
                    If dsdata.Tables(0).Rows.Count > 0 Then
                        dr1 = dsdata.Tables(0).Rows(0)
                        totweightD = dr1("totweightD").ToString
                    End If
                End If
                If totweightD = "" Then
                    totweightD = "0"
                End If
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("insert into sdw_rptbyweight_temp (dept,majortype,totalS,totalD,fromdate,todate) values('" & dept & "','Domestic Waste','0','" & totweightD & "','" & fd & "','" & td & "')", conn)

                    Cmd.ExecuteNonQuery()

                Catch ex As SqlException
                    MessageBox(ex.Message)

                End Try


                '  ElseIf major = "Schedule Waste" Then
                getSWDsum_SWdet(dept, fd, td)
                '  Dim ds2 As DataSet
                Dim dr2 As DataRow
                MyGlobal.Con_Str()
                'dr2 = dsdata.Tables(0).Rows(0)
                If recstatus = True Then
                    If dsdata.Tables(0).Rows.Count > 0 Then
                        dr2 = dsdata.Tables(0).Rows(0)
                        totweightS = dr2("totweightS").ToString
                    End If
                End If
                If totweightS = "" Then
                    totweightS = "0"
                End If
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    ' Cmd = New SqlCommand("insert into sdw_rptbyweight_temp (dept,majortype,totalS,totalD) values('" & dept & "','Schedule Waste','" & totweightS & "','--')", conn)
                    Cmd = New SqlCommand("update sdw_rptbyweight_temp set totalS = '" & totweightS & "' where dept = '" & dept & "'", conn)

                    Cmd.ExecuteNonQuery()

                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try
                '  End If
            Next

        End If
        
    End Sub
    Private Sub getoverallsum()
        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        con.Open()
        Cmd = New SqlCommand("delete from sdw_rptoverall_temp", con)
        Cmd.ExecuteNonQuery()

        Dim totweightD
        Dim totweightS

        Dim fd1 As String
        fd1 = fromdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("allfromd") = fd

        Dim td1 As String
        td1 = todate.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("alltod") = td

        Dim dept
        Dim ds As DataSet
        Dim dr As DataRow
        MyGlobal.Con_Str()
        MyGlobal.Open_Con()
        ds = Open_Department(con, DAP, 2, "select departmentcode from department")
        If ds.Tables(0).Rows.Count > 0 Then
            Dim i
            For i = 0 To ds.Tables(0).Rows.Count - 1
                dr = ds.Tables(0).Rows(i)
                dept = dr("departmentcode").ToString

                Dim itemsD
                'Dim dr6 As DataRow
                MyGlobal.Con_Str()
                MyGlobal.Open_Con()
                'dssafety = Open_Domwasteitem(con, DAP, 2, "select distinct items from safety_domesticwasteconsignmentdetails")
                'If dssafety.Tables(0).Rows.Count > 0 Then
                '    Dim j
                '    For j = 0 To dssafety.Tables(0).Rows.Count - 1
                '        dr6 = dssafety.Tables(0).Rows(j)
                '        itemsD = dr6("items").ToString

                dssafety = getSWDsum_DWitems(dept, fd, td, "Rubbish")
                Dim dr1 As DataRow

                If dssafety.Tables(0).Rows.Count > 0 Then
                    dr1 = dssafety.Tables(0).Rows(0)
                    If Not dr1("totweightD") Is System.DBNull.Value Then
                        totweightD = dr1("totweightD").ToString
                    Else
                        totweightD = "0"
                    End If
                    If totweightD = "" Then
                        totweightD = "0"
                    End If
                Else
                    totweightD = "0"
                End If
                Try
                    Dim rubbish = totweightD
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("insert into sdw_rptoverall_temp (dept,fromdate,todate,rubbish) values('" & dept & "','" & fd & "','" & td & "','" & rubbish & "')", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim dssafety1 As DataSet
                'Dim dr2 As DataRow
                dssafety1 = getSWDsum_DWitems(dept, fd, td, "Paper")

                If dssafety1.Tables(0).Rows.Count > 0 Then
                    dr1 = dssafety1.Tables(0).Rows(0)
                    If Not dr1("totweightD") Is System.DBNull.Value Then
                        totweightD = dr1("totweightD").ToString
                    Else
                        totweightD = "0"
                    End If
                    If totweightD = "" Then
                        totweightD = "0"
                    End If
                Else
                    totweightD = "0"
                End If

                Try
                    Dim paper = totweightD
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set paper = '" & paper & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim dssafety2 As DataSet
                dssafety2 = getSWDsum_DWitems(dept, fd, td, "Metal")

                If dssafety2.Tables(0).Rows.Count > 0 Then
                    dr1 = dssafety2.Tables(0).Rows(0)
                    If Not dr1("totweightD") Is System.DBNull.Value Then
                        totweightD = dr1("totweightD").ToString
                    Else
                        totweightD = "0"
                    End If
                    If totweightD = "" Then
                        totweightD = "0"
                    End If
                Else
                    totweightD = "0"
                End If

                Dim metal = totweightD
                Try
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set metal = '" & metal & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim dssafety3 As DataSet
                dssafety3 = getSWDsum_DWitems(dept, fd, td, "SW410")

                If dssafety3.Tables(0).Rows.Count > 0 Then
                    dr1 = dssafety3.Tables(0).Rows(0)
                    If Not dr1("totweightD") Is System.DBNull.Value Then
                        totweightD = dr1("totweightD").ToString
                    Else
                        totweightD = "0"
                    End If
                    If totweightD = "" Then
                        totweightD = "0"
                    End If
                Else
                    totweightD = "0"
                End If

                Dim sw410 = totweightD
                Try
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set sw410 = '" & sw410 & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try
              


                Dim dssafety4 As DataSet
                dssafety4 = getSWDsum_DWitems(dept, fd, td, "Plastic")

                If dssafety4.Tables(0).Rows.Count > 0 Then
                    dr1 = dssafety4.Tables(0).Rows(0)
                    If Not dr1("totweightD") Is System.DBNull.Value Then
                        totweightD = dr1("totweightD").ToString
                    Else
                        totweightD = "0"
                    End If
                    If totweightD = "" Then
                        totweightD = "0"
                    End If
                Else
                    totweightD = "0"
                End If

                Dim plastic = totweightD
                Try
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set plastic = '" & plastic & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim dssafety5 As DataSet
                dssafety5 = getSWDsum_DWitems(dept, fd, td, "Carton")

                If dssafety5.Tables(0).Rows.Count > 0 Then
                    dr1 = dssafety5.Tables(0).Rows(0)
                    If Not dr1("totweightD") Is System.DBNull.Value Then
                        totweightD = dr1("totweightD").ToString
                    Else
                        totweightD = "0"
                    End If
                    If totweightD = "" Then
                        totweightD = "0"
                    End If
                Else
                    totweightD = "0"
                End If

                Dim carton = totweightD
                Try
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set carton = '" & carton & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try




                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim itemsS
                MyGlobal.Con_Str()
                MyGlobal.Open_Con()

                Dim ds11 As DataSet
                ds11 = getSWDsum_SWitems(dept, fd, td, "Waste Slurry")

                If ds11.Tables(0).Rows.Count > 0 Then
                    dr1 = ds11.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If

                Try
                    Dim ws = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set wasteslurry = '" & ws & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try




                Dim ds12 As DataSet
                ds12 = getSWDsum_SWitems(dept, fd, td, "Waste Colour")

                If ds12.Tables(0).Rows.Count > 0 Then
                    dr1 = ds12.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If

                Try
                    Dim wc = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set wastecolour = '" & wc & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try




                Dim ds13 As DataSet
                ds13 = getSWDsum_SWitems(dept, fd, td, "Waste Sludge")

                If ds13.Tables(0).Rows.Count > 0 Then
                    dr1 = ds13.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If

                Try
                    Dim wsl = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set wastesludge = '" & wsl & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim ds14 As DataSet
                ds14 = getSWDsum_SWitems(dept, fd, td, "Scarp Product(Before Firing)")

                If ds14.Tables(0).Rows.Count > 0 Then
                    dr1 = ds14.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If
                Try
                    Dim sp = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set scrapproduct = '" & sp & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim ds15 As DataSet
                ds15 = getSWDsum_SWitems(dept, fd, td, "Waste Oil")

                If ds15.Tables(0).Rows.Count > 0 Then
                    dr1 = ds15.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If

                Try
                    Dim wo = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set wasteoil = '" & wo & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim ds16 As DataSet
                ds16 = getSWDsum_SWitems(dept, fd, td, "Contaminate Waste")

                If ds16.Tables(0).Rows.Count > 0 Then
                    dr1 = ds16.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If
                Try
                    Dim cw = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set contwaste = '" & cw & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



                Dim ds17 As DataSet
                ds17 = getSWDsum_SWitems(dept, fd, td, "Solvent")

                If ds17.Tables(0).Rows.Count > 0 Then
                    dr1 = ds17.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If

                Try
                    Dim sol = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set solvent = '" & sol & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try
           

                Dim ds18 As DataSet
                ds18 = getSWDsum_SWitems(dept, fd, td, "Empty Drum")

                If ds18.Tables(0).Rows.Count > 0 Then
                    dr1 = ds18.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If

                Try
                    Dim ed = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set emptydrum = '" & ed & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try




                Dim ds19 As DataSet
                ds19 = getSWDsum_SWitems(dept, fd, td, "Electronic Waste")

                If ds19.Tables(0).Rows.Count > 0 Then
                    dr1 = ds19.Tables(0).Rows(0)
                    If Not dr1("totweightS") Is System.DBNull.Value Then
                        totweightS = dr1("totweightS").ToString
                    Else
                        totweightS = "0"
                    End If
                    If totweightS = "" Then
                        totweightS = "0"
                    End If
                Else
                    totweightS = "0"
                End If

                Try
                    Dim ew = totweightS
                    Dim conn As New SqlConnection(constr)
                    conn.Open()
                    Cmd = New SqlCommand("update sdw_rptoverall_temp set electronicwaste = '" & ew & "' where dept='" & dept & "'", conn)
                    Cmd.ExecuteNonQuery()
                Catch ex As SqlException
                    MessageBox(ex.Message)
                End Try



            Next

        End If
    End Sub

    Function getSWDsum_DWitems(ByVal dept As String, ByVal fd As Date, ByVal td As Date, ByVal itemsD As String) As DataSet
        SQLstat = "SELECT sum(weight) as totweightD FROM Safety_domesticwasteconsignment,Safety_domesticwasteconsignmentdetails where majortype= 'Domestic Waste' and dept='" & dept & "' and dateapplied > '" & fd & "' and dateapplied < '" & td & "' and items = '" & itemsD & "' and Safety_domesticwasteconsignment.recordno = Safety_domesticwasteconsignmentdetails.recordno"

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(SQLstat, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function
    Function getSWDsum_SWitems(ByVal dept As String, ByVal fd As Date, ByVal td As Date, ByVal itemsS As String) As DataSet
        SQLstat = "SELECT sum(weight) as totweightS FROM Safety_domesticwasteconsignment,Safety_schedulewasteconsignmentdetails where majortype= 'Schedule Waste' and dept='" & dept & "' and dateapplied > '" & fd & "' and dateapplied < '" & td & "' and items = '" & itemsS & "' and Safety_domesticwasteconsignment.recordno = Safety_schedulewasteconsignmentdetails.recordno"

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(SQLstat, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function


End Class