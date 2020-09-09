"use strict";

$(document).ready(function () {
    $('.sw-basic').on('click', function () {
        swal('Basic', 'Text basic', 'info');
    });

    $('.sw-success').on('click', function () {
        swal('Success', 'Text success', 'success');
    });

    $('.sw-warning').on('click', function () {
        swal('Warning', 'Text warning', 'warning');
    });

    $('.sw-error').on('click', function () {
        swal('Error', 'Text error', 'error');
    });

    $('.sw-info').on('click', function () {
        swal('Info', 'Text info', 'info');
    });

    $('.sw-okcancel').on('click', function () {
        swal({
            title: 'Make a choise?',
            text: 'Choise the button',
            icon: 'warning',
            buttons: true,
            dangerMode: true
        }).then(ans => {
            if (ans) {
                swal('Answer', 'Your answer - OK', 'success');
            }
            else {
                swal('Answer', 'Your answer - Cancel', 'error');
            }
        });
    });

    $('.sw-prompt').on('click', function () {
        swal('Write something ...', { content: 'input' }).then((value) => {
            swal('Your write: ' + value);
        })
    });

    $('.sw-ajax').on('click', function () {
        swal({
            text: 'Search for a movie.',
            content: "input",
            button: {
                text: "Search!",
                closeModal: false,
            },
        })
            .then(name => {
                if (!name) throw null;

                return fetch(`https://itunes.apple.com/search?term=${name}&entity=movie`);
            })
            .then(results => {
                return results.json();
            })
            .then(json => {
                const movie = json.results[0];

                if (!movie) {
                    return swal("No movie was found!");
                }

                const name = movie.trackName;
                const imageURL = movie.artworkUrl100;

                swal({
                    title: "Top result:",
                    text: name,
                    icon: imageURL,
                });
            })
            .catch(err => {
                if (err) {
                    swal("Oh noes!", "The AJAX request failed!", "error");
                } else {
                    swal.stopLoading();
                    swal.close();
                }
            });
    });
});