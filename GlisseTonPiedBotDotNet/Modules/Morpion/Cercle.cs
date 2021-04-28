using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.Fonts;

namespace GlisseTonPiedBot.Modules.Morpion
{
    class Cercle
    {
        private Image image;

        public Cercle(Image image)
        {
            this.image = image;
        }
        public Image drawCircle(int row, char column)
        {
            using (Image image = Image.Load("image/MorpionGripModif.png"))
            {
                FontCollection collection = new FontCollection();
                FontFamily arial = collection.Install("font/arial.ttf");
                Font font = arial.CreateFont(50, FontStyle.Bold);

                image.Mutate(x => x.DrawText("X", font, Color.Black, new PointF(image.Width / 100, image.Height / 100)));
                image.Save("image/update.png");
                return image;
            }
        }
        
    }
}
