using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace TheMonsterSlayer
{

    public partial class MainWindow : Window //Saving and loading
    {
        public int SAVELOAD_Level = 0;


        public void SaveGame()
        {
            SAVELOAD_Level = CurrentLevel - 1; //saving 1 level empty so player can move to the level he saved.

            string text = SAVELOAD_Level.ToString();
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.txt", text);


        }

        public void LoadGame()
        {


            string text = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "SaveFile.txt");


            var GlitchScreeneffect = new BitmapImage();
            GlitchScreeneffect.BeginInit();
            GlitchScreeneffect.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\glitch-static.gif");
            GlitchScreeneffect.EndInit();
            ImageBehavior.SetAnimatedSource(GlitchScreen, GlitchScreeneffect);


            if (text != "Data")
            {
                if (Int32.Parse(text) > 0)
                {
                    CurrentLevel = Int32.Parse(text);
                    NextLevel();
                }

                if (Int32.Parse(text) > 3)
                {
                    Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\MediumMusic.wav", true);
                    DarknessScreen.Opacity = 0.3;
                    GlitchScreen.Opacity = 0.1;
                    Song1Play = false;
                    Song2Play = true;


                }
                if (Int32.Parse(text) > 7)
                {
                    Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\ScaryMusic.wav", true);
                    DarknessScreen.Opacity = 0.6;
                    GlitchScreen.Opacity = 0.2;

                    Song2Play = false;
                    Song3Play = true;
                }

                if (Int32.Parse(text) > 11)
                {
                    Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\HorrorSoundsDisortionLong.wav", true);
                    DarknessScreen.Opacity = 0.9;
                    GlitchScreen.Opacity = 0.3;

                    Song3Play = false;
                    Song5Play = true;

                }

                if (Int32.Parse(text) > 14)
                {
                    Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\GatesToHeaven.wav", true);
                    DarknessScreen.Opacity = 0;
                    GlitchScreen.Opacity = 0;

                    Song5Play = false;
                    Song4Play = true;
                }

                for (int i = 0; i < Enemies.Length; i++)
                {

                }
            }
        }

    }
}
