"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established

connection.on("ReceiveMessage", function (message) {
    appendMessageText(message, false);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

 function sendMessage (toUserId) {
    var message = document.getElementById("messageInput").value;

    if (toUserId != 0) {
        appendMessageText(message, true);
        connection.invoke("SendPrivateMessage", toUserId, message).catch(function (err) {
            return console.error(err.toString());
        });
    }
};

function appendMessageText(text, isMine) {
    var currendDate = new Date();
    var messageDataSpan = document.createElement("span");

    messageDataSpan.className = "message-data-time";
    messageDataSpan.innerText = currendDate.getHours() + ":" + currendDate.getMinutes();
    var messageData = document.createElement("div");
    if (isMine) {
        messageData.className = "message-data";
    } else {
        messageData.className = "message-data text-right";
    }
    messageData.appendChild(messageDataSpan);

    var messageDiv = document.createElement("div");
    if (isMine) {
        messageDiv.className = "message my-message";
    } else {
        messageDiv.className = "message other-message float-right";
    }
    messageDiv.innerText = text;

    var li = document.createElement("li");
    li.className = "clearfix";
    li.appendChild(messageData);
    li.appendChild(messageDiv);

    document.getElementById("messages").appendChild(li);
    document.getElementById("messageInput").value = "";
}