(function() {
'use strict';

angular.module('hyHwebApp')
  .controller('AboutCtrl', AboutCtrl);

AboutCtrl.$inject = ['$scope', '$http'];

  function AboutCtrl($scope, $http) {

    $scope.title = 'Abount HyH';

  };
}());
