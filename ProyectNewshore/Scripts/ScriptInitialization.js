(function ($) {
    $(document).ready(function () {
        $('.carousel').carousel();
    });

    setInterval(function () {
        $('.carousel').carousel('next')
    }, 2000);

    $(document).ready(function () {
        $('select').formSelect();
    });

    $(document).ready(function () {
        $('.datepicker').datepicker({
            format: 'yyyy/mm/dd'
        });
    });
}(jQuery));
