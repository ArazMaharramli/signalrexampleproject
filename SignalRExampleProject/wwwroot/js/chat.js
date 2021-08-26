"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (message) {
    AddMessageToUI(user, message);
});
connection.on("ReceiveOldMessages", function (user, message) {
    AddMessageToUI(user, message);
});
connection.start().then(function () {
    document.getElementById("messagesList").innerHTML = "";
    GetOldMessages();
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var receiverUserId = $('#receiverUserId  option:selected').val();
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", receiverUserId, message).catch(function (err) {
        return console.error(err.toString());
    });
    AddMessageToUI("You", message);
    event.preventDefault();
});

function AddMessageToUI(user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    li.textContent = `${user} : ${message}`;
}

function GetOldMessages() {
    connection.invoke("GetOldMessages").catch(function (err) {
        return console.error(err.toString());
    });
}