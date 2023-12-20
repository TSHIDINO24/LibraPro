IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [Category] (
        [Category_ID] int NOT NULL IDENTITY,
        [Category_Name] varchar(max) NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([Category_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [User] (
        [User_ID] int NOT NULL IDENTITY,
        [User_Name] varchar(max) NOT NULL,
        [User_Surname] varchar(max) NOT NULL,
        [User_IDNumber] nchar(13) NOT NULL,
        [User_Email] varchar(max) NOT NULL,
        [User_Address] varchar(max) NOT NULL,
        [User_Phone] varchar(max) NOT NULL,
        [User_Type] varchar(max) NOT NULL,
        [User_Password] varchar(max) NOT NULL,
        [User_Status] varchar(max) NOT NULL,
        [User_CreatedDate] datetime NOT NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([User_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [Book] (
        [Book_ID] int NOT NULL IDENTITY,
        [Book_Title] varchar(max) NOT NULL,
        [Book_Author] varchar(max) NOT NULL,
        [Book_Status] varchar(max) NOT NULL,
        [Book_Quantity] int NOT NULL,
        [Book_Image] varchar(max) NOT NULL,
        [Book_Description] varchar(max) NOT NULL,
        [Category_ID] int NOT NULL,
        CONSTRAINT [PK_Book] PRIMARY KEY ([Book_ID]),
        CONSTRAINT [FK_Book_Category] FOREIGN KEY ([Category_ID]) REFERENCES [Category] ([Category_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [Notification] (
        [Notification_ID] int NOT NULL IDENTITY,
        [Notification_Details] varchar(max) NOT NULL,
        [Notification_Date] datetime NOT NULL,
        [User_ID] int NOT NULL,
        CONSTRAINT [PK_Notification] PRIMARY KEY ([Notification_ID]),
        CONSTRAINT [FK_Notification_User] FOREIGN KEY ([User_ID]) REFERENCES [User] ([User_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [Bag] (
        [Bag_ID] int NOT NULL IDENTITY,
        [Book_ID] int NOT NULL,
        [User_ID] int NOT NULL,
        [BookTitle] varchar(max) NOT NULL,
        [BookAuthor] varchar(max) NOT NULL,
        [BookImage] varchar(max) NOT NULL,
        CONSTRAINT [PK_Bag] PRIMARY KEY ([Bag_ID]),
        CONSTRAINT [FK_Bag_Book] FOREIGN KEY ([Book_ID]) REFERENCES [Book] ([Book_ID]),
        CONSTRAINT [FK_Bag_User] FOREIGN KEY ([User_ID]) REFERENCES [User] ([User_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [Borrow] (
        [Borrow_ID] int NOT NULL IDENTITY,
        [Borrow_Date] datetime NOT NULL,
        [Borrow_ReturnedDate] datetime NOT NULL,
        [Borrow_Code] varchar(max) NOT NULL,
        [User_ID] int NOT NULL,
        [BookTitle] varchar(max) NOT NULL,
        [BookAuthor] varchar(max) NOT NULL,
        [BookImage] varchar(max) NOT NULL,
        [Bag_ID] int NOT NULL,
        CONSTRAINT [PK_Borrow] PRIMARY KEY ([Borrow_ID]),
        CONSTRAINT [FK_Borrow_Bag] FOREIGN KEY ([Bag_ID]) REFERENCES [Bag] ([Bag_ID]),
        CONSTRAINT [FK_Borrow_User] FOREIGN KEY ([User_ID]) REFERENCES [User] ([User_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [Fine] (
        [Fine_ID] int NOT NULL IDENTITY,
        [Fine_Amount] money NOT NULL,
        [Fine_Date] datetime NOT NULL,
        [Borrow_ID] int NOT NULL,
        CONSTRAINT [PK_Fine] PRIMARY KEY ([Fine_ID]),
        CONSTRAINT [FK_Fine_Borrow] FOREIGN KEY ([Borrow_ID]) REFERENCES [Borrow] ([Borrow_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE TABLE [Transaction] (
        [Transaction_ID] int NOT NULL IDENTITY,
        [Transaction_Date] datetime NOT NULL,
        [Transaction_Status] varchar(max) NOT NULL,
        [FIne_ID] int NOT NULL,
        [User_ID] int NOT NULL,
        CONSTRAINT [PK_Transaction] PRIMARY KEY ([Transaction_ID]),
        CONSTRAINT [FK_Transaction_Fine] FOREIGN KEY ([FIne_ID]) REFERENCES [Fine] ([Fine_ID]),
        CONSTRAINT [FK_Transaction_User] FOREIGN KEY ([User_ID]) REFERENCES [User] ([User_ID])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Bag_Book_ID] ON [Bag] ([Book_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Bag_User_ID] ON [Bag] ([User_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Book_Category_ID] ON [Book] ([Category_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Borrow_Bag_ID] ON [Borrow] ([Bag_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Borrow_User_ID] ON [Borrow] ([User_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Fine_Borrow_ID] ON [Fine] ([Borrow_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Notification_User_ID] ON [Notification] ([User_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Transaction_FIne_ID] ON [Transaction] ([FIne_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    CREATE INDEX [IX_Transaction_User_ID] ON [Transaction] ([User_ID]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20230803223410_MigrationV1'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230803223410_MigrationV1', N'8.0.0-preview.6.23329.4');
END;
GO

COMMIT;
GO

