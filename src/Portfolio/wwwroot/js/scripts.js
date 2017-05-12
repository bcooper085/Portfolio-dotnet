$(function () {
    $('#github-projects').html("<h4>View Projects</h4>");
    $('#github-projects').click(function () {
        $.ajax({
            url: 'Home/CollectProjects',
            type: "GET",
            datatype: 'json',
            success: function (result) {
                $(".proj-list").html(result);
            }
        });
    });
});