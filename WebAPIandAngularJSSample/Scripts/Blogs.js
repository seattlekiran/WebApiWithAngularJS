/// <reference path="angular.js" />

var app = angular.module("WebApiAndAngularJSSample", []);

app.controller("BlogsCtrl", function ($scope, $http) {

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