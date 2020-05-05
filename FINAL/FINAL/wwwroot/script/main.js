
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

    $('.nav-tabs > li > button').click(function () {
        //find actived navigation and remove 'active' css
        var actived_nav = $('.nav-tabs > li.active');
        actived_nav.removeClass('active');

        //add 'active' css into clicked navigation
        $(this).parents('li').addClass('active');

        if ($(this).attr('data-filter') == ".active") {
            $('.selectPanel').css("opacity", 1);

            var actived_panel = $('.selectPanel > ul > li.active');
            actived_panel.removeClass('active');

            $('.selectPanel > ul > li').first().addClass('active');
        }
        else {
            $('.selectPanel').css("opacity", 0);
        }
    });

    $('.selectPanel > ul > li > button').click(function () {

        //find actived navigation and remove 'active' css
        var actived_nav = $('.selectPanel > ul > li.active');

        actived_nav.removeClass('active');

        //add 'active' css into clicked navigation
        $(this).parents('li').addClass('active');
    });

        //END OF NAVIGATION TABS MENU

    

        //Carousels in HOME page
        if($(".property-photo").length>0){
            $(".property-photo").owlCarousel({
                loop:true,
                items: 1,
                nav:true,
                smartSpeed: 500,
                dots: false
            });
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
        
        // END of Carousels

    //REGISTER USER
    $("#userTypeId").change(function () {
        var human = $('.humanparam');
        var company = $('.companyparam');
        var value = $("#userTypeId option:selected").val();
        var paramArr = [human, company];
        // Selected PropertyOwner or Makler
        if (value > 1) { 
            
            if (!company.hasClass("d-none")) {
                company.addClass("d-none");
            }

            human.removeClass("d-none");
            
        }
        // Selected nothing
        else if (value == "") {

            for (var i = 0; i < paramArr.length; i++) {

                if (!paramArr[i].hasClass('d-none')) {

                    paramArr[i].addClass('d-none');
                }
            }

        }
        // Selected Company
        else {
            if (!human.hasClass("d-none")) {
                human.addClass("d-none");
            }

            company.removeClass("d-none");
            
        }

    });

   

    //FILE (LOGO) UPLOAD (SETTINGS)
    $('#SettingForm #upload-photo').on("change", function () {
        //Remove before uploaded logo
        $(this).closest(".right-side").find(".image").remove();
        //Create new place for uploaded logo
        uploadedPhoto = $('<div>', { class: 'image' }).appendTo($(this).closest(".right-side"));
        //Attach uploaded logo into place
        readURL(this);
    });
    //Reading uploaded logo
    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            $(reader).on("load", function () {
                $('<div>', { class: 'imageContainer' }).appendTo(uploadedPhoto).append($("<img/>", { src: this.result }));
            });

            reader.readAsDataURL(input.files[0]);
        }
    }

    //REMOVE UPLOADED LOGO (SETTINGS)
    $(document).on("click", "#SettingForm .image", function (e) {

        var selectedImage = $(this);

        Notiflix.Confirm.Show(
            'Foto Silinsin?',
            ' ',
            'Bəli',
            'Xeyr',
            function () { // Yes button callback

                if ($(selectedImage).closest(".right-side").find("#addPhoto").attr("class") == "d-none") {

                    $(selectedImage).closest(".right-side").find("#addPhoto").removeClass("d-none");

                }

                $(selectedImage).remove();

                Notiflix.Report.Success(
                    'Foto silindi !!!',
                    ' ',
                    'Oldu'
                );



            }, function () { // No button callback

            }
        );
    });

    //DEACTIVATE addvertisiment (CABINET)
    $(document).on("click", ".deactivateItem", function (e) {

        var selectedButton = $(this);

        e.preventDefault();

        //Customizing Confirm
        Notiflix.Confirm.Init({
            titleColor: 'red',
            titleFontSize: '20px',
            buttonsFontSize: '16px',
            fontFamily: 'Arch',
        })

        Notiflix.Confirm.Show(

            'Elan Deaktiv Edilsin?',
            ' ',
            'Bəli',
            'Xeyr',
            function () { // Yes button callback
                //Addvertisiment status will be changed to DEACTIVE (Add controller, Deactive action)
                $.getJSON('../..' + selectedButton[0].pathname, function (response) {

                    // Deactive Adds count will be renewed
                    $("#deactivatedAdds").text(response.deactivatedAddsCount);

                    // Active Adds count will be renewed
                    $("#activeAdds").text(response.activeAddsCount);

                    // Waiting Adds count will be renewed
                    $("#waitingAdds").text(response.waitingAddsCount);

                    $("#rentAdds").text(response.rentAddsCount);

                    $("#saleAdds").text(response.saleAddsCount);

                });

                selectedButton.closest(".col-md-3").removeClass('active').removeClass('waiting').addClass('deactive');

                selectedButton.closest(".contain-item").addClass('nonactive');

                selectedButton.parent('li').siblings().remove();

                var id = selectedButton[0].pathname.split('/')[3];

                selectedButton.attr("class", "removeItem").attr("title", "Sil").attr('href', '/add/remove/' + id);

                selectedButton.children().attr('class', 'far fa-trash-alt');



                Notiflix.Notify.Success('Elanınız deaktivasiya edildi');

            },
            function () { // No button callback

            }

        );
    });

    //REMOVE Deactivated addvertisiment from list (CABINET)
    $(document).on("click", ".removeItem", function (e) {

        var selectedButton = $(this);

        e.preventDefault();

        Notiflix.Confirm.Show(
            'Elan Silinsin?',
            ' ',
            'Bəli',
            'Xeyr',
            function () { // Yes button callback
                // Addvertisiment status will be changed to HIDDEN (Add controller, Remove action)
                $.getJSON('../..' + selectedButton[0].pathname, function (response) {
                    // Deactive Adds count will be renewed
                    $("#deactivatedAdds").text(response.deactivatedAddsCount);

                    // All Adds count will be renewed
                    $("#allAdds").text(response.allAddsCount);

                });

                Notiflix.Notify.Success('Elanınız silindi!');
                // Addvertisiment item will be remove
                selectedButton.closest(".col-md-3").remove();



            }, function () { // No button callback

            }

        );


    });
    

    //Filling FloorNumber options (ADD -> CREATE)
    $("#CreateAdd #floorSum").change(function () {

        //Remove all options
        $("#floorNum > option[value!='']").remove();

        var id = $(this).val();

        for (var i = 1; i <= id; i++) {
            //Add new options
            $("#floorNum").append('<option value="' + i + '">' + i + '</option>');
        };

    });

    // Filter Form-items by select PropertySort  (ADD -> CREATE)
    $('#CreateAdd #propSort').change(function () {

        var filterValue = $(this).children("option:selected").attr('data-filter');

        var FormGroup = $(".form-group:not('.showByJs')");

        for (var i = 0; i < FormGroup.length; i++) {

            if (filterValue != undefined) {

                if (!FormGroup[i].classList.contains(filterValue)) {

                    FormGroup[i].classList.add("d-none");
                }
                else {
                    FormGroup[i].classList.remove("d-none");
                }
            }
            
        }
    });

    //Fill Property Projects by select PropertySort  (ADD -> CREATE)
    $("#CreateAdd #propSort").change(function () {
       
        var id = $(this).val();

        $.getJSON('./getprojects/' + id, function (response) {

            if (response.length > 0) {

                $("#project").removeClass("d-none");

                $.each(response, function (index, value) {
                    $("#projectList").append('<option value="' + value.propProjectID + '">' + value.propProjectName + '</option>');
                });

            } else {
                $("#project").addClass("d-none");
                $("#projectList >  option[value!='']").remove();
            }
        });
    });
    

    //Fill Districts by select City  (ADD -> CREATE)
    $("#CreateAdd #city").change(function () {
     
        var id = $(this).val();

        $.getJSON('./getdistricts/' + id, function (response) {
         
            if (response.length > 0) {

                $("#district").removeClass("d-none");

                $.each(response, function (index, value) {
                    $("#districtList").append('<option value="' + value.districtId + '">' + value.districtName + ' rayonu</option>');
                });

            } else {
                $("#district").addClass("d-none");
                $("#districtList >  option[value!='']").remove();
            }
        });

        
    });



    //UPLOAD PHOTOS OF PROPERTY (ADD -> CREATE)
    $("#CreateAdd #upload-photo").change(function (e) {

        var uploadedPhotos = $(this).closest(".form-group").find("#uploadedPhotos");

        if (uploadedPhotos.length == 0) {
            uploadedPhotos = $('<div>', { id: 'uploadedPhotos' }).appendTo($(this).closest(".form-group"));
        }

        for (var i = 0; i < e.originalEvent.srcElement.files.length; i++) {

            var file = e.originalEvent.srcElement.files[i];

            var reader = new FileReader();

            $(reader).on("load", function () {
                $('<div>', { class: 'imageContainer' }).appendTo(uploadedPhotos).append($("<img/>", { src: this.result }));
            });

            reader.readAsDataURL(file);

        }
    });

    //REMOVE UPLOADED PHOTO OF PROPERTY (ADD -> CREATE)
    $(document).on("click", "#CreateAdd .imageContainer", function (e) {
        if ($(".imageContainer").length > 1) {
            $(this).remove();
        }
        else {
            $(this).closest("#uploadedPhotos").remove();
        }
    });

   


   
    
   
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

