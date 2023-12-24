using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Reg;
using Rectangle = System.Drawing.Rectangle;

namespace AI_ESP
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            // 创建WPF窗口
            Window wpfWindow = new Window();
            wpfWindow.WindowStyle = WindowStyle.None;
            wpfWindow.WindowState = WindowState.Maximized;
            wpfWindow.AllowsTransparency = true;
            wpfWindow.Background = System.Windows.Media.Brushes.Transparent;
            wpfWindow.Topmost = true;

            // 添加一个Canvas用于绘制方框
            Canvas canvas = new Canvas();
            wpfWindow.Content = canvas;

            // 获取所有摄像头
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            // 输出摄像头信息
            for (int i = 0; i < videoDevices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {videoDevices[i].Name}");
            }

            // 用户选择摄像头
            Console.WriteLine("请输入摄像头序号以开始接收视频流：");
            int selectedCameraIndex;
            while (!int.TryParse(Console.ReadLine(), out selectedCameraIndex)
                   || selectedCameraIndex < 1
                   || selectedCameraIndex > videoDevices.Count)
            {
                Console.WriteLine("无效的输入，请重新输入摄像头序号：");
            }

            VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[selectedCameraIndex - 1].MonikerString);
            Console.WriteLine($"正在连接摄像头：{videoDevices[selectedCameraIndex - 1].Name}");
            videoSource.NewFrame += (s, e) =>
            {
                // 处理视频流中的每一帧
                Console.WriteLine(59.97);
                using (System.Drawing.Bitmap bitmap = (System.Drawing.Bitmap)e.Frame.Clone())
                {
                    Image<Bgr, byte> imageFrame = new Image<Bgr, byte>(ConvertImageToByte3DArray(bitmap));
                    // 使用OpenCV进行人体检测
                    var bodyDetector = new CascadeClassifier("haarcascade_frontalface_default.xml"); // 替换为适合你需求的分类器
                    //haarcascade_frontalface_default.xml 脸部
                    var bodies = bodyDetector.DetectMultiScale(imageFrame, 1.1, 3, System.Drawing.Size.Empty); // 调整参数以适应检测
                   
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        canvas.Children.Clear();
                       
                        foreach (var body in bodies)
                        {
                            Console.WriteLine($"{bodies.Length}个人体 坐标{body.X},{body.Y}");
                            System.Windows.Shapes.Rectangle rect = new System.Windows.Shapes.Rectangle();
                            rect.Stroke = System.Windows.Media.Brushes.Red;
                            rect.StrokeThickness = 2;
                            rect.Width = body.Width;
                            rect.Height = body.Height;
                            Canvas.SetLeft(rect, body.X);
                            Canvas.SetTop(rect, body.Y);
                            canvas.Children.Add(rect);
                        }
                    });
                }
            };
            videoSource.Start();
            var app = new Application();
            app.Run(wpfWindow);
        }

        public static byte[,,] ConvertImageToByte3DArray(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;

            byte[,,] byteArray = new byte[height, width, 3]; // 3 是因为 BGR 图像每个像素有3个通道

            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            int stride = bmpData.Stride;

            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width * 3; x++)
                    {
                        byteArray[y, x / 3, x % 3] = ptr[y * stride + x];
                    }
                }
            }

            bitmap.UnlockBits(bmpData);

            return byteArray;
        }

    }
}
