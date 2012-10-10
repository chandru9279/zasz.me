(function() {
  var addJqueryCenter, addJqueryModal, attachHandlers;

  attachHandlers = function() {
    $(".Expand-Button").click(function() {
      return $(this).next().slideToggle();
    });
    $(".Modal").modalpop({
      speed: 300
    });
    $("#Search-Box").keypress(function(e) {
      if (e.which === 13) {
        $("#SearchForm").submit();
        return true;
      }
      return true;
    });
    $("#Search-Box").autocomplete({
      source: "/Home/Autocomplete"
    });
    if ($("#BlogTagCloud").length > 0) {
      $("#BlogTagCloud").load(function() {
        $.get("/Blog/TagCloudLinks", function(links) {
          $("#TagCloudLinks").replaceWith(links);
        });
      });
    }
  };

  addJqueryCenter = function() {
    return jQuery.fn.center = function() {
      this.css("position", "absolute");
      this.css("top", ($(window).height() - this.outerHeight()) / 2 + $(window).scrollTop() + "px");
      this.css("left", ($(window).width() - this.outerWidth()) / 2 + $(window).scrollLeft() + "px");
      return this;
    };
  };

  addJqueryModal = function() {
    return jQuery.fn.modalpop = function(options) {
      var defaults, height, width;
      defaults = {
        speed: 500,
        center: false
      };
      $.extend(defaults, options);
      width = $(window).width();
      height = $(document).height();
      jQuery("body").prepend("<div id='mask'></div>");
      jQuery("#mask").css("height", height);
      jQuery("#mask").css("width", width);
      return this.each(function() {
        jQuery(this).click(function() {
          var $this, id;
          $this = jQuery(this);
          id = $this.attr("href");
          $(id).center();
          $("#mask").css("filter", "alpha(opacity=80)");
          jQuery("#mask").fadeIn(defaults.speed);
          jQuery(id).fadeIn(defaults.speed);
          return false;
        });
        return jQuery("#mask").click(function() {
          jQuery(this).fadeOut(defaults.speed);
          return jQuery(".Pro-Popup").fadeOut(defaults.speed);
        });
      });
    };
  };

  $(document).ready(function() {
    addJqueryCenter();
    addJqueryModal();
    return attachHandlers();
  });

}).call(this);
