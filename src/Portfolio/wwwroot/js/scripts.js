$(function () {
    $('#github-projects').click(function () {
        event.preventDefault();
        console.log($(this).serialize());
        $.ajax({
            url: 'Project/CollectProjects',
            type: 'GET',
            data: { cityName: "bcooper085" },
            dataType: 'json',
            success: function (result) {
                $(".proj-list").html(result);
                console.log(result);
            }
        })
    })
});