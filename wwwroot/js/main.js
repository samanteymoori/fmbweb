jQuery(function ($) {
    "use strict"
    var preloader = $('.preloader');
    preloader.remove();
    
    $('#datetimepicker4').datetimepicker();
	
	var htmlBody = $('html,body');
	var app = $("#appointment");
	//Event delegation for slider appointment
    $("#slider").on("click",function (e) {
		if ( $(e.target).is('a') ) 
			htmlBody.animate({scrollTop: app.offset().top - 60},'slow');
		return false;
    });

    // Init the slider 
    InitSlider();
    
    //Init doc details
    InitDocDetails();

    //Init testimonials
    InitTestimonials();

    //Init gallery
    InitGallery();

    //Init partners
    InitPartners();
});

//Init the slider
function InitSlider()
{
    $('#slider #wrapper').slick({
        dots: true,
        arrows: true,
        autoplay: true,
        infinite: true,
        speed: 500,
        fade: true,
        adaptiveHeight: false,
        swipeToSlide: true,
        cssEase: 'linear'
    });
}
$(document).ready(function(){
  $('#slider .inner').css('height', $(window).height() + 'px');
});

//Init doctors slider
function InitDocDetails()
{
    $('#ourdoctors #details').slick({
        lazyLoad: 'ondemand',
        slidesToShow: 3,
        slidesToScroll: 1,
        prevArrow: '<div class="arrow-left"><span class="fa fa-angle-left"></span><span class="sr-only">Prev</span></div>',
        nextArrow: '<div class="arrow-right"><span class="fa fa-angle-right"></span><span class="sr-only">Next</span></div>',
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 2,
                    centerPadding: '0px',
                    autoplay: true,
                    arrows: false,
                    slidesToScroll: 2
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 1,
                    centerPadding: '0px',
                    autoplay: true,
                    arrows: false,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    centerPadding: '0px',
                    autoplay: true,
                    arrows: false,
                    slidesToScroll: 1
                }
            }
        ]
    });
}

//Init testimonials
function InitTestimonials()
{
    $('#testimonials #tmwrapper').slick({
        dots: true,
        infinite: true,
        speed: 600,
        slidesToShow: 1,
        arrows: false,
        customPaging: function (slider, i) {
            // this example would render "tabs" with titles
            return '<button class="tab">' + $(slider.$slides[i]).find('.slide-title').text() + '</button>';
        },
        adaptiveHeight: true
    });
}

//Init Gallery
function InitGallery()
{
    $('#gallery #phwrapper').slick({
        lazyLoad: 'ondemand',
        slidesToShow: 4,
        slidesToScroll: 1,
        prevArrow: '.gallery .details .arrow-left2',
        nextArrow: '.gallery .details .arrow-right2',

        responsive: [
        {
            breakpoint: 1200,
            settings: {
                centerMode: true,
                centerPadding: '0px',
                slidesToShow: 2
            }
        },
        {
            breakpoint: 768,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '0px',
                slidesToShow: 2
            }
        },
        {
            breakpoint: 480,
            settings: {
                arrows: false,
                centerMode: true,
                centerPadding: '0px',
                autoplay: true,
                slidesToShow: 2
            }
        }
        ]
    });
}

//Init the partners
function InitPartners()
{
    $('#partners #pwraper').slick({
        arrows: true,
        lazyLoad: 'ondemand',
        slidesToShow: 5,
        slidesToScroll: 1,
        prevArrow: '<div class="arrow-left"><span class="fa fa-angle-left"></span><span class="sr-only">Prev</span></div>',
        nextArrow: '<div class="arrow-right"><span class="fa fa-angle-right"></span><span class="sr-only">Next</span></div>',
        responsive: [
            {
                breakpoint: 992,
                settings: {
                    arrows: true,
                    centerMode: true,
                    centerPadding: '0px',
                    autoplay: true,
                    slidesToShow: 3
                }
            },
            {
                breakpoint: 768,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '0px',
                    autoplay: true,
                    slidesToShow: 2
                }
            },
            {
                breakpoint: 480,
                settings: {
                    arrows: false,
                    centerMode: true,
                    centerPadding: '0px',
                    autoplay: true,
                    slidesToShow: 1
                }
            }
        ]
    });
}



//Check if email is OK
function checkmail(input) {
    var pattern1 = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;
    if (pattern1.test(input)) { return true; } else { return false; }
}

//Send email
function sendemail() {
    var name = document.getElementById("name");
    var email = document.getElementById("email");
    var sel1 = document.getElementById("sel1");
    var datetimepicker4 = document.getElementById("datetimepicker4");
    var comment = document.getElementById("comment");

    $("section#appointment #msg")[0].style.color = "red";
    $("section#appointment #msg")[0].style.display = "none";
    if (name.value == "") {
        $("section#appointment #msg")[0].innerText = 'Please provide a name.';
        $("section#appointment #msg")[0].style.display = "block";
        return false;
    }
    else if (email.value == "") {
        $("section#appointment #msg")[0].innerText = 'Please provide an email.';
        $("section#appointment #msg")[0].style.display = "block";
        return false;
    }
    else if (checkmail(email.value) == false) {
        $("section#appointment #msg")[0].innerText = 'Please provide a valid email address.';
        $("section#appointment #msg")[0].style.display = "block";
        return false;
    }
    else if (sel1.value == "") {
        $("section#appointment #msg")[0].innerText = 'Please select a doctor.';
        $("section#appointment #msg")[0].style.display = "block";
        return false;
    }
    else if (datetimepicker4.value == "") {
        $("section#appointment #msg")[0].innerText = "Please select a datetime.";
        $("section#appointment #msg")[0].style.display = "block";
        return false;
    }
    else if (comment.value == "") {
        $("section#appointment #msg")[0].innerText = "Please give a comment.";
        $("section#appointment #msg")[0].style.display = "block";
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "php/submit.php",
            data: $("#form1").serialize(),
            success: function (msg) {
                $("section#appointment #msg")[0].innerText = msg;
                $("section#appointment #msg")[0].style.color = "green";
                $("section#appointment #msg")[0].style.display = "block";
            }
        });
    }
}