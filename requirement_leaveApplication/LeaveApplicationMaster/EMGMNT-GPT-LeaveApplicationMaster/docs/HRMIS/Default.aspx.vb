Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.emanagement.[Global]
Imports System.IO

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim Mynet As New emanagement.netglobal
    Dim a
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim message As String = "Some Employees Probationary or Contract is going to over. Do You want to see the details!!!"
        'Dim sb As New System.Text.StringBuilder()
        'sb.Append("<script type = 'text/javascript'>")
        'sb.Append("window.onload=function(){")
        'sb.Append("return confirm('")
        'sb.Append(message)
        'sb.Append("')};")
        'sb.Append("</script>")
        'ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        GetEmpVehino(Session("empcode"))
        lblecode.Text = Session("empcode")
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                lblename.Text = dr("empname").ToString
                lblsect.Text = dr("sectioncode").ToString + "-" + dr("sectionname").ToString
                lbldept.Text = dr("departmentcode").ToString + "-" + dr("departmentname").ToString
                lbldesig.Text = dr("designation").ToString
                Session("desgtmp") = dr("designation").ToString
            End If
        End If
        RaiseappraisalAlert()
    End Sub
    Public Sub RaiseappraisalAlert()
        Dim SqlText
        Dim category = Session("_ecategory")
        getdesigname(Session("_edesig"))
        Dim dsa As DataSet
        Dim dra As DataRow
        Dim dcode

        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                dcode = dr("desigcode").ToString.Trim
                Session("dcode") = dcode
            End If
        End If

        If Session("empcode") = "014623" Then
            SqlText = "hrmis_GetExpiryDetails"
            dsa = getExpiryList(SqlText)
        End If

        If dcode = "EA" Then
            SqlText = "hrmis_GetExpiryDetails"
            dsa = getExpiryList(SqlText)

        ElseIf dcode = "MD" Or dcode = "GM" Or dcode = "DGM" Or dcode = "VGM" Or dcode = "PL Man" Or dcode = "SGM" Or dcode = "SPM" Then
            SqlText = "hrmis_GetExpiryDetails"
            dsa = getExpiryList(SqlText)
        End If

        'If category = "Department Head" Or category = "departmenthead" Then
        '    SqlText = "hrmis_GetExpiryDetails_hod"
        '    dsa = getExpiryList(SqlText, Session("_edept"))

        If category = "Department Head" Or category = "departmenthead" Then
            GetHeadDept()
            'SqlText = "SELECT * FROM   empmaster, emp_appraisalnote where empmaster.empcode = emp_appraisalnote.empcode and resigned= 'N' and departmentcode in (" & dept & ") and status = 'S' and nationality <> 'JAP' order by empmaster.empcode"
            'dsa = getExpiryList(SqlText, Session("_edept"))

        ElseIf category = "sectionhead" Or category = "Section Head" Then
            SqlText = "hrmis_GetExpiryDetails_SH"
            dsa = getExpiryList(SqlText, Session("_esect"))
        End If
        Dim contract, prob As Integer
        prob = 0
        contract = 0
        Dim drpc

        Try
            If dsa.Tables(0).Rows.Count <> 0 Then
                Dim acount = dsa.Tables(0).Rows.Count
                drpc = dsa.Tables(0).Rows(0)
                Dim stat = drpc("appraisaltype").ToString
                If stat = "P" Then
                    prob = prob + 1
                ElseIf stat = "C" Then
                    contract = contract + 1
                End If
                lblp.Text = prob
                lblc.Text = contract

                lblMessage.Text = "Some Employees Probationary or Contract is going to over. Do You want to see the details!!!"
                alertMpe.Show()
                Panel1.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function getExpiryList(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "ExpList")
        con.Close()
        Return ds
    End Function
    Function getExpiryList(ByVal sqltext As String, ByVal val As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@dept", val)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "ExpList")
        con.Close()
        Return ds
    End Function

    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click

        Dim category = Session("_ecategory")
        Dim dcode = Session("dcode")

        If dcode = "EA" Then

            If lblp.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\pcexpiTylistEa.aspx")
            End If
            If lblc.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\contractexpirylistea.aspx")
            End If

        ElseIf dcode = "MD" Or dcode = "GM" Or dcode = "DGM" Or dcode = "VGM" Or dcode = "PL Man" Or dcode = "SGM" Or dcode = "SPM" Then
            If lblp.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\pcexpiTylistEa.aspx")
            End If
            If lblc.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\contractexpirylistea.aspx")
            End If
        End If
        Exit Sub

        If category = "Department Head" Or category = "departmenthead" Then

            If lblp.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\pcexpirylisthod.aspx")
            End If
            If lblc.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\contractexplisthod.aspx")
            End If

        ElseIf category = "sectionhead" Or category = "Section Head" Then
            Response.Redirect("~\hrmis\appraisal\pcexpirylistSH.aspx")
        End If
        Exit Sub

        If Session("empcode") = "014623" Then

            If lblp.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\probcontractexplist.aspx")
            End If
            If lblc.Text > 0 Then
                Response.Redirect("~\hrmis\appraisal\contractexplistpayroll.aspx")
            End If
        End If

    End Sub

    Private Sub GetHeadDept()

        Dim SqlText
        Dim dsa As DataSet
        Dim dra As DataRow

        Dim dsh As DataSet
        Dim drh As DataRow
        Dim headdept, mydept

        dsh = GetHeadAssignment()
        If dsh.Tables(0).Rows.Count > 0 Then
            drh = dsh.Tables(0).Rows(0)
            mydept = drh("ldepartmentcode").ToString
            Dim hoddepts = mydept.split(",")
            For i As Integer = 0 To hoddepts.Length - 1
                headdept = headdept & "'" & hoddepts(i) & "',"
            Next
            headdept = headdept.remove(headdept.length - 1, 1)
        Else
            headdept = "'" & Session("_edept") & "'"
        End If
        '  Label1.Text = headdept
        SqlText = "SELECT * FROM   empmaster, emp_appraisalnote where empmaster.empcode = emp_appraisalnote.empcode and resigned= 'N' and departmentcode in (" & headdept & ") and status = 'S' and nationality <> 'JAP' order by empmaster.empcode"
        dsa = getExpiryListhod(SqlText)

        Try
            If dsa.Tables(0).Rows.Count <> 0 Then
                Dim acount = dsa.Tables(0).Rows.Count
                lblMessage.Text = "Some Employees Probationary or Contract is going to over. Do You want to see the details!!!"
                alertMpe.Show()
                Panel1.Visible = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function getExpiryListhod(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "ExpList")
        con.Close()
        Return ds
    End Function
    Function GetHeadAssignment() As DataSet

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from head_assignment_emanagement where empcode ='" & Session("empcode") & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function
End Class