window.IndexModule = (function ($) {
    function getStudent () {
        $.ajax({
            url: '/Admin/PersonType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'Student' },
            beforeSend: function () {
                $('#spinner').css('display', 'block');
            },
            success: function (data) {
                $('#results').html(data);
                $('#type-display').html('Student');
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
            url: '/Admin/PersonType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'Faculty' },
            beforeSend: function () {
                $('#spinner').css('display', 'block');
            },
            success: function (data) {
                $('#results').html(data);
                $('#type-display').html('Faculty');
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
            url: '/Admin/PersonType',
            type: 'POST',
            dataType: 'html',
            data: { type: 'Staff' },
            beforeSend: function () {
                $('#spinner').css('display', 'block');
            },
            success: function (data) {
                $('#results').html(data);
                $('#type-display').html('Professor');
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
        init: function() {
            $(document).ready(function () {
                $('#Student').click(function () {
                    getStudent();
                });

                $('#Faculty').click(function () {
                    getFaculty();
                });

                $('#Staff').click(function () {
                    getStaff();
                });
            });

            getStudent();
        }
    };
})(jQuery);