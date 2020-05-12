
$(document).ready(function(){
    let alreadyDid = false;

    var navmenu = $("#header");

    var triggerMenu = $('#header .trigger');

    $(document).on('scroll',function(){
        const viewTop = $(document).scrollTop();  //Ekranin yuxari heddi
        const viewBottom = viewTop +$(window).height(); //Ekranin asagi heddine qeder olan mesafe
        
        // NAVIGATION MENU
        if(viewTop > navmenu[0].clientHeight){
            navmenu.css({
                "background-color": "white",
                "box-shadow": "7px 7px 11px -7px rgba(110,110,110,1)",
                "transition" : "all 0.5s ease 0s",
                "border-bottom" : "1px solid #FDA94F"
            });
        }
        else{
            navmenu.css({
                "background-color": "transparent",
                "box-shadow": "none",
                "transition" : "all 0.5s ease 0s",
                "border-bottom" : "none"
            });
        }
        // END of NAVIGATION MENU       
        
    });
     //NAVIGATION TABS MENU 
     $('.nav-tabs > li > a').click(function(event){
        event.preventDefault();//stop browser to take action for clicked anchor
					
		//get displaying tab content jQuery selector
		var active_tab_selector = $('.nav-tabs > li.active > a').attr('href');					
					
		//find actived navigation and remove 'active' css
		var actived_nav = $('.nav-tabs > li.active');
		actived_nav.removeClass('active');
					
		//add 'active' css into clicked navigation
		$(this).parents('li').addClass('active');
					
		//hide displaying tab content
		$(active_tab_selector).removeClass('active');
		$(active_tab_selector).addClass('hide');
					
		//show target tab content
		var target_tab_selector = $(this).attr('href');
		$(target_tab_selector).removeClass('hide');
		$(target_tab_selector).addClass('active');
        });
        //END OF NAVIGATION TABS MENU

        //Carousels
        if($(".property-photo").length>0){
            $(".property-photo").owlCarousel({
                loop:true,
                items: 1,
                nav:true,
                smartSpeed: 500,
                dots: false
            });
        }
        
        //Show POPUP 
        $(".property-photo .item").click(function(){ 
            $href = $(this).children("img").attr("src"); //get image source from pressed image
            $("#modal").css("display","flex"); //Show popup
            $("#modal #modal-content img").attr("src", ""+ $href); //set image source into popup
         
        });

        //Close Popup 
        $("#modal #modal-content img").click(function(){
            ClosePopup();
        });
        $("#modal #close").click(function(){
            ClosePopup();
        });

        function ClosePopup(){
            $("#modal").css("display", "none");
            $(".property-photo .show").removeClass("show");
            $(".property-photo .active").addClass("show");
        };

        //Select Next arrow button
        $next = $("#modal > #modal-content > .nav-buttons > i[aria-label='Next']");
        //Select Previous arrow button
        $prev = $("#modal > #modal-content > .nav-buttons > i[aria-label='Previous']");
        
        //Adding show class into active photo in owl for using in popup
        $(".property-photo .active").addClass("show");
        
        //Next arrow button click
        $next.click(function(){
            $active = $(".property-photo .show");
            $nextItem = $active.next();
            $start = $(".owl-item").not(".cloned").first();
           
            ChangePhotoInModal($active, $nextItem, $start);
        });

        //Previous arrow button click
        $prev.click(function(){
            $active = $(".property-photo .show");
            $prevItem = $active.prev();
            $start = $(".owl-item").not(".cloned").last();

            ChangePhotoInModal($active, $prevItem, $start);

        });


        // Function for change image in Popup
        function ChangePhotoInModal(active, arrow, start){
            if(arrow.length>0 && !arrow.hasClass("cloned")){
                arrow.addClass("show");
                active.removeClass("show");
            }
            else{
                start.addClass("show");
                active.removeClass("show");
            }
             $("#modal #modal-content img").attr("src", ""+arrow.find("img").attr("src"));
        }
        
        if($(".partners-logo").length>0){
            $(".partners-logo").owlCarousel({
                loop:true,
                items: 3,
                loop: true,
                nav:true,
                smartSpeed: 500,
                autoplay: true,
                autoplayTimeout: 2000,
                autoplayHoverPause: true,
                dots: false
            });
        }
        
        $("#propSort").change(function(){
            if($(this).val()=='yenitikili'||
            $(this).val()=='köhnətikili' ||
            $(this).val()=='heyetevi'){
                $('#flatSum').removeClass('d-none');
                $('#totalVolume').removeClass('d-none');
            }
            else if($(this).val()=='ofis'||
            $(this).val()=='obyekt'||
            $(this).val()=='qaraj'
            ){
                $('#totalVolume').removeClass('d-none');
                if(!$('#flatSum').hasClass('d-none')){
                    $('#flatSum').addClass('d-none');
                }
            }
            else{
                $('#flatSum').addClass('d-none');
                $('#totalVolume').addClass('d-none');
            }
            
        })

        $("#city").change(function(){
            if($(this).val()=="Bakı"){
                $('#regionCity').removeClass('d-none');
            }
            else{
                if(!$('#regionCity').hasClass('d-none')){
                    $('#regionCity').addClass('d-none');
                }
            }
        })
        // END of Carousels
        
        $("#showMap").click(function(){
            $("#modal").css("display", "block");
        });
        $("#modal #close").click(function(){
            $("#modal").css("display", "none");
        })
        
        // //#PARALLAX DIGIT counterup 
        // if($('.content-parallax strong').length>0){
        //     let digits = $('.content-parallax strong');
        //     var limits = [96, 190, 12, 46];
        //     const time = 1000;        
        //     let parallaxSectionTop = $('#parallax-digits').offset().top;
        //     let parallaxSectionMidlle = parallaxSectionTop + $('#parallax-digits').height()/2;       
        //     if(viewTop<parallaxSectionTop && parallaxSectionMidlle<viewBottom && !alreadyDid){
        //         alreadyDid = true;
        //         $(digits).each((index, digit)=>{
        //             let count = 1;
        //             const Counter = setInterval(function(){
        //                     if(count>=limits[index]){                    
        //                         clearInterval(Counter)                        
        //                     }                                        
        //                     $(digit).text(count++)
        //             },time/limits[index])
        //         })
        //     }
        // }        
        // //#END of PARALLAX DIGIT counterup       
        

        // // FEATURES FADEUP
        // if($(".content-features").length>0){
        //     let featuresSectionTop = $('#features').offset().top;
        //     let featuresSectionMidlle = featuresSectionTop + $('#features').height()/2 
        //     if(featuresSectionMidlle<viewBottom){
        //         FadeIn($(".content-features"), "Y");
        //     }
        // }        
        // // END OF FEATURES FADEUP


        // //CLOUD SERVICES FADE-LEFT        
        // if($('#cloud-services .content-photo img').length>0){
        //     let cloudservicesSectionTop = $('#cloud-services').offset().top;
        //     let cloudservicesSectionMidlle = cloudservicesSectionTop + $('#cloud-services').height()/2 
        //     if(cloudservicesSectionMidlle<viewBottom){
        //         FadeIn($('#cloud-services .content-photo img'), "X");
        //     }
        // }       
        // //END OF CLOUD SERVICES FADE-LEFT

        // //DESIGN DEVELOPMENT FADE-LEFT
        // if( $('#design-development .content-photo img').length>0){
        //     let designdevelopmentSectionTop = $('#design-development').offset().top;
        //     let designdevelopmentSectionMidlle = designdevelopmentSectionTop + $('#design-development').height()/2; 
        //     if(designdevelopmentSectionMidlle<viewBottom){
        //         FadeIn($('#design-development .content-photo img'), "X");
        //     }
        // }        
        // //END OF DESIGN DEVELOPMENT FADE-LEFT
        
        // //PRICE PLAN FADE-UP
        // if($('.content-price').length>0){            
        //     let priceplanSectionTop = $('#price-plans').offset().top;
        //     let priceplanSectionMidlle = priceplanSectionTop + $('#price-plans').height()/2;           
        //     if(priceplanSectionMidlle<viewBottom){                
        //         FadeIn($('.content-price'), "Y");                
        //     }
        // }
       //END of PRICE PLAN FADE-UP

//     // SMOOTH SLIDE SECTIONS ON NAVBAR MENU
//     $('a[href^="#"]').on('click', function(e) {
//         e.preventDefault()
//         if($(this).attr('href').length>1){
//             if($(window).width()<991){
//                 $("#header .menu").slideToggle();
//             }
//            $('html, body').animate(
//                {
//                  scrollTop: $($(this).attr('href')).offset().top,
//                },
//                1000,
//                'linear'
//              )
//          }
      
//       })
//     // END OF SMOOTH SLIDE SECTIONS

//     //Trigger MENU in RESPONSIVE SIDE  
//     triggerMenu.click(function(){
//         $("#header .menu").slideToggle();
//         $('#header .trigger').toggleClass('active');
//     })
//     //END of Trigger MENU in RESPONSIVE SIDE  

//     //ACCORDION MENU
//     var accordionButton = $('#faq .content-header');
//     var accordionMenu = $('#faq .content-text');   
//     // Opened menu when page is loaded
//     $('#faq .content-header').eq(1).addClass('active').next().slideDown('normal');
    
//     // Click function for accordion buttons
//     accordionButton.click((e)=>{
//         e.preventDefault();
//        if(!$(e.currentTarget).hasClass("active")){        
//         accordionButton.removeClass('active');
//         accordionMenu.slideUp('normal');
//         $(e.currentTarget).next().stop(true,true).slideDown('normal');
//         $(e.currentTarget).addClass('active');        
//        }
//     });    
//     // END of ACCORDION MENU
    
// function FadeIn(items, type){
//     $.each(items, function(index){
//         let time = [index+1]*0.4;
//         if(type=="Y"){
//             $(this).css({
//                 "transform" : 'translateY(0px)',
//                 "transition" : 'all ' +  time + 's linear 0s',
//                 "opacity" : '1'
//           }) 
//         }
//         else if(type=="X"){
//             $(this).css({
//                 "transform" : 'translateX(0px)',
//                 "transition" : 'all ' +  time + 's linear 0s',
//                 "opacity" : '1'
//           }) 
//         }  

//         }
        
//     )};

});

