SELECT r.name AS RoleName, m.name AS UserName
FROM sys.database_role_members rm
JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
WHERE r.name = 'role_NhanVien' AND m.name = 'user_nv001';
SELECT * FROM KHACH_HANG;
SELECT * FROM TAI_KHOAN_DANG_NHAP;

-- Tạo login nếu chưa có
CREATE LOGIN [login_nv002] WITH PASSWORD = 'pass1234';
-- Tạo user
CREATE USER [user_nv002] FOR LOGIN [login_nv002];
-- Gán vào role_NhanVien
ALTER ROLE role_NhanVien ADD MEMBER [user_nv002];

INSERT INTO TAI_KHOAN_DANG_NHAP (TenDangNhap, MatKhau, MaNV)
VALUES ('nv002', 'pass1234', 'NV002'); -- Thay 'NV001' bằng mã nhân viên thực tế

SELECT * FROM TAI_KHOAN_DANG_NHAP WHERE TenDangNhap = 'nv002';

GRANT EXECUTE ON sp_TraCuuLichSuGiaoDich_KhachHang TO role_NhanVien;

SELECT * FROM sys.server_principals WHERE name = 'login_nv002';

GRANT EXECUTE ON sp_TaoGiaoDich TO role_NhanVien;
GRANT EXECUTE ON sp_TatToanSoTietKiem TO role_NhanVien;

IF NOT EXISTS (SELECT 1 FROM KHACH_HANG WHERE MaKH = 'KH0004')
BEGIN
    INSERT INTO KHACH_HANG (MaKH, HoTen, NgaySinh, SDT, DiaChi, Email)
    VALUES ('KH0004', N'Lê Thị D', '1990-01-01', '0987654321', N'123 Đường Láng, Hà Nội', 'lethid@example.com');
END

IF NOT EXISTS (SELECT 1 FROM TAI_KHOAN_TIET_KIEM WHERE MaSoTK = 'TK0004')
BEGIN
    INSERT INTO TAI_KHOAN_TIET_KIEM (MaSoTK, MaKH, MaLoaiTK, NgayMoSo, NgayDaoHan, SoTien, SoDuHienTai, TrangThai, MaCN, SoLanTaiTuc, LoaiTienGui)
    VALUES ('TK0004', 'KH0004', 'LTK001', '2025-01-01', '2025-07-01', 15000000, 15000000, N'Đang hoạt động', 'CN001', 0, N'VNĐ');
END

-- 6. Thêm tài khoản tiết kiệm cho KH0004
IF NOT EXISTS (SELECT 1 FROM TAI_KHOAN_TIET_KIEM WHERE MaSoTK = 'TK0004')
BEGIN
    INSERT INTO TAI_KHOAN_TIET_KIEM (MaSoTK, MaKH, MaLoaiTK, NgayMoSo, NgayDaoHan, SoTien, SoDuHienTai, TrangThai, MaCN, SoLanTaiTuc, LoaiTienGui)
    VALUES ('TK0004', 'KH0004', 'LTK001', '2025-01-01', '2025-07-01', 15000000, 15000000, N'Đang hoạt động', 'CN001', 0, N'VNĐ');
END

-- 7. Thêm giao dịch mẫu cho TK0004
IF NOT EXISTS (SELECT 1 FROM GIAO_DICH WHERE MaGD = 'GD0004')
BEGIN
    INSERT INTO GIAO_DICH (MaGD, MaSoTK, LoaiGD, SoTien, NgayGD, MaNV)
    VALUES ('GD0004', 'TK0004', N'Gửi tiền', 15000000, '2025-01-01 10:00:00', 'NV002');
END

SELECT * FROM KHACH_HANG WHERE MaKH = 'KH0004';
SELECT * FROM TAI_KHOAN_TIET_KIEM WHERE MaSoTK = 'TK0004';
SELECT * FROM GIAO_DICH WHERE MaSoTK = 'TK0004';
SELECT * FROM NHAN_VIEN WHERE MaNV = 'NV002';
SELECT * FROM TAI_KHOAN_DANG_NHAP WHERE TenDangNhap = 'nv002';

SELECT r.name AS RoleName, m.name AS UserName
FROM sys.database_role_members rm
JOIN sys.database_principals r ON rm.role_principal_id = r.principal_id
JOIN sys.database_principals m ON rm.member_principal_id = m.principal_id
WHERE r.name = 'role_NhanVien' AND m.name = 'user_nv002';

SELECT * FROM LOAI_TIET_KIEM;


IF NOT EXISTS (SELECT 1 FROM YEU_CAU_MO_SO WHERE MaYC = 'YC0004')
BEGIN
    INSERT INTO YEU_CAU_MO_SO (MaYC, MaKH, MaLoaiTK, SoTien, NgayYeuCau, TrangThai)
    VALUES ('YC0004', 'KH0004', 'LTK001', 20000000, '2025-04-26', N'Chờ xác nhận');
END

SELECT * FROM sys.server_principals WHERE name = 'login_nv002';
USE QuanLyGuiTietKiem;
SELECT * FROM sys.database_principals WHERE name = 'user_nv002';

GRANT EXECUTE ON sp_TraCuuLichSuGiaoDich_KhachHang TO role_NhanVien;


GRANT EXECUTE ON sp_TraCuuLichSuGiaoDich_KhachHang TO role_NhanVien;
GRANT EXECUTE ON sp_TaoGiaoDich TO role_NhanVien;
GRANT EXECUTE ON sp_TatToanSoTietKiem TO role_NhanVien;

USE QuanLyGuiTietKiem;
SELECT * FROM sys.database_principals WHERE name = 'user_nv002';

GRANT EXECUTE ON sp_XacNhanMoSo TO role_NhanVien;
GRANT EXECUTE ON sp_ThemKhachHangMoi TO role_NhanVien;
GRANT EXECUTE ON sp_CapNhatThongTinKhachHang TO role_NhanVien;
GRANT EXECUTE ON sp_XoaKhachHang TO role_NhanVien;

SELECT 
    p.name AS PrincipalName,
    perm.permission_name,
    perm.class_desc,
    OBJECT_NAME(perm.major_id) AS ObjectName
FROM sys.database_principals p
JOIN sys.database_permissions perm ON p.principal_id = perm.grantee_principal_id
WHERE p.name = 'role_NhanVien';

SELECT * FROM KHACH_HANG WHERE MaKH = 'KH0004';
SELECT * FROM TAI_KHOAN_TIET_KIEM WHERE MaSoTK = 'TK0004';
SELECT * FROM GIAO_DICH WHERE MaGD = 'GD0004';
SELECT * FROM YEU_CAU_MO_SO WHERE MaYC = 'YC0004';
SELECT * FROM NHAN_VIEN WHERE MaNV = 'NV002';
SELECT * FROM TAI_KHOAN_DANG_NHAP WHERE TenDangNhap = 'nv002';

SELECT * FROM CHI_NHANH WHERE MaCN = 'CN001';
SELECT * FROM LOAI_TIET_KIEM WHERE MaLoaiTK = 'LTK001';
SELECT * FROM NHAN_VIEN WHERE MaNV = 'NV002';

EXEC sp_TraCuuLichSuGiaoDich_KhachHang @TenDangNhap = 'nv002', @MaKH = 'KH0004', @TuNgay = NULL, @DenNgay = NULL;

EXEC sp_XacNhanMoSo @MaYC = 'YC0004', @MaNV = 'NV002', @MaCN = 'CN001', @TrangThai = N'Đã xác nhận';

EXEC sp_ThemKhachHangMoi @HoTen = N'Trần Văn E', @NgaySinh = '1990-01-01', @MaSoCCCD = '123456789012', @NgayCap = '2020-01-01', @SDT = '0987654321', @DiaChi = N'Hà Nội', @Email = 'tranvane@example.com', @TenDangNhapNV = 'nv002';
EXEC sp_CapNhatThongTinKhachHang @MaKH = 'KH0004', @HoTen = N'Lê Thị D Updated', @NgaySinh = '1990-01-01', @SDT = '0987654321', @DiaChi = N'Hà Nội Updated', @Email = 'lethid_updated@example.com', @TenDangNhapNV = 'nv002';
EXEC sp_XoaKhachHang @MaKH = 'KH0004', @TenDangNhapNV = 'nv002';


