"use strict";
var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
//Disable send button until connection is established

connection.on("ReceiveMessage", function (message, fromUserId) {
    if (fromUserId == currentUserId) {
        let li = appendMessageText(message, false);
        document.getElementById("messages").appendChild(li);
        document.getElementById("messageInput").value = "";
    } else {
        let item = document.getElementById("count-" + fromUserId);
        if (item == null) {
            countData = document.createElement("div");
        }
        item.innerText = (+item.innerText) + 1;
        textItem.innerText = message;
    }
});

function getMessages(event, toUserId) {
    if (toUserId != 0) {
        connection.invoke("GetMessages", toUserId, +event.value).catch(function (err) {
            return console.error(err.toString());
        });
    }
}

connection.on("ReturnMessages", function (messages, page, isLast) {
    let messagesDiv = document.getElementById("messages");
    let firstMessage = messagesDiv.firstChild;
    let paginationButton = document.getElementById("pagination-button");
    paginationButton.value = page;

    for(const message of messages){
        let li = appendMessageText(message.text, message.isMineMessage);
        messagesDiv.insertBefore(li, firstMessage);
        firstMessage = li;
    }
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

 function sendMessage (toUserId) {
    var message = document.getElementById("messageInput").value;

    if (toUserId != 0) {
        let li = appendMessageText(message, true);
        document.getElementById("messages").appendChild(li);
        document.getElementById("messageInput").value = "";
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
        messageData.className = "message-data content-left";
    } else {
        messageData.className = "message-data content-right";
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
    return li;
}



