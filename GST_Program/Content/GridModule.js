$(document).ready(function () {
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