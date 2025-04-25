ALTER PROCEDURE sp_TraCuuLichSuGiaoDich_KhachHang 
    @MaKH VARCHAR(10), 
    @TuNgay DATE = NULL, 
    @DenNgay DATE = NULL,
    @TenDangNhap VARCHAR(50), -- Thêm tham số TenDangNhap để kiểm tra quyền
    @KetQua BIT OUTPUT, 
    @ThongBao NVARCHAR(255) OUTPUT
AS 
BEGIN
    BEGIN TRY
        -- Kiểm tra quyền truy cập  
        DECLARE @UserName NVARCHAR(100) = 'user_' + @TenDangNhap;  
        IF NOT EXISTS (  
            SELECT 1   
            FROM sys.database_role_members rm  
            JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id  
            JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id  
            WHERE r.name IN ('role_NhanVien', 'role_KhachHang') AND m.name = @UserName  
        )  
        BEGIN  
            SET @KetQua = 0;  
            SET @ThongBao = N'Bạn không có quyền tra cứu lịch sử giao dịch!';  
            RETURN;  
        END  
  
        -- Kiểm tra mã khách hàng  
        IF NOT EXISTS (SELECT 1 FROM KHACH_HANG WHERE MaKH = @MaKH)  
        BEGIN  
            SET @KetQua = 0;  
            SET @ThongBao = N'Khách hàng không tồn tại!';  
            RETURN;  
        END  
  
        -- Kiểm tra xem người dùng có phải là khách hàng đang truy cập thông tin của chính mình không  
        IF EXISTS (  
            SELECT 1   
            FROM sys.database_role_members rm  
            JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id  
            JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id  
            WHERE r.name = 'role_KhachHang' AND m.name = @UserName  
        )  
        BEGIN  
            DECLARE @MaKH_DangNhap VARCHAR(10);  
            SELECT @MaKH_DangNhap = MaKH  
            FROM TAI_KHOAN_DANG_NHAP  
            WHERE TenDangNhap = @TenDangNhap;  
  
            IF @MaKH_DangNhap != @MaKH  
            BEGIN  
                SET @KetQua = 0;  
                SET @ThongBao = N'Bạn chỉ có quyền xem lịch sử giao dịch của chính mình!';  
                RETURN;  
            END  
        END  
  
        -- Tra cứu lịch sử giao dịch  
        SELECT gd.MaGD, gd.MaSoTK, tk.MaKH, gd.LoaiGD, gd.SoTien, gd.NgayGD, gd.MaNV, nv.HoTen AS TenNhanVien  
        FROM GIAO_DICH gd  
        JOIN TAI_KHOAN_TIET_KIEM tk ON gd.MaSoTK = tk.MaSoTK  
        LEFT JOIN NHAN_VIEN nv ON gd.MaNV = nv.MaNV  
        WHERE tk.MaKH = @MaKH  
        AND (@TuNgay IS NULL OR gd.NgayGD >= @TuNgay)  
        AND (@DenNgay IS NULL OR gd.NgayGD <= @DenNgay)  
        ORDER BY gd.NgayGD DESC;  
  
        SET @KetQua = 1;  
        SET @ThongBao = N'Tra cứu lịch sử giao dịch thành công!';  
    END TRY  
    BEGIN CATCH  
        SET @KetQua = 0;  
        SET @ThongBao = ERROR_MESSAGE();  
    END CATCH  
END;
GO


SELECT * FROM KHACH_HANG;