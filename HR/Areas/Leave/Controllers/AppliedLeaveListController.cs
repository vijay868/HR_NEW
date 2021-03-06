﻿using HR.Controllers;
using HR.Core.Models;
using HR.Models;
using HR.Service.Account.IAccountService;
using HR.Service.CompanyDetails.ICompany;
using HR.Service.Leave.ILeaveService;
using HR.Service.Master.IMasterService;
using HR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Areas.Leave.Controllers
{
    public class AppliedLeaveListController : BaseController
    {


        public JsonResult GetAppliedLeaveList()
        {
            JsonResult result = null;
            try
            {
                LookUp employeeDepartment = LookUpCodeService.GetLookUp<LookUp>(s => s.LookUpCategory == "EmployeeDesignation" && s.LookUpCode == "Manager").FirstOrDefault();

                EmployeeHeader employeeHeader = EmployeeProfileService.GetEmployeeProfileList<EmployeeHeader>(e => e.Id == USER_OBJECT.EmployeeId && e.EmployeeWorkDetail.FirstOrDefault().DesignationId == employeeDepartment.LookUpID).FirstOrDefault();

                List<EmployeeLeaveList> employeeLeaveList = Leaveservice.GetLeaveList<EmployeeLeaveList>(e => e.ManagerId == employeeHeader.Id).OrderBy(o => o.EmployeeId).ToList();
                List<EmployeeLeaveViewModel> employeeLeaveViewModelList = new List<EmployeeLeaveViewModel>();
                foreach (EmployeeLeaveList employeeLeave in employeeLeaveList)
                {
                    LookUp leaveType = LookUpCodeService.GetLookUpType(employeeLeave.LeaveTypeId);
                    EmployeeLeaveViewModel employeeLeaveViewModel = new EmployeeLeaveViewModel();
                    employeeLeaveViewModel.Id = employeeLeave.Id;
                    employeeLeaveViewModel.EmployeeName = employeeLeave.Employee.FirstName + " " + employeeLeave.Employee.LastName;
                    employeeLeaveViewModel.EmployeeId = employeeLeave.Employee.Id;
                    employeeLeaveViewModel.EmployeeNumber = employeeLeave.Employee.IDNumber;
                    employeeLeaveViewModel.LeaveType = leaveType.LookUpCode;
                    employeeLeaveViewModel.LeaveTypeId = leaveType.LookUpID;
                    employeeLeaveViewModel.FromDate = employeeLeave.FromDate;
                    employeeLeaveViewModel.Days = employeeLeave.Days;
                    employeeLeaveViewModel.ToDate = employeeLeave.ToDate;
                    employeeLeaveViewModel.ApplyDate = employeeLeave.ApplyDate;
                    employeeLeaveViewModel.Status = employeeLeave.Status;
                    employeeLeaveViewModel.Reason = employeeLeave.Reason;
                    employeeLeaveViewModel.Remarks = employeeLeave.Remarks;
                    employeeLeaveViewModel.BranchId = employeeLeave.BranchId;
                    employeeLeaveViewModel.TeamLeadId = employeeLeave.ManagerId;
                    employeeLeaveViewModelList.Add(employeeLeaveViewModel);
                }
                if (employeeLeaveViewModelList != null && employeeLeaveViewModelList.Any())
                    result = Json(new { employeeLeaveList = employeeLeaveViewModelList, sucess = true }, JsonRequestBehavior.AllowGet);
                else
                    result = Json(new { sucess = false, message = "No Data Found." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    return Json(new { success = false, message = ex.InnerException.Message }, JsonRequestBehavior.DenyGet);
            }
            return result;
        }
        public ActionResult AppliedLeaveList()
        {
            return View();
        }
    }
}