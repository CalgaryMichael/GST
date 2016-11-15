window.BadgeBankModule = (function ($) {
    function getAll () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'All' },
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

    function getPeer () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'Student-Peer' },
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

    function getSelf () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'Student-Self' },
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

    function getStaff () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'Staff-Student' },
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

    function getFaculty () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'Faculty-Student' },
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
            $(document).ready(function () {
                $('#All').click(function () {
                    getAll();
                });

                $('#St-Pe').click(function () {
                    getPeer();
                });

                $('#St-Se').click(function () {
                    getSelf();
                });

                $('#Staff-St').click(function () {
                    getStaff();
                });

                $('#Fa-St').click(function () {
                    getFaculty();
                });
            });

            getAll();
        }
    };
})(jQuery);