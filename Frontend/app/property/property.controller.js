(function() {
    'use strict';

    angular
        .module('app')
        .controller('PropertyController', PropertyController);

    PropertyController.$inject = ['PropertyFactory', 'LocalStorageFactory', '$state', 'toastr'];

    /* @ngInject */
    function PropertyController(PropertyFactory, LocalStorageFactory, $state, toastr) {
        var pc = this;
        pc.title = 'PropertyController';
        pc.getOwnerProperties = getOwnerProperties;
        pc.addProperty = addProperty;
        pc.updateProperty = updateProperty;
        pc.deleteProperty = deleteProperty;
        pc.logOut = logOut;

        getOwnerProperties();

        ////////////////

        function getOwnerProperties() {
            var properties = LocalStorageFactory.getKey('savedProperties');
            pc.properties = properties;
            }

        function logOut() {
          $state.go('search');
          LocalStorageFactory.clear();
        }

        function addProperty() {

            var user = LocalStorageFactory.getKey('savedUser');

            var property = {
                            'UserId': user.userId,
                            'PropertyName': pc.pname,
                            'Address1': pc.address1,
                            'Address2': pc.address2,
                            'City': pc.city,
                            'State': pc.state,
                            'Zip': pc.zip,
                            'ContactPhone': pc.phone,
                            'Rent': pc.rent,
                            'SqFt': pc.sqft,
                            'Bedrooms': pc.bedrooms,
                            'Bathrooms': pc.bathrooms,
                            'PetFriendly': pc.pet,
                            'LeaseTerms': pc.lease,
                            'PropertyImage': pc.image,
                            };

            PropertyFactory.postProperty(property).then(
                function(response){
                    toastr.success(response.statusText);
                    $("input").val('');
                    //PropertyFactory.updatePropGrid(user.userName);
                },
                function(error){
                    toastr.error('Property Not Created');
                    console.log(error);
                })
        }

        function updateProperty(id, p) {

            PropertyFactory.updateProperty(id, p).then(
                function(response){
                    toastr.success('Property Updated');
                }, function(error){
                    console.log(error);
                    toastr.error('Property Not Updated');
                })
        }

        function deleteProperty(id) {
            PropertyFactory.deleteProperty(id).then(
                function(response){
                    toastr.success('Property Deleted')
                },function(error){
                    console.log(error);
                    toastr.error('Property Not Deleted');
                })
            getOwnerProperties();
        }
    }
})();
