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

