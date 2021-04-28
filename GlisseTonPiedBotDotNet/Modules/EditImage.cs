using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;

using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Fonts;

namespace GlisseTonPiedBot.Modules
{
    class EditImage
    {
        private String imageLink;

        public EditImage(string imageLink)
        {
            this.imageLink = imageLink;
        }

        public String convertWebImage()
        {
            String fillChemin = "/home/bastien/Documents/bot/GlisseTonPiedDiscordBot/GlisseTonPiedBotDotNet/bin/Debug/net5.0/image/imgtmp.png";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(imageLink, fillChemin);
                Console.WriteLine("DL de " + imageLink);
            }
            return fillChemin;
        }

        public String Brightness()
        {
            String EditFillChemin = "/home/bastien/Documents/bot/GlisseTonPiedDiscordBot/GlisseTonPiedBotDotNet/bin/Debug/net5.0/image/update.png";
            using (Image image = Image.Load(convertWebImage()))
            {
                
                image.Mutate(c => c.ProcessPixelRowsAsVector4(row =>
                {
                    for (int x = 0; x < row.Length; x++)
                    {
                        for (int y = 0; y < row.Length; y++)
                        {
                            // We can apply any custom processing logic here
                            //row[x] = Vector4.SquareRoot(row[x]);
                            // row[y] = Vector4.SquareRoot(row[y]);
                            row[y] = Vector4.Normalize(row[y]);
                        }
                       
                    }
                }));
                image.Save("/home/bastien/Documents/bot/GlisseTonPiedDiscordBot/GlisseTonPiedBotDotNet/bin/Debug/net5.0/image/update.png");
                // image.Save(outPath);
                return EditFillChemin;
            }
        }
        

        public String writeMessageOnImage(String text, String text1, String text2, String text3, String text4, int nbArgument)
        {
            String EditFillChemin = "/home/bastien/Documents/bot/GlisseTonPiedDiscordBot/GlisseTonPiedBotDotNet/bin/Debug/net5.0/image/update.png";

            FontCollection collection = new FontCollection();
            //FontFamily arial = collection.Install("font/arial.ttf");
            FontFamily Burbank = collection.Install("/home/bastien/Documents/bot/GlisseTonPiedDiscordBot/GlisseTonPiedBotDotNet/bin/Debug/net5.0/font/Burbank.ttf");
            using (Image image = Image.Load(convertWebImage()))
            {

                int fontSize = image.Width / 5;
                int fontSizeBorder = fontSize +3;
                Font font = Burbank.CreateFont(fontSize, FontStyle.Bold);
                Font fontBorder = Burbank.CreateFont(fontSizeBorder, FontStyle.Bold);
                String finalText = "";
                String finalTextBorder = "";

                for (int i = 0; i < nbArgument; i++)
                {
                    switch (i)
                    {
                        case 0:
                            for (int j = 0; j < text.Length; j++)
                            {
                                
                                    finalText = finalText + text[j];
                            }
                            
                            break;
                        case 1:
                            for (int j = 0; j < text1.Length; j++)
                            {
                                finalText = finalText + text1[j];
                            }
                            break;
                        case 2:
                            for (int j = 0; j < text2.Length; j++)
                            {
                                finalText = finalText + text2[j];
                            }
                            break;
                        case 3:
                            for (int j = 0; j < text3.Length; j++)
                            {
                                finalText = finalText + text3[j];
                            }
                            break;
                        case 4:
                            for (int j = 0; j < text4.Length; j++)
                            {
                                finalText = finalText + text4[j];
                            }
                            break;
                    }

                        finalText = finalText + "\n";
                }
                finalTextBorder = finalText;
                image.Mutate(x => x.DrawText(finalText, fontBorder, Color.Black, new PointF(image.Width / 100, image.Height / 100)));
                image.Mutate(x => x.DrawText(finalText, font, Color.White, new PointF(image.Width/100, image.Height/100)));

                image.Save("/home/bastien/Documents/bot/GlisseTonPiedDiscordBot/GlisseTonPiedBotDotNet/bin/Debug/net5.0/image/update.png");
                // image.Save(outPath);
                return EditFillChemin;
            }
        }


    }
}
