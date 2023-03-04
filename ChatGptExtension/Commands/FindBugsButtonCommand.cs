namespace ChatGptExtension.Commands
{
    [Command(PackageIds.FindBugsButtonCommand)]
    public class FindBugsButtonCommand : BaseCommand<FindBugsButtonCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("ChatGptExtension", "Button clicked");
        }
    }
}
