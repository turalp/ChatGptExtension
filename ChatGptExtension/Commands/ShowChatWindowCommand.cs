﻿using ChatGptExtension.WIndows;

namespace ChatGptExtension.Commands
{
    [Command(PackageIds.ShowChatWindowCommand)]
    internal sealed class ShowChatWindowCommand : BaseCommand<ShowChatWindowCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e) => await ChatToolWindow.ShowAsync();
    }
}
