(function() {
    'use strict';

    angular
        .module('app')
        .factory('PropertyFactory', PropertyFactory);

    PropertyFactory.$inject = ['$http', '$q', 'localApi'];

    /* @ngInject */
    function PropertyFactory($http, $q, localApi) {
        var service = {
            getProperties: getProperties,
            updatePropGrid: updatePropGrid,
            postProperty: postProperty,
            updateProperty: updateProperty,
            deleteProperty: deleteProperty
        };
        return service;

        ////////////////

        function getProperties(search){
            return $http({
                method: 'GET',
                url: localApi + 'Properties/GetSearchProperties',
                params: search
              })
        }

        function updatePropGrid(username) {
          return  $http({
            method: 'GET',
            url: localApi + 'Properties/GetPropsByUsername',
            params: username
          })
        }

        function postProperty(property){
          return $http.post(localApi+'Properties', property);
        }

        function updateProperty(id, property) {
          return $http.put(localApi+'Properties/'+id, property);
        }

        function deleteProperty(id){
          return $http.delete(localApi+'Properties/'+id)
        }
    }
})();
