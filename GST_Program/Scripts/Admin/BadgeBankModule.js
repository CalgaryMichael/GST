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


window.IndexModule = (function () {
    getAll = function () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: "All" },
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

    getPeer = function () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: "Student-Peer" },
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

    getSelf = function () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: "Student-Self" },
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

    getStaff = function () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: "Staff-Student" },
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

    getFaculty = function () {
        $.ajax({
            url: '/Admin/BadgeBankType',
            type: 'POST',
            dataType: 'html',
            data: { type: "Faculty-Student" },
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
        getAll: function () {
            getAll();
        },
        getPeer: function () {
            getPeer();
        },
        getSelf: function () {
            getSelf();
        },
        getStaff: function () {
            getFaculty();
        },
        getProfessor: function () {
            getProfessor();
        },
    };
})(jQuery);