(function () {
    //Artist information below the Timetable
    function ArtistInfo(Name) {
        //Ajax Call to get the right information from the database.
        $.ajax({
            type: "post",
            //get dance events through AJAX to GetDanceEventByDay controller
            url: "/Artist/GetArtistByName",
            //parameter for the Artist get, give the name of the button with it
            data: { Name },
            success: function (data) {
                //change html elements for info of artist
                $('#dance-band-info').text(data[0].Description);
                $('#artist-foto').attr('src', data[0].PictureUrl);

            }
        })
    }

    //Timetable and click function of timetable elements
    function getEvent(data, timetable, renderer) {
        //Click function timetable elements
        var options = {
            url: '#',
            //Fuction for click event of the timetable blocks
            onClick: function (event, timetable, clickEvent) {
                //give artist to controller, controller returns artist model and js gives it to ajax
                var price;
                var totalprice;
                var danceEvent;
                var amountDance;
                //For Loop voor price en Winkelmandje informatie
                for (i = 0; i < data.length; i++) {
                    if (event.name == data[i].Name) {
                        price = data[i].Price;
                        //Event Information to Basket
                        danceEvent = data[i];
                        $('#artist-title').text(data[i].Name);
                    }
                }

                //Price Values from the Event to the information page
                $('#ticketprice').text('\u20AC ' + price.toFixed(2));
                $('#dancetotalprice').text('\u20AC ' + price.toFixed(2));
                //Function for data retrieval of Artist info
                ArtistInfo(event.name);

                //wijzig price
                $('#amount').change(changeTotalPrice);
                //Total price change
                function changeTotalPrice() {
                    amountDance = $('#amount').val();
                    totalprice = amountDance * price;
                    //Changing the total price in the view
                    $('#dancetotalprice').text(totalprice.toFixed(2));
                }

                //Order button
                $('.dance-btn-order').click(function () {
                    if ((+amountDance + +danceEvent.SoldTickets) > danceEvent.AmountofTickets) {
                        alert(danceEvent.Name + ' sold out');
                    } else {
                        //e.preventDefault();
                        // Amount of tickets
                        amountDance = $('#amount').val();

                        //Event Information to Basket
                        $.ajax({
                            type: "post",
                            //get Dance events dmv ajax naar GetJazzEventByDay controller
                            url: "/Ticket/FillSession",
                            //parameter for controller, give day number with it
                            data: { ticketevent: danceEvent, eventamount: amountDance },
                            error: function () {
                                alert('Someting went wrong...');
                            }
                        });
                    }

                });

                //onclick make band visible, only startup
                $('.artist-info').animate({ opacity: 1 }, 500, function () { });
            }
        };

        //Adding the events to timetable to be shown with a for loop
        for (var i = 0; i < Object.keys(data).length; i++) {
            var danceobj = data[i];
            // startDate and endDate variable creation to with a substr to strip away the seconds and milliseconds.
            var startDate = new Date(parseInt(danceobj.Starttime.substr(6)));
            var endDate = new Date(parseInt(danceobj.Endtime.substr(6)));
            // Here the timetable information from the concert gets added to the timetable with a try in case of errors
            try {
                timetable.addEvent(danceobj.Name, danceobj.Location, new Date(2019, 7, startDate.getDate(), startDate.getHours(), startDate.getMinutes()), new Date(2019, 7, endDate.getDate(), endDate.getHours(), endDate.getMinutes()), options);

            }
            // Error Message in case of problems
            catch {
                alert("Something went wrong! If possible please contact system administrator! Have a very nice day.");
            }


        }
        //Creation of the timetable with the data input above
        renderer.draw('.timetable');

    }

    //Function for timetable day change and show.
    function showDanceEvent(event) {
        $.ajax({
            type: "post",
            //get dance events via ajax naar GetDanceEventByDay controller
            url: "/Dance/GetDanceEventByDay",
            //parameter voor controller, geef dag nummer mee
            data: { day: event.data.dayNum },
            success: function (data) {
                //Create Timetable variable
                var timetable = new Timetable();
                //Set the times for beginning and end of the Timetable
                timetable.setScope(14, 2);
                //Gives the rows with the locations
                for (i = 0; i < data.length; i++) {
                    timetable.addLocations([data[i].Location]);
                }
            

                //Use the renderer method of Timetable.
                var renderer = new Timetable.Renderer(timetable);
                //controller return model dance events in data
                getEvent(data, timetable, renderer);

            }
        });
        


        var options = {
            url: '#',
            data: { id: 4, info: "" },
            onClick: function (event, timetable, clickEvent) {
                document.getElementById("band-title").innerHTML = event.name + " in " + event.location;
            }
        };


    }


    //Document ready function activition for Timetable load.
    $(document).ready(function () {
        GetSetDays();
    });

    function GetSetDays() {
        $.ajax({
            type: "post",
            //get dance events via ajax naar GetDanceEventDay controller
            url: "/Dance/GetDanceEventDay",
            //parameter voor controller, geef dag nummer mee
            //data: {},
            success: function (data) {
                //GetSetDays Is only activated when the page is loaded, thus using the part next to show the main page when finished loading.Timetable Main Page
                var date = new Date(parseInt(data[0].substr(6)));
                var dancefirstday = {
                    data: { dayNum: date.getDate(), day: GetActualDay(date.getDay()) }
                };
                showDanceEvent(dancefirstday);

                //Click functions the sidebuttons
                for (i = 0; i < data.length; i++) {
                    //Click function for the timetable days
                    var date = new Date(parseInt(data[i].substr(6)));

                    //Day buttons timetable
                    var day = i + 1;
                    var buttonname = '#day' + day;
                    $(buttonname).text(GetActualDay(date.getDay()));
                    $(buttonname).click({ dayNum: date.getDate(), day: GetActualDay(date.getDay()) }, showDanceEvent);

                    //Click and name functions for the All-Access Pass 1 Day buttons
                    buttonname = '#Allday' + day;
                    $(buttonname).text('All-Access Pass ' + GetActualDay(date.getDay()));
                    $(buttonname).click(function () { ShowAllAccessInformation(this.id), ChangeOpacity() });

                }
                //Button All days All-access
                $('#Allday').text('All-Access ' + (data.length) + ' Day Pass');
                $('#Allday').click(function () { ShowAllAccessInformation('Allday'), ChangeOpacity() });
            }
        })
    }
    function GetActualDay(day) {
        switch (day) {
            case 6:
                return "Saturday";
            case 0:
                return "Sunday";
            case 1:
                return "Monday";
            case 2:
                return "Tuesday";
            case 3:
                return "Wednesday";
            case 4:
                return "Thursday";
            case 5:
                return "Friday";
        }

    }
    //startup animations
    $('.links-dance').animate({ opacity: 1 }, 780, function () {
        $('.midden-dance').animate({ opacity: 1 }, 680, function () {
            $('.rechts-dance').animate({ opacity: 1 }, 580, function () { });
        });
    });

    function ShowAllAccessInformation(Name) {

        
        $.ajax({
            type: "post",
            //get Dance events dmv ajax naar GetJazzEventByDay controller
            url: "/Dance/GetDanceEventByName",
            //parameter for controller, give day number with it
            data: { Name: Name },
            success: function (data) {
                //Gives first value of the name back to the method to place the information from the artist to the page.
                SetAllAccessInfo(data[0]);
            }

        });
    }

    function SetAllAccessInfo(data) {
        var price;
        var totalprice;
        var danceEvent;
        var amountDance;
        price = data.Price;
        //Event Information to Basket
        danceEvent = data;
        //Price Values from the Event to the information page
        $('#ticketprice').text('\u20AC ' + price.toFixed(2));
        $('#dancetotalprice').text('\u20AC ' + price.toFixed(2));
        //Function for data retrieval of Artist info
        ArtistInfo(data.Name);
        var date = new Date(parseInt(data.Starttime.substr(6)));
        $('#artist-title').text('All-Access Pass ');
        if ("Allday" == data.Name) {
            $('#artist-title').text('All-Access Pass Festival');
        }
        //Totalprice functie
        function changeTotalPrice() {
            amountDance = $('#amount').val();
            totalprice = amountDance * price;
            //Changing the total price in the view
            $('#dancetotalprice').text(totalprice.toFixed(2));
        }

        $('.dance-btn-order').click(function () {
            // Amount of tickets
            amountDance = $('#amount').val();
            //Amount and Price Change on page, also changes price for the fillSession call
            $('#amount').change(changeTotalPrice);
            //Total price change

            //Event Information to Basket
            $.ajax({
                type: "post",
                //get Dance events dmv ajax naar GetJazzEventByDay controller
                url: "/Ticket/FillSession",
                //parameter for controller, give day number with it
                data: { ticketevent: danceEvent, eventamount: amountDance },
            });

        });
    }

    function ChangeOpacity() {
        $('.artist-info').animate({ opacity: 1 }, 500, function () { });

    }
}())