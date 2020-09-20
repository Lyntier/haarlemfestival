

function ShowAllRestaurants() {
    var x = document.getElementById('Restaurants');
    if (x.style.visibility === 'hidden') {
        x.style.visibility = 'visible';
    } else (x.style.visibility === 'visible')
}

function ShowRestaurantDetails() {
    var x = document.getElementById('RestaurantDetails');
    if (x.style.visibility === 'hidden') {
        x.style.visibility = 'visible';
    } else (x.style.visibility === 'visible')
}

function ReservationButton() {
    var x = document.getElementById('OrderTickets');
    if (x.style.visibility === 'hidden') {
        x.style.visibility = 'visibile';
    } else (x.style.visibility === 'visibile')
}

document.getElementById('Restaurants').style.visibility = 'hidden';
document.getElementById('RestaurantDetails').style.visibility = 'hidden';
document.getElementById('OrderTickets').style.visibility = 'hidden';