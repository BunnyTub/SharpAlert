//using System;
//using System.Threading;
//using Avalonia;
//using Avalonia.Controls.ApplicationLifetimes;

//namespace SharpAlert.ProgramWorker
//{
//    public class AvaloniaHost
//    {
//        private Thread? _thread;

//        public void StartAvaloniaWindow()
//        {
//            _thread = new Thread(() =>
//            {
//                AppBuilder.Configure<MyAvaloniaApp>()
//                          .UsePlatformDetect()
//                          .LogToTrace()
//                          .StartWithClassicDesktopLifetime(Array.Empty<string>());
//            });

//            _thread.SetApartmentState(ApartmentState.STA);
//            _thread.IsBackground = true;
//            _thread.Start();
//        }
//    }

//}
