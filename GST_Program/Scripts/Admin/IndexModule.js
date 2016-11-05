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
});

window.IndexModule = (function () {
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
        getStudent: function () {
            getStudent();
        },
        getFaculty: function () {
            getFaculty();
        },
        getProfessor: function () {
            getProfessor();
        },
    };
})(jQuery);