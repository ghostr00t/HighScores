(function () {
    "use strict";
    angular
        .module("highScores")
        .controller("highScoresCtrl", ["playerResource", highScoresCtrl]);

    function highScoresCtrl(playerResource) {
        var vm = this;

        vm.searchCriteria = "player_1";

        playerResource.query({search: vm.searchCriteria}, function (data) {
            vm.players = data
        });
    }
}());