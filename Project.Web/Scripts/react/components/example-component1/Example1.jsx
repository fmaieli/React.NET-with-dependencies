class CommentBox extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [] };
        this.handleCommentSubmit = this.handleCommentSubmit.bind(this);
    }

    loadCommentsFromServer() {
        let self = this;
        let comments = loadCommentsFromServer(this.props.url);
        comments
            .then(function (resultData) {
                self.setState({ data: resultData })
            });
    }

    handleCommentSubmit(comment) {
        const comments = this.state.data;
        comment.Id = comments.length + 1;
        const newComments = comments.concat([comment]);
        this.setState({ data: newComments });

        let postComments = handleCommentSubmit(comment, this.props.submitUrl);
        postComments
            .then(data => console.log(data));
    }

    componentDidMount() {
        this.loadCommentsFromServer();
    }

    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList data={this.state.data} />
                <CommentForm onCommentSubmit={this.handleCommentSubmit} />
                <StyledComponentsExample />
            </div>
        );
    }
}

class CommentList extends React.Component {
    render() {
        const commentNodes = this.props.data.map(comment => (
            <Comment author={comment.Author} key={comment.Id}>
                {comment.Text}
            </Comment>
        ));
        return <div className="commentList">{commentNodes}</div>;
    }
}

class Comment extends React.Component {
    rawMarkup() {
        const md = new Remarkable();
        const rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };
    }
    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor">{this.props.author}</h2>
                <span dangerouslySetInnerHTML={this.rawMarkup()} />
                <Reactstrap.Badge href="#" color="danger">
                    {this.props.author}
                </Reactstrap.Badge>
            </div>
        );
    }
}

ReactDOM.render(
    <CommentBox
        url="/comments"
        submitUrl="/comments/new"
        pollInterval={2000}
    />,
    document.getElementById('App'),
);