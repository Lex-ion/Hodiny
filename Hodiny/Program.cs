using System.Drawing;
using System.Drawing.Imaging;



namespace Hodiny
{
    internal class Program
    {
        




        public static Pen velkaRucicka = new Pen(Color.Yellow, 3);
        public static Pen malaRucicka = new Pen(Color.Blue,2);
        public static Pen vterinovarucicka = new Pen(Color.Red, 1);
        


        public static SolidBrush brushTextu = new SolidBrush(Color.Magenta);
        public static Font font = new Font("Impact",16);
        public static StringFormat formatStringu = new StringFormat();
        public static Rectangle rectTextu = new Rectangle(0,0,99,99);

        public static int delka = 45;
        public static double uhel = 0;

        public static int minuty;
        public static int hodiny;

        static void Main(string[] args)
        {

            Console.SetBufferSize(1500, 1500);
          

            Console.CursorVisible = false;

            int x = 49;
            int y = 49;

            while (true)
            {
                Console.Title = DateTime.Now.TimeOfDay.ToString();
                Bitmap bitmap = new Bitmap(100, 100);
                Bitmap bitmapRucicky = new Bitmap(100, 100);
                Console.Clear();


                int hodina = DateTime.Now.Hour;
                if (hodina > 12)
                {
                    hodina -= 12;
                }

                uhel = DateTime.Now.Minute * 0.105;

                Point stred = new Point(x, y);
                double x1 = Math.Cos(uhel) * delka + x;
                double y1 = Math.Sin(uhel) * delka + y;
                PointF point = new PointF((float)x1, (float)y1);

                uhel = hodina * 0.525 + DateTime.Now.Minute * 0.105 / 60;

                x1 = Math.Cos(uhel) * delka / 2 + x;
                y1 = Math.Sin(uhel) * delka / 2 + y;
                PointF point2 = new PointF((float)x1, (float)y1); uhel = hodina * 0.525 + DateTime.Now.Minute * 0.105 / 60;

                uhel = DateTime.Now.Second * 0.105;

                x1 = Math.Cos(uhel) * delka *1.25 + x;
                y1 = Math.Sin(uhel) * delka * 1.25 + y;
                PointF point3 = new PointF((float)x1, (float)y1);


                formatStringu.FormatFlags = StringFormatFlags.DirectionVertical;
                formatStringu.Alignment = StringAlignment.Center;


                
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawString("12", font, brushTextu, 77, 49, formatStringu);
                    graphics.DrawString("6", font, brushTextu, -8, 49, formatStringu);
                    graphics.DrawString("9", font, brushTextu, 35, 5, formatStringu);
                    graphics.DrawString("3", font, brushTextu, 35, 97, formatStringu);
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }





                using (var graphics = Graphics.FromImage(bitmapRucicky))
                {
                    graphics.DrawLine(vterinovarucicka, stred, point3);

                    graphics.DrawLine(velkaRucicka, stred, point);


                    graphics.DrawLine(malaRucicka, stred, point2);
                    bitmapRucicky.RotateFlip(RotateFlipType.RotateNoneFlipX);
                }

                for (int i = 0; i < 100; i++)
                {
                    Console.Write("|");
                    for (int j = 0; j < 100; j++)
                    {


                        if (bitmapRucicky.GetPixel(i, j).ToArgb() == Color.Red.ToArgb())
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("# ");
                        }
                        else if (bitmapRucicky.GetPixel(i, j).ToArgb() == Color.Yellow.ToArgb())
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("# ");
                        }
                        else if (bitmapRucicky.GetPixel(i, j).ToArgb() == Color.Blue.ToArgb())
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("# ");
                        }
                        else if (bitmap.GetPixel(i, j).ToArgb() == Color.Magenta.ToArgb())
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.Write("# ");
                        }
                        else
                        {
                            Console.Write("  ");

                        }

                        Console.ForegroundColor = ConsoleColor.White;


                    }
                    Console.WriteLine("|");


                    
                }
                Thread.Sleep(3500);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}