(function() {
    'use strict';

    angular
        .module('app')
        .controller('UserController', UserController);

    UserController.$inject = ['UserFactory', '$state', 'toastr'];

    /* @ngInject */
    function UserController(UserFactory, $state, toastr) {
        var uc = this;
        uc.title = 'UserController';
        uc.addUser = addUser;

        ////////////////

        function addUser() {

        	var newUser = {'FirstName': uc.fname,
        					'LastName': uc.lname,
        					'Email': uc.email,
        					'PropertyManager': uc.manager,
        					'UserName': uc.uname };

        	UserFactory.addUser(newUser).then(
        		function(response){
              toastr.success('User Created');
        			if(newUser.PropertyManager == true){
        				$state.go('propertyGrid');
        			} else {
        				$state.go('search');
        			}

        		},
        		function(error){
        			console.log(error);
        			$state.go('search');
        		})
        }
    }
})();
