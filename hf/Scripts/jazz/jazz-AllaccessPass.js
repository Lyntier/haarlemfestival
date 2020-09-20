function GetAccesspass(data) {
   
    $('#jazz-aap').click(function () {
        var pass;
        var eventAmount = $('[name=eventmount]').val();
        var allPassId = $('[name=ticketevent]:checked').val();
        for (var i = 0; i < data.length; i++) {
            if (data[i].Id == allPassId) {
                pass = data[i];
            }
            //converteren to jsdate
            var startDate = new Date(parseInt(pass.Starttime.substr(6)));
            var endDate = new Date(parseInt(pass.Endtime.substr(6)));

            //replace jsdate instead of C# date
            pass.Starttime = startDate;
            pass.Endtime = endDate;

            //replace jsdate to json date
            pass.Starttime = pass.Starttime.toJSON();
            pass.Endtime = pass.Endtime.toJSON();
        }

        //ajax to ticket controller
        $.ajax({
            type: "post",
            //get jazz events dmv ajax naar GetJazzEventByDay controller
            url: "/Ticket/FillSession",
            //parameter voor controller, geef event en amount mee
            data: { ticketevent: pass, eventamount: eventAmount },

        });
        
    });
}

$.ajax({
    type: "post",
    //get All access pass via ajax
    url: "/Jazz/GetAccesspass",
    success: function (data) {
        GetAccesspass(data);
    }
});