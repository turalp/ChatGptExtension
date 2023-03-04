namespace ChatGptExtension.Commands
{
    [Command(PackageIds.ExplainButtonCommand)]
    public class ExplainButtonCommand : BaseCommand<ExplainButtonCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("ChatGptExtension", "Button clicked");
        }
    }
}
