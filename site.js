
$(document).ready(function () {
    $("#Make").on("change", function () {
        $list = $("#Model");
        $.ajax({
            url: "/Vehicle/getModels",
            type: "GET",
            data: { id: $("#Make").val() }, 
            traditional: true,
            success: function (result) {
                $list.empty();
                $.each(result, function (i, item) {
                    $list.append('<option value="' + item["modelId"] + '"> ' + item["model"] + ' </option>');
                });
            },
            error: function () {
                alert("Something went wrong ...");
            }
        });
    });
});