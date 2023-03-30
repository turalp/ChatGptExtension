global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using ChatGptExtension.Commands;
using ChatGptExtension.WIndows;
using System.Runtime.InteropServices;
using System.Threading;

namespace ChatGptExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ChatToolWindow.ChatPane), Style = VsDockStyle.Tabbed, Window = WindowGuids.DocumentWell)]
    [Guid(PackageGuids.ChatGptExtensionString)]
    public sealed class ChatGptExtensionPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            this.RegisterToolWindows();
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            
            await AddTestButtonCommand.InitializeAsync(this);
            await CompleteCodeButtonCommand.InitializeAsync(this);
            await ExplainButtonCommand.InitializeAsync(this);
            await FindBugsButtonCommand.InitializeAsync(this);
            await OptimizeButtonCommand.InitializeAsync(this);
            await ShowChatWindowCommand.InitializeAsync(this);
        }
    }
}