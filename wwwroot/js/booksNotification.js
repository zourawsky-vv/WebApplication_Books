"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/booksPageHub").build();

connection.on("CountPerBook", (booksCount) => {
    for (var i = 0; i < booksCount.length; i++) {
        var bookCount = document.getElementById("book-" + booksCount[i].id);

        bookCount.textContent = bookCount.textContent.substring(0, bookCount.textContent.lastIndexOf(" ") + 1)
            + booksCount[i].count;

        if (booksCount[i].count > 10) {
            bookCount.classList = "text-success float-right mb-0";
        }
        else {
            bookCount.classList = "text-danger float-right mb-0";
        }
    }
})

connection.start().catch(function (err) {
    return console.error(err.toString());
});