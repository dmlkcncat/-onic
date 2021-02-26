angular.module('starter.services', [])

.factory('Chats', function() {
  // Might use a resource here that returns a JSON array

  // Some fake testing data
  var chats = [{
    id: 0,
    face: 'img/forrest.jpg'
  }, {
    id: 1,
    face: 'img/forrest.jpg'
  }, {
    id: 2,
    face: 'img/adam.jpg'
  }, {
    id: 3,
    face: 'img/perry.png'
  }, {
    id: 4,
    face: 'img/mike.png'
  }];

  return {
    all: function() {
      return chats;
    },
    remove: function(film) {
      chats.splice(chats.indexOf(film), 1);
    },
    get: function(filmid) {
      for (var i = 0; i < chats.length; i++) {
        if (chats[i].id === parseInt(filmid)) {
          return chats[i];
        }
      }
      return null;
    }
  };
});
