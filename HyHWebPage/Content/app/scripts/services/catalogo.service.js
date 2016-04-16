(function() {
  'use strict';

  angular.module('hyHwebApp')
    .factory('Catalogo', Catalogo);

  function Catalogo($resource) {
    return $resource(
            'http://localhost:9898/api/catalogo/:name/:id',
            {name: '@name', id: '@id' });
  }
}());
