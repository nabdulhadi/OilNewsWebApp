(function () {
  'use strict';

  config.$inject = ['$routeProvider', '$locationProvider'];

  angular.module('moviesApp', [
      'ngRoute', 'moviesServices'
  ]).config(config);

  function config($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', {
          templateUrl: '/views/list.html',
          controller: 'MoviesListController'
        })
        .when('/movies/add', {
          templateUrl: '/views/add.html',
          controller: 'MoviesAddController'
        })
        .when('/movies/edit/:id', {
          templateUrl: '/views/edit.html',
          controller: 'MoviesEditController'
        })
        .when('/movies/delete/:id', {
          templateUrl: '/views/delete.html',
          controller: 'MoviesDeleteController'
        });

    $locationProvider.html5Mode(true);
  }

})(); (function () {
  'use strict';
   
  angular
      .module('moviesApp')
      .controller('MoviesListController', MoviesListController)
      .controller('MoviesAddController', MoviesAddController)
      .controller('MoviesEditController', MoviesEditController)
      .controller('MoviesDeleteController', MoviesDeleteController);

  /* Movies List Controller  */
  MoviesListController.$inject = ['$scope', 'Movie'];

  function MoviesListController($scope, Movie) {
    $scope.movies = Movie.query();
  }

  /* Movies Create Controller */
  MoviesAddController.$inject = ['$scope', '$location', 'Movie'];

  function MoviesAddController($scope, $location, Movie) {
    $scope.movie = new Movie();
    $scope.add = function () {
      $scope.movie.$save(function () {
        $location.path('/');
      });
    };
  }

  /* Movies Edit Controller */
  MoviesEditController.$inject = ['$scope', '$routeParams', '$location', 'Movie'];

  function MoviesEditController($scope, $routeParams, $location, Movie) {
    $scope.movie = Movie.get({ id: $routeParams.id });
    $scope.edit = function () {
      $scope.movie.$save(function () {
        $location.path('/');
      });
    };
  }

  /* Movies Delete Controller  */
  MoviesDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Movie'];

  function MoviesDeleteController($scope, $routeParams, $location, Movie) {
    $scope.movie = Movie.get({ id: $routeParams.id });
    $scope.remove = function () {
      $scope.movie.$remove({ id: $scope.movie.id }, function () {
        $location.path('/');
      });
    };
  }

})();


 (function () {
  'use strict';

  angular
      .module('moviesServices', ['ngResource'])
      .factory('Movie', Movie);

  Movie.$inject = ['$resource'];

  function Movie($resource) {
    return $resource('/api/movies/:id');
  }

})();

