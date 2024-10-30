using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Port_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string serverIP = "127.0.0.1"; // Địa chỉ IP của server
                int port = 12345; // Cổng của server

                // Tạo TcpClient và kết nối tới server
                TcpClient client = new TcpClient(serverIP, port);

                // Gửi yêu cầu "port" để server liệt kê các cổng mở
                string message = txtMessage.Text;
                byte[] data = Encoding.UTF8.GetBytes(message);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                // Nhận danh sách cổng mở từ server
                byte[] responseData = new byte[1024 * 10]; // Tăng kích thước buffer nếu danh sách lớn
                int bytesRead = stream.Read(responseData, 0, responseData.Length);
                string responseMessage = Encoding.UTF8.GetString(responseData, 0, bytesRead);

                // Hiển thị kết quả trong MessageBox
                MessageBox.Show("Danh sách các cổng đang mở:\n" + responseMessage);

                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }
    }
}
