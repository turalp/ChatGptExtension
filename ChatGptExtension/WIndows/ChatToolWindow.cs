using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualStudio.Imaging;

namespace ChatGptExtension.WIndows
{
    internal class ChatToolWindow : BaseToolWindow<ChatToolWindow>
    {
        public override Type PaneType => typeof(ChatPane);

        public override async Task<FrameworkElement> CreateAsync(int toolWindowId, CancellationToken cancellationToken)
        {
            return await Task.FromResult<FrameworkElement>(new ChatToolUserControl());
        }

        public override string GetTitle(int toolWindowId) => "Chat GPT";

        [Guid("dcb44fff-3fa8-4f06-a59a-d2006c8a880a")]
        internal class ChatPane : ToolWindowPane
        {
            public ChatPane()
            {
                // Set an image icon for the tool window
                BitmapImageMoniker = KnownMonikers.StatusInformation;
            }
        }
    }
}
