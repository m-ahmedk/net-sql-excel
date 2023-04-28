// import.js

$(function () {
    // Handle form submission
    $('#import-form').submit(function (e) {
        e.preventDefault();

        var formData = new FormData($(this)[0]);

        $.ajax({
            url: '@Url.Action("Import", "AppUsers")',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                // Show success message
                $('#import-modal .modal-body').html('<p>' + data + '</p>');
            },
            error: function (xhr, status, error) {
                // Show error message
                $('#import-modal .modal-body').html('<p>Import failed: ' + error + '</p>');
            }
        
        });
    });
});