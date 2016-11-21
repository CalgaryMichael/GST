$(document).ready(function () {
    //var coreTable = $('#coreTable').DataTable({
    //    "info": false,
    //    "paging": false,
    //    "ordering": false,
    //    "searching": false,
    //    "columnDefs": [
    //        {
    //            "targets": [4],
    //            "searchable": false
    //        },
    //        {
    //            "targets": [0],
    //            "searchable": false,
    //            "visible": false
    //        },
    //        {
    //            "targets": [3],
    //            "searchable": false,
    //            "visible": false
    //        }
    //    ],
    //    "drawCallback": function (settings) {
    //        var api = this.api();
    //        var rows = api.rows({ page: 'current' }).nodes();
    //        var last = null;

    //        api.column(2, { page: 'current' }).data().each(function (group, i) {
    //            if (last !== group) {
    //                $(rows).eq(i).before(
    //                    '<tr class="group"><td colspan="5">' + group + '</td></tr>'
    //                );

    //                last = group;
    //            }
    //        });
    //    }
    //});

    var comTable = $('#commendationTable').DataTable({
        "info": false,
        "pagingType": "simple",
        "pageLength": 5,
        "order": [[3, "desc"]],
        "columnDefs": [
            {
                "targets": [4],
                "searchable": false,
                "orderable": false
            },
            {
                "targets": [0],
                "searchable": false,
                "orderable": false,
                "visible": false
            },
            {
                "targets": [3],
                "searchable": false,
                "visible": false
            }
        ]
    });

    $('#commendationTable tbody').on('click', 'tr', function () {
        var data = comTable.row(this).data();
        window.location.href = "/Tree/BadgeHistoryDetail/" + data[0];
    });
});