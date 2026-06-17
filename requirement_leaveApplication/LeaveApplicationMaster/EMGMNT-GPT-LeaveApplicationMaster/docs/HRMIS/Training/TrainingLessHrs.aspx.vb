Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class TrainingLessHrs
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (156)
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

        MyGlobal.Con_Str()
        Dim con As New SqlConnection(constr)
        con.Open()
        Cmd = New SqlCommand("delete from temp_lesstraininghrs", con)
        Cmd.ExecuteNonQuery()

        Dim mth = Date.Now.Month
        Dim mi

        If mth = 4 Then
            mi = 1
        ElseIf mth = 5 Then
            mi = 2
        ElseIf mth = 6 Then
            mi = 3
        ElseIf mth = 7 Then
            mi = 4
        ElseIf mth = 8 Then
            mi = 5
        ElseIf mth = 9 Then
            mi = 6
        ElseIf mth = 10 Then
            mi = 7
        ElseIf mth = 11 Then
            mi = 8
        ElseIf mth = 12 Then
            mi = 9
        ElseIf mth = 1 Then
            mi = 10
        ElseIf mth = 2 Then
            mi = 11
        ElseIf mth = 3 Then
            mi = 12
        End If

        '''' Get Training hrs by category
        Dim dsth As DataSet
        Dim drth As DataRow
        dsth = GetTrainingHrs()
        Dim hrsS, hrsO
        Dim ExpS, ExpO
        Dim CurmthS, curmthO
        Dim S
        If dsth.Tables(0).Rows.Count <> 0 Then
            For S = 0 To dsth.Tables(0).Rows.Count - 1
                drth = dsth.Tables(0).Rows(S)
                If drth("category") = "S" Then
                    hrsS = drth("hrs")
                    ExpS = hrsS / 12
                    ExpS = Math.Round(ExpS, 2)
                    CurmthS = ExpS * mi
                ElseIf drth("category") = "O" Then
                    hrsO = drth("hrs")
                    ExpO = hrsO / 12
                    ExpO = Math.Round(ExpO, 2)
                    curmthO = ExpO * mi
                End If
            Next
          
        End If

        ''''''Get Employee List
        Dim dsemp As DataSet
        Dim dremp As DataRow
        dsemp = GetEmpList()
        Dim emp
        Dim desig
        Dim hrs
        Dim mthexphrs
        Dim curmthexphrs
        Dim tothrsattend As Decimal
        Dim j
        Dim lackhrs
        If dsemp.Tables(0).Rows.Count <> 0 Then
            For j = 0 To dsemp.Tables(0).Rows.Count - 1
                dremp = dsemp.Tables(0).Rows(j)
                emp = dremp("empcode").ToString
                desig = dremp("designation").ToString
                If dremp("designation") <> "Operator" Then
                    hrs = hrsS
                    mthexphrs = ExpS
                    curmthexphrs = CurmthS
                ElseIf dremp("designation") = "Operator" Then
                    hrs = hrsO
                    mthexphrs = ExpO
                    curmthexphrs = curmthO
                End If

                Dim dsh As DataSet
                Dim drh As DataRow
                Dim k

                dsh = GetTrainingattendedHrs(emp)
                If dsh.Tables(0).Rows.Count <> 0 Then
                    drh = dsh.Tables(0).Rows(0)
                    If Not drh("tothrs") Is System.DBNull.Value Then
                        tothrsattend = drh("tothrs").ToString
                    Else
                        tothrsattend = 0
                    End If
                    If tothrsattend < curmthexphrs Then
                        lackhrs = curmthexphrs - tothrsattend
                    Else
                        lackhrs = 0
                    End If
                Else
                    lackhrs = curmthexphrs
                End If

                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into temp_lesstraininghrs (empcode,tothrsneeded,monhrsneeded,tothrsattended,tillmonthtarget,lackinghrs) values('" & emp & "', '" & hrs & "','" & mthexphrs & "','" & tothrsattend & "','" & curmthexphrs & "','" & lackhrs & "') ", conn)
                Cmd.ExecuteNonQuery()
            Next
            Response.Redirect("/hrmis/Training/TrLessHrs.aspx")

        End If


    End Sub
    Function GetTrainingHrs()

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from Td_TrainingHrs", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "TH")
        con.Close()
        Return ds

    End Function
    Function GetEmpList()
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from empmaster where resigned<>'Y' and designation <>'Japanese' and designation <>'MD' and designation <>'EA' order by designation, departmentcode", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "EL")
        con.Close()
        Return ds
    End Function

    Function GetTrainingattendedHrs(ByVal emp As String)
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select sum(td_hours) as tothrs from td_employeetraining where empcode = '" & emp & "' and td_dateattended > '" & _fisyrStart & "' and td_dateattended < '" & _fisyrEnd & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "TAH")
        con.Close()
        Return ds

    End Function


End Class