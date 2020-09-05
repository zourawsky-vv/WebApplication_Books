"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/indexPageHub").build();

connection.on("SendBooksCount", (booksCount) => {
    var bBooksCount = document.getElementById("bookCount");
    bBooksCount.textContent = booksCount;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
})