$('.js-btn-order').one('click', function (e) {

   

    $.ajax({
        type: "post",
        //get jazz events dmv ajax naar GetJazzEventByDay controller
        url: "/Ticket/FillSession",
        //parameter voor controller, geef event en amount mee
        data: { ticketevent: jazzEvent, eventamount: amountJazz },

    });

    $('.jazz-btn-order').css("background-color", "green");
    setTimeout(function () {
        $('.jazz-btn-order').css("background-color", "deepskyblue");
    }, 400);
});



function addtocart(eventobj, amount, e) {
    e.preventDefault();
    amount = $('#amount').val();
}

//order button, notice one methode
$('.jazz-btn-order').one('click', function (e) {

    e.preventDefault();
    amountJazz = $('#amount').val();

    $.ajax({
        type: "post",
        //get jazz events dmv ajax naar GetJazzEventByDay controller
        url: "/Ticket/FillSession",
        //parameter voor controller, geef event en amount mee
        data: { ticketevent: jazzEvent, eventamount: amountJazz },
        success: function () {
            console.log(jazzEvent);
            alert(jazzEvent.Name + ' added to your Cart');
        },
        error: function () {
            alert('Someting went wrong...');
        }

    });

    $('.jazz-btn-order').css("background-color", "green");
    setTimeout(function () {
        $('.jazz-btn-order').css("background-color", "deepskyblue");
    }, 400);
});