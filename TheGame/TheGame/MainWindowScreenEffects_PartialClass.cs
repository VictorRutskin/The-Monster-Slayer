using System;
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
    public partial class MainWindow : Window  //ScreenEffects
    {
        public void Ending1() // Dying from monsters = dying from insanity
        {
            Song1Play = false;
            Song2Play = false;
            Song3Play = false;
            Song4Play = false;
            Song5Play = false;
            Song6Play = true;

            MainScreenPicture.Fill = EndingsPictures(1);
            MainScreenPicture.Opacity = 100;
            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\scaryviolin.wav", true);
            PlayAgainBtn(true);

        }
        public void Ending2() // Dstaying crazy with mom
        {
            Song1Play = false;
            Song2Play = false;
            Song3Play = false;
            Song4Play = false;
            Song5Play = false;
            Song6Play = true;

            MainScreenPicture.Fill = EndingsPictures(2);
            MainScreenPicture.Opacity = 100;
            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\scaryviolin.wav", true);
            PlayAgainBtn(true);


        }

        public void Ending3() // taking meds and going to mental hospital
        {
            Song1Play = false;
            Song2Play = false;
            Song3Play = false;
            Song4Play = false;
            Song5Play = false;
            Song6Play = true;

            MainScreenPicture.Fill = EndingsPictures(3);
            MainScreenPicture.Opacity = 100;
            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\scaryviolin.wav", true);
            PlayAgainBtn(true);


        }


        public void Ending4() // going to jail forever
        {
            Song1Play = false;
            Song2Play = false;
            Song3Play = false;
            Song4Play = false;
            Song5Play = false;
            Song6Play = true;

            MainScreenPicture.Fill = EndingsPictures(4);
            MainScreenPicture.Opacity = 100;
            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\scaryviolin.wav", true);
            PlayAgainBtn(true);



        }

        public async void Ending5() // happy world
        {
            await Task.Delay(3000); 
            Text(6, true);
            await Task.Delay(3000);
            Text(6, false);
            await Task.Delay(3000);
            Text(7, true);
            await Task.Delay(3000);
            Text(7, false);
            await Task.Delay(3000);
            Text(8, true);
            await Task.Delay(10000);
            Text(8, false);
            await Task.Delay(3000);
            PlayAgainBtn(true);


        }

        public async void ScreenEffectBoss1() // Dying from monsters = dying from insanity
        {
            if (Enemies[0] != null && Enemies[1] != null && Enemies[2] != null && Enemies[3] != null)
            {
                if (Enemies[0].Hp < 1 && Enemies[1].Hp < 1 && Enemies[2].Hp < 1 && Enemies[3].Hp < 1)
                {
                    Boss1Bool = false; //no need to proc anymore, done once

                    await Task.Delay(3000); //wait for boss to appear
                    MainScreenPicture.Opacity = 100;

                    var GlitchScreeneffect = new BitmapImage();
                    GlitchScreeneffect.BeginInit();
                    GlitchScreeneffect.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\JumpScares\glitch-static.gif");
                    GlitchScreeneffect.EndInit();
                    ImageBehavior.SetAnimatedSource(GlitchScreen, GlitchScreeneffect);
                    GlitchScreen.Opacity = 0.1;

                    Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\Glitch.wav", true);
                    MainScreenPicture.Fill = JumpScaresPictures(0);
                    await Task.Delay(500); //0.5 seconds for the photo appearance
                    MainScreenPicture.Opacity = 0;
                    Boss1Xaml.Opacity = 100;
                    Text(1, true);   //say stuff and appear
                                     
                    // ending 2 or able to continue to next lvl
                    for(int i = 0; i < 1000; i++) //wait for about 12 seconds aswell
                    {
                        if ((Canvas.GetLeft(Boss1Xaml) - Canvas.GetLeft(TheBullet) > -200 && Canvas.GetLeft(Boss1Xaml) - Canvas.GetLeft(TheBullet) < 200 &&
                           Canvas.GetTop(Boss1Xaml) - Canvas.GetTop(TheBullet) > -200 && Canvas.GetTop(Boss1Xaml) - Canvas.GetTop(TheBullet) < 20 &&
                           TheBullet.Opacity == 100)) //if got shot   
                        {
                            DecisionMade = true;
                            Song1Play = false;
                            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\WomanScream.wav", true);
                            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\MediumMusic.wav", true);
                            Text(1, false); //first text disabled
                            Boss1Xaml.Opacity = 0;
                            MainScreenPicture.Opacity = 100;
                            MainScreenPicture.Fill = JumpScaresPictures(1);
                            await Task.Delay(1000); //1 seconds for the photo appearance
                            MainScreenPicture.Opacity = 0;
                            break;

                        }
                        await Task.Delay(1); //setting time very important to not break app 
                    }
                    if (DecisionMade == false)
                    {
                        DecisionMade = true;
                        Text(1, false); //first text disabled
                        Ending2();
                        Boss1Xaml.Opacity = 100;
                    }

                }
            }
            

        }

        public async void ScreenEffectBoss2() // Dying from monsters = dying from insanity
        {
            if (Enemies[0] != null && Enemies[1] != null && Enemies[2] != null && Enemies[3] != null &&
                Enemies[4] != null && Enemies[5] != null && Enemies[6] != null && Enemies[7] != null)
            {
                if (Enemies[0].Hp < 1 && Enemies[1].Hp < 1 && Enemies[2].Hp < 1 && Enemies[3].Hp < 1 &&
                    Enemies[4].Hp < 1 && Enemies[5].Hp < 1 && Enemies[6].Hp < 1 && Enemies[7].Hp < 1)
                {
                    Boss2Bool = false; //no need to proc anymore, done once

                    await Task.Delay(3000); //wait for boss to appear
                    MainScreenPicture.Opacity = 100;

                    GlitchScreen.Opacity = 0.2;

                    Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\Glitch.wav", true);
                    MainScreenPicture.Fill = JumpScaresPictures(6);
                    await Task.Delay(500); //0.5 seconds for the photo appearance
                    MainScreenPicture.Opacity = 0;
                    Boss2Xaml.Opacity = 100;
                    Text(2, true);   //say stuff and appear
                    await Task.Delay(3000); //wait 2 seconds
                    Text(2, false);   //say stuff and appear
                    Text(3, true);   //say stuff and appear
                    // ending 3 or able to continue to next lvl
                    for (int i = 0; i < 1000; i++) //wait for about 12 seconds aswell
                    {
                        if ((Canvas.GetLeft(Boss2Xaml) - Canvas.GetLeft(TheBullet) > -200 && Canvas.GetLeft(Boss2Xaml) - Canvas.GetLeft(TheBullet) < 200 &&
                           Canvas.GetTop(Boss2Xaml) - Canvas.GetTop(TheBullet) > -200 && Canvas.GetTop(Boss2Xaml) - Canvas.GetTop(TheBullet) < 20 &&
                           TheBullet.Opacity == 100)) //if got shot   
                        {
                            DecisionMade = true;
                            Song2Play = false;
                            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\MonsterScream.wav", true);
                            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\ScaryMusic.wav", true);

                            Boss2Xaml.Opacity = 0;
                            Text(3, false);
                            var image = new BitmapImage();
                            image.BeginInit();
                            image.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Bosses\Boss2\Boss2Animation.gif");
                            image.EndInit();
                            ImageBehavior.SetAnimatedSource(DeadMonsterAnimation, image);
                            DeadMonsterAnimation.Opacity = 100; 
                            await Task.Delay(2000); //wait 2 seconds
                            DeadMonsterAnimation.Opacity = 0;
                            MainScreenPicture.Opacity = 100;
                            MainScreenPicture.Fill = JumpScaresPictures(2);
                            await Task.Delay(1000); //1 seconds for the photo appearance
                            MainScreenPicture.Opacity = 0;
                            break;

                        }
                        await Task.Delay(1); //setting time very important to not break app 
                    }
                    if (DecisionMade == false)
                    {
                        DecisionMade = true;
                        Text(3, false);   
                        Ending3();
                        Boss2Xaml.Opacity = 100;
                    }

                }
            }


        }

        public async void ScreenEffectBoss3() // Dying from monsters = dying from insanity
        {
            if (Enemies[0] != null && Enemies[1] != null && Enemies[2] != null && Enemies[3] != null &&
                Enemies[4] != null && Enemies[5] != null && Enemies[6] != null && Enemies[7] != null &&
                Enemies[8] != null && Enemies[9] != null && Enemies[10] != null && Enemies[11] != null)

            {
                if (Enemies[0].Hp < 1 && Enemies[1].Hp < 1 && Enemies[2].Hp < 1 && Enemies[3].Hp < 1 &&
                    Enemies[4].Hp < 1 && Enemies[5].Hp < 1 && Enemies[6].Hp < 1 && Enemies[7].Hp < 1 &&
                    Enemies[8].Hp < 1 && Enemies[9].Hp < 1 && Enemies[10].Hp < 1 && Enemies[11].Hp < 1)

                {
                    Boss3Bool = false; //no need to proc anymore, done once

                    await Task.Delay(3000); //wait for boss to appear
                    MainScreenPicture.Opacity = 100;

                    GlitchScreen.Opacity = 0.3;

                    Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\Glitch.wav", true);
                    MainScreenPicture.Fill = JumpScaresPictures(5);
                    await Task.Delay(500); //0.5 seconds for the photo appearance
                    MainScreenPicture.Opacity = 0;
                    Boss3Xaml.Opacity = 100;
                    Text(4, true);   //say stuff and appear
                    //good ending 2 or able to continue to next lvl
                    for (int i = 0; i < 1000; i++) //wait for about 12 seconds aswell
                    {
                        if ((Canvas.GetLeft(Boss3Xaml) - Canvas.GetLeft(TheBullet) > -200 && Canvas.GetLeft(Boss3Xaml) - Canvas.GetLeft(TheBullet) < 200 &&
                           Canvas.GetTop(Boss3Xaml) - Canvas.GetTop(TheBullet) > -200 && Canvas.GetTop(Boss3Xaml) - Canvas.GetTop(TheBullet) < 20 &&
                           TheBullet.Opacity == 100)) //if got shot   
                        {
                            DecisionMade = true;
                            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\PoliceOfficerScream.wav", true);

                            Text(4, false);   //say stuff and appear
                            Boss3Xaml.Opacity = 0;
                            MainScreenPicture.Opacity = 100;
                            MainScreenPicture.Fill = JumpScaresPictures(3);
                            await Task.Delay(1000); //1 seconds for the photo appearance
                            MainScreenPicture.Opacity = 0;
                            break;
                        }
                        await Task.Delay(1); //setting time very important to not break app 
                    }
                    if (DecisionMade == false)
                    {
                        DecisionMade = true;
                        Text(4, false);
                        Ending4();
                        Boss3Xaml.Opacity = 100;
                    }

                }
            }


        }



    }
}
