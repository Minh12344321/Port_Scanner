## Port Scanner
Giới thiệu
Dự án này là một công cụ đơn giản sử dụng Python và thư viện socket để liệt kê các cổng giao thức trên một địa chỉ IP hoặc tên miền cụ thể. Nó giúp người dùng xác định các cổng đang mở và dịch vụ đang chạy trên đó.

Tính năng
Quét một địa chỉ IP hoặc tên miền để liệt kê tất cả các cổng mở.
Hỗ trợ quét cả cổng TCP và UDP.
Giao diện dòng lệnh đơn giản và dễ sử dụng.
Yêu cầu
Python 3.x
Thư viện socket (được tích hợp sẵn trong Python)
Cài đặt
Tải mã nguồn từ kho lưu trữ này về máy của bạn:
bash
Copy code
git clone https://github.com/username/repo-name.git
Di chuyển vào thư mục dự án:
bash
Copy code
cd repo-name
Sử dụng
Chạy chương trình bằng lệnh sau, thay thế <host> bằng địa chỉ IP hoặc tên miền mà bạn muốn quét:

bash
Copy code
python port_scanner.py <host>
Ví dụ
bash
Copy code
python port_scanner.py 192.168.1.1
Lưu ý
Việc quét cổng có thể bị coi là hành vi xâm nhập không hợp pháp nếu thực hiện trên các hệ thống không được phép. Hãy đảm bảo bạn có quyền truy cập trước khi quét bất kỳ địa chỉ nào.
Dự án này chỉ nhằm mục đích giáo dục và nghiên cứu.
Đóng góp
Nếu bạn muốn đóng góp cho dự án, hãy tạo một pull request hoặc mở một issue để thảo luận về ý tưởng của bạn.

Giấy phép
Dự án này được cấp phép theo Giấy phép MIT.
