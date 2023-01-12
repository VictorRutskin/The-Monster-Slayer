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
    public partial class MainWindow : Window //Animations
    {

        public void Set_Background(int lvl) //reads all backgrounds and sets the needed one for the current level
        {
            BackGrounds[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\City1_Pale.png")));
            BackGrounds[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\City2_pale.png")));
            BackGrounds[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\City3_pale.png")));
            BackGrounds[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\City4_pale.png")));
            BackGrounds[4] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\postapocalypse1.png")));
            BackGrounds[5] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\postapocalypse2.png")));
            BackGrounds[6] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\postapocalypse3.png")));
            BackGrounds[7] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\postapocalypse4.png")));
            BackGrounds[8] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\Stage3bg1.png")));
            BackGrounds[9] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\Stage3bg2.png")));
            BackGrounds[10] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\Stage3bg3.png")));
            BackGrounds[11] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\Stage3bg4.png")));
            BackGrounds[12] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\CrazyBackground1.png")));

            for (int i = 0; i < BackGrounds.Length; i++)
            {
                if ((lvl - 1) == i)
                {
                    Background = BackGrounds[i];
                    
                }
            }
        }

        public void Text(int num,bool show) //gets number, returns the needed ammobar
        {
            TextImages[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Explanation1.png")));
            TextImages[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Boss1Sentence.png")));
            TextImages[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Boss2SentencePart1.png")));
            TextImages[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Boss2SentencePart2.png")));
            TextImages[4] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Boss3Sentence.png")));
            TextImages[5] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Explanation1.png")));
            TextImages[6] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Ending5Part1.png")));
            TextImages[7] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Ending5Part2.png")));
            TextImages[8] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\Ending5Part3.png")));
            TextImages[9] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Text\MainTitleText.png")));

            for (int i = 0; i < TextImages.Length; i++)
            {
                if (num == i && show == true)
                {
                    TextBarXaml.Fill = TextImages[i]; //cut to /2
                    if(i == 1)
                    {
                        TextBarXaml.Width = TextBarXaml.Width / 1.5;
                    }
                }
            }
            

            if(show ==true)
            {
                TextBarXaml.Opacity = 100;
            }
            else
            {
                TextBarXaml.Opacity = 0;
            }

        }

        public ImageBrush AmmoBarAnimation(int num) //gets number, returns the needed ammobar
        {
            AmmoBar[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar0.png")));
            AmmoBar[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar1.png")));
            AmmoBar[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar2.png")));
            AmmoBar[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar3.png")));
            AmmoBar[4] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar4.png")));
            AmmoBar[5] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar5.png")));
            AmmoBar[6] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar6.png")));
            AmmoBar[7] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar7.png")));
            AmmoBar[8] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\AmmoBar8.png")));

            return AmmoBar[num];
        }

        public ImageBrush HealthBarAnimation(int num) //gets number, returns the needed hpbar
        {
            HpBar[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\HpBar0.png")));
            HpBar[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\HpBar1.png")));
            HpBar[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\HpBar2.png")));
            HpBar[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bars\HpBar3.png")));
            return HpBar[num];

        }

        public ImageBrush EndingsPictures(int num) //gets number, returns the needed hpbar
        {
            Endings[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Endings\Ending1.png")));
            Endings[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Endings\Ending2.png")));
            Endings[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Endings\Ending3.png")));
            Endings[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Endings\Ending4.png")));
            return Endings[num-1];

        }

        public ImageBrush JumpScaresPictures(int num) //gets number, returns the needed hpbar
        {
            JumpScares[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bosses\Boss1\Boss1Screen.png")));
            JumpScares[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\JumpScare4.png")));
            JumpScares[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\JumpScare1.png")));
            JumpScares[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\JumpScare3.png")));
            JumpScares[4] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\JumpScare2.png")));
            JumpScares[5] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\JumpScare5.png")));
            JumpScares[6] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\JumpScare6.png")));
            JumpScares[7] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\MainGameWindow.png")));


            return JumpScares[num];

        }

        public ImageBrush Boss2AnimationPictures(int num) //gets number, returns the needed hpbar
        {
            Boss2Pictures[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bosses\Boss2\Boss2Static1.png")));
            Boss2Pictures[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bosses\Boss2\Boss2Static2.png")));
            return Boss2Pictures[num];

        }

        public void WalkingAnimation(string side)
        {
            if (side == "right")
            {
                MainCharactersImages[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\RightWalk1.png")));
                MainCharactersImages[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\RightWalk2.png")));
                MainCharactersImages[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\RightWalk3.png")));
                MainCharactersImages[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\RightWalk4.png")));
            }
            else if (side == "left")
            {
                MainCharactersImages[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\LeftWalk1.png")));
                MainCharactersImages[1] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\LeftWalk2.png")));
                MainCharactersImages[2] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\LeftWalk3.png")));
                MainCharactersImages[3] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\LeftWalk4.png")));
            }

           
        }


    }
}
