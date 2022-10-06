using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NetDimension.NanUI;
using NetDimension.NanUI.HostWindow;
using NetDimension.NanUI.JavaScript;
using Newtonsoft.Json;

namespace NanUI_AutoTransfer
{
    class MainWindow : Formium
    {
        // 设置窗体样式类型
        public override HostWindowType WindowType => HostWindowType.System;
        //public override HostWindowType WindowType => HostWindowType.System;
        // 指定启动 Url
        public override string StartUrl => "http://static.app.local";

        //如果 EmbeddedFiles 中 ,还有一层目录 则需要追加到 StartUrl的后面, 如http://resources.app.local/adminUI  ,自动加载 adminUI文件夹里面的 index.html
        //public override string StartUrl => "http://resources.app.local";

        //public override string StartUrl => "http://www.baidu.com";


        public MainWindow()
        {
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            Title = "标题栏文字";
            // 在此处设置窗口样式
            Size = new System.Drawing.Size(SW, SH);
            Icon = new System.Drawing.Icon("windows.ico", 32, 32);
            CustomizeSplashScreen();    
            
        }

        private void CustomizeSplashScreen()
        {
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;
            SplashScreen.BackColor = ColorTranslator.FromHtml("#8368A6");
            // Add a picture box
            // 添加一个PictureBox组件放置加载动画

            var loaderGif = new PictureBox
            {

                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                Size = new Size(SW, SH),
                //Image = Resources.
                BorderStyle = BorderStyle.None,
                BackColor = Color.Transparent,
                SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom,

            };

            loaderGif.Location = new Point(0, 0);

            SplashScreen.Content.Add(loaderGif);    
        }
        protected override void OnReady()
        {
            // 注册窗口关闭前事件
            BeforeClose += MainWindow_BeforeClose;
            // 在此处进行浏览器相关操作
            KeyEvent += MainWindow_KeyEvent;
            LoadEnd += BrowserLoadEnd;

            //这个是内存通讯, 现在用http通讯
            TestRegisterJavaScriptObject();
            this.Active();
        }
        private void BrowserLoadEnd(object sender, NetDimension.NanUI.Browser.LoadEndEventArgs e)
        {       
        }
        public void setActive() {
        }

        /// <summary>
        /// 内存通讯 ,现在不用内存通讯了
        /// </summary>
        private void TestRegisterJavaScriptObject()
        {
            var pObj = new JavaScriptObject();
            //关闭
            pObj.Add("close", (args) =>
            {
                InvokeIfRequired(() =>
                {
                    this.Close();      
                });

                return null;
            });
        }
        //启用线程获取数据
   
        
        
        //关闭监听
        private void MainWindow_BeforeClose(object sender, NetDimension.NanUI.Browser.FormiumCloseEventArgs e)
        {
        
                System.Environment.Exit(0);
        }
        //按键监听
        private void MainWindow_KeyEvent(object sender, NetDimension.NanUI.Browser.KeyEventArgs e)
        {
            // Force reload the page when F5 is pressed 
            // 注册F5键按下时强制刷新页面
            if (e.KeyEvent.WindowsKeyCode == (int)Keys.F5)
            {
                Reload(true);
            }

            // Show DevTools when F12 is pressed
            // 注册F12键按下时打开开发者工具
            if (e.KeyEvent.WindowsKeyCode == (int)Keys.F12)
            {
                ShowDevTools();
            }
            if (e.KeyEvent.WindowsKeyCode == (int)Keys.Enter)
            {
                
            }
        }
    }
        
}
