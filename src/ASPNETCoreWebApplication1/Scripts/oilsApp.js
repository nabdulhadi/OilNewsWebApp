(function () {
  'use strict';

  config.$inject = ['$routeProvider', '$locationProvider'];

  angular.module('oilsApp', [
    'ngRoute', 'oilsServices'
  ]).config(config);

  function config($routeProvider, $locationProvider) {
    $routeProvider
      .when('/oils', {
        templateUrl: '/oils/list.html',
        controller: 'OilsListController'
      })
      .when('/oils/add', {
        templateUrl: '/oils/add.html',
        controller: 'OilsAddController'
      })
      .when('/oils/edit/:id', {
        templateUrl: '/oils/edit.html',
        controller: 'OilsEditController'
      });

    $locationProvider.html5Mode(true);
  }

})();

