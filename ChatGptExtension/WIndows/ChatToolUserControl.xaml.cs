using Microsoft.Web.WebView2.Core;
using System.IO;
using System.Windows.Controls;
using Settings = ChatGptExtension.Properties.Settings;
using MessageBox = System.Windows.Forms.MessageBox;

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

        private async void ChatToolWindow_Initialized(object sender, EventArgs e)
        {
            string userDataFolder = Path.Combine(Path.GetTempPath(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            var cwv2Environment = await CoreWebView2Environment.CreateAsync(null, userDataFolder, null);

            await chatWebView.EnsureCoreWebView2Async(cwv2Environment);

            chatWebView.Visibility = string.IsNullOrEmpty(Settings.Default.ChatGptApiKey) ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
        }

        private void buttonApi_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(apiKeyTextBox.Text))
            {
                MessageBox.Show("Provided API key is null or empty. Try again, please.");
            }

            Settings.Default.ChatGptApiKey = apiKeyTextBox.Text;
            chatWebView.Visibility = string.IsNullOrEmpty(Settings.Default.ChatGptApiKey) ? System.Windows.Visibility.Hidden : System.Windows.Visibility.Visible;
        }
    }
}
