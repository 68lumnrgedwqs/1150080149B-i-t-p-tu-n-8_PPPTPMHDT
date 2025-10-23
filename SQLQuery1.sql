-- 1. Stored Procedure hiển thị tất cả NXB (Read - All)
USE QuanLyBanSach;
GO
CREATE PROC HienThiNXB
AS
BEGIN
    SELECT * FROM NhaXuatBan
END
GO

-- 2. Stored Procedure hiển thị chi tiết NXB theo mã (Read - Single)
CREATE PROC HienThiChiTietNXB
    @maNXB char(10)
AS
BEGIN
    SELECT * FROM NhaXuatBan
    WHERE NXB = @maNXB
END
GO

-- 3. Stored Procedure thêm dữ liệu cho NXB (Create)
CREATE PROC ThemDuLieu
    @maNXB char(10),
    @tenNXB nvarchar(100),
    @diaChi nvarchar(500)
AS
BEGIN
    INSERT INTO NhaXuatBan 
    VALUES (@maNXB, @tenNXB, @diaChi)
END
GO

-- 4. Stored Procedure cập nhật thông tin NXB (Update)
CREATE PROC CapNhatThongTin
    @maNXB char(10),
    @tenNXB nvarchar(100),
    @diaChi nvarchar(500)
AS
BEGIN
    UPDATE NhaXuatBan
    SET
        TenNXB = @tenNXB,
        DiaChi = @diaChi
    WHERE NXB = @maNXB
END
GO

-- 5. Stored Procedure xóa NXB (Delete)
CREATE PROC XoaNXB
    @maNXB char(10)
AS
BEGIN
    DELETE FROM NhaXuatBan 
    WHERE NXB = @maNXB
END
GO