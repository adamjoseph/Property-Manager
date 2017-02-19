(function() {
    'use strict';

    angular
        .module('app')
        .factory('UserFactory', UserFactory);

    UserFactory.$inject = ['$http', '$q', 'localApi'];

    /* @ngInject */
    function UserFactory($http, $q, localApi) {
        var service = {
            addUser: addUser,
            getUser: getUser
        };
        return service;

        ////////////////

        function addUser(user){
          return $http.post(localApi+'Users', user);
        }

        function getUser(user) {
        	var defer = $q.defer();

        	$http({
        		method: 'GET',
        		url: localApi + 'Users/User',
        		params: {'username': user}
        	}).then(function(response){
        		defer.resolve(response);
        	},
        	function(error){
        		defer.reject(error);
        	});

        	return defer.promise;
        }
    }
})();
