(function () {
  'use strict';

  config.$inject = ['$routeProvider', '$locationProvider'];

  angular.module('moviesApp', [
      'ngRoute', 'moviesServices'
  ]).config(config);

  function config($routeProvider, $locationProvider) {
    $routeProvider
      .when('/movies', {
        templateUrl: '/movies/list.html',
        controller: 'MoviesListController'
      })
      .when('/movies/add', {
        templateUrl: '/movies/add.html',
        controller: 'MoviesAddController'
      })
      .when('/movies/edit/:id', {
        templateUrl: '/movies/edit.html',
        controller: 'MoviesEditController'
      })
      .when('/movies/delete/:id', {
        templateUrl: '/movies/delete.html',
        controller: 'MoviesDeleteController'
      });

    $locationProvider.html5Mode(true);
  }

})();

