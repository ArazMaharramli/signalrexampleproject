"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

connection.on("ReceiveNotification", function (header, message) {
    showNotification(header, message, 10000);
});

connection.start().then(function () {
    showNotification("#", "Connected", 3000);
}).catch(function (err) {
    showNotification("#", "Connection Error", 3000);
    return console.error(err.toString());
});

function showNotification(header, message, delay) {

    $("#notificationPanel").show();
    var html = '<div class="row"><a href="' + header + '">' + message + '</a></div>';
    $("#notificationPanel").append(html);

    setTimeout(function () {
        $("#notificationPanel").hide();
        document.getElementById("notificationPanel").innerHTML = "";
    }, delay);
}