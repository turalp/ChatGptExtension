using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Windows.Controls;

namespace ChatGptExtension.WIndows
{
    /// <summary>
    /// Interaction logic for ChatToolWindow.xaml
    /// </summary>
    public partial class ChatToolUserControl : UserControl
    {
        public ChatToolUserControl()
        {
            InitializeComponent();

            string userDataFolder = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            var cwv2Environment = CoreWebView2Environment.CreateAsync(null, userDataFolder, null).ConfigureAwait(false).GetAwaiter().GetResult();

            chatWebView.EnsureCoreWebView2Async(cwv2Environment).ConfigureAwait(false);
        }

        private void chatWebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (e.IsSuccess)
            {
                string path = Path.GetFullPath("C:\\Users\\tural\\source\\repos\\ChatGptExtension\\ChatGptExtension\\View\\chat.extension.html");
                string url = new Uri(path).AbsoluteUri;
                chatWebView.CoreWebView2.Navigate(url);
            }
        }
    }
}
