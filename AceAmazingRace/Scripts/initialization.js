$(function () {
    $(".datepicker").datepicker();
    $('.timepicker').timepicker({ 'timeFormat': 'h:i A' });
    $("input[type=text]").css("max-width", "400px");
});
