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
    public partial class MainWindow : Window //Level Editor
    {
        public async void LevelConditions(int level) //sets conditions needed to level, like character size and location
        {

            if (level == 1)
            {
                Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\NiceMusic1.wav", true);
                Canvas.SetLeft(MainCharacter, 0);
                MainCharactersImages[0] = new ImageBrush(new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\MainCharacterA\RightWalk1.png")));
                MainCharacter.Fill = MainCharactersImages[0];
                Skip = false;

                MainScreenPicture.Opacity = 100;
                MainScreenPicture.Fill = JumpScaresPictures(7);
                Text(9, true);   
                Text(9, false);   
                for (int i = 0; i < 100; i++)
                {
                    TextBarXaml.Opacity = TextBarXaml.Opacity + 0.01;

                    await Task.Delay(10);

                }
                for (int i = 0; i < 100; i++)
                {
                    TextBarXaml.Opacity = TextBarXaml.Opacity - 0.01;
                    await Task.Delay(10);

                }
                await Task.Delay(500);
                MainScreenPicture.Opacity = 0;
            }
            if (level == 2) //in this level set new size for the rest of the game.
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                StaticGun.Opacity = 100;
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                //Enemies[] Enemies = new Enemies[10];

                //Enemies Enemy1 = new Enemies(1, "ReaperEnemy", 1500,3);
                //Enemies Enemy2 = new Enemies(2, "ReaperEnemy", 1800,3);
                if(Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", 1800, 3, 2);


                }

                //Enemies[0] = Enemy1;
                //Enemies[1] = Enemy2;
                Skip = false;
            }
            if (level == 3)
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", -1000, 3, 2);
                    SetUpEnemy(2, "ReaperEnemy", 2000, 3, 2);
                    SetUpEnemy(3, "BrainEnemy", 1000, 1, 3);
                }
                Skip = false;

            }
            if (level == 4)
            {

                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", -200, 3, 2);
                    SetUpEnemy(2, "GhostEnemy", 1000, 2, 2);
                    SetUpEnemy(3, "ReaperEnemy", 1900, 3, 2);
                    SetUpEnemy(4, "BrainEnemy", 1200, 1, 3);
                }
                while (MainCharacterHp > 0 && Boss1Bool == true) //if character alive + boss still not proc'd
                {
                    ScreenEffectBoss1(); 
                    await Task.Delay(100); //wait for boss to appear
                }               


                Skip = false;

            }

            if (level == 5)
            {
                ReaperSpeedBoost = ReaperSpeedBoost + 1;
                GhostSpeedBoost = ReaperSpeedBoost + 1;
                BrainSpeedBoost = ReaperSpeedBoost + 1;

                Boss1Bool = false; //in case i skipped
                ResetEnemies();
                Set_Background(CurrentLevel);
                DarknessScreen.Opacity = DarknessScreen.Opacity+0.3;
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;


                if (Skip == false)
                {
                    SetUpEnemy(1, "GhostEnemy", 1000, 2, 3);
                    SetUpEnemy(2, "ReaperEnemy", 1200, 3, 3);
                    SetUpEnemy(3, "ReaperEnemy", -1000, 3, 3);
                    SetUpEnemy(4, "BrainEnemy", 50, 1, 4);
                    SetUpEnemy(5, "BrainEnemy", 1050, 1, 4);
                }

                Skip = false;
            }
            if (level == 6)
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "GhostEnemy", 1000, 2, 3);
                    SetUpEnemy(2, "ReaperEnemy", 1200, 3, 3);
                    SetUpEnemy(3, "ReaperEnemy", -1000, 3, 3);
                    SetUpEnemy(4, "BrainEnemy", 0, 1, 4);
                    SetUpEnemy(5, "BrainEnemy", 1700, 1, 4);
                    SetUpEnemy(6, "ReaperEnemy", 1900, 3, 3);

                }

                Skip = false;
            }
            if (level == 7)
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "GhostEnemy", 700, 2, 3);
                    SetUpEnemy(2, "ReaperEnemy", -1000, 3, 3);
                    SetUpEnemy(3, "ReaperEnemy", 1500, 3, 3);
                    SetUpEnemy(4, "BrainEnemy", 600, 1, 4);
                    SetUpEnemy(5, "BrainEnemy", 1200, 1, 4);
                    SetUpEnemy(6, "ReaperEnemy", 2500, 3, 3);
                    SetUpEnemy(7, "ReaperEnemy", -1500, 3, 3);

                }

                Skip = false;
                DecisionMade = false; // reseting for next boss
            }
            if (level == 8)
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", 400, 3, 3);
                    SetUpEnemy(2, "ReaperEnemy", 800, 3, 3);
                    SetUpEnemy(3, "ReaperEnemy", 1200, 3, 3);
                    SetUpEnemy(4, "BrainEnemy", 500, 1, 4);
                    SetUpEnemy(5, "BrainEnemy", 1000, 1, 4);
                    SetUpEnemy(6, "ReaperEnemy", 1600, 3, 3);
                    SetUpEnemy(7, "GhostEnemy", -1000, 2, 3);
                    SetUpEnemy(8, "GhostEnemy", 2800, 2, 3);
                }

                while (MainCharacterHp > 0 && Boss2Bool == true) //if character alive + boss still not proc'd    
                {
                    ScreenEffectBoss2(); 
                    await Task.Delay(100); //wait for boss to appear
                }

                Skip = false;
            }
            if (level == 9)
            {
                ReaperSpeedBoost = ReaperSpeedBoost + 1;
                GhostSpeedBoost = ReaperSpeedBoost + 1;
                BrainSpeedBoost = ReaperSpeedBoost + 2;

                Boss2Bool = false; //in case i skipped
                ResetEnemies();
                Set_Background(CurrentLevel);
                DarknessScreen.Opacity = DarknessScreen.Opacity + 0.3;
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", -400, 3, 4);
                    SetUpEnemy(2, "ReaperEnemy", 800, 3, 4);
                    SetUpEnemy(3, "ReaperEnemy", 1200, 3, 4);
                    SetUpEnemy(4, "BrainEnemy", 600, 1, 6);
                    SetUpEnemy(5, "BrainEnemy", -800, 1, 6);
                    SetUpEnemy(6, "ReaperEnemy", 1600, 3, 4);
                    SetUpEnemy(7, "GhostEnemy", -400, 2, 4);
                    SetUpEnemy(8, "GhostEnemy", 800, 2, 4);
                    SetUpEnemy(9, "GhostEnemy", -1000, 2, 4);
                }

                Skip = false;
            }
            if (level == 10)
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", 300, 3, 4);
                    SetUpEnemy(2, "ReaperEnemy", 450, 3, 4);
                    SetUpEnemy(3, "ReaperEnemy", 1200, 3, 4);
                    SetUpEnemy(4, "BrainEnemy", 500, 1, 6);
                    SetUpEnemy(5, "BrainEnemy", -1000, 1, 6);
                    SetUpEnemy(6, "ReaperEnemy", -1000, 3, 4);
                    SetUpEnemy(7, "GhostEnemy", -1000, 2, 4);
                    SetUpEnemy(8, "GhostEnemy", 1500, 2, 4);
                    SetUpEnemy(9, "GhostEnemy", -1000, 2, 4);
                    SetUpEnemy(10, "BrainEnemy", 1500, 1, 6);
                }

                Skip = false;
            }
            if (level == 11)
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", -1700, 3, 4);
                    SetUpEnemy(2, "ReaperEnemy", 1600, 3, 4);
                    SetUpEnemy(3, "ReaperEnemy", 500, 3, 4);
                    SetUpEnemy(4, "BrainEnemy", 5000, 1, 6);
                    SetUpEnemy(5, "BrainEnemy", -2000, 1, 6);
                    SetUpEnemy(6, "ReaperEnemy", 900, 3, 4);
                    SetUpEnemy(7, "GhostEnemy", 500, 2, 4);
                    SetUpEnemy(8, "GhostEnemy", 1500, 2, 4);
                    SetUpEnemy(9, "GhostEnemy", -500, 2, 4);
                    SetUpEnemy(10, "BrainEnemy", 1500, 1, 6);
                    SetUpEnemy(11, "ReaperEnemy", -500, 3, 4);

                }
                Skip = false;
                DecisionMade = false; // reseting for next boss
            }
            if (level == 12)
            {
                ResetEnemies();
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                if (Skip == false)
                {
                    SetUpEnemy(1, "ReaperEnemy", 200, 3, 4);
                    SetUpEnemy(2, "ReaperEnemy", 800, 3, 4);
                    SetUpEnemy(3, "ReaperEnemy", 4000, 3, 4);
                    SetUpEnemy(4, "BrainEnemy", 0, 1, 6);
                    SetUpEnemy(5, "BrainEnemy", 4000, 1, 6);
                    SetUpEnemy(6, "ReaperEnemy", 1600, 3, 4);
                    SetUpEnemy(7, "GhostEnemy", 0, 2, 4);
                    SetUpEnemy(8, "GhostEnemy", -1000, 2, 4);
                    SetUpEnemy(9, "GhostEnemy", 200, 2, 4);
                    SetUpEnemy(10, "ReaperEnemy", -200, 3, 4);
                    SetUpEnemy(11, "ReaperEnemy", -2000, 3, 4);
                    SetUpEnemy(12, "ReaperEnemy", -3000, 3, 4);


                }

                while (MainCharacterHp > 0 && Boss3Bool == true) //if character alive + boss still not proc'd    
                {
                    ScreenEffectBoss3();
                    await Task.Delay(100); //wait for boss to appear
                }

                Skip = false;
            }

            if (level == 13)
            {
                Song3Play = false;
                Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\HorrorSoundsDisortionLong.wav", true);


                Boss3Bool = false; //in case i skipped
                Set_Background(CurrentLevel);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;

                Spin();

                Skip = false;
            }

            if (level == 14)
            {
                Set_Background(CurrentLevel-1);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;


                Skip = false;
            }

            if (level == 15)
            {
                Set_Background(CurrentLevel-2);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;


                Skip = false;
            }

            if (level == 16)
            {
                Set_Background(CurrentLevel-3);
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;


                Skip = false;
            }

            if (level == 17)
            {
                Song5Play = false;
                Play(AppDomain.CurrentDomain.BaseDirectory + @"Sounds\GatesToHeaven.wav", true);
                StopSpin();
                Ending5();
                DarknessScreen.Opacity = DarknessScreen.Opacity -0.6;
                var image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\Backgrounds\Ending5.gif");
                image.EndInit();
                ImageBehavior.SetAnimatedSource(MainScreenPictureGif, image);
                MainScreenPictureGif.Opacity = 100;
           //     MainCharacter
                //nice background
                Canvas.SetLeft(StaticGun, 29);
                Canvas.SetTop(StaticGun, 843);
                Canvas.SetLeft(TheBullet, 80);
                Canvas.SetTop(TheBullet, 843);
                Canvas.SetLeft(GunAnimation, 34);
                Canvas.SetTop(GunAnimation, 825);
                Canvas.SetLeft(MainCharacter, 0);
                Canvas.SetTop(MainCharacter, 750);
                MainCharacter.Width = 100;
                MainCharacter.Height = 200;
                // after getting to middle of map main character looks at you
                //cant move or do anything
                //say something
                //game end

                Skip = false;
            }


        }

        public void CheckIfNextLevel() // if gets to right border, go to next level + set position to left
        {           

            if (CurrentLevel == 1)
            {
                if (Canvas.GetLeft(MainCharacter) >= 1920 -200 && KillCondition() == true) //right side of window //when big
                {
                    NextLevel();
                }
            }

            else if (CurrentLevel == 4 || CurrentLevel == 8 || CurrentLevel == 12)
            {
                if (Canvas.GetLeft(MainCharacter) >= 1920 -120 && KillCondition() == true && DecisionMade == true) // + if desicion about boss made
                {
                    NextLevel();
                }
            }
            else if (CurrentLevel > 1)
            {
                if (Canvas.GetLeft(MainCharacter) >= 1920 -120 && KillCondition() == true) //right side of window // when small
                {
                    NextLevel();
                }
            }

            if(Skip == true) //Level skipping
            {
                NextLevel();
            }


        }

        public void NextLevel() // get to next level in order
        {
            CurrentLevel++; //adding +1 to level
            LevelConditions(CurrentLevel);
            MainCharacterHp = 3;
            HpBarXaml.Fill = HealthBarAnimation(MainCharacterHp);

        }

        public bool KillCondition() // gets the hp value of all enemies
        {
            if (CurrentLevel > 1)
            {


                bool AllDeath = false; //checks if all dead
                int checker = 0;
                //  LevelConditions(CurrentLevel);
                for (int i = 0; i < Enemies.Length; i++)
                {
                    if (Enemies[i] == null)
                    {
                        checker++;

                    }
                    else if (Enemies[i] != null)
                    {
                        if (Enemies[i].Hp == 0)
                        {
                            checker++;
                        }
                    }
                }
                if (checker == 13)
                {
                    AllDeath = true;
                }
                return AllDeath;

            }
            else
            {
                return true;
            }

        }




    }
}
