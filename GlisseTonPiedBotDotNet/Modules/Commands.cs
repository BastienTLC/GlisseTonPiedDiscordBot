using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Rest;
using Discord.WebSocket;
using GlisseTonPiedBot.Modules.Morpion;
using GlisseTonPiedBotDotNet.Modules;
using Image = SixLabors.ImageSharp.Image;

namespace GlisseTonPiedBot.Modules
{

    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("giroud")]
        public async Task GiroudAsync()
        {
            await ReplyAsync(VideoLinkData.videoGiroud);
        }
        [Command("explosion")]
        public async Task ExplosionAsync()
        {
            await ReplyAsync(VideoLinkData.videoExplosion);
        }
        [Command("cafard")]
        public async Task CafardAsync()
        {
            await ReplyAsync(VideoLinkData.videoCafard);
        }
        [Command("xd")]
        public async Task XdAsync()
        {
            await ReplyAsync(VideoLinkData.videoxd);
        }
        [Command("ptn")]
        public async Task PtnAsync()
        {
            await ReplyAsync(VideoLinkData.videoPutain);
        }
        [Command("chocolat")]
        public async Task ChocolatAsync()
        {
            await ReplyAsync(VideoLinkData.videoChocolat);
        }

        [Command("masterclass")]
        public async Task MasterClassAsync()
        {
            await ReplyAsync(VideoLinkData.videoMasterClass);
        }
        [Command("oupa")]
        public async Task OupaAsync()
        {
            await ReplyAsync(VideoLinkData.VideoOupa);
        }



        [Command("help")]
        public async Task helpAsync()
        {
            EmbedBuilder builder = new EmbedBuilder();
            Emoji skip = new Emoji("⏭️");
            Emoji dot1 = new Emoji(":small_orange_diamond:");
            Emoji dot2 = new Emoji(":small_blue_diamond:");

            builder.WithTitle("Liste des commandes");
            builder.AddField(new Emoji(":movie_camera:") + "Commande Vidéo", dot1 + " %giroud \n"
                + dot1 + " %explosion \n"
                + dot1 + " %cafard \n"
                + dot1 + " %xd \n"
                + dot1 + " %ptn \n"
                + dot1 + " %chocolat \n"
                + dot1 + " %masterclass \n"
                + dot1 + " %oupa \n"
                , true);

            builder.AddField(new Emoji(":camera:") + "Commande Image", dot2 + " %text *@user your text \n"
              + dot2 + " %fouine *@user \n"
              + dot2 + " %brighness *@user (NUL)\n"

              , true);
            // true - for inline
            builder.WithThumbnailUrl("https://cdn.discordapp.com/attachments/732571903729860695/830443919249637397/unknown.png");
            builder.WithColor(Color.LightOrange);
            var message = await ReplyAsync("", false, builder.Build());
        }

        public async Task TestCommand(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var message = await ReplyAsync("choisissez votre signe : ");
                var emotes = new[]
                {
            new Emoji("1️⃣"),
            new Emoji("2️⃣"),
            new Emoji("3️⃣"),
            new Emoji("4️⃣"),
            new Emoji("5️⃣"),
            new Emoji("6️⃣"),
            new Emoji("7️⃣"),
            new Emoji("8️⃣"),
            new Emoji("9️⃣"),
            new Emoji("🔟")
                };
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                await message.AddReactionsAsync(emotes);
                stopWatch.Stop();
                await message.ModifyAsync(x => x.Content = "Vous avez pas choisit votre signe");
                await Task.Delay(5000);
                //var nbreac = await message.GetReactionUsersAsync(skip, 100).FlattenAsync();
            }
        }



        [Command("fouine")]
        public async Task AvatarAsync(SocketUser user = null, ushort size = 512)
        {
            if (user == null)
            {
                await ReplyAsync(CDN.GetUserAvatarUrl(Context.User.Id, Context.User.AvatarId, size, ImageFormat.Auto));
            }
            else
            {
                await ReplyAsync(CDN.GetUserAvatarUrl(user.Id, user.AvatarId, size, ImageFormat.Auto));
               // await ReplyAsync(user.GetAvatarUrl());
            }
        }

        [Command("brighness")]
        public async Task DistortionAvatar(SocketUser user = null, ushort size = 512)
        {
            EditImage editImage = new EditImage(CDN.GetUserAvatarUrl(user.Id, user.AvatarId, size, ImageFormat.Auto));
            Console.WriteLine(user.GetAvatarUrl());
            editImage.Brightness();
            

            await Context.Channel.SendFileAsync("image\\update.png", "Caption goes here");

        }

        [Command("text")]
        public async Task TextAvatar(SocketUser user = null,String text = "TEXT", String text1 = "", String text2 = "", String text3 = "", String text4 = "")
        {
            int nbArgument = 1;

            if (text4 != "")
                nbArgument = 5;
            if (text3 != "" && text4 == "")
                nbArgument = 4;
            if (text2 != "" && text3 == "")
                nbArgument = 3;
            if (text1 != "" && text2 == "")
                nbArgument = 2;



            EditImage editImage = new EditImage(CDN.GetUserAvatarUrl(user.Id, user.AvatarId, 512, ImageFormat.Auto));
            Console.WriteLine(user.GetAvatarUrl());
            editImage.writeMessageOnImage(text, text1, text2, text3, text4, nbArgument);

            await Context.Channel.SendFileAsync("image\\update.png");
        }

        [Command("morpion")]
        public async Task TextAvatar(SocketUser user)
        {
            SocketUser principalUser = Context.User;
            await Context.Channel.SendMessageAsync(Context.User.Username);
            MorpionMain morpionGame = new MorpionMain(Context.User,user);
            EmbedBuilder builder = new EmbedBuilder();
            Emoji vs = new Emoji(":vs:");
            Emoji dot1 = new Emoji(":small_orange_diamond:");
            Emoji dot2 = new Emoji(":small_blue_diamond:");
            Emoji cercle = new Emoji("⭕");
            Emoji croix = new Emoji("❌");


            builder.WithTitle("Partie de Morption");
            builder.AddField(dot1 + principalUser.Username, " " + principalUser.Mention, true);
            builder.AddField("DUEL", vs, true);
            builder.AddField(dot2 + user.Username, " " + user.Mention, true);
            builder.WithThumbnailUrl(Context.User.GetAvatarUrl());
            builder.WithImageUrl(user.GetAvatarUrl());
            builder.WithColor(Color.LightOrange);
            var message = await ReplyAsync("", false, builder.Build());

            
            await message.AddReactionAsync(cercle);
            await message.AddReactionAsync(croix);

            

            while (true)
            {
                var nbreac = await message.GetReactionUsersAsync(cercle, 100).FlattenAsync();
                if (nbreac.Count() > 2)
                {

                    Console.WriteLine("L'utilisateur a réagie");
                }
            }
            
            //await TestCommand(1);






        }




    }
}
