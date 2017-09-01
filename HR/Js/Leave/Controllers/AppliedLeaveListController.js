﻿angular.module('ngHR').controller('AppliedLeaveListController', ['$scope', '$http', 'growl', '$filter', 'UtilityFunc', 'EmployeeLeave', 'growlService',
function ($scope, $http, growl, $filter, UtilityFunc, EmployeeLeave, growlService) {

    $scope.init = function () {
        $scope.EmployeeLeaveList = {}
        $scope.LeaveList = false;
        $scope.AppliedLeaveList = {};
 
    }
 $scope.test = false;
    $scope.init();

    $scope.SearchEmployeeLeaveList = function (TeamLeadId) {
        debugger;
        if (TeamLeadId != null && TeamLeadId != "") {
        EmployeeLeave.GetEmployeeLeaveListBasedOnTeamLead(TeamLeadId).then(function (response) {
            if (response.data && response.data.sucess == true) {
                $scope.EmployeeLeaveList = response.data.employeeLeaveList;
                    $scope.test = true;
                    debugger;
                angular.forEach($scope.EmployeeLeaveList, function (val, idx) {
                    $scope.EmployeeLeaveList[idx].SNo = idx + 1;
                        debugger;
                    $scope.EmployeeLeaveList[idx].FromDate = moment(val.FromDate).format(UtilityFunc.DateFormat());
                    $scope.EmployeeLeaveList[idx].ToDate = moment(val.ToDate).format(UtilityFunc.DateFormat());
                    $scope.EmployeeLeaveList[idx].ApplyDate = moment(val.ApplyDate).format(UtilityFunc.DateFormat());
                })
            }
        });
        }
    };
    $scope.formatDate = function (date) {
        if (date != null)
            return moment(date).format(UtilityFunc.DateFormat());
        else
            return null;
    }
    $scope.onEditEmployeeLeave = function (employeeLeave) {
        debugger;
        $scope.LeaveList = true;
     
        $scope.AppliedLeaveList = employeeLeave;
    }
    $scope.AcceptOrReject = function (AppliedLeaveList, status) {
        debugger;
        AppliedLeaveList.Status = status;
        EmployeeLeave.SaveEmployeeLeave(AppliedLeaveList).then(function (response) {
            if (response.data && response.data.sucess == true) {
                growlService.growl(response.data.message, 'success');
                $scope.LeaveList = false;
            }
        })
    }

}])