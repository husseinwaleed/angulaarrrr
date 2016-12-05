(function () {
    'use strict';

    var myApp = angular.module('myApp', [
            "ngRoute" // <-- This is needed to use AngularJS Routing!  
    ]);
  myApp.controller('DetailsController', function ($scope, $http, $routeParams,$location) { // <-- This is needed to handle extract/read parameters out of url
        $scope.params = $routeParams;

        $http.get("/Home/Getpersondetail/" + $scope.params.Id)
            .then(function (response) {
                $scope.person = response.data;
            });

        $scope.deleteuser = function () {
            $http.get("/Home/Delete/" + $scope.params.Id)
          .success(function (response) {
            $location.url("/Home/Index");
          });
        };
  });

  myApp.controller('EditController', function ($scope, $http, $routeParams, $location) {
      $scope.params = $routeParams;
      $scope.firstname;
      $scope.lastname;
      $scope.country;
      $scope.phone;
      $scope.Id = $routeParams.Id;

      $scope.edituser = function ()
      {
       
          var aPerson = { Id: $scope.Id, firstname: $scope.firstname, lastname: $scope.lastname, country: $scope.country, phone: $scope.phone };
          console.log(aPerson);
          $http({
              method: "Post",
              url: "/Home/Edit",
              data: aPerson
          })
        .success(function (response) {
  
            $location.url("/Home/Index");
           
        });
     
    
      };
  });

  myApp.controller('createnew', function ($scope, $http, $routeParams, $location) {
      $scope.params = $routeParams;
      $scope.firstname;
      $scope.lastname;
      $scope.country;
      $scope.phone;
      //$scope.Id = $routeParams.Id;

      $scope.create = function () {

          var aPerson = { firstname: $scope.firstname, lastname: $scope.lastname, country: $scope.country, phone: $scope.phone };
          console.log(aPerson);
          $http({
              method: "Post",
              url: "/Home/Create",
              data: aPerson
          })
        .success(function (response) {

            $location.url("/Home/Index");

        });


      };
  });




    myApp.controller('myCtrl', function ($scope, $http) {


        $http.get("/Home/Getdatalist")
           .then(function (response) {
               $scope.personlist = response.data;
           });
            });
    myApp.config(function ($routeProvider) {
        $routeProvider
              .when('/createnew', {
                  templateUrl: '/Content/app/CreateUser.html',
                  controller: 'createnew'
              })
            .when('/Edit/:Id', {
                templateUrl: '/Content/app/Edit.html',
                controller: 'EditController'
            })
            .when('/Person/:Id', {
                templateUrl: '/Content/app/Details.html',
                controller: 'DetailsController'
            })
          .when('/Index', {
              templateUrl: '/Content/app/mainlist.html',
              controller: 'myCtrl'
          })
           
        .otherwise({
            redirectTo: '/Index'

        });

    });
})();