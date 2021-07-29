function like(DiscussionId) {
    var token = $("#votesForm input[name=__RequestVerificationToken]").val();
    var json = { DiscussionId: DiscussionId, VoteType: "Like" };
    $.ajax({
        url: "/api/votes",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            $('#likesCount').html(data.likes);
            $('#dislikesCount').html(data.dislikes);
        }
    });
}

function dislike(DiscussionId) {
    var token = $("#votesForm input[name=__RequestVerificationToken]").val();
    var json = { DiscussionId: DiscussionId, VoteType: "Dislike" };
    $.ajax({
        url: "/api/votes",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            $('#likesCount').html(data.likes);
            $('#dislikesCount').html(data.dislikes);
        }
    });
}