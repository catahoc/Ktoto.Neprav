if (!Array.prototype.find) {
    Array.prototype.find = function (predicate) {
        if (this == null) {
            throw new TypeError('Array.prototype.find called on null or undefined');
        }
        if (typeof predicate !== 'function') {
            throw new TypeError('predicate must be a function');
        }
        var list = Object(this);
        var length = list.length >>> 0;
        var thisArg = arguments[1];
        var value;

        for (var i = 0; i < length; i++) {
            value = list[i];
            if (predicate.call(thisArg, value, i, list)) {
                return value;
            }
        }
        return undefined;
    };
}

function getGetArg(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
var getUserId = function () {
    return $(this).data('user-id');
};
loadUsersIntoDivs = function (authorsToLoad) {
    var userIds = authorsToLoad.map(getUserId).get().join();
    VK.api("users.get", { user_ids: userIds, fields: "photo_100,first_name,last_name" }, function (data) {
        if (data.response) {
            authorsToLoad.each(function (ix, div) {
                var authorControl = $(div);
                var userData = data.response.find(function(el) {
                    return el.uid == authorControl.data('user-id');
                });
                var avatarControl = authorControl.find('.avatar');
                avatarControl.attr('src', userData.photo_100);
                var name = userData.first_name + ' ' + userData.last_name;
                var nameControl = authorControl.find('.name-link');
                nameControl.text(name);
            });
        }
    });
};
$(function () {
    VK.init(function () {
    });
});

