function likeComment(CommentId, currRowId) {
    var token = $("#commentVotesForm input[name=__RequestVerificationToken]").val();
    var json = { CommentId: CommentId, VoteType: "Like" };
    $.ajax({
        url: "/api/votes",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            $('#likesCount_' + currRowId).html(data.likes);
            $('#dislikesCount_' + currRowId).html(data.dislikes);
        }
    });
}

function dislikeComment(CommentId, currRowId) {
    var token = $("#commentVotesForm input[name=__RequestVerificationToken]").val();
    var json = { CommentId: CommentId, VoteType: "Dislike" };
    $.ajax({
        url: "/api/votes",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            $('#likesCount_' + currRowId).html(data.likes);
            $('#dislikesCount_' + currRowId).html(data.dislikes);
        }
    });
}