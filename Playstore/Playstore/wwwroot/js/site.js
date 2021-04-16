
(function ($) {
    jQuery(document).ready(function ($) {
        $(".owl-carousel").owlCarousel({
            items: 1,
            singleItem: true,
            itemsScaleUp: true,
            navigation: true,
            navigationText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            pagination: true,
            merge: false,
            mergeFit: true,
            slideBy: 1,
            autoPlay: false
        });
    });
})(jQuery);

