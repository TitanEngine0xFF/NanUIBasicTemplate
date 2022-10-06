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
                    // �ڴ˴����� CEF ����ز���
                });

                env.CustomCefCommandLineArguments(commandLine =>
                {
                    // �ڴ˴�ָ�� CEF �����в���   
                    commandLine.AppendSwitch("disable-web-security");
                });

            }, app =>
            {
                app.UseSingleInstance(() =>
                {
                    MessageBox.Show("ʵ���Ѿ����У�ֻ������һ��ʵ��", "Single Instance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                });
                app.ClearCacheFile();

                // StartUrl => http://resources.app.local/client-ui/
                //app.UseEmbeddedFileResource("http", "resources.app.local", "EmbeddedFiles");

                 //ʹ�� LocalFileResource ע�᱾���ļ���Դ�����������ļ����ڵ��ļ���Ŀ¼�ṹӳ�䵽 http://static.app.local �����¡�
                app.UseLocalFileResource("http", "static.app.local", System.IO.Path.Combine(Application.StartupPath, "LocalFiles"));
                //ָ����������
                app.UseMainWindow(context => mainWindow);
            })
            .Build()
            .Run();


            //ʼ�� winform ��Ŀ
            //Application.SetHighDpiMode(HighDpiMode.SystemAware);
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
