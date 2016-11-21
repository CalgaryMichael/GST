$(document).ready(function () {
    var table = $('#competencyTable').DataTable({
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

    $('#competencyTable tbody').on('click', 'tr', function () {
        var data = table.row(this).data();
        window.location.href = "/Tree/BadgeHistoryDetail/" + data[0];
    });
});