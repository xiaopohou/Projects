﻿class ArticleDetail {
    ablumList: ArticleDetailAblum[];
    action: TimeLineAction;
    ad: Advertising;
    advantageList: string;
    anchor: ArticleDetailAnchor[];
    author: string;
    category: string;
    comment: ArticleDetail;
    commentNum: number;
    comments: ArticleDetail[];
    content: string;
    contentPage: number;
    cover: string;
    detailType: number;
    disadvantageList: string;
    editor: string;
    game: GameBase;
    games: ArticleRelatedGame[];
    images: TimeLineImage[];
    isFavorited: boolean;
    isLiked: boolean;
    isQuestion: boolean;
    isShort: boolean;
    isSolve: boolean;
    isVideo: boolean;
    likeNum: number;
    news: ArticleDetail[];
    originalPost: ArticleDetail;
    parentSource: ArticleDetailParentSource;
    postId: number;
    programList: ArticleDetailProgram[];
    publishDate: number;
    relatedGame: ArticleRelatedGame[];
    remark: string;
    reviewScore: number;
    shareNum: number;
    shareUrl: string;
    text: string;
    thumbnail: TimeLineImage;
    timeLineType: number;
    title: string;
    user: UserBase;
    videoList: ArticleDetailVideo[];
    voteList: ArticleDetailVote[];
}