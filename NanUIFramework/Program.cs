using NanUI_AutoTransfer;
using NetDimension.NanUI;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanUI_AutoTransfer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            MainWindow mainWindow = new MainWindow();

            WinFormium.CreateRuntimeBuilder(env =>
            {

                env.CustomCefSettings(settings =>
                {
                    // 在此处设置 CEF 的相关参数
                });

                env.CustomCefCommandLineArguments(commandLine =>
                {
                    // 在此处指定 CEF 命令行参数   
                    commandLine.AppendSwitch("disable-web-security");
                });

            }, app =>
            {
                app.UseSingleInstance(() =>
                {
                    MessageBox.Show("实例已经运行，只能运行一个实例", "Single Instance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
                app.ClearCacheFile();

                // StartUrl => http://resources.app.local/client-ui/
                //app.UseEmbeddedFileResource("http", "resources.app.local", "EmbeddedFiles");

                 //使用 LocalFileResource 注册本地文件资源，并将本地文件夹内的文件及目录结构映射到 http://static.app.local 域名下。
                app.UseLocalFileResource("http", "static.app.local", System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));
                //指定启动窗体
                app.UseMainWindow(context => mainWindow);
            })
            .Build()
            .Run();


            //始于 winform 项目
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
