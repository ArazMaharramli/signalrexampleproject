"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    AddMessageToUI(user, message);
});

connection.start().then(function () {
    GetOldMessages();
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var receiverUserId = $('#ReceiverId').val();
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", receiverUserId, message).catch(function (err) {
        return console.error(err.toString());
    });
    AddMessageToUI("You", message);
    event.preventDefault();
});

function AddMessageToUI(user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").prepend(li);
    li.textContent = `${user} : ${message}`;
}

function GetOldMessages() {
    document.getElementById("messagesList").innerHTML = "";
    connection.invoke("GetOldMessages").catch(function (err) {
        return console.error(err.toString());
    });
}