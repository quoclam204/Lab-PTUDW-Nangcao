-- Tạo database
CREATE DATABASE ef_lab1;
GO
USE ef_lab1;
GO

-- Tạo bảng Blog
CREATE TABLE Blog (
    BlogId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Tạo bảng Post
CREATE TABLE Post (
    PostId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NULL,
    BlogId INT NOT NULL,
    CONSTRAINT FK_Post_Blog FOREIGN KEY (BlogId) REFERENCES Blog(BlogId)
);

-- Dữ liệu mẫu cho Blog
INSERT INTO Blog (Name) VALUES
(N'Văn hóa'),
(N'Xã hội'),
(N'Tự nhiên'),
(N'Kinh tế');

-- Dữ liệu mẫu cho Post
INSERT INTO Post (Title, Content, BlogId) VALUES
(N'Bóng đá Việt Nam thay huấn luyện viên', N'Ông Nguyễn Hữu Thắng trở thành tân huấn luyện viên tuyển Việt Nam', 1),
(N'Tiêm phòng vắc xin bệnh dại', N'Tiêm phòng ngày 25/02/2012', 2),
(N'Tin tự nhiên', N'Tin tự nhiên', 2),
(N'ABC', N'DEF', 4);

-- Tạo database
CREATE DATABASE ef_lab1;
GO
USE ef_lab1;
GO

-- Tạo bảng Blog
CREATE TABLE Blog (
    BlogId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Tạo bảng Post
CREATE TABLE Post (
    PostId INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NULL,
    BlogId INT NOT NULL,
    CONSTRAINT FK_Post_Blog FOREIGN KEY (BlogId) REFERENCES Blog(BlogId)
);

-- Dữ liệu mẫu cho Blog
INSERT INTO Blog (Name) VALUES
(N'Văn hóa'),
(N'Xã hội'),
(N'Tự nhiên'),
(N'Kinh tế');

-- Dữ liệu mẫu cho Post
INSERT INTO Post (Title, Content, BlogId) VALUES
(N'Bóng đá Việt Nam thay huấn luyện viên', N'Ông Nguyễn Hữu Thắng trở thành tân huấn luyện viên tuyển Việt Nam', 1),
(N'Tiêm phòng vắc xin bệnh dại', N'Tiêm phòng ngày 25/02/2012', 2),
(N'Tin tự nhiên', N'Tin tự nhiên', 2),
(N'ABC', N'DEF', 4);

-- c. Thêm bảng Student và gieo lại mã nguồn
CREATE TABLE Student (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentName NVARCHAR(50),
    StudentAddress NVARCHAR(50)
);

SELECT *
FROM Blog

SELECT *
FROM Blog
