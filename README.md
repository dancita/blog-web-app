# blog-web-app

Create a small web app for a minimalist blog front end.

Please find the provided sql script for a database below. Feel free to run it in to create a database.

Think about the structure and maintainability of the code and prioritise satisfying the user stories rather than attempting to build a complete solution.

## User stories

**As a** reader of the blog  
**I want** see a list of the titles of all of the available blog posts  
**So that** I can choose which post to read

**As a** reader of the blog  
**I want** see the number of comments each post has in the list  
**So that** I can get a feel for how intersting the post is

**As a** reader of the blog  
**I want** be able to click on a post in the list to view the post  
**So that** I can read the full post

## SQL Script

```
CREATE TABLE [dbo].[BlogPosts] (
    [BlogPostID]      INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (255) NOT NULL,
    [Body]        NVARCHAR (MAX) NOT NULL,
    [PublishedOn] DATETIME       CONSTRAINT [DF_Blog_PublishedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__BlogPosts_BlogPostID] PRIMARY KEY CLUSTERED ([BlogPostID] ASC)
);

CREATE TABLE [dbo].[BlogComment] (
    [CommentID]   INT            IDENTITY (1, 1) NOT NULL,
    [BlogPostID]      INT            NOT NULL,
    [Comment]     NVARCHAR (MAX) NOT NULL,
    [CommentedOn] DATETIME       CONSTRAINT [DF_BlogComment_CommentedOn] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__BlogComment_CommentID] PRIMARY KEY CLUSTERED ([CommentID] ASC),
    CONSTRAINT [FK_BlogComment_Blog] FOREIGN KEY ([BlogPostID]) REFERENCES [dbo].[BlogPosts] ([BlogPostID])
);


SET IDENTITY_INSERT [dbo].[BlogPosts] ON 

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (1, N'How to bake a cake', N'<p>Blog body</p>', CAST(N'2020-02-01' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (2, N'How to bake cookies', N'<p>Blog body</p>', CAST(N'2020-02-14' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (3, N'How to bake bread', N'<p>Blog body</p>', CAST(N'2020-02-25' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (4, N'How to make custard', N'<p>Blog body</p>', CAST(N'2020-03-10' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (5, N'The joys of raisins', N'<p>Blog body</p>', CAST(N'2020-03-16' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (6, N'Making pizza dough', N'<p>Blog body</p>', CAST(N'2020-03-28' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (7, N'To kneed, or not to kneed, that is the question', N'<p>Blog body</p>', CAST(N'2020-04-04' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (8, N'Is Bake Off better on Channel 4?', N'<p>Blog body</p>', CAST(N'2020-04-21' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (9, N'The perfect Victoria Sponge', N'tes', CAST(N'2020-03-01' AS DateTime))

INSERT [dbo].[BlogPosts] ([BlogPostID], [Title], [Body], [PublishedOn]) VALUES (10, N'How to make a croissant', N'test', CAST(N'2020-02-01' AS DateTime))

SET IDENTITY_INSERT [dbo].[BlogPosts] OFF

SET IDENTITY_INSERT [dbo].[BlogComment] ON 

INSERT [dbo].[BlogComment] ([CommentID], [BlogPostID], [Comment], [CommentedOn]) VALUES (1, 2, N'These are great cookies.', CAST(N'2020-02-14 18:42:44.158' AS DateTime))

INSERT [dbo].[BlogComment] ([CommentID], [BlogPostID], [Comment], [CommentedOn]) VALUES (2, 6, N'Fairly average dough.', CAST(N'2020-04-08 11:56:21.136' AS DateTime))

INSERT [dbo].[BlogComment] ([CommentID], [BlogPostID], [Comment], [CommentedOn]) VALUES (3, 2, N'Yummy cookies.', CAST(N'2020-03-08 10:25:35.215' AS DateTime))

INSERT [dbo].[BlogComment] ([CommentID], [BlogPostID], [Comment], [CommentedOn]) VALUES (4, 4, N'My custard was lumpy.', CAST(N'2020-04-08 08:56:12.109' AS DateTime))

INSERT [dbo].[BlogComment] ([CommentID], [BlogPostID], [Comment], [CommentedOn]) VALUES (5, 7, N'Comment body', CAST(N'2020-05-10 11:21:08.112' AS DateTime))

INSERT [dbo].[BlogComment] ([CommentID], [BlogPostID], [Comment], [CommentedOn]) VALUES (6, 1, N'Comment body', CAST(N'2020-02-21 11:46:18.147' AS DateTime))

SET IDENTITY_INSERT [dbo].[BlogComment] OFF

```
