Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class KPIreportsbyselection1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim empcode, sect, dept, yr, qoption, emptype, stat As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
   

        stat = LTrim(RTrim(Session("Otstat")))
        empcode = LTrim(RTrim(Session("kpiemp")))
        sect = LTrim(RTrim(Session("kpisect")))
        dept = LTrim(RTrim(Session("kpidept")))
        yr = LTrim(RTrim(Session("kpiyear")))
        qoption = LTrim(RTrim(Session("kpioption")))
        emptype = LTrim(RTrim(Session("kpiemptype")))

        '' CR variables
        MyGlobal.rptcon()

        Dim crReportDocument As KPIOverallReport1

        Dim crDatabase As Database
        Dim crTables As Tables
        Dim crTable As Table
        Dim crTableLogOnInfo As TableLogOnInfo
        Dim crConnectionInfo As ConnectionInfo

        crReportDocument = New KPIOverallReport1

        crConnectionInfo = New ConnectionInfo
        With crConnectionInfo
            .ServerName = sver
            .DatabaseName = dbname
            .UserID = uid
            .Password = pw
        End With

        'Get the tables collection from the report object
        crDatabase = crReportDocument.Database
        crTables = crDatabase.Tables

        'Apply the logon information to each table in the collection
        For Each crTable In crTables
            crTableLogOnInfo = crTable.LogOnInfo
            crTableLogOnInfo.ConnectionInfo = crConnectionInfo
            crTable.ApplyLogOnInfo(crTableLogOnInfo)
        Next

        '' get non staff designation
        Dim headdept, mydept
        If emptype = "NS" Then
            Dim dsh As DataSet
            Dim drh As DataRow


            dsh = GetNonstaffDesig()
            If dsh.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To dsh.Tables(0).Rows.Count - 1
                    drh = dsh.Tables(0).Rows(i)
                    mydept = drh("desig").ToString
                    headdept = headdept & "'" & mydept & "',"
                Next
                headdept = headdept.remove(headdept.length - 1, 1)

            Else
                Exit Sub
            End If
        End If

       


        If stat = "D" And emptype = "Y" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.foreignemp} = '" & emptype & "' and {empmaster.departmentcode} = '" & dept & "' and {empmaster.resigned} = 'N' and ({designation.designationname} = 'Operator' or {designation.designationname} = 'Technical Operator') "
        ElseIf stat = "D" And emptype = "N" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.foreignemp} = '" & emptype & "' and {empmaster.departmentcode} = '" & dept & "' and {empmaster.resigned} = 'N' and ({designation.designationname} = 'Operator' or {designation.designationname} = 'Technical Operator') "
        ElseIf stat = "D" And emptype = "Both" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.departmentcode} = '" & dept & "' and {empmaster.resigned} = 'N' and ({designation.designationname} = 'Operator' or {designation.designationname} = 'Technical Operator') "
        ElseIf stat = "D" And emptype = "NS" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.departmentcode} = '" & dept & "' and {empmaster.resigned} = 'N' and {designation.designationname} in [" & headdept & "]"


        ElseIf stat = "S" And emptype = "Y" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.foreignemp} = '" & emptype & "' and {empmaster.sectioncode} = '" & sect & "' and {empmaster.resigned} = 'N' and ({designation.designationname} = 'Operator' or {designation.designationname} = 'Technical Operator') "
        ElseIf stat = "S" And emptype = "N" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.foreignemp} = '" & emptype & "' and {empmaster.sectioncode} = '" & sect & "' and {empmaster.resigned} = 'N' and ({designation.designationname} = 'Operator' or {designation.designationname} = 'Technical Operator') "
        ElseIf stat = "S" And emptype = "Both" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.sectioncode} = '" & sect & "' and {empmaster.resigned} = 'N' and ({designation.designationname} = 'Operator' or {designation.designationname} = 'Technical Operator') "
        ElseIf stat = "S" And emptype = "NS" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.sectioncode} = '" & sect & "' and {empmaster.resigned} = 'N' and {designation.designationname} in [" & headdept & "]"

        ElseIf stat = "E" And emptype = "Y" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.foreignemp} = '" & emptype & "' and {empmaster.empcode} = '" & empcode & "' and {empmaster.resigned} = 'N'"
        ElseIf stat = "E" And emptype = "N" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.foreignemp} = '" & emptype & "' and {empmaster.empcode} = '" & empcode & "' and {empmaster.resigned} = 'N' "
        ElseIf stat = "E" And emptype = "Both" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {empmaster.empcode} = '" & empcode & "'"

        ElseIf stat = "O" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and ({designation.designationname} = 'Operator' or {designation.designationname} = 'Technical Operator') "
        ElseIf stat = "ONS" Then
            crReportDocument.RecordSelectionFormula = "{performancedatainput.year1} = '" & yr & "' and {performancedatainput.option1} =  '" & qoption & "' and {designation.designationname} in [" & headdept & "]"

        End If

        CrystalReportViewer1.ReportSource = crReportDocument


    End Sub

    Function GetNonstaffDesig() As DataSet

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("hrmis_getnonstaffdesig", con)
        Command.CommandType = CommandType.StoredProcedure
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "desig")
        con.Close()
        Return ds
    End Function

End Class