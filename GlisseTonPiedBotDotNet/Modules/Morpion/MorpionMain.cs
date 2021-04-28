using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord;
using Discord.Commands;

namespace GlisseTonPiedBot.Modules.Morpion
{
    public class MorpionMain 
    {
        private SocketUser firstPlayer;
        private SocketUser secondPlayer;

        public MorpionMain(SocketUser firstPlayer, SocketUser secondPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.secondPlayer = secondPlayer;
        }

    }
}
