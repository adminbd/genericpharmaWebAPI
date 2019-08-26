(function( $ ) {

	// NAVIGATION CALLBACK FOR Woocommerce MENU
	var ww = jQuery(window).width();
	jQuery(document).ready(function() { 
		jQuery(".top-menu .nav li a").each(function() {
			if (jQuery(this).next().length > 0) {
				jQuery(this).addClass("parent");
			};
		})
		jQuery(".toggleWooMenu").click(function(e) { 
			e.preventDefault();
			jQuery(this).toggleClass("active");
			jQuery(".top-menu .nav").slideToggle('fast');
		});
		adjustMenu();
	})

	// navigation orientation resize callbak
	jQuery(window).bind('resize orientationchange', function() {
		ww = jQuery(window).width();
		adjustMenu();
	});

	var adjustMenu = function() {
		if (ww < 720) {
			jQuery(".toggleWooMenu").css("display", "block");
			if (!jQuery(".toggleWooMenu").hasClass("active")) {
				jQuery(".top-menu .nav").hide();
			} else {
				jQuery(".top-menu .nav").show();
			}
			jQuery(".top-menu .nav li").unbind('mouseenter mouseleave');
		} else {
			jQuery(".toggleWooMenu").css("display", "none");
			jQuery(".top-menu .nav").show();
			jQuery(".top-menu .nav li").removeClass("hover");
			jQuery(".top-menu .nav li a").unbind('click');
			jQuery(".top-menu .nav li").unbind('mouseenter mouseleave').bind('mouseenter mouseleave', function() {
				jQuery(this).toggleClass('hover');
			});
		}
	}

	// NAVIGATION CALLBACK FOR MAIN MENU
	var ww = jQuery(window).width();
	jQuery(document).ready(function() { 
		jQuery(".main-menu .nav li a").each(function() {
			if (jQuery(this).next().length > 0) {
				jQuery(this).addClass("parent");
			};
		})
		jQuery(".toggleMenu").click(function(e) { 
			e.preventDefault();
			jQuery(this).toggleClass("active");
			jQuery(".main-menu .nav").slideToggle('fast');
		});
		adjustMenu();
	})

	// navigation orientation resize callbak
	jQuery(window).bind('resize orientationchange', function() {
		ww = jQuery(window).width();
		adjustMenu();
	});

	var adjustMenu = function() {
		if (ww < 720) {
			jQuery(".toggleMenu").css("display", "block");
			if (!jQuery(".toggleMenu").hasClass("active")) {
				jQuery(".main-menu .nav").hide();
			} else {
				jQuery(".main-menu .nav").show();
			}
			jQuery(".main-menu .nav li").unbind('mouseenter mouseleave');
		} else {
			jQuery(".toggleMenu").css("display", "none");
			jQuery(".main-menu .nav").show();
			jQuery(".main-menu .nav li").removeClass("hover");
			jQuery(".main-menu .nav li a").unbind('click');
			jQuery(".main-menu .nav li").unbind('mouseenter mouseleave').bind('mouseenter mouseleave', function() {
				jQuery(this).toggleClass('hover');
			});
		}
	}


	
})( jQuery );