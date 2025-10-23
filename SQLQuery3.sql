USE QuanLyBanSach;
GO

DELETE FROM Sach;
DELETE FROM NhaXuatBan;
GO

-- Sau đó mới chạy lại phần thêm dữ liệu:
INSERT INTO NhaXuatBan VALUES ('001', N'Nguyễn Hoàng Nam', N'11dhcnpm2, 1150080149');
INSERT INTO NhaXuatBan VALUES ('002', N'Khoa học xã hội', N'Trần Phú, XÃ Nội');
INSERT INTO NhaXuatBan VALUES ('003', N'Viện văn hóa thể thao', N'Hai Bà Trưng, Hà Nội');
GO

INSERT INTO Sach VALUES ('1', N'Học lập trình C#', '001', N'Nguyễn Lưu', CONVERT(datetime, '2022-01-01'), 'Khg');
INSERT INTO Sach VALUES ('2', N'Lập trình ASP.NET Core', '002', N'Trọng Khải', CONVERT(datetime, '2019-01-01'), 'Khg');
INSERT INTO Sach VALUES ('3', N'Lập trình Scratch', '002', N'Bá Trọng', CONVERT(datetime, '2022-01-01'), 'Khg');
GO
USE QuanLyBanSach;
GO
SELECT * FROM NhaXuatBan;
SELECT * FROM Sach;

