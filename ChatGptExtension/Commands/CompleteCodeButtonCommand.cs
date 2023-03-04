namespace ChatGptExtension.Commands
{
    [Command(PackageIds.CompleteCodeButtonCommand)]
    internal class CompleteCodeButtonCommand : BaseCommand<CompleteCodeButtonCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("ChatGptExtension", "Button clicked");
        }
    }
}
