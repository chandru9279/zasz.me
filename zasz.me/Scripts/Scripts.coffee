attachHandlers = ->	
	# ClickHandlers
	
	$(".Expand-Button").click ->
		$(this).next().slideToggle()
	
	# OtherWireup
	$(".Modal").modalpop speed: 300

	$("#Search-Box").keypress (e) ->
		if e.which is 13
			$("#SearchForm").submit()
			return true
		true

	$("#Search-Box").autocomplete source: "/Home/Autocomplete"
	
	if $("#BlogTagCloud").length > 0
		$("#BlogTagCloud").load ->
			$.get "/Blog/TagCloudLinks", (links) ->
				$("#TagCloudLinks").replaceWith links
				return
			return
		return

addJqueryCenter = ->
	jQuery.fn.center = ->
		@css "position", "absolute"
		@css "top", ($(window).height() - @outerHeight()) / 2 + $(window).scrollTop() + "px"
		@css "left", ($(window).width() - @outerWidth()) / 2 + $(window).scrollLeft() + "px"
		this

addJqueryModal = ->	
	#Popup is centered based on
	#http://stackoverflow.com/questions/210717/what-is-the-best-way-to-center-a-div-on-the-screen-using-jquery
	jQuery.fn.modalpop = (options) ->
		defaults =
			speed: 500
			center: false

		$.extend defaults, options
		width = $(window).width()		
		#Get the full page height including the scroll area
		height = $(document).height()
		jQuery("body").prepend "<div id='mask'></div>"
		jQuery("#mask").css "height", height
		jQuery("#mask").css "width", width
		@each ->
			jQuery(this).click ->
				$this = jQuery(this)
				id = $this.attr("href")
				$(id).center()
				$("#mask").css "filter", "alpha(opacity=80)"
				jQuery("#mask").fadeIn defaults.speed
				jQuery(id).fadeIn defaults.speed
				false

			jQuery("#mask").click ->
				jQuery(this).fadeOut defaults.speed
				jQuery(".Pro-Popup").fadeOut defaults.speed
		
$(document).ready ->
	addJqueryCenter()
	addJqueryModal()
	attachHandlers()