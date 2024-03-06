CREATE TABLE [dbo].[Users] (
    [Id_Users] INT           IDENTITY (1, 1) NOT NULL,
    [Email]    VARCHAR (100) NOT NULL,
    [Password] VARCHAR (MAX) NOT NULL,
    [Nickname] VARCHAR (50)  NOT NULL,
    [IsAdmin]  BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([Id_Users] ASC),
    CONSTRAINT [CHK_Email_Format] CHECK ([Email] like '%@%.%')
);

