global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using ChatGptExtension.Commands;
using ChatGptExtension.WIndows;
using EnvDTE80;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Documents;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace ChatGptExtension
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(ChatToolWindow.ChatPane))]
    [Guid(PackageGuids.ChatGptExtensionString)]
    public sealed class ChatGptExtensionPackage : ToolkitPackage
    {
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
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