window.BadgeHistoryModule = (function ($) {
    function getGiver () {
        $.ajax({
            url: '/Admin/BadgeHistoryGiver',
            type: 'POST',
            dataType: 'html',
            data: { ID: $('#txtSearch').val() },
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

    function getReceiver () {
        $.ajax({
            url: '/Admin/BadgeHistoryReceiver',
            type: 'POST',
            dataType: 'html',
            data: { ID: $('#txtSearch').val() },
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

    function getBadge () {
        $.ajax({
            url: '/Admin/BadgeHistoryBadge',
            type: 'POST',
            dataType: 'html',
            data: { ID: $('#txtSearch').val() },
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

    function submitForm () {
        if ($('input[name="searchType"]:checked').val() === $('#Giver').val()) {
            getGiver();

        } else if ($('input[name="searchType"]:checked').val() === $('#Receiver').val()) {
            getReceiver();

        } else if ($('input[name="searchType"]:checked').val() === $('#Badge').val()) {
            getBadge();
        }
    };

    return {
        init: function () {
            $(document).ready(function () {
                $('#searchIcon').click(function () {
                    submitForm();
                });
            });

            $('#txtSearch').keypress(function (e) {
                if (e.which === 13) {
                    submitForm();
                }
            });
        },
        getGiver: function () {
            getGiver();
        },
        getReceiver: function () {
            getReceiver();
        },
        getBadge: function () {
            getBadge();
        }
    };
})(jQuery);