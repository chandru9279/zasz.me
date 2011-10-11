/*
Home Page 
Status-History widget 
*/

$(document).ready(function () {

    AttachHandlers();

    jQuery.fn.center = function () {
        this.css("position", "absolute");
        this.css("top", ($(window).height() - this.outerHeight()) / 2 + $(window).scrollTop() + "px");
        this.css("left", ($(window).width() - this.outerWidth()) / 2 + $(window).scrollLeft() + "px");
        return this;
    };
});

var StatusExpanded = false;
var BodyClickedHandlers = new Array();

function AttachHandlers() {
    /* ClickHandlers */
    $('body').click(BodyClicked);
    $('#Status-History-Expand-Button').click(ExpandStatus);
    $(".Expand-Button").click(function () {
        $(this).next().slideToggle();
    });
    /* OtherWireup */
    $('.Modal').modalpop({ speed: 300 });
    $.watermark.options.className = 'Light-Message';
}


function BodyClicked() {
    jQuery.each(BodyClickedHandlers, function() {
        this();
    });
}

function ExpandStatus() {
    if (StatusExpanded)
        CloseStatus();
    else {
        BodyClickedHandlers.push(CloseStatus);
        $('#Status-History').toggleClass('Status-History Status-History-Expanded');
        StatusExpanded = true;
    }
    return false;
}

function CloseStatus() {
    if (StatusExpanded) {
        $('#Status-History').removeClass('Status-History-Expanded');
        $('#Status-History').addClass('Status-History');
        StatusExpanded = false;
    }
}


/*
ModalPop 

Author: Owain Lewis
Author URL: www.Owainlewis.com
Simple Modal Dialog for jQuery
The idea here was to keep this plugin as lightweight and easy to customize as possible
You are free to use this plugin for whatever you want.
If you enjoy this plugin, I'd love to hear from you

With minor edits to the way the popup is centered based on
http://stackoverflow.com/questions/210717/what-is-the-best-way-to-center-a-div-on-the-screen-using-jquery
*/

(function () {
    jQuery.fn.modalpop = function (options) {

        var defaults = {
            speed: 500,
            center: false
        };

        $.extend(defaults, options);
        var width = $(window).width();
        //Get the full page height including the scroll area
        var height = $(document).height();
        jQuery('body').prepend("<div id='mask'></div>");
        jQuery('#mask').css('height', height);
        jQuery('#mask').css('width', width);

        return this.each(function () {

            jQuery(this).click(function () {
                $this = jQuery(this);
                var id = $this.attr('href');
                $(id).center();
                $('#mask').css('filter', 'alpha(opacity=80)');
                jQuery('#mask').fadeIn(defaults.speed);
                jQuery(id).fadeIn(defaults.speed);
                return false;
            });

            jQuery('#mask').click(function () {
                jQuery(this).fadeOut(defaults.speed);
                jQuery('.Pro-Popup').fadeOut(defaults.speed);
            });

        });
    };

})(jQuery);


