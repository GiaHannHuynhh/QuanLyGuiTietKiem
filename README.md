# QuanLyGuiTietKiem
NHÓM 03

MÔN: Database Management System

HƯỚNG DẪN LÀM VIỆC VỚI DỰ ÁN QUẢN LÝ GỬI TIẾT KIỆM CÓ THỜI HẠN

Chào mọi người, dưới đây là hướng dẫn để các bạn clone project, thiết lập database, làm việc trên nhánh của mình, và đẩy thay đổi lên GitHub.

QUAN TRỌNG: Trước khi bắt đầu thì bạn cần:
- Xem video trên Youtube để hiểu và biết cách làm việc cơ bản với Git và GitHub
- Đảm bảo bạn đã cài Git (tải tại: https://git-scm.com/downloads nếu chưa có)
- Tạo tài khoản GitHub -> gửi thông tin tài khoản (tên đăng nhập và gmail) lên group Zalo 
- Đăng nhập GitHub vào Visual Studio

TỔNG QUAN:
- 

---

### BƯỚC 1: Clone repository về máy
1. Chuẩn bị:
   - Đảm bảo bạn đã cài Git (tải tại: https://git-scm.com/downloads nếu chưa có).
2. Khởi động Visual Studio 2022.
3. Clone repository:
   - Vào **File** > **Clone Repository**.
   - Dán URL repository:  https://github.com/GiaHannHuynhh/QuanLyGuiTietKiem.git
   - Chọn thư mục để lưu project (ví dụ: `C:\Users\<tên bạn>\Source\Repos\QuanLyGuiTietKiem`).
   - Nhấn **Clone**.
   (Nếu được yêu cầu đăng nhập GitHub, nhập username và password của bạn)
4. Mở project:
- Sau khi clone, Visual Studio sẽ tự động mở file `QuanLyGuiTietKiem.sln`.

---

### BƯỚC 2: Thiết lập database
Mình đã đẩy file `QuanLyGuiTietKiem.bak` lên branch `main` để các bạn khôi phục database. Làm theo các bước sau:

1. Chuẩn bị:
- Mở SQL Server và SQL Server Management Studio (SSMS)
2. Khôi phục database:
- Mở SSMS -> connect (đăng nhập)
- Chuột phải vào mục **Databases** > chọn **Restore Database...**.
- Trong cửa sổ **Restore Database**:
- Chọn **Device** > nhấn nút `...` > **Add** > tìm file `QuanLyGuiTietKiem.bak` trong thư mục project của bạn > **OK**.
- Nhấn **OK** để khôi phục. Database `QuanLyGuiTietKiem` sẽ xuất hiện trong danh sách **Databases**.
3. **Chỉnh sửa file cấu hình**:
- Trong Visual Studio, mở file `App.Example.config`.
- Tìm dòng connection string, ví dụ:  
<connectionStrings> <add name="QuanLyGuiTietKiem" connectionString="Server=localhost;Database=QuanLyGuiTietKiem;Trusted_Connection=True;" providerName="System.Data.SqlClient" /> </connectionStrings> ``` - Thay `Server=localhost` bằng tên server của bạn (nếu khác), hoặc thêm username/password nếu server yêu cầu. - Lưu file và đổi tên thành `App.config` (xóa phần `.Example`). 4. **Kiểm tra**: - Chạy ứng dụng trong Visual Studio (nhấn F5) để kiểm tra kết nối database.


### BƯỚC 3: Chuyển sang nhánh của bạn
Mỗi người đã được tạo một nhánh riêng (HoangNam, ThuyTrang, ToNhu)
Tìm nhánh của bạn:
- Trong Visual Studio, vào Git > Manage Branches.
- Trong phần Local branches, tìm nhánh của bạn 
- Nếu không thấy, trong phần Remote branches, tìm origin/thanhvien1 > chuột phải > Fetch để tải về máy.
Chuyển sang nhánh:
- Chuột phải vào nhánh của bạn (ví dụ: thanhvien1) > Checkout.
- Kiểm tra ở dưới cùng của Visual Studio, bạn sẽ thấy thanhvien1 | QuanLyGuiTietKiem.

### BƯỚC 4: Làm việc trên nhánh của bạn
Sửa code:
- Làm việc bình thường trên nhánh của bạn (sửa code, thêm file,...).
- Ví dụ: Chỉnh sửa Form1.cs hoặc các file khác theo phần của bạn.
Commit thay đổi:
- Sau khi sửa xong, vào Git Changes (dưới cùng của Visual Studio).
- Bạn sẽ thấy danh sách các file đã sửa.
- Nhập thông điệp commit (ví dụ: "Thêm tính năng đăng nhập cho thanhvien1").
- Nhấn Commit All.
Đẩy thay đổi lên nhánh của bạn trên GitHub:
- Sau khi commit, nhấn Push (biểu tượng mũi tên lên).
- Thay đổi của bạn sẽ được đẩy lên nhánh của bạn trên GitHub
  
### BƯỚC 5: Kiểm tra trên GitHub
- Vào GitHub, truy cập repository: https://github.com/GiaHannHuynhh/QuanLyGuiTietKiem
- Nhấn menu Branch > chọn nhánh của bạn 
- Kiểm tra xem các thay đổi của bạn đã xuất hiện chưa.
  
LƯU Ý QUAN TRỌNG
- Chỉ làm việc trên nhánh của mình, không làm trên main.
- Nếu cần cập nhật nhánh của bạn với các thay đổi mới từ main:
+ Chuyển sang nhánh của bạn: ví dụ Chuột phải vào thanhvien1 > Checkout.
+ Gộp main vào nhánh của bạn: Chuột phải vào main > Merge 'main' into 'thanhvien1'.
+ Nếu có xung đột, Visual Studio sẽ báo, bạn cần sửa thủ công.
+ Sau khi gộp, commit và push lại: Commit All > Push.
- Khi hoàn thành phần của bạn, báo mình để mình gộp nhánh của bạn vào main.


  
