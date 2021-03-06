﻿using System.Threading.Tasks;
using Discord.Commands;
using DiscordBingoBot.Services;

namespace DiscordBingoBot.Commands.BingoCommands
{
    // Keep in mind your module **must** be public and inherit ModuleBase.
    // If it isn't, it will not be discovered by AddModulesAsync!
    public class JoinCommand : ModuleBase<SocketCommandContext>
    {
        private readonly IBingoService _bingoService;

        public JoinCommand(IBingoService bingoService)
        {
            _bingoService = bingoService;
        }

        [Command("join")]
        [Summary("Joins the active bingo game")]
        public async Task Join()
        {
            var message = Context.Message;

            var result = _bingoService.Register(Context.User.Mention);
            if (result.Result)
            {

                await ReplyAsync(Context.User.Mention + " has joined the Bingo game");
            }
            else
            {
                await ReplyAsync(Context.User.Mention + " can't join the Bingo game: " + result.Info);
            }

            await message.DeleteAsync();
        }
    }
}
