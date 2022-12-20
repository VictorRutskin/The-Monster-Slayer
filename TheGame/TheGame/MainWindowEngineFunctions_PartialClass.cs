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
    public partial class MainWindow : Window //The Engine behind the game
    {

        //public async void Reset() // resets all game data to start
        //{
        //    RightDirection = false;
        //    LeftDirection = false;
        //    ShootingCooldown = false; //takes a moment from bullet to bullet, if false can shoot.
        //    ReloadCooldown = false;
        //    Reload = false; // reloading gun
        //    Skip = false;
        //    Menu = false; //opening menu
        //    DoAnimationRight = true;
        //    DoAnimationLeft = true;
        //    DoAnimationShooting = true;
        //    DoJump = true; //animation time cooldown
        //    Boss1Bool = true; //procing boss 1 or not?
        //    Boss2Bool = true; //procing boss 2 or not?
        //    Boss3Bool = true; //procing boss 3 or not?
        //    DecisionMade = false;
        //    Vulnerability = false; // if Vulnerability true cant get dmg
        //    Spinbool = true; //allows spinning
        //    Song1Play = true; //nice
        //    Song2Play = true; //medium
        //    Song3Play = true; //scaryvery
        //    Song4Play = true; //heaven
        //    Song5Play = true; //disotrion
        //    Song6Play = false; //violin
        //    MainCharacterHp = 3;


        //}


        public async void PlayAgainBtn(bool activate) 
        {
            if(activate==true)
            {
                PlayAgainButton.IsEnabled = true;
                PlayAgainButton.Opacity = 1;
            }
            else if(activate==false)
            {
                PlayAgainButton.IsEnabled = false;
                PlayAgainButton.Opacity = 0;
            }

            await Task.Delay(1);


        }
        public async void MenuEffect() 
        {
            bool Store = true; //storing the data only once because while loop

            while (CurrentLevel < 20)
            {
                if (Menu == true)
                {
                    MenuScreen.Opacity = 0.5;
                    PlayButton.Opacity = 1;
                  //  SettingsButton.Opacity = 1;
                    ExitButton.Opacity = 1;

                    SaveButton.Opacity = 1;

                    LoadButton.Opacity = 1;

                    SaveButton.IsEnabled = true;

                    LoadButton.IsEnabled = true;

                    PlayButton.IsEnabled = true;
                  //  SettingsButton.IsEnabled = true;
                    ExitButton.IsEnabled = true;

                    speed = 0;
                    ReaperSpeed = 0;
                    ReaperSpeedBoost = 0;
                    BrainSpeed = 0;
                    BrainSpeedBoost = 0;
                    GhostSpeed = 0;
                    GhostSpeedBoost = 0;


                    //for (int i = 0; i < Enemies.Length; i++)
                    //{
                    //    if (Enemies[i] != null && Store == true)
                    //    {
                    //        Enemies[i].ReaperEnemySpeed = EnemiesSpeedDataSaver[i];
                    //        Store = false;
                    //    }
                    //}

                    //for (int i = 0; i < Enemies.Length; i++)
                    //{
                    //    if (Enemies[i] != null)
                    //    {
                    //        Enemies[i].ReaperEnemySpeed = 0;
                    //    }
                    //}


                }
                else if (Menu == false)
                {
                    Store = true;
                    MenuScreen.Opacity = 0;
                    PlayButton.Opacity = 0;
                    SaveButton.Opacity = 0;
                    LoadButton.Opacity = 0;

                    //   SettingsButton.Opacity = 0;
                    ExitButton.Opacity = 0;

                    PlayButton.IsEnabled = false;
                   // SettingsButton.IsEnabled = false;
                    ExitButton.IsEnabled = false;

                    SaveButton.IsEnabled = false;

                    LoadButton.IsEnabled = false;

                    speed = 20;
                    ReaperSpeed = 2 ;
                    GhostSpeed = 2 ;
                    BrainSpeed = 3 ;

                    if(CurrentLevel>4)
                    {
                        ReaperSpeedBoost =1;
                        BrainSpeedBoost = 1;
                        GhostSpeedBoost = 1;


                    }
                    if (CurrentLevel>8)
                    {
                        ReaperSpeedBoost = 2;
                        BrainSpeedBoost = 2;
                        GhostSpeedBoost= 4;
                    }

                    //for (int i = 0; i < Enemies.Length; i++)
                    //{
                    //    if (Enemies[i] != null)
                    //    {
                    //        EnemiesSpeedDataSaver[i] = Enemies[i].ReaperEnemySpeed;
                    //    }
                    //}


                }

                await Task.Delay(1);

            }
        }

        public async void ReloadEffect() // 2 seconds
        {
            if (CurrentLevel > 1 && Ammotation < 8 && ReloadCooldown == false) //cant in lvl 1 + no need if 10 bullets
            {
                ReloadCooldown = true;
                ReloadEffectPart1.Opacity = 100;
                ReloadEffectPart2.Opacity = 100;
                Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\Reload.wav", true);
                for (int i = 0; i < 130; i++) // 2 seconds effect
                {
                    Canvas.SetLeft(ReloadEffectPart1, Canvas.GetLeft(MainCharacter) + 10);
                    Canvas.SetTop(ReloadEffectPart1, Canvas.GetTop(MainCharacter) - 70);
                    Canvas.SetLeft(ReloadEffectPart2, Canvas.GetLeft(MainCharacter) + 24);
                    Canvas.SetTop(ReloadEffectPart2, Canvas.GetTop(MainCharacter) - 60);

                    RotateTransform rotation = new RotateTransform();
                    rotation.Angle = i;
                    rotation.CenterX = Canvas.GetLeft(ReloadEffectPart1) + ReloadEffectPart1.Width;
                    rotation.CenterY = Canvas.GetTop(ReloadEffectPart1) + ReloadEffectPart1.Height;
                    ReloadEffectPart1.LayoutTransform = rotation;

                    await Task.Delay(1); //wait for animation to finish, can be used thanks to async // 1 second cooldown to shoot

                }
                ReloadEffectPart1.Opacity = 0;
                ReloadEffectPart2.Opacity = 0;
                ReloadCooldown = false;
            }
        }

        public async void Spin() 
        {
            Spinbool = true;
            while (MainCharacterHp>0 && Spinbool==true)
            {
                for (int i = 0; i < 360; i++) // 6 seconds effect
                {


                    RotateTransform rotation = new RotateTransform();
                    rotation.Angle = i;
                    rotation.CenterX = Canvas.GetLeft(MainCharacter) + MainCharacter.Width;
                    rotation.CenterY = Canvas.GetTop(MainCharacter) + MainCharacter.Height;
                    rotation.CenterX = Canvas.GetLeft(StaticGun) + StaticGun.Width;
                    rotation.CenterY = Canvas.GetTop(StaticGun) + StaticGun.Height;
                    rotation.CenterX = Canvas.GetLeft(GunAnimation) + GunAnimation.Width;
                    rotation.CenterY = Canvas.GetTop(GunAnimation) + GunAnimation.Height;
                    rotation.CenterX = Canvas.GetLeft(TheBullet) + TheBullet.Width;
                    rotation.CenterY = Canvas.GetTop(TheBullet) + TheBullet.Height;
                    MainCharacter.LayoutTransform = rotation;
                    StaticGun.LayoutTransform = rotation;
                    GunAnimation.LayoutTransform = rotation;
                    TheBullet.LayoutTransform = rotation;


                    await Task.Delay(1); //wait for animation to finish, can be used thanks to async // 1 second cooldown to shoot

                }
            }
        }

        public void StopSpin() 
        {
            Spinbool = false;

        }
        public async void VulnerabilityEffect() // 2 seconds
        {
            Vulnerability = true;

            //cant shoot
            for (int i = 0; i < 5; i++)
            {

                for (int j = 0; j < 20; j++)
                {
                    MainCharacter.Opacity = MainCharacter.Opacity - 0.02;
                    await Task.Delay(3);

                }

                for (int j = 0; j < 20; j++)
                {
                    MainCharacter.Opacity = MainCharacter.Opacity + 0.02;
                    await Task.Delay(3);
                }
                await Task.Delay(10);

            }
            Vulnerability = false;

        }
        public async void BulletEffect() // 2 seconds
        {

            TheBullet.Opacity = 100;
            Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\GunShot.wav", true);
            if (RightDirection == true) //right
            {
                double Y = Canvas.GetTop(MainCharacter) + 100;  //getting value of Y for the rest of the array
                for (int i = 0; i < 30; i++) // 2 seconds effect
                {
                    Canvas.SetTop(TheBullet, Y); ;
                    Canvas.SetLeft(TheBullet, Canvas.GetLeft(TheBullet) + 50);
                    await Task.Delay(1); //moment wait

                }
            }

            else if (LeftDirection == true)//left
            {
                double Y = Canvas.GetTop(MainCharacter) + 100;  //getting value of Y for the rest of the array
                for (int i = 0; i < 30; i++) // 2 seconds effect
                {
                    Canvas.SetTop(TheBullet, Y); ;
                    Canvas.SetLeft(TheBullet, Canvas.GetLeft(TheBullet) - 50);
                    await Task.Delay(1); //moment wait

                }


            }

            TheBullet.Opacity = 0;
            Canvas.SetLeft(TheBullet, Canvas.GetLeft(StaticGun) - 10); //resseting bullet position
        }


        private async void GameTimerEvent(object sender, EventArgs e)
        {

            if (GoLeft == true && Canvas.GetLeft(MainCharacter) >= -5)
            {
                Canvas.SetLeft(MainCharacter, Canvas.GetLeft(MainCharacter) - speed);
                 Canvas.SetLeft(StaticGun, Canvas.GetLeft(StaticGun) - speed);
                Canvas.SetLeft(GunAnimation, Canvas.GetLeft(GunAnimation) - speed);
                Canvas.SetLeft(TheBullet, Canvas.GetLeft(TheBullet) - speed);


            }

            if (GoRight == true && Canvas.GetLeft(MainCharacter) + (MainCharacter.Width - 150) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(MainCharacter, Canvas.GetLeft(MainCharacter) + speed);
                Canvas.SetLeft(StaticGun, Canvas.GetLeft(StaticGun) + speed);
                Canvas.SetLeft(GunAnimation, Canvas.GetLeft(GunAnimation) + speed);
                Canvas.SetLeft(TheBullet, Canvas.GetLeft(TheBullet) + speed);

            }

            if (Shoot == true && ShootingCooldown == true)
            {
                DoAnimationShooting = false;

                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Gun\GunAnimation.gif");
                image.EndInit();
                ImageBehavior.SetAnimatedSource(GunAnimation, image);
                StaticGun.Opacity = 0;
                GunAnimation.Opacity = 100;
                await Task.Delay(300); //wait for animation to finish, and bullet shoot CD, can be used thanks to async
                StaticGun.Opacity = 100;
                GunAnimation.Opacity = 0;
                DoAnimationShooting = true;


                //shooting animation ocapiity = 100 png = 0 +effects on enemies if in right direction
            }
        }


        private async void KeyIsDown(object sender, KeyEventArgs e)
        {


            if ((e.Key == Key.Right || e.Key == Key.D) && DoAnimationRight == true && speed > 0)
            {
                RightDirection = true;
                LeftDirection = false;

                ScaleTransform FlipTransform = new ScaleTransform(); //crating a new transformable object
                FlipTransform.ScaleX = 1; //setting it to positive flipping
                StaticGun.RenderTransform = FlipTransform; //setting static gun to flip
                GunAnimation.RenderTransform = FlipTransform; //setting gun animation to flip
                TheBullet.RenderTransform = FlipTransform; //setting gun animation to flip

                CheckIfNextLevel();
                WalkingAnimation("right"); //using the animations from walking
                GoRight = true;

                if (DoAnimationRight == true)
                {
                    if (Image < 3)
                    {
                        Image = Image + 1;
                        MainCharacter.Fill = MainCharactersImages[Image];
                    }
                    else
                    {
                        Image = 0;
                        MainCharacter.Fill = MainCharactersImages[Image];
                    }
                    DoAnimationRight = false;
                }

                await Task.Delay(100); //wait for animation to finish, can be used thanks to async


                DoAnimationRight = true;


            }

            if ((e.Key == Key.Left || e.Key == Key.A) && DoAnimationLeft == true && speed > 0)
            {
                RightDirection = false;
                LeftDirection = true;

                ScaleTransform FlipTransform = new ScaleTransform(); //crating a new transformable object
                FlipTransform.ScaleX = -1; //setting it to negative flipping
                StaticGun.RenderTransform = FlipTransform; //setting static gun to flip
                GunAnimation.RenderTransform = FlipTransform; //setting gun animation to flip
                TheBullet.RenderTransform = FlipTransform; //setting gun animation to flip

                CheckIfNextLevel();
                WalkingAnimation("left"); //using the animations from walking
                GoLeft = true;

                if (DoAnimationLeft == true)
                {
                    if (Image < 3)
                    {
                        Image = Image + 1;
                        MainCharacter.Fill = MainCharactersImages[Image];
                    }
                    else
                    {
                        Image = 0;
                        MainCharacter.Fill = MainCharactersImages[Image];
                    }
                    DoAnimationLeft = false;

                }


                await Task.Delay(100); //wait for animation to finish, can be used thanks to async

                DoAnimationLeft = true;


            }

            if ((e.Key == Key.Up || e.Key == Key.W) && DoJump == true && speed > 0)
            {
                int lvl = CurrentLevel;
                DoJump = false;
                for (int i = 0; i < 50; i++) //up
                {
                    Canvas.SetTop(MainCharacter, Canvas.GetTop(MainCharacter) - 10);
                    Canvas.SetTop(StaticGun, Canvas.GetTop(StaticGun) - 10);
                    Canvas.SetTop(TheBullet, Canvas.GetTop(TheBullet) - 10);
                    Canvas.SetTop(GunAnimation, Canvas.GetTop(GunAnimation) - 10);
                    await Task.Delay(10); //jump wait
                    if (CurrentLevel != lvl) //if moved to next lvl stop jump
                    {
                        i = 50;
                    }
                }
                for (int i = 0; i < 50; i++) // down
                {
                    Canvas.SetTop(MainCharacter, Canvas.GetTop(MainCharacter) + 10);
                    Canvas.SetTop(StaticGun, Canvas.GetTop(StaticGun) + 10);
                    Canvas.SetTop(TheBullet, Canvas.GetTop(TheBullet) + 10);
                    Canvas.SetTop(GunAnimation, Canvas.GetTop(GunAnimation) + 10);
                    await Task.Delay(10); //jump wait
                    if (CurrentLevel != lvl) //if moved to next lvl stop jump
                    {
                        i = 50;
                    }
                }
                DoJump = true;

            }


            if (e.Key == Key.Space && ShootingCooldown == false && CurrentLevel > 1 && Ammotation > 0 && DoAnimationShooting == true && speed > 0)
            {
                //if (Vulnerability == false)
                //{
                    ShootingCooldown = true;
                    Ammotation = Ammotation - 1; //minus one bullet
                    AmmoBarXaml.Fill = AmmoBarAnimation(Ammotation); //setting ammo animation based on ammutation in magazine rn
                    Shoot = true;
                    BulletEffect();
                    await Task.Delay(500); //wait for animation to finish, can be used thanks to async // 1.5 second cooldown to shoot
                    ShootingCooldown = false;
                    //add events of shooting
                //}
            }

            if (e.Key == Key.R && Ammotation<8 && speed > 0)
            {
                Ammotation = 0; // cant shoot while reloading
                Reload = true;
                ReloadEffect(); //doing the roload effect
                await Task.Delay(2000); // 2 seconds effect
                Ammotation = 8;
                AmmoBarXaml.Fill = AmmoBarAnimation(Ammotation); //setting ammo animation to full after reloading


            }

            if (e.Key == Key.M)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (Enemies[i] != null)
                    {

                        Enemies[i].Hp = 0;

                    }
                }

                Skip = true;
                CheckIfNextLevel();

            }

            
            if (e.Key == Key.Escape)
            {
                if (Menu == false)
                {
                    Menu = true;

                }
                else
                {
                    Menu = false;

                }

            }


        }








        private void KeyIsUp(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Right || e.Key == Key.D)
            {
                GoRight = false;

            }

            if (e.Key == Key.Left || e.Key == Key.A)
            {
                GoLeft = false;
            }

            if (e.Key == Key.Up || e.Key == Key.W)
            {
                Jump = false;
            }

            if (e.Key == Key.Space)
            {
                Shoot = false;
            }

            if (e.Key == Key.R)
            {
                Reload = false;
            }

            if (e.Key == Key.M) //level skip
            {
                Skip = false;
            }

            if (e.Key == Key.Escape)
            {
               // Menu = false;
            }

        }

        private void MainCharacter_TouchDown(object sender, TouchEventArgs e) // needs to exist empty for some reason
        {

        }

        private void Rectangle_KeyDown(object sender, KeyEventArgs e) // needs to exist empty for some reason
        {
            //if (e.Key == Key.Right || e.Key == Key.D)
            //{
            //    GoRight = true;
            //}

            //if (e.Key == Key.Left || e.Key == Key.A)
            //{
            //    GoLeft = true;
            //}
        }
    }
}
