
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

let map;

function initMap() {
    map = new google.maps.Map(document.getElementById("map"), {
        center: { lat: 51.245240, lng: -0.556590 },
        zoom: 15,
    });
}
