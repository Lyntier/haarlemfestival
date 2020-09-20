
$(document).ready(function () {
    $("#btn-historic-reserve").click(function () {
        $("#historic-info").slideToggle(800);
        $("#historic-reserve").delay(800).slideToggle(800);
    });
});

$(document).ready(function () {
    $("#btn-historic-back").click(function () {
        $("#historic-reserve").slideToggle(800);
        $("#historic-info").delay(800).slideToggle(800);
    });
});

$(document).ready(function () {
    $(".location-button").click(function () {
        var id = $(this).attr('id');

        $(".location-button").hide();
        $("#hl-" + id).show();

        $(".right-historic").css({ "grid-template-columns": "auto" });
    });

    $(".historic-location-close").click(function () {

        $(".historic-location").hide();
        $(".location-button").show();

        $(".right-historic").css({ "grid-template-columns": "auto auto auto" });
    });
});

function amountSelect(selected) {
    var amount = selected.options[selected.selectedIndex].value;
    var ticketAmount = amount % 4;
    var ticketPrice = ticketAmount * 17.50;
    var familyAmount = Math.floor(amount / 4);
    var familyPrice = familyAmount * 60;
    var totalPrice = ticketPrice + familyPrice;
    $("#historic-ticket-amount").text(ticketAmount + " Tickets");
    $("#historic-ticket-price").text("€ " + ticketPrice.toFixed(2));
    $("#historic-family-amount").text(familyAmount + " Family tickets");
    $("#historic-family-price").text("€ " + familyPrice.toFixed(2));
    $("#historic-total-price").text("€ " + totalPrice.toFixed(2));
}