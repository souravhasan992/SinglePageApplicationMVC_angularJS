var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    $scope.View = 'List';
    $scope.Employee = {
        Id: 0,
        Name: "",
        GenderId: 1,
        JoiningDate: "",
        Salary:0
    }
    $scope.Reset = function () {
        $scope.Employee = {
            Id: 0,
            Name: "",
            GenderId: 1,
            JoiningDate: "",
            Salary: 0
        }
    }
    $scope.SwitchView = function (view) {
        $scope.View = view;
        $scope.GetAllData();
    }
    $scope.GetAllData = function () {
        $scope.GetGenders();
        $scope.GetEmployees();
    }
    $scope.GetEmployees = function () {
        $http({
            transformRequest: angular.identity,
            Headers: { 'content-type': 'application/json' },
            method: 'get',
            url: '/Employees/GetEmployees'
        }).then(function (response) {
            $scope.employees = response.data;
        }, function error() {
            console.log(error)
        })
    }
    $scope.GetGenders = function () {
        $http({
            method: "get",
            url: '/Employees/GetGenders'
        }).then(function (response) {
            $scope.genders = response.data;
        }, function error() {
            console.log(error)
        })
    }
    $scope.EmpSave = function () {
        $http({
            method: 'post',
            url: '/Employees/InsertEmployee',
            datatype: 'json',
            data: JSON.stringify($scope.Employee)
        }).then(function (response) {
            console.log(response);
            $scope.Reset();
            $scope.SwitchView('List');
        }, function error() {
            console.log(error)
        })
    }
    $scope.EmpEdit = function (emp) {
        $scope.Employee.Id = emp.Id;
        $scope.Employee.Name = emp.Name;
        $scope.Employee.GenderId = emp.GenderId;
        $scope.Employee.JoiningDate = emp.JoiningDate;
        $scope.Employee.Salary = emp.Salary;
        $scope.SwitchView('Form');
    }
    $scope.EmpUpdate = function () {
        $http({
            method: 'post',
            url: '/Employees/UpdateEmployee',
            datatype: 'json',
            data: JSON.stringify($scope.Employee)
        }).then(function (response) {
            console.log(response);
            $scope.Reset();
        }, function error() {
            console.log(error)
        })
    }
    $scope.EmpDelete = function (emp) {
        $http({
            method: 'post',
            url: '/Employees/DeleteEmployee',
            datatype: 'json',
            data: JSON.stringify(emp)
        }).then(function (response) {
            console.log(response);
            $scope.Reset();
        }, function error() {
            console.log(error)
        })
    }


})