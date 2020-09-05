"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/booksPageHub").build();

//connection.on("CountPerBook", (booksCount) => {
//    console.log(booksCount);
//    for (var i = 0; i < booksCount.length; i++) {
//        var bookCount = document.getElementById("bookCount-" + booksCount[i].id);

//        bookCount.textContent = bookCount.textContent.substring(0, bookCount.textContent.lastIndexOf(" ") + 1)
//            + booksCount[i].count;

//        if (booksCount[i].count > 10) {
//            bookCount.classList = "text-success float-right mb-0";
//        }
//        else {
//            bookCount.classList = "text-danger float-right mb-0";
//        }
//    }
//});

connection.on("EditBook", (editBook) => {
    console.log(editBook);
    var bookTitle = document.getElementById("bookTitle-" + editBook.id);
    bookTitle.textContent = editBook.title;

    var bookPrice = document.getElementById("bookPrice-" + editBook.id);
    bookPrice.textContent = bookPrice.textContent.substring(0, bookPrice.textContent.lastIndexOf(" ") + 1) + editBook.price;

    var bookCount = document.getElementById("bookCount-" + editBook.id);
    bookCount.textContent = bookCount.textContent.substring(0, bookCount.textContent.lastIndexOf(" ") + 1) + editBook.count;

    if (editBook.count > 10) {
        bookCount.classList = "text-success float-right mb-0";
    }
    else {
        bookCount.classList = "text-danger float-right mb-0";
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});