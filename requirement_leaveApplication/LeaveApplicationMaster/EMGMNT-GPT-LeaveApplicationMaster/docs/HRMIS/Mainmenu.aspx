<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/ems.Master" CodeBehind="Mainmenu.aspx.vb" Inherits="E_Management.Mainmenu" 
    title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPHApplication" runat="server">
    <asp:Menu ID="Menu1" runat="server">
        <Items>
            <asp:MenuItem Text="LEAVE" Value="LEAVE">
                <asp:MenuItem NavigateUrl="~/HRMIS/Leave/Leaveform.aspx" Target="_blank" Text="LEAVE FORM"
                    Value="LEAVE FORM"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Leave/Selfstatus.aspx" Target="_blank" Text="SELF STATUS"
                    Value="SELF STATUS"></asp:MenuItem>
                <asp:MenuItem Text="APPROVALS" Value="APPROVALS">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Leave/HODapproval.aspx" Target="_blank" Text="HOD APPROVAL"
                        Value="HOD APPROVAL"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Leave/ERApproval.aspx" Target="_blank" Text="ER APPROVAL"
                        Value="ER APPROVAL"></asp:MenuItem>
                </asp:MenuItem>
                 <asp:MenuItem Text="Reports" Value="Reports">
                    <asp:MenuItem Text="Leave Entitilement" Value="Leave Entitilement" NavigateUrl="~/HRMIS/Leave/RptLeaveEntitilement.aspx" Target="_blank"></asp:MenuItem>
                    <asp:MenuItem Text="Leave Summary" Value="Leave Summary" NavigateUrl="~/HRMIS/Leave/rPTlEAVEoVERALLSUMMARY.aspx" Target="_blank"></asp:MenuItem>
                    <asp:MenuItem Text="HOD ALL Leave" Value="HOD ALL Leave" NavigateUrl="~/HRMIS/Leave/RPThod.aspx" Target="_blank"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Leave/Rptleaveoverall.aspx" Target="_blank" Text="LeaveOverall"
                        Value="LeaveOverall"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Leave/PayrollLeaveCancel.aspx" Target="_blank"
                    Text="Payroll Leave Cancel" Value="Payroll Leave Cancel"></asp:MenuItem>
            </asp:MenuItem>
        <asp:MenuItem Text="GATE PASS" Value="GATE PASS">
            <asp:MenuItem Text="APPLICATION" Value="APPLICATION">
                <asp:MenuItem NavigateUrl="~/HRMIS/GatePass/GPform.aspx" Target="_blank" Text="GP FORM"
                    Value="GP FORM"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/GatePass/CVPass.aspx" Text="CP PASS" Value="CP PASS" Target="_blank">
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/HRMIS/GatePass/GpApproval.aspx" Text="APPROVALS" Value="APPROVALS" Target="_blank">
            </asp:MenuItem>
            <asp:MenuItem NavigateUrl="~/HRMIS/GatePass/CVselfstatus.aspx" Text="SELF STATUS"
                Value="SELF STATUS" Target="_blank"></asp:MenuItem>
            <asp:MenuItem Text="REPORTS" Value="REPORTS">
                <asp:MenuItem NavigateUrl="~/HRMIS/GatePass/GpReports.aspx" Text="GP REPORT" Value="GP REPORT" Target="_blank">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/GatePass/CVReports.aspx" Text="CV REPORT" Value="CV REPORT" Target="_blank">
                </asp:MenuItem>
            </asp:MenuItem>
            </asp:MenuItem>
         <asp:MenuItem Text="BUSINESS TRIP" Value="Business Trip">
                <asp:MenuItem Text="Applications" Value="Applications">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTform.aspx" Target="_blank" Text="BT Form"
                        Value="BT Form"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCform.aspx" Target="_blank" Text="TC form"
                        Value="TC form"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTCVform.aspx" Target="_blank" Text="CV Form"
                        Value="CV Form"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTSelfstatus.aspx" Target="_blank"
                        Text="Self Status" Value="Self Status"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="EAApprovals" Value="EAApprovals">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTEAViewaspx.aspx" Target="_blank"
                        Text="BT approval" Value="BT approval"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCEAApproval.aspx" Target="_blank"
                        Text="TC approval" Value="TC approval"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="HOD Approvals" Value="HOD Approvals">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTHODView.aspx" Target="_blank"
                        Text="BT View" Value="BT View"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCHodApproval.aspx" Target="_blank"
                        Text="TC approval" Value="TC approval"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Finance" Value="Finance">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/BTFMDView.aspx" Target="_blank"
                        Text="BT View" Value="BT View"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TCfinance.aspx" Target="_blank"
                        Text="TC finance" Value="TC finance"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/TcFMDapproval.aspx" Target="_blank"
                        Text="TC FMD" Value="TC FMD"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Admin" Value="Admin">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/AdminBt.aspx" Target="_blank" Text="BT View"
                        Value="BT View"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/adminbtfareentry.aspx" Target="_blank"
                        Text="EDIT cost" Value="EDIT cost"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Reports" Value="Reports">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Reports/ReportBT.aspx" Target="_blank"
                        Text="BT Reports" Value="BT Reports"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Reports/ReportCV.aspx" Target="_blank"
                        Text="CV Reports" Value="CV Reports"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Reports/ReportTC.aspx" Target="_blank"
                        Text="TC Reports" Value="TC Reports"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Master" Value="Master">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Business Trip/Master_USDLimit.aspx" Target="_blank"
                        Text="USD Master" Value="USD Master"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="CLINIC" Value="CLINIC">
                <asp:MenuItem NavigateUrl="~/HRMIS/Clinic/clinicform.aspx" Target="_blank" Text="CLINICFORM"
                    Value="CLINICFORM"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Clinic/HODAPPROVAL.aspx" Target="_blank" Text="APPROVAL"
                    Value="APPROVAL"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/Clinic/clinicpassqueue.aspx" Target="_blank" Text="TREATEMENT ENTRY"
                    Value="TREATEMENT ENTRY"></asp:MenuItem>
                <asp:MenuItem Target="_blank" Text="REPORTS" Value="REPORTS">
                    <asp:MenuItem NavigateUrl="~/HRMIS/Clinic/MCReport'.aspx" Target="_blank" Text="MCReport"
                        Value="MCReport"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/Clinic/CPassRpt.aspx" Target="_blank" Text="Clinic Pass Report"
                        Value="Clinic Pass Report"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="JS" Value="JS">
                <asp:MenuItem NavigateUrl="~/HRMIS/JS/NewJS.aspx" Target="_blank" Text="NEW JS" Value="NEW JS">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/JS/EditJS.aspx" Target="_blank" Text="EDIT JS"
                    Value="EDIT JS"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/JS/JSReport.aspx" Target="_blank" Text="JS REPORT"
                    Value="PRINT JS"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/JS/jobcode.aspx" Target="_blank" Text="JOB CODE SETTING"
                    Value="JOB CODE SETTING"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/JS/jobPurposeSetting.aspx" Target="_blank" Text="JOB PURPOSE SETTING"
                    Value="JOB PURPOSE SETTING"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/JS/GoalSetting.aspx" Target="_blank" Text="GOAL SETTING"
                    Value="GOAL SETTING"></asp:MenuItem>
            </asp:MenuItem>
         
                   <asp:MenuItem Text="COMPANY TRANSPORT" Value="COMPANY TRANSPORT">
                <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/VehicleMaster.aspx" Target="_blank"
                    Text="VEHICLE MASTER" Value="VEHICLE MASTER"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/INSuranceRoadtax.aspx" Target="_blank"
                    Text="INSURANCE/RT" Value="INSURANCE/RT"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/VehicleService.aspx" Target="_blank"
                    Text="SERVICE DETAILS" Value="SERVICE DETAILS"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/summondetails.aspx" Text="SUMMON DETAILS"
                    Value="SUMMON DETAILS"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/servicecentremaster.aspx" Text="SERVICE CENTRE MASTER"
                    Value="SERVICE CENTRE MASTER"></asp:MenuItem>
                <asp:MenuItem Text="PASSPORT /VISA" Value="PASSPORT /VISA">
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/GroupMaster.aspx" Target="_blank"
                        Text="GROUP MASTER" Value="GROUP MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/ppdetailsentry.aspx" Target="_blank"
                        Text="PP ENTRY/RENEW" Value="PP ENTRY/RENEW"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/MissingPerson.aspx" Target="_blank"
                        Text="MISSING PERSON ENTRY" Value="MISSING PERSON ENTRY"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/MissingPersonEdit.aspx" Target="_blank"
                        Text="MISSING PERSON ENTRY EDIT" Value="MISSING PERSON ENTRY EDIT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/workpermitdetails.aspx" Target="_blank"
                        Text="WP ENTRY" Value="WP ENTRY"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/workpermitdetailsedit.aspx"
                        Target="_blank" Text="WP ENTRY EDIT" Value="WP ENTRY EDIT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/Spousechildrendetails.aspx"
                        Target="_blank" Text="SPOUSE/CHILDREN DETAILS" Value="SPOUSE/CHILDREN DETAILS"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/BTvisaentry.aspx" Target="_blank"
                        Text="BT VISA ENTRY MASTER" Value="BT VISA ENTRY MASTER"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="TRANSPORT" Value="TRANSPORT">
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/areamaster.aspx" Target="_blank"
                        Text="AREA MASTER" Value="AREA MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/Route Master.aspx" Target="_blank"
                        Text="ROUTE MASTER" Value="ROUTE MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/group.aspx" Target="_blank"
                        Text="GROUPMASTER" Value="GROUPMASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/PickUpTimemaster.aspx" Target="_blank"
                        Text="PICK UP TIME MASTER" Value="PICK UP TIME MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/shiftmaster.aspx" Target="_blank"
                        Text="SHIFT MASTER" Value="SHIFT MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/individualallocation.aspx" Target="_blank"
                        Text="INDIVIDUAL ALLOCATION" Value="INDIVIDUAL ALLOCATION"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/ownvehiclamaster.aspx" Target="_blank"
                        Text="OWN VEHICLE MASTER" Value="OWN VEHICLE MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/supplierMaster.aspx" Target="_blank"
                        Text="SUPPLIER MASTER" Value="SUPPLIER MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/BusVan.aspx" Target="_blank"
                        Text="BUS / VAN MASTER" Value="BUS / VAN MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/CalendarMaster.aspx" Target="_blank"
                        Text="CALENDER MASTER" Value="CALENDER MASTER"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/ProductionRequest.aspx" Text="Production Request Edit/Payroll"
                        Value="PR " Target="_blank"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/PRbysection.aspx" Target="_blank"
                        Text="Prod.Request By section" Value="Prod.Request By section"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="REPORTS" Value="REPORTS">
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/PPexpiryList.aspx" Target="_blank"
                        Text="CURRENT PP EXPIRY LIST" Value="CURRENT PP EXPIRY LIST"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/VisaExpDetails.aspx" Target="_blank"
                        Text="CURRENT VISA EXPIRY LIST" Value="CURRENT VISA EXPIRY LIST"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/transportreport.aspx" Target="_blank"
                        Text="VEHICLE TRANSPORT" Value="VEHICLE TRANSPORT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/company Transport/TransportrouteRpt.aspx" Target="_blank"
                        Text="ROUTE TRANSPORT " Value="ROUTE TRANSPORT "></asp:MenuItem>
                    <asp:MenuItem Target="_blank" Text="PR REPORT" Value="PR REPORT" NavigateUrl="~/HRMIS/company Transport/PRReports.aspx"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="ADMIN MASTERS" Value="ADMIN MASTERS">
                <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/EmpMaster.aspx" Target="_blank" Text="EMP MASTER"
                    Value="EMP MASTER"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/DEPARTMENTMASTER.aspx" Target="_blank"
                    Text="DEPT MASTER" Value="DEPT MASTER"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/Designationmaster.aspx" Target="_blank"
                    Text="DESIG MASTER" Value="DESIG MASTER"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/sectionmaster.aspx" Target="_blank"
                    Text="SECT MASTER" Value="SECT MASTER"></asp:MenuItem>
                <asp:MenuItem Text="REPORTS" Value="REPORTS">
                    <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/deptrpt.aspx" Target="_blank" Text="DEPT RPT"
                        Value="DEPT RPT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/sectrpt.aspx" Target="_blank" Text="SECT RPT"
                        Value="SECT RPT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/DESIGNATIONRPT.aspx" Target="_blank"
                        Text="DESIG RPT" Value="DESIG RPT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/empmasterrpt.aspx" Target="_blank"
                        Text="EMP LIST" Value="EMP LIST"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/AdminMasters/birthday.aspx" Target="_blank" Text="BIRTHDAY LIST"
                        Value="BIRTHDAY LIST"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="OT" Value="OT">
                <asp:MenuItem NavigateUrl="~/HRMIS/OT/BudgetSettings.aspx" Target="_blank" Text="BUDGET SETTING"
                    Value="BUDGET SETTING"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/OT/OTapprovalEA.aspx" Target="_blank" Text="EA Approval"
                    Value="EA Approval"></asp:MenuItem>
                <asp:MenuItem Text="OT Entry" Value="OT Entry">
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/OTstaffEntry.aspx" Target="_blank" Text="Staff OT"
                        Value="Staff OT"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/OTentryCategory.aspx" Target="_blank" Text="OT by Dept/Sect"
                        Value="OT by Dept/Sect"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/HODapprovalOT.aspx" Text="HOD Approval" Value="HOD Approval">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/OTentryPayroll.aspx" Target="_blank" Text="FMD Edit OT"
                        Value="FMD Edit OT"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Master Screens" Value="Master Screens">
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/OTphMaster.aspx" Text="Public holiday " Value="Public holiday ">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/WeeklyMaxOThrs.aspx" Text="Max OT Week Hrs "
                        Value="Max OT Week Hrs "></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/staffOTEligible.aspx" Target="_blank" Text="Staff Elligibility"
                        Value="Staff Elligibility"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Reports" Value="Reports">
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/RptOtOverall.aspx" Target="_blank" Text="OT overall Report"
                        Value="OT overall Report"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/OT/RptOTBudgetSetting.aspx" Target="_blank" Text="Budget Report"
                        Value="Budget Report"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
            <asp:MenuItem Text="KPI" Value="KPI">
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/MajorKPI.aspx" Target="_blank" Text="MajorKPI"
                    Value="MajorKPI"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/SubKPI.aspx" Target="_blank" Text="Sub KPI"
                    Value="Sub KPI"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/IndividualSetting.aspx" Target="_blank" Text="KPI settings"
                    Value="KPI settings"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/HODApproveSUbKPI.aspx" Target="_blank" Text="SUB KPI approval"
                    Value="SUB KPI approval"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/DailyUpdateKPI.aspx" Target="_blank" Text="Dailyupdate"
                    Value="Dailyupdate"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/KPI HOd approve.aspx" Target="_blank" Text="HOD approval"
                    Value="HOD approval"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/KPI EA approval.aspx" Target="_blank" Text="EA Approval"
                    Value="EA Approval"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/OperatorKPI.aspx" Target="_blank" Text="Operator KPI"
                    Value="Operator KPI"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="~/HRMIS/KPI/Report MajorSubList.aspx" Target="_blank"
                    Text="Reports" Value="Reports">
                    <asp:MenuItem NavigateUrl="~/HRMIS/KPI/Report MajorSubList.aspx" Target="_blank"
                        Text="Major/SubList" Value="Major/SubList"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/KPI/rptUpdatedandNU.aspx" Target="_blank" Text="Updated&amp;NotUpdatedKPI"
                        Value="Updated&amp;NotUpdatedKPI"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/HRMIS/KPI/OperatorKPIrpt.aspx" Target="_blank" Text="OperatorRpt"
                        Value="OperatorRpt"></asp:MenuItem>
                </asp:MenuItem>
            </asp:MenuItem>
        </Items>
    </asp:Menu>
</asp:Content>
