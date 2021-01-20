/*------------------------------------------------------------------------------------
    
JS INDEX
=============

01 - Main Slider JS
02 - Counter JS
03 - Gallery Lightbox JS
04 - Testimonial JS
05 - Team Slider JS
06 - Category JS
07 - Progressbar JS
08 - Responsive Menu
09 - Btn To Top JS



-------------------------------------------------------------------------------------*/


(function ($) {
	"use strict";

    jQuery(document).ready(function($){
        
        /* 
        =================================================================
        01 - Main Slider JS
        =================================================================	
        */
        
        $(".bleezy-slide").owlCarousel({
            animateOut: 'fadeOut',
            animateIn: 'fadeIn',
            items: 1,
            nav: true,
            dots: false,
            autoplay: true,
            loop: true,
            navText: ["<i class='fa fa-chevron-left'></i>", "<i class='fa fa-chevron-right'></i>"],
            mouseDrag: false,
            touchDrag: false
        });
        
        $(".bleezy-slide").on("translate.owl.carousel", function(){
            $(".bleezy-main-slide h2, .bleezy-main-slide p").removeClass("animated fadeInUp").css("opacity", "0");
            $(".bleezy-main-slide .bleezy-btn").removeClass("animated fadeInDown").css("opacity", "0");
        });
        $(".bleezy-slide").on("translated.owl.carousel", function(){
            $(".bleezy-main-slide h2, .bleezy-main-slide p").addClass("animated fadeInUp").css("opacity", "1");
            $(".bleezy-main-slide .bleezy-btn").addClass("animated fadeInDown").css("opacity", "1");
        });
        
        
        /* 
        =================================================================
        02 - Counter JS
        =================================================================	
        */
        
        
        $('.counter').counterUp({
            delay: 10,
            time: 1000
        });
        
        
        /* 
        =================================================================
        03 - Lightbox JS
        =================================================================	
        */


          $('.gallery2').featherlightGallery({

            gallery: {
              next: 'next Ã‚Â»',
              previous: 'Ã‚Â« previous'
            },
            variant: 'featherlight-gallery2'

          });
        
        /* 
        =================================================================
        04 - Testimonial JS
        =================================================================	
        */
        
        $(".testimonial-slide").owlCarousel({
            autoplay:true,
            loop:true,
            margin:20,
            touchDrag:false,
            mouseDrag:false,
            items:1,
            nav: false,
            dots: true,
            autoplayTimeout: 6000,
            autoplaySpeed: 1200,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            responsive:{
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                600: {
                    items: 1
                },
                1000: {
                    items: 1
                },
                1200: {
                    items: 1
                }
            }
        });

        
        /* 
        =================================================================
        05 - Team Slider JS
        =================================================================	
        */
        $(".team-slider").owlCarousel({
            autoplay:true,
            loop:true,
            margin:20,
            touchDrag:true,
            mouseDrag:true,
            nav: true,
            dots: false,
            autoplayTimeout: 6000,
            autoplaySpeed: 1200,
            autoplayHoverPause:true,
            navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            responsive:{
                0: {
                    items: 1
                },
                480: {
                    items: 1
                },
                600: {
                    items: 3
                },
                1000: {
                    items: 4
                },
                1200: {
                    items: 4
                }
            }
        });
        
        /* 
        =================================================================
        06 - Category JS
        =================================================================	
        */
        
          $(document).on('click','.widget_product_categories a, .widget_categories a',function(){
            var paerent = $(this).closest('li');
            var t = $(this);
            if(paerent.children('ul').length > 0){
                $(this).closest('li').children('ul').slideToggle();
                return false;
            }
            })
        
         /* 
        =================================================================
        07 - Progressbar JS
        =================================================================	
        */
            var $pcircle = $('.circle');
            var $pbar = $('.bar');
            $pcircle.each(function(i) {
            var circle = new ProgressBar.Circle(this, {
                color: 'rgba(224, 26, 34, 0.82)',
                trailColor: 'rgba(224, 26, 34, 0.82)',
                strokeWidth: 2,
                trailWidth: 2,
                duration: 2000,
                easing: 'easeInOut'
            });
            var cvalue = ($(this).attr('data-value') / 100);
            $pcircle.waypoint(function() {
                circle.animate(cvalue);
                }, {
                offset: "100%"
                })
            });
            $pbar.each(function(i) {
            var bar = new ProgressBar.Line(this, {
                color: '#f26520',
                trailColor: '#0d0d0d',
                strokeWidth: 2,
                trailWidth: 2,
                duration: 3000,
                easing: 'easeInOut',
                text: {
                    style: {
                        color: '#0d0d0d',
                        position: 'absolute',
                        right: '0',
                        top: '-30px',
                        padding: 0,
                        margin: 0,
                        transform: null
                    },
                    autoStyleContainer: false
                },
                step: function(state, bar, attachment) {
                    bar.setText(Math.round(bar.value() * 100) + ' %');
                }
            });
            var bvalue = ($(this).attr('data-value') / 100);
            $pbar.waypoint(function() {
                bar.animate(bvalue);
            },   {
                    offset: "100%"
                })
            });
        
        
        
        /* 
        =================================================================
        08 - Responsive Menu
        =================================================================	
        */
        $("ul#bleezy_navigation").slicknav({
            prependTo: ".bleezy-responsive-menu"
        });
        
        
        /* 
        =================================================================
        09 - Btn To Top JS
        =================================================================	
        */
        if ($("body").length) {
            var btnUp = $('<div/>', {
                'class': 'btntoTop'
            });
            btnUp.appendTo('body');
            $(document).on('click', '.btntoTop', function() {
                $('html, body').animate({
                    scrollTop: 0
                }, 700);
            });
            $(window).on('scroll', function() {
                if ($(this).scrollTop() > 200) $('.btntoTop').addClass('active');
                else $('.btntoTop').removeClass('active');
            });
        }
        
        

    });
}(jQuery));	
