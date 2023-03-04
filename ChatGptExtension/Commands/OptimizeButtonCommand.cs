namespace ChatGptExtension.Commands
{
    [Command(PackageIds.OptimizeButtonCommand)]
    public class OptimizeButtonCommand : BaseCommand<OptimizeButtonCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("ChatGptExtension", "Button clicked");
        }
    }
}
