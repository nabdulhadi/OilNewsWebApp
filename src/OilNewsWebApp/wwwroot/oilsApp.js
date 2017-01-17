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

 (function () {
  'use strict';
   
  angular
      .module('oilsApp')
      .controller('OilsListController', OilsListController)
      .controller('OilsAddController', OilsAddController)
      .controller('OilsEditController', OilsEditController)
      .controller('OilsDeleteController', OilsDeleteController);

  /* Oils List Controller  */
  OilsListController.$inject = ['$scope', 'Oil'];

  function OilsListController($scope, Oil) {
    $scope.oils = Oil.query();
  }

  /* Oils Create Controller */
  OilsAddController.$inject = ['$scope', '$location', 'Oil'];

  function OilsAddController($scope, $location, Oil) {
    $scope.oil = new Oil();
    $scope.add = function () {
      $scope.oil.$save(function () {
        $location.path('/oils');
      });
    };
  }

  /* Oils Edit Controller */
  OilsEditController.$inject = ['$scope', '$routeParams', '$location', 'Oil'];

  function OilsEditController($scope, $routeParams, $location, Oil) {
    $scope.oil = Oil.get({ id: $routeParams.id });
    $scope.edit = function () {
      $scope.oil.$save(function () {
        $location.path('/oils');
      });
    };
  }

  /* Oils Delete Controller  */
  OilsDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Oil'];

  function OilsDeleteController($scope, $routeParams, $location, Oil) {
    $scope.oil = Oil.get({ id: $routeParams.id });
    $scope.remove = function () {
      $scope.oil.$remove({ id: $scope.oil.id }, function () {
        $location.path('/oils');
      });
    };
  }

})();


 (function () {
  'use strict';

  angular
    .module('oilsServices', ['ngResource'])
    .factory('Oil', Oil);

  Oil.$inject = ['$resource'];

  function Oil($resource) {
    return $resource('/api/oils/:id');
  }

})();

