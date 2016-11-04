window.HomeModule = (function ($) {
    getGiver = function (value) {
        $.ajax({
            url: '/Admin/getGiver',
            type: 'POST',
            dataType: 'html',
            data: { ID: value },
            beforeSend: function () {
                $('#spinner').css('display', 'block');
            },
            success: function (data) {
                $('#results').html(data);
            },
            error: function (data) {
                $('#results').html(data.responseText);
            },
            complete: function () {
                $('#spinner').css('display', 'none');
            }
        });
    };

    return {
        init: function () {
            $('#txtSearch').keypress(function (e) {
                if (e.which === 13) {
                    getGiver($('#txtSearch').val());
                }
            });
        },
        getGiver: function (value) {
            getGiver(value);
        }
    };
})(jQuery);