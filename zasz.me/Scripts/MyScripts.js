/*
Home Page 
Status-History widget 
*/

$(document).ready(function () {
AttachClickHandlers();
$('.Modal').modalpop({ speed: 300 });
});

var StatusExpanded = false;
var BodyClickedHandlers = new Array();

function AttachClickHandlers() {

$('body').click(BodyClicked)
$('#Status-History-Expand-Button').click(ExpandStatus);
}


function BodyClicked() {
jQuery.each(BodyClickedHandlers, function () {
this();
})
}

function ExpandStatus() {
if (StatusExpanded)
CloseStatus();
else {
BodyClickedHandlers.push(CloseStatus);
$('#Status-History').toggleClass('Status-History Status-History-Expanded')
StatusExpanded = true;
}
return false;
}

function CloseStatus() {
if (StatusExpanded) {
$('#Status-History').removeClass('Status-History-Expanded')
$('#Status-History').addClass('Status-History')
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
*/

(function () {
    jQuery.fn.modalpop = function (options) {

        var defaults = {
            speed: 500,
            center: false
        };

        var options = $.extend(defaults, options);
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
                //Get the window height and width
                var winH = height;
                var winW = width;

                //Set the popup window to center if required
                if (defaults.center == true) {
                    $(id).css('top', winH / 2 - $(id).height() / 2);
                } else {
                    $(id).css('top', 200);
                }
                $(id).css('left', winW / 2 - $(id).width() / 2);
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


