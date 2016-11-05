window.BadgeHistoryModule = (function ($) {
    getGiver = function () {
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

    getReceiver = function () {
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

    getBadge = function () {
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

    getStudent = function () {
        $.ajax({
            url: '/Admin/PersonType',
            type: 'POST',
            dataType: 'html',
            data: { type: "Student" },
            beforeSend: function () {
                $('#spinner').css('display', 'block');
            },
            success: function (data) {
                $('#results').html(data);
                $('#type-display').html("Student");
            },
            error: function (data) {
                $('#results').html(data.responseText);
            },
            complete: function () {
                $('#spinner').css('display', 'none');
            }
        });
    };

    getFaculty = function () {
        $.ajax({
            url: '/Admin/PersonType',
            type: 'POST',
            dataType: 'html',
            data: { type: "Faculty" },
            beforeSend: function () {
                $('#spinner').css('display', 'block');
            },
            success: function (data) {
                $('#results').html(data);
                $('#type-display').html("Faculty");
            },
            error: function (data) {
                $('#results').html(data.responseText);
            },
            complete: function () {
                $('#spinner').css('display', 'none');
            }
        });
    };

    getProfessor = function () {
        $.ajax({
            url: '/Admin/PersonType',
            type: 'POST',
            dataType: 'html',
            data: { type: "Professor" },
            beforeSend: function () {
                $('#spinner').css('display', 'block');
            },
            success: function (data) {
                $('#results').html(data);
                $('#type-display').html("Professor");
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
        },
    };
})(jQuery);

var submitForm = (function () {
    if ($('input[name="searchType"]:checked').val() == $('#Giver').val()) {
        getGiver();

    } else if ($('input[name="searchType"]:checked').val() == $('#Receiver').val()) {
        getReceiver();

    } else if ($('input[name="searchType"]:checked').val() == $('#Badge').val()) {
        getBadge();
    }
});

$(document).ready(function () {
    $('#searchIcon').click(function () {
        submitForm();
    });

    $('#Student').click(function () {
        getStudent();
    });

    $('#Faculty').click(function () {
        getFaculty();
    });

    $('#Professor').click(function () {
        getProfessor();
    });
})