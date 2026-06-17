Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class MWClinicPassApprovals
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim cancfwd As String
    Dim appno As String
    Protected comp As String
    Dim ds1 As New DataSet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        thisdate = DateTime.Now
        MyApp.GetfiscalYear()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (308)
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
        Con.Close()


        ''''' ******* MARUWA MALAYSIA CODING

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Getempdetails("MMSB")
        Dim dr1 As DataRow
        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            getdesigname(Session("Udesig"))
            Dim dcode
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcode = dr("desigcode").ToString.Trim
                    Session("dcode") = dcode
                End If
            End If
            If Not IsPostBack Then
                If dcode = "EA" Or dcode = "MD" Or dcode = "GM" Or dcode = "DGM" Or dcode = "PL Man" Or dcode = "SGM" Or dcode = "SPM" Then
                    BindGrid("MMSB")
                Else
                    GetHeadDept("MMSB")
                End If
            End If
            GridMMSB.Visible = True
        Else
            GridMMSB.Visible = False
        End If
        Con.Close()
        ds1.Clear()
        ''''' ******* MARUWA MELAKA CODING
        MyGlobal.Open_Con_mel()
        MyGlobal.Con_Str()
        Getempdetails("MEL")
        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            '''
            getdesigname(Session("Udesig"))
            Dim dcodeMEL
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcodeMEL = dr("desigcode").ToString.Trim
                    Session("dcodeMEL") = dcodeMEL
                End If
            End If
            If Not IsPostBack Then
                If dcodeMEL = "EA" Or dcodeMEL = "MD" Or dcodeMEL = "GM" Or dcodeMEL = "DGM" Or dcodeMEL = "PL Man" Or dcodeMEL = "SGM" Or dcodeMEL = "SPM" Then
                    BindGrid("MEL")
                Else
                    GetHeadDept("MEL")
                End If
            End If
            GRIDMEL.Visible = True
        Else
            GRIDMEL.Visible = False
        End If
        Con.Close()
        ds1.Clear()
        ''''' ******* MARUWA LIGHTING CODING
        MyGlobal.Open_Con_lit()
        MyGlobal.Con_Str()
        Getempdetails("MLG")
        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            ''
            getdesigname(Session("Udesig"))
            Dim dcodelig
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcodelig = dr("desigcode").ToString.Trim
                    Session("dcodeLIG") = dcodelig
                End If
            End If
            If Not IsPostBack Then
                If dcodelig = "EA" Or dcodelig = "MD" Or dcodelig = "GM" Or dcodelig = "DGM" Or dcodelig = "PL Man" Or dcodelig = "SGM" Or dcodelig = "SPM" Then
                    BindGrid("MLG")
                Else
                    GetHeadDept("MLG")
                End If
            End If
            GRIDLIG.Visible = True
        Else
            GRIDLIG.Visible = False
        End If

        Con.Close()
        ds1.Clear()

        ''''' ******* MARUWA OUTSOURCE CODING
        MyGlobal.Open_Con_out()
        MyGlobal.Con_Str()

        Getempdetails("MOU")

        If ds1.Tables(0).Rows.Count > 0 Then
            dr1 = ds1.Tables(0).Rows(0)
            Session("Udesig") = dr1("designation").ToString
            Session("Udept") = dr1("departmentcode").ToString
            ''
            getdesigname(Session("Udesig"))
            Dim dcodeOS
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    dcodeOS = dr("desigcode").ToString.Trim
                    Session("dcodeOS") = dcodeOS
                End If
            End If

            If Not IsPostBack Then
                If dcodeOS = "EA" Or dcodeOS = "MD" Or dcodeOS = "GM" Or dcodeOS = "DGM" Or dcodeOS = "PL Man" Or dcodeOS = "SGM" Or dcodeOS = "SPM" Then
                    BindGrid("MOU")
                Else
                    GetHeadDept("MOU")
                End If
            End If
            GRIDOS.Visible = True
        Else
            GRIDOS.Visible = False
        End If
        Con.Close()
    End Sub
    Private Sub GetHeadDept(ByVal comp As String)
        Dim dsh As DataSet
        Dim drh As DataRow
        Dim headdept, mydept
        dsh = GetHeadAssignment(comp)
        If dsh.Tables(0).Rows.Count > 0 Then
            drh = dsh.Tables(0).Rows(0)
            mydept = drh("ldepartmentcode").ToString
            Dim hoddepts = mydept.split(",")
            For i As Integer = 0 To hoddepts.Length - 1
                headdept = headdept & "'" & hoddepts(i) & "',"
            Next
            headdept = headdept.remove(headdept.length - 1, 1)
        Else
            headdept = "'" & Session("Udept") & "'"
        End If
        BindGridhod(headdept, comp)
    End Sub
    Function GetHeadAssignment(ByVal comp As String) As DataSet
        Dim conn
        Dim con
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        If comp = "MMSB" Then
            con = New SqlConnection(constr)
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
        End If
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from head_assignment_emanagement where empcode ='" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
    Private Sub BindGridhod(ByVal dept As String, ByVal comp As String)
        Dim conn
        Dim con
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        If comp = "MMSB" Then
            con = New SqlConnection(constr)
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
        End If
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT clinicstaffgatepass.passno, clinicstaffgatepass.empcode, clinicstaffgatepass.department, clinicstaffgatepass.category, clinicstaffgatepass.sect, clinicstaffgatepass.status, clinicstaffgatepass.dateapplied, clinicstaffgatepass.etimeout, clinicstaffgatepass.etimein, clinicstaffgatepass.sickness, empmaster.empname  FROM clinicstaffgatepass CROSS JOIN empmaster inner join designation as designation on empmaster.designation = designation.designationname  WHERE (empmaster.departmentcode in (" & dept & ") ) AND (clinicstaffgatepass.status = 'S') and empmaster.empcode <> '" & Session("empcode") & "' and (dlevel < '4') AND  clinicstaffgatepass.empcode = empmaster.empcode ORDER BY clinicstaffgatepass.passno DESC", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "CPaPPROVALShod")
        If comp = "MEL" Then
            GridMEL.DataSource = ds
            GridMEL.DataBind()
        ElseIf comp = "MLG" Then
            GridLig.DataSource = ds
            GridLig.DataBind()
        ElseIf comp = "MOU" Then
            GridOS.DataSource = ds
            GridOS.DataBind()
        ElseIf comp = "MMSB" Then
            GridMMSB.DataSource = ds
            GridMMSB.DataBind()
        End If
        con.Close()
    End Sub
    Private Sub BindGrid(ByVal comp As String)

        Dim conn
        Dim con
        Dim ddcode
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        If comp = "MMSB" Then
            con = New SqlConnection(constr)
            ddcode = Session("dcode")
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
            ddcode = Session("dcodeMel")
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
            ddcode = Session("dcodelig")
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
            ddcode = Session("dcodeos")
        End If
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("CpApproval", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@stat", ddcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "HOdLEave")
        If comp = "MEL" Then
            GRIDMEL.DataSource = ds
            GRIDMEL.DataBind()
        ElseIf comp = "MLG" Then
            GRIDLIG.DataSource = ds
            GRIDLIG.DataBind()
        ElseIf comp = "MOU" Then
            GRIDOS.DataSource = ds
            GRIDOS.DataBind()
        ElseIf comp = "MMSB" Then
            GridMMSB.DataSource = ds
            GridMMSB.DataBind()
        End If
        con.Close()
    End Sub
    Function Getempdetails(ByVal comp As String) As DataSet
        Dim conn
        Dim con
        MyGlobal.Con_Str()

        If comp = "MMSB" Then
            con = New SqlConnection(constr)
        ElseIf comp = "MEL" Then
            con = New SqlConnection(con_mel)
        ElseIf comp = "MLG" Then
            con = New SqlConnection(con_lig)
        ElseIf comp = "MOU" Then
            con = New SqlConnection(con_os)
        End If
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from empmaster where empcode ='" & Session("empcode") & "' and resigned = 'N'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "emp")
        con.Close()
        Return ds1

    End Function

    Private Sub gridmmsb_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridMMSB.PageIndexChanging
        If Session("dcode") = "EA" Or Session("dcode") = "MD" Or Session("dcode") = "GM" Or Session("dcode") = "DGM" Or Session("dcode") = "PL Man" Or Session("dcode") = "SGM" Or Session("dcode") = "SPM" Then
            BindGrid("MMSB")
        Else
            GetHeadDept("MMSB")
        End If
        GridMMSB.PageIndex = e.NewPageIndex
        GridMMSB.DataBind()
    End Sub

    Private Sub GridMEL_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridMEL.PageIndexChanging
        If Session("dcodemel") = "EA" Or Session("dcodemel") = "MD" Or Session("dcodemel") = "GM" Or Session("dcodemel") = "DGM" Or Session("dcodemel") = "PL Man" Or Session("dcode") = "SGM" Or Session("dcode") = "SPM" Then
            BindGrid("MEL")
        Else
            GetHeadDept("MEL")
        End If
        GridMEL.PageIndex = e.NewPageIndex
        GridMEL.DataBind()
    End Sub

    Private Sub GridLig_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridLIG.PageIndexChanging
        If Session("dcodeLIG") = "EA" Or Session("dcodeLIG") = "MD" Or Session("dcodeLIG") = "GM" Or Session("dcodeLIG") = "DGM" Or Session("dcodeLIG") = "PL Man" Or Session("dcode") = "SGM" Or Session("dcode") = "SPM" Then
            BindGrid("MLG")
        Else
            GetHeadDept("MLG")
        End If
        GridLig.PageIndex = e.NewPageIndex
        GridLig.DataBind()
    End Sub

    Private Sub GridOS_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridOS.PageIndexChanging
        If Session("dcodeOS") = "EA" Or Session("dcodeOS") = "MD" Or Session("dcodeOS") = "GM" Or Session("dcodeOS") = "DGM" Or Session("dcodeOS") = "PL Man" Or Session("dcode") = "SGM" Or Session("dcode") = "SPM" Then
            BindGrid("MOU")
        Else
            GetHeadDept("MOU")
        End If
        GridOS.PageIndex = e.NewPageIndex
        GridOS.DataBind()
    End Sub

    Public Sub UpdateclinicApprovalMMSB(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridMMSB.Rows.Count - 1
            Dim passno As String = GridMMSB.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridMMSB.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If status = "A" Then
                DS = Open_clinic(Con, DAP, 2, "update clinicstaffgatepass set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approveddate = getdate()  where passno = '" & passno & "'")
            End If
            MyGlobal.db_close()
        Next
        GetHeadDept("MMSB")
        GridMMSB.DataBind()
    End Sub
    Public Sub UpdateclinicApprovalmel(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridMEL.Rows.Count - 1
            Dim passno As String = GridMEL.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridMEL.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con_mel()
            MyGlobal.Con_Str()
            If status = "A" Then
                DS = Open_clinic(Con, DAP, 2, "update clinicstaffgatepass set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approveddate = getdate()  where passno = '" & passno & "'")
            End If
            MyGlobal.db_close()
        Next
        GetHeadDept("MEL")
        GridMEL.DataBind()
    End Sub
    Public Sub UpdateclinicApprovallig(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridLIG.Rows.Count - 1
            Dim passno As String = GridLIG.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridLIG.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con_lit()
            MyGlobal.Con_Str()
            If status = "A" Then
                DS = Open_clinic(Con, DAP, 2, "update clinicstaffgatepass set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approveddate = getdate()  where passno = '" & passno & "'")
            End If
            MyGlobal.db_close()
        Next
        GetHeadDept("MLG")
        GridLIG.DataBind()

    End Sub
    Public Sub UpdateclinicApprovalOS(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridOS.Rows.Count - 1
            Dim passno As String = GridOS.Rows(i).Cells(0).Text
            Dim status As String = DirectCast(GridOS.Rows(i).FindControl("rbstatus"), RadioButtonList).SelectedValue
            MyGlobal.Open_Con_out()
            MyGlobal.Con_Str()
            If status = "A" Then
                DS = Open_clinic(Con, DAP, 2, "update clinicstaffgatepass set status = '" & status & "', approvedby = '" & Session("empcode") & "' ,approveddate = getdate()  where passno = '" & passno & "'")
            End If
            MyGlobal.db_close()
        Next
        GetHeadDept("MOU")
        GridOS.DataBind()
    End Sub

    Protected Sub searchgridapp(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click, ImageButton2.Click
        Dim str
        str = Txtsearchapp.Text.Trim
        If str <> "" Then
            For n As Integer = 0 To GridMMSB.Rows.Count - 1
                Dim lbn As String = GridMMSB.Rows(n).Cells(1).Text
                Dim empname As String = GridMMSB.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridMMSB.Rows(n).Focus()
                    GridMMSB.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridMMSB.Rows(n).BackColor = Drawing.Color.White
                End If
            Next


            For n As Integer = 0 To GridMEL.Rows.Count - 1
                Dim lbn As String = GridMEL.Rows(n).Cells(1).Text
                Dim empname As String = GridMEL.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridMEL.Rows(n).Focus()
                    GridMEL.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridMEL.Rows(n).BackColor = Drawing.Color.White
                End If
            Next

            For n As Integer = 0 To GridLIG.Rows.Count - 1
                Dim lbn As String = GridLIG.Rows(n).Cells(1).Text
                Dim empname As String = GridLIG.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridLIG.Rows(n).Focus()
                    GridLIG.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridLIG.Rows(n).BackColor = Drawing.Color.White
                End If
            Next

            For n As Integer = 0 To GridOS.Rows.Count - 1
                Dim lbn As String = GridOS.Rows(n).Cells(1).Text
                Dim empname As String = GridOS.Rows(n).Cells(2).Text
                If lbn.ToString.ToLower.Contains(str.ToString.ToLower) = True Or empname.ToString.ToLower.Contains(str.ToString.ToLower) = True Then
                    GridOS.Rows(n).Focus()
                    GridOS.Rows(n).BackColor = Drawing.Color.Orange
                Else
                    GridOS.Rows(n).BackColor = Drawing.Color.White
                End If
            Next
        End If
    End Sub

    Protected Sub rbOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOption.SelectedIndexChanged
        If rbOption.SelectedValue = "HA" Then
            PNLMMSB.Visible = True
            PNLMEL.Visible = False
            PNLLIG.Visible = False
            PNLOS.Visible = False
        ElseIf rbOption.SelectedValue = "LA" Then
            PNLMMSB.Visible = False
            PNLMEL.Visible = False
            PNLLIG.Visible = True
            PNLOS.Visible = False
        ElseIf rbOption.SelectedValue = "OA" Then
            PNLMMSB.Visible = False
            PNLMEL.Visible = False
            PNLLIG.Visible = False
            PNLOS.Visible = True
        ElseIf rbOption.SelectedValue = "MA" Then
            PNLMMSB.Visible = False
            PNLMEL.Visible = True
            PNLLIG.Visible = False
            PNLOS.Visible = False
        Else
            PNLMMSB.Visible = True
            PNLMEL.Visible = True
            PNLLIG.Visible = True
            PNLOS.Visible = True
        End If
    End Sub
End Class