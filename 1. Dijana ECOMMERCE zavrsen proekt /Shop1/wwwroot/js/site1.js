/* --------------------------- FOCUS --------------------------- */

$(function () {
    var message = "Where'd you go boo? 🥺";
    var original;

    $(window).focus(function () {
        if (original) {
            document.title = original;
        }
    }).blur(function () {
        var title = $('title').text();
        if (title != message) {
            original = title;
        }
        document.title = message;
    });
});

/* --------------------------- END FOCUS --------------------------- */


// search

$(document).ready(function () {
    $("#productName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/api/product/search',
                headers: { "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val() },
                data: { "term": request.term },
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (xhr, textStatus, error) {
                    alert(xhr.statusText);
                    alert(textStatus);
                    alert(error);
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                }
            });
        },
        minLength: 2
    });
});


// konverzija all letters to uppercase
function myFunction() {
    var x = document.getElementById("inputToUpper");
    x.value = x.value.toUpperCase();
}




////
$(function () {
    $('.list-heading-accordion').on('click', function (e) {
        e.preventDefault();
        if ($(this).hasClass('active')) {
            $(this).removeClass('active');
            $(this).next()
                .stop()
                .slideUp(300);
        } else {
            $(this).addClass('active');
            $(this).next()
                .stop()
                .slideDown(300);
        }
    });
});


/* --------------------------- INDEX SHOP SCROLL TO TOP --------------------------- */

// Get the button
let mybutton = document.getElementById("myBtn");

// When the user scrolls down 20px from the top of the document, show the button
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
        mybutton.style.display = "block";
    } else {
        mybutton.style.display = "none";
    }
}

// When the user clicks on the button, scroll to the top of the document
function topFunction() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}


/* --------------------------- END INDEX SHOP SCROLL TO TOP --------------------------- */
