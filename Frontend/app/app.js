(function() {
    'use strict';

    angular
        .module('app', ['ui.router', 'LocalStorageModule', 'toastr'])
        .value('localApi', 'http://localhost:49892/api/')
        .config(function(localStorageServiceProvider){
        	localStorageServiceProvider
        })
        .config(function($stateProvider, $urlRouterProvider){

        	//More any unmatched URL set up default route to main
			$urlRouterProvider.otherwise('/search');

			$stateProvider
			.state('search', {
				url: "/search",
				templateUrl: "app/search/search.html",
				controller: "SearchController",
				controllerAs: "sc"
			})
			.state('search.searchGrid', {
				url: "/searchGrid",
				templateUrl: "app/search/search.grid.html",
				controller: "SearchController",
				controllerAs: "sc"
			})
			.state('register', {
				url: "/register",
				templateUrl: "app/user/register.html",
				controller: "UserController",
				controllerAs: "uc"
			})
			.state('propertyGrid', {
				url: "/propertyGrid",
				templateUrl: "app/property/property.grid.html",
				controller: "PropertyController",
				controllerAs: "pc"
			})
			.state('propertyGrid.propertyDetail', {
				url: "/propertyDetail",
				templateUrl: "app/property/property.detail.html",
				controller: "PropertyController",
				controllerAs: "pc"
			})
        })
})();
