(function() {
 'use strict';

angular.module('hyHwebApp')
  .controller('MainCtrl', MainCtrl);

MainCtrl.$inject = ['$scope', '$http'];

  function MainCtrl($scope, $http) {

    $scope.title = 'HyH WebPage';
    
  };
}());
