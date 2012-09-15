$(document).ready(function() {
    addJqueryCenter();
    addJqueryModal();
    attachHandlers();
});

var statusExpanded = false;
var bodyClickedHandlers = new Array();

function attachHandlers() {
    /* ClickHandlers */
    $('body').click(bodyClicked);
    $('#Status-History-Expand-Button').click(expandStatus);
    $('.Expand-Button').click(function() {
        $(this).next().slideToggle();
    });
    /* OtherWireup */
    $('.Modal').modalpop({ speed: 300 });
    $("#Search-Box").keypress(function (e) {
        if (e.which == 13) {
            $('#SearchForm').submit();
            return true;
        }
        return true;
    });
    $("#Search-Box").autocomplete({
        source: "/Home/Autocomplete"
    });
    if ($('#blogTagCloud').length > 0) {
        $('#blogTagCloud').load(function() {
            $.get('/Blog/TagCloudLinks', function(links) {
                $('#tagCloudLinks').replaceWith(links);
            });
        });
    }
}

function bodyClicked() {
    jQuery.each(bodyClickedHandlers, function() {
        this();
    });
}

function expandStatus() {
    if (statusExpanded)
        closeStatus();
    else {
        bodyClickedHandlers.push(closeStatus);
        $('#Status-History').toggleClass('Status-History Status-History-Expanded');
        statusExpanded = true;
    }
    return false;
}

function closeStatus() {
    if (statusExpanded) {
        $('#Status-History').removeClass('Status-History-Expanded');
        $('#Status-History').addClass('Status-History');
        statusExpanded = false;
    }
}

function addJqueryCenter() {
    jQuery.fn.center = function () {
        this.css('position', 'absolute');
        this.css('top', ($(window).height() - this.outerHeight()) / 2 + $(window).scrollTop() + 'px');
        this.css('left', ($(window).width() - this.outerWidth()) / 2 + $(window).scrollLeft() + 'px');
        return this;
    };
}

function addJqueryModal() {
    /*
    Popup is centered based on
    http://stackoverflow.com/questions/210717/what-is-the-best-way-to-center-a-div-on-the-screen-using-jquery
    */
    jQuery.fn.modalpop = function(options) {

        var defaults = {
            speed: 500,
            center: false
        };

        $.extend(defaults, options);
        var width = $(window).width();
        //Get the full page height including the scroll area
        var height = $(document).height();
        jQuery('body').prepend('<div id=\'mask\'></div>');
        jQuery('#mask').css('height', height);
        jQuery('#mask').css('width', width);

        return this.each(function() {

            jQuery(this).click(function() {
                $this = jQuery(this);
                var id = $this.attr('href');
                $(id).center();
                $('#mask').css('filter', 'alpha(opacity=80)');
                jQuery('#mask').fadeIn(defaults.speed);
                jQuery(id).fadeIn(defaults.speed);
                return false;
            });

            jQuery('#mask').click(function() {
                jQuery(this).fadeOut(defaults.speed);
                jQuery('.Pro-Popup').fadeOut(defaults.speed);
            });

        });
    };
}