"use strict";

$(document).ready(() => {
    $('form.contact-form').submit((e) => {
        e.preventDefault();
        let formData = new FormData(e.currentTarget);

        $.ajax({
            url: 'Home/Subscribe/',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: (res) => {
                console.log(res)
            },
            error: (err) => {
                console.log(err)
            }
        })
    })
})