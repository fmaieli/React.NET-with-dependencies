
function loadCommentsFromServer(url) {
    return fetch(url)
        .then(response => response.json());
}

function handleCommentSubmit(comment, submitUrl) {
    const requestOptions = {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ Author: comment.Author, Text: comment.Text })
    };
    return fetch(submitUrl, requestOptions)
        .then(response => response.json());
}