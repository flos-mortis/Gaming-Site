let map;

function initMap() { }
$(() =>
    initMap = function () {
        map = new google.maps.Map(document.getElementById('map'), {
            center: { lat: 51.245240, lng: -0.556590 },
            zoom: 15,
        });
    })