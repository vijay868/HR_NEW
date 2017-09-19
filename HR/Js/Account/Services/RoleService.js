﻿app.service('RoleService', ['$http', '$q', function ($http, $q) {
    this.GetRoles = function () {
        debugger;
        var deferred = $q.defer();
        $http.get('/RoleRights/GetRoles').then(function (response) {
            deferred.resolve(response);
        }, function (err) {
            deferred.reject(err);
        })
        return deferred.promise;
    }
    this.SaveEmployeeRoles = function (role) {
        debugger;
        var deferred = $q.defer();
        $http.post('/RoleRights/SaveEmployeeRoles', role).then(function (response) {
            deferred.resolve(response);
        }, function (err) {
            deferred.reject(err);
        })
        return deferred.promise;
    }
    //this.GetSecurables = function () {
    //    var deferred = $q.defer();
    //    $http.get('/Securable/GetSecurables').then(function (response) {
    //        deferred.resolve(response);
    //    }, function (err) {
    //        deferred.reject(err);
    //    })
    //    return deferred.promise;
    //}
}])