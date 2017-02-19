(function() {
    'use strict';

    angular
        .module('app')
        .controller('SearchController', SearchController);

    SearchController.$inject = ['PropertyFactory', 'UserFactory', 'LocalStorageFactory', '$state', 'toastr'];

    /* @ngInject */
    function SearchController(PropertyFactory, UserFactory, LocalStorageFactory, $state, toastr) {
        var sc = this;
        sc.title = 'SearchController';
        sc.getProperties = getProperties;
        sc.getUser = getUser;


        ////////////////

        function getProperties() {
            var property = {
                                'UserName': sc.uname,
                                'City': sc.city,
                                'Zip': sc.zip,
                                'MinRent': sc.minrent,
                                'MaxRent': sc.maxrent,
                                'Bedrooms': sc.bedrooms,
                                'Bathrooms': sc.bathrooms
                            };

            PropertyFactory.getProperties(property).then(
                function(response){
                    sc.properties = response.data;
                    //$state.go('search.searchGrid');
            },
            function(error){
                console.log(error);
            })
        }

        function getUser(username) {
            UserFactory.getUser(username).then(
                function(response){
                    sc.user = response.data;

                    if(sc.user.propertyManager == true){
                        toastr.success('Logged in as ' + sc.user.firstName);
                        LocalStorageFactory.saveKey('savedUser', sc.user);
                        LocalStorageFactory.saveKey('savedProperties', sc.user.properties);
                        $state.go('propertyGrid');

                    } else {
                        toastr.success('Logged in as ' + sc.user.firstName);
                        LocalStorageFactory.saveKey('savedUser', sc.user);
                    }
                },
                function(error){
                    console.log(error);
                })
        }
    }
})();
