/*<script>
    function addMarker(latitude, longitude, title, description, map) {
                var latLng = new google.maps.LatLng(latitude, longitude);
                var contentString = '<h3>' + title + '</h3>' + '<p>' + description + '</p>';

                var infowindow = new google.maps.InfoWindow({
        content: contentString
});

                var marker = new google.maps.Marker({
        position: latLng,
    title: title,
    map: map,
    draggable: false
});

                google.maps.event.addListener(marker, 'click', function () {
        infowindow.open(map, marker);
    });
            }
</script>
*/