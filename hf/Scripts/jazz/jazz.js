
//data is timetable
function getEvent(data, timetable, renderer) {
   
    var options = {
        url: '#',
        data: {timetable: data},
        //onclick show a band
        onClick: function (event, timetable, clickEvent) {
            //geef artist mee naar controller, controller return artist model en js geeft het hier weer via ajax
            var artist;
            var price;
            var totalprice;
            var jazzEvent;
            var amountJazz;
    

            //check list data and asign artist
            for (var i = 0; i < event.options.data.timetable.length; i++) {
                if (event.options.data.timetable[i].JazzArtist.Name == event.name) {
                    artist = data[i].JazzArtist;
                    price = data[i].Price;
                    jazzEvent = data[i];
                } 
            }
           
            //change html elements
            $('#band-title').text(artist.Name + " in " + event.location);
            $('.jazz-band-info').text(artist.Description);
            $('#band-foto').attr('src', artist.PictureUrl);
            $('#jazz-band-video').attr('src', artist.ClipUrl);
            $('#ticketprice').text('\u20AC ' + price.toFixed(2));

         

            //change amount totalprice text
            $('#amount').change(changeTotalPrice);

            function changeTotalPrice() {
                amountJazz = $('#amount').val();
                totalprice = amountJazz * price;

                $('#jazztotalprice').text(totalprice.toFixed(2));
            }

            //order button, notice one methode
            $('.jazz-btn-order').one('click', function (e) {

                console.log(jazzEvent);

                e.preventDefault();
                amountJazz = $('#amount').val();
         
                //check if tickets sold out
                if (+jazzEvent.AmountofTickets < (+jazzEvent.SoldTickets + +amountJazz)) {
                    alert(jazzEvent.Name + ' sold out');
                } else {

                    $.ajax({
                        type: "post",
                        //get jazz events dmv ajax naar GetJazzEventByDay controller
                        url: "/Ticket/FillSession",
                        //parameter voor controller, geef event en amount mee
                        data: { ticketevent: jazzEvent, eventamount: amountJazz },
                        success: function () {
                            
                            alert(jazzEvent.Name + ' added to your Cart');
                        },
                        error: function () {
                            alert('Someting went wrong...');
                        }

                    });

                    $('.jazz-btn-order').css("background-color", "green");
                    setTimeout(function () {
                        $('.jazz-btn-order').css("background-color", "deepskyblue");
                    }, 400)
                }
            });


            //onclick make band visible, only startup
            $('.band-info').animate({ opacity: 1 }, 500, function () { });
        }
    };


    //display bands on timetable
    for (var i = 0; i < Object.keys(data).length; i++) {
        var jazzobj = data[i];

        //converteren to jsdate
        var startDate = new Date(parseInt(jazzobj.Starttime.substr(6)));
        
        var endDate = new Date(parseInt(jazzobj.Endtime.substr(6)));
    
        //replace jsdate instead of C# date
        jazzobj.Starttime = startDate;
        jazzobj.Endtime = endDate;

        //replace jsdate to json date
        jazzobj.Starttime = jazzobj.Starttime.toJSON();
        jazzobj.Endtime = jazzobj.Endtime.toJSON();


        if (jazzobj.Hall == null) {
            timetable.addEvent(jazzobj.Name, jazzobj.Location, new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDay(), startDate.getHours(), startDate.getMinutes()), new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDay(), endDate.getHours(), endDate.getMinutes()), options);
        } else {
            timetable.addEvent(jazzobj.Name, jazzobj.Hall, new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDay(), startDate.getHours(), startDate.getMinutes()), new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDay(), endDate.getHours(), endDate.getMinutes()), options);
        }
   
    }

    timetable.addLocations(['test']);
    renderer.draw('.timetable');
    
}


function getLocations() {
   
    var array = ['Main Hall', 'Second Hall', 'Third Hall', 'Grote Markt Haarlem'];

    return array;
}





function showJazzTimetable(event) {
    var timetable = new Timetable();
    timetable.setScope(15, 23); // optional, only whole hours between 0 and 23
    timetable.addLocations(getLocations());
    var renderer = new Timetable.Renderer(timetable);
    

    $.ajax({
        type: "post",
        //get jazz events via ajax to jazz controller by GetJazzEventByDay methode
        url: "/Jazz/GetJazzEventByDay",
        //parameter for controller day number
        data: { day: event.data.dayNum },
        success: function (data) {
            //controller return model jazz events
            //pass jazz events, timetable, renderer to getEvent methode
            getEvent(data, timetable, renderer);
        }
    });

    
  

    //band title text
    $('#jazzdag').text(event.data.day + " " +event.data.dayNum);
    var options = {
        url: '#',
        data: { id: 4, info: "" },
        onClick: function (event, timetable, clickEvent) {
            document.getElementById("band-title").innerHTML = event.name + " in " + event.location;
        }
    };
    
}

$('#Thursday').click({ dayNum: "26", day: "Thursday" }, showJazzTimetable);
$('#Friday').click({ dayNum: "27", day: "Friday" }, showJazzTimetable);
$('#Saturday').click({ dayNum: "28", day: "Saturday" }, showJazzTimetable);
$('#Sunday').click({ dayNum: "29", day: "Sunday" }, showJazzTimetable);

//onload load 26th
$(document).ready(function () {
    var jazzthursday = {
        data: {dayNum: "26", day: "Thursday"}
    };
    showJazzTimetable(jazzthursday);
   
});

//startup animations
$('.links-jazz').animate({ opacity: 1 }, 780, function () {
    $('.midden-jazz').animate({ opacity: 1 }, 680, function () {
        $('.rechts-jazz').animate({ opacity: 1 }, 580, function () { });
    });
});

