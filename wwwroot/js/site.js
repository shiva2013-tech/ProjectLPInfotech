// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    var PlaceHolderELement = $("#PlaceHolderHere");
 
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHolderELement.html(data);
            PlaceHolderELement.find('.modal').modal('show');
        })
    });

    PlaceHolderELement.on('click', '[data-save="modal"]', function (event) {
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        //var url = "/Settings/" + actionUrl;
        var url = actionUrl;
        var sendData = form.serialize();
        $.post(url, sendData).done(function (data) {
            PlaceHolderELement.find('.modal').modal('hide');
        })
    })
});
