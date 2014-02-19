/// <reference path="angular.js" />

var app = angular.module("WebApiAndAngularJSSample", ['ngRoute']);

app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/createPost', {
            templateUrl: 'templates/createPost.html',
            controller: 'BlogsCtrl'
        }).
        when('/showPosts', {
            templateUrl: 'templates/showPosts.html',
            controller: 'BlogsCtrl',
            
        }).
        when('/showPost/:postId', {
            templateUrl: 'templates/showPost.html',
            controller: 'BlogsCtrl'
        }).
        otherwise({
            redirectTo: '/showPosts'
        });
  }]);

app.controller("BlogsCtrl", function ($scope, $http, $routeParams) {

    $scope.getBlog = function () {
        $http.get("api/blogs/" + $routeParams.postId).success(function (data) {
            $scope.blog = data;
        }).error(function () {
            alert("an error has occurred");
        })
    }

    $scope.getAllBlogs = function(){
        $http.get("api/blogs").success(function(data){
        $scope.blogs = data;
        }).error(function () {
            alert("an error has occurred");
        })
    }

    $scope.createNewPost = function(){
        var data = { Title: $scope.blogTitle, Description: $scope.blogDesc };

        $http.post("api/blogs", data).success(function (data, status, headers) {

            alert("New blog post added");

            $http.get(headers("location")).success(function (data) {
                $scope.blogs.push(data);
            });
        })
    }
});
