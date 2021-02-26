angular.module('starter.controllers', [])

  .controller('DashCtrl', function ($scope) { })
  .controller('yeniCtrl', function ($scope) { })

.controller('ChatsCtrl', function($scope, Chats, $http) {
  // With the new view caching in Ionic, Controllers are only called
  // when they are recreated or on app start, instead of every page change.
  // To listen for when this page is active (for example, to refresh data),
  // listen for the $ionicView.enter event:
  //
  //$scope.$on('$ionicView.enter', function(e) {
  //});

  $http.get("http://localhost:50938/api/Film/TumFilmleriGetir").then(function (response) {
      $scope.film = response.data;
  });

  $scope.FilmSil = function (sid) {
    alert(sid) 
    $http.get("http://localhost:50938/api/Film/FilmSil?filmid=" + sid)
      .then(function (response) {
      $scope.film = response.data;
    });
      alert('Basariyla silindi')
    }
})

  .controller('ChatDetailCtrl', function ($scope, $stateParams, Chats, $http) {
    $http.get("http://localhost:50938/api/Bilet/BiletFilmiGetir?filmid=" + $stateParams.filmid).then(function (response) {
      $scope.biletfilm = response.data;
    });


    //$scope FilmSil = function (sid) {
    //  $http.get("http://localhost:50938/api/Bilet/BiletSil?biletid=" + sid).then(function (response) {
    //    $scope.biletfilm = response.data;
    //  });
    //}
    
  })
 

  .controller('AccountCtrl', function ($scope, $http) {
    $http.get("http://localhost:50938/api/Salon/TumSalonlariGetir").then(function (response) {
      $scope.salon = response.data;
    });
    $http.get("http://localhost:50938/api/Koltuk/TumKoltukGetir").then(function (response) {
      $scope.koltuk = response.data;
    });
    $http.get("http://localhost:50938/api/Film/TumFilmleriGetir").then(function (response) {
      $scope.film = response.data;
    });
    $scope.biletekle = function (said, kid, fid)
    {
      $scope.veri = {
        salonid: said,
        koltukid: kid,
        filmid : fid
      }
      $http.post("http://localhost:50938/api/Bilet/YeniBiletEkle", $scope.veri).then(function (response) {
        if (response.data != null)
          alert("Biletiniz  başarıyla kaydedilmiştir. İyi seyirler dileriz");
      });

    }
  $scope.settings = {
    enableFriends: true
  };
});
