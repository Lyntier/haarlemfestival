
$(document).ready(function () {
    $('#food').click(function () {
        $('.midden').css('visibility', 'visible');
        $('#mid-dance').css('display', 'none');
        $('#mid-historic').css('display', 'none');
        $('#mid-jazz').css('display', 'none');
        $('#mid-food').css('display', 'block');
    });
    $('#jazz').click(function () {
        $('.midden').css('visibility', 'visible');
        $('#mid-historic').css('display', 'none');
        $('#mid-dance').css('display', 'none');
        $('#mid-food').css('display', 'none');
        $('#mid-jazz').css('display', 'block');
    });
    $('#historic').click(function () {
        $('.midden').css('visibility', 'visible');
        $('#mid-dance').css('display', 'none');
        $('#mid-jazz').css('display', 'none');
        $('#mid-food').css('display', 'none');
        $('#mid-historic').css('display', 'block');
    });
    $('#dance').click(function () {
        $('.midden').css('visibility', 'visible');
        $('#mid-historic').css('display', 'none');
        $('#mid-jazz').css('display', 'none');
        $('#mid-food').css('display', 'none');
        $('#mid-dance').css('display', 'block');
    });
});
