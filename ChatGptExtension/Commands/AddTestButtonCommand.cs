namespace ChatGptExtension
{
    [Command(PackageIds.AddTestButtonCommand)]
    internal sealed class AddTestButtonCommand : BaseCommand<AddTestButtonCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("ChatGptExtension", "Button clicked");
        }
    }
}
