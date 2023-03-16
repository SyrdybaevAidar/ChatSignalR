"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/userStatus")
    .build();

//Disable the send button until connection is established.
/*document.getElementById("sendButton").disabled = true;*/
connection.start().then(function () {
});
connection.on("online", function (userId) {
    let item = document.getElementById(userId);
    item.className = "fa fa-circle online";
    let statusName = document.getElementById("user-status-" + userId);
    statusName.innerText = "online";
});

connection.on("offline", function (userId) {
    let item = document.getElementById(userId);
    item.className = "fa fa-circle offline";
    let statusName = document.getElementById("user-status-" + userId);
    statusName.innerText = "offline";
});

connection.on("GetAllOnlineUserIds", function (userIds) {

    for (const id of userIds) {
        let item = document.getElementById(id);
        item.className = "fa fa-circle online";
        let statusName = document.getElementById("user-status-" + id);
        statusName.innerText = "online";
    }
});

function checkPosition() {
    const height = document.body.offsetHeight
    const screenHeight = window.innerHeight
    const scrolled = window.scrollY

    const threshold = height - screenHeight / 4

    // Отслеживаем, где находится низ экрана относительно страницы:
    const position = scrolled + screenHeight

    if (position >= threshold) {
        // Если мы пересекли полосу-порог, вызываем нужное действие.
    }
}

