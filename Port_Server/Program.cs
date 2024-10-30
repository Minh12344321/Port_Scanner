using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Địa chỉ IP và cổng server
        IPAddress ipAddress = IPAddress.Any;
        int port = 12345;

        // Tạo TcpListener để lắng nghe kết nối từ client
        TcpListener server = new TcpListener(ipAddress, port);
        server.Start();
        Console.WriteLine($"Server đang chạy tại IP {ipAddress} trên cổng {port}...");

        // Chấp nhận kết nối từ client
        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client đã kết nối!");

            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string clientMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Nhận tin nhắn từ client: {clientMessage}");

            // Kiểm tra nếu client gửi tin nhắn "port", thì mới bắt đầu quét cổng
            if (clientMessage.ToLower() == "port")
            {
                Console.WriteLine("Bắt đầu quét cổng theo yêu cầu từ client...");

                // Gọi hàm quét các cổng đang mở
                string openPorts = ListOpenPorts();

                // Gửi kết quả quét về cho client
                byte[] responseData = Encoding.UTF8.GetBytes(openPorts);
                stream.Write(responseData, 0, responseData.Length);
            }
            else
            {
                // Phản hồi lại client với thông điệp khác
                string responseMessage = "Server đã nhận tin nhắn của bạn!";
                byte[] responseData = Encoding.UTF8.GetBytes(responseMessage);
                stream.Write(responseData, 0, responseData.Length);
            }

            client.Close();
        }
    }

    // Hàm liệt kê các cổng đang mở trên server
    static string ListOpenPorts()
    {
        StringBuilder openPorts = new StringBuilder();
        for (int port = 1; port <= 65535; port++)
        {
            try
            {
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                listener.Stop();
            }
            catch (SocketException)
            {
                // Chỉ thêm thông tin cổng mở vào danh sách khi có exception (cổng đang mở)
                openPorts.AppendLine($"Port {port} đang mở.");
            }
        }
        return openPorts.ToString();
    }
}
