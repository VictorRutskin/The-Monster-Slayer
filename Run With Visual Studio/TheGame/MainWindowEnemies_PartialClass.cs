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
    public partial class MainWindow : Window  //All About Enemies
    {
        // public int ReaperEnemySpeed = 20; // speed of Reaper
        //   public bool[] Enemies = new bool[10]; // need to make an array that keeps all the data of each enemy

        Enemies[] EnemiesArray;

        public MainWindow(Enemies[] EnemiesArray) //setting value
        {
            this.EnemiesArray = EnemiesArray;
        }

        public async void SetUpEnemy(int id, string name, int location, int Hp, int ReaperEnemySpeed)
        {

            int LocalEnemyCount = EnemiesCount;
            EnemiesCount++;
            Enemies EnemyData = new Enemies(id, name, location, Hp, ReaperEnemySpeed);
            Image[] Enemy = new Image[13]; //setting new type of array of image type
            //setting all images (objects)
            Enemy[0] = ReaperEnemy;
            Enemy[1] = ReaperEnemy2;
            Enemy[2] = ReaperEnemy3;
            Enemy[3] = ReaperEnemy4;
            Enemy[4] = ReaperEnemy5;
            Enemy[5] = ReaperEnemy6;
            Enemy[6] = ReaperEnemy7;
            Enemy[7] = ReaperEnemy8;
            Enemy[8] = ReaperEnemy9;
            Enemy[9] = ReaperEnemy10;
            Enemy[10] = ReaperEnemy11;
            Enemy[11] = ReaperEnemy12;
            Enemy[12] = ReaperEnemy13;


            for (int i = 0; i < EnemiesArray.Length; i++)
            {
                if (Enemies[i] == null)
                {
                    Enemies[i] = EnemyData;
                    LocalEnemyCount = i;
                    i = EnemiesArray.Length;

                }
            }

            if (Enemies[LocalEnemyCount].Name == "GhostEnemy")
            {
                bool CanDamage = true;
                bool HpReduced = false;
                bool MainCharacterHpReduced = false;
                bool LeftCorner = false;
                bool TopBorder = false;

                var image1 = new BitmapImage();
                image1.BeginInit();
                image1.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\GhostEnemy\GhostAnimation.gif");
                image1.EndInit();


                ImageBehavior.SetAnimatedSource(Enemy[LocalEnemyCount], image1);
                Canvas.SetLeft(Enemy[LocalEnemyCount], location);
                Canvas.SetTop(Enemy[LocalEnemyCount], 270);


                while (Enemies[LocalEnemyCount].Hp > 0)  // ORIGINAL REAPER CODE
                {

                    ScaleTransform FlipTransformRight = new ScaleTransform(); //crating a new transformable object
                    ScaleTransform FlipTransformLeft = new ScaleTransform(); //crating a new transformable object
                    FlipTransformRight.ScaleX = 1; //setting it to positive flipping
                    FlipTransformLeft.ScaleX = -1; //setting it to positive flipping

                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) < System.Windows.SystemParameters.PrimaryScreenWidth - System.Windows.SystemParameters.PrimaryScreenWidth) //x
                    {
                        LeftCorner = true;
                    }
                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) > System.Windows.SystemParameters.PrimaryScreenWidth - 200) //x
                    {
                        LeftCorner = false;
                    }
                    if (LeftCorner == false) //X
                    {
                        Canvas.SetLeft(Enemy[LocalEnemyCount], Canvas.GetLeft(Enemy[LocalEnemyCount]) - (GhostSpeed + GhostSpeedBoost));
                        Enemy[LocalEnemyCount].RenderTransform = FlipTransformLeft;
                        await Task.Delay(10);
                    }
                    else //x
                    {
                        Canvas.SetLeft(Enemy[LocalEnemyCount], Canvas.GetLeft(Enemy[LocalEnemyCount]) + (GhostSpeed + GhostSpeedBoost));
                        Enemy[LocalEnemyCount].RenderTransform = FlipTransformRight;

                        await Task.Delay(10);
                    }

                    if (Canvas.GetTop(Enemy[LocalEnemyCount]) < 0) //y
                    {
                        TopBorder = true;
                    }
                    if (Canvas.GetTop(Enemy[LocalEnemyCount]) > 800) //y
                    {
                        TopBorder = false;
                    }

                    if (TopBorder == false) //y
                    {
                        Canvas.SetTop(Enemy[LocalEnemyCount], Canvas.GetTop(Enemy[LocalEnemyCount]) - (GhostSpeed + GhostSpeedBoost));
                        await Task.Delay(10);
                    }
                    else //y
                    {
                        Canvas.SetTop(Enemy[LocalEnemyCount], Canvas.GetTop(Enemy[LocalEnemyCount]) + (GhostSpeed + GhostSpeedBoost));

                        await Task.Delay(10);
                    }


                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) > -300 && Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) < -50 &&
                            Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) > -200 && Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) < 20 &&
                            TheBullet.Opacity == 100 && HpReduced == false) // if nearX+Y+bullet visble + no shoot CD
                    {
                        HpReduced = true;
                        Enemies[LocalEnemyCount].Hp--;
                        TheBullet.Opacity = 0;
                        await Task.Delay(1000); //0.5second before damaging again
                        HpReduced = false;
                    }


                    if (Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) > 50 && Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) < 250 &&
                        Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) > -200 && Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) < 200 &&
                        Enemies[LocalEnemyCount].Hp > 0 && MainCharacterHpReduced == false && speed > 0) // if nearX+Y+enemy has hp + hp redution CD
                    {
                        MainCharacterHpReduced = true;
                        if (MainCharacterHp > 1 && Vulnerability == false)
                        {
                            if (Vulnerability == false)
                            {
                                MainCharacterHp--;
                            }
                            VulnerabilityEffect();
                        }
                        else if (MainCharacterHp == 1)
                        {
                            if (Vulnerability == false)
                            {
                                Ending1();
                            }
                        }
                        HpBarXaml.Fill = HealthBarAnimation(MainCharacterHp);
                        await Task.Delay(1000); //second before damaging again
                        MainCharacterHpReduced = false;
                    }



                }

                if (Enemies[LocalEnemyCount].Hp == 0)
                {
                    await Task.Delay(1);
                    CanDamage = false;
                    Enemy[LocalEnemyCount].Opacity = 0;

                }

            }
            //
            if (Enemies[LocalEnemyCount].Name == "BrainEnemy")
            {
                bool CanDamage = true;
                bool HpReduced = false;
                bool MainCharacterHpReduced = false;
                bool LeftCorner = false;

                var image1 = new BitmapImage();
                image1.BeginInit();
                image1.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\BrainEnemy\BrainEnemyAnimation.gif");
                image1.EndInit();


                ImageBehavior.SetAnimatedSource(Enemy[LocalEnemyCount], image1);
                Canvas.SetLeft(Enemy[LocalEnemyCount], location);
                Canvas.SetTop(Enemy[LocalEnemyCount], 270);


                while (Enemies[LocalEnemyCount].Hp > 0)  // ORIGINAL REAPER CODE
                {
                    ScaleTransform FlipTransformRight = new ScaleTransform(); //crating a new transformable object
                    ScaleTransform FlipTransformLeft = new ScaleTransform(); //crating a new transformable object
                    FlipTransformRight.ScaleX = 1; //setting it to positive flipping
                    FlipTransformLeft.ScaleX = -1; //setting it to positive flipping

                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) < System.Windows.SystemParameters.PrimaryScreenWidth - System.Windows.SystemParameters.PrimaryScreenWidth)
                    {
                        LeftCorner = true;
                    }
                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) > System.Windows.SystemParameters.PrimaryScreenWidth - 200)
                    {
                        LeftCorner = false;
                    }
                    if (LeftCorner == false)
                    {
                        Canvas.SetLeft(Enemy[LocalEnemyCount], Canvas.GetLeft(Enemy[LocalEnemyCount]) - (BrainSpeed + BrainSpeedBoost));
                        Enemy[LocalEnemyCount].RenderTransform = FlipTransformLeft; //setting gun animation to flip
                        await Task.Delay(10);
                    }
                    else
                    {
                        Canvas.SetLeft(Enemy[LocalEnemyCount], Canvas.GetLeft(Enemy[LocalEnemyCount]) + (BrainSpeed + BrainSpeedBoost));
                        Enemy[LocalEnemyCount].RenderTransform = FlipTransformRight; //setting gun animation to flip

                        await Task.Delay(10);
                    }


                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) > -200 && Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) < 0 &&
                            Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) > -200 && Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) < 20 &&
                            TheBullet.Opacity == 100 && HpReduced == false) // if nearX+Y+bullet visble + no shoot CD
                    {
                        HpReduced = true;
                        Enemies[LocalEnemyCount].Hp--;
                        TheBullet.Opacity = 0;
                        await Task.Delay(500); //0.5second before damaging again
                        HpReduced = false;
                    }


                    if (Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) > -100 && Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) < 250 &&
                        Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) > -200 && Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) < 150 &&
                        Enemies[LocalEnemyCount].Hp > 0 && MainCharacterHpReduced == false && speed > 0) // if nearX+Y+enemy has hp + hp redution CD
                    {
                        MainCharacterHpReduced = true;
                        if (MainCharacterHp > 1 && Vulnerability == false)
                        {

                            if (Vulnerability == false)
                            {
                                MainCharacterHp--;
                            }
                            VulnerabilityEffect();
                        }
                        else if (MainCharacterHp == 1)
                        {
                            if (Vulnerability == false)
                            {
                                Ending1();
                            }
                        }
                        HpBarXaml.Fill = HealthBarAnimation(MainCharacterHp);
                        await Task.Delay(1000); //second before damaging again
                        MainCharacterHpReduced = false;
                    }



                }

                if (Enemies[LocalEnemyCount].Hp == 0)
                {
                    CanDamage = false;
                    Enemy[LocalEnemyCount].Opacity = 0;

                }

            }

            else if (Enemies[LocalEnemyCount].Name == "ReaperEnemy")
            {
                bool CanDamage = true;
                bool HpReduced = false;
                bool MainCharacterHpReduced = false;


                var image1 = new BitmapImage();
                image1.BeginInit();
                image1.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\ReaperEnemy\ReaperEnemyWalk.gif");
                image1.EndInit();

                var image2 = new BitmapImage();
                image2.BeginInit();
                image2.UriSource = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PNG\ReaperEnemy\ReaperEnemyAttack.gif");
                image2.EndInit();

                ImageBehavior.SetAnimatedSource(Enemy[LocalEnemyCount], image1);
                Canvas.SetLeft(Enemy[LocalEnemyCount], location);
                Canvas.SetTop(Enemy[LocalEnemyCount], 758);



                while (Enemies[LocalEnemyCount].Hp > 0)
                {
                    ScaleTransform FlipTransformRight = new ScaleTransform(); //crating a new transformable object
                    ScaleTransform FlipTransformLeft = new ScaleTransform(); //crating a new transformable object
                    FlipTransformRight.ScaleX = 1; //setting it to positive flipping
                    FlipTransformLeft.ScaleX = -1; //setting it to positive flipping

                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) > Canvas.GetLeft(MainCharacter))
                    {
                        Canvas.SetLeft(Enemy[LocalEnemyCount], Canvas.GetLeft(Enemy[LocalEnemyCount]) - (ReaperSpeed + ReaperSpeedBoost));
                        Enemy[LocalEnemyCount].RenderTransform = FlipTransformLeft; //setting gun animation to flip
                        await Task.Delay(10);
                    }
                    else
                    {
                        Canvas.SetLeft(Enemy[LocalEnemyCount], Canvas.GetLeft(Enemy[LocalEnemyCount]) + (ReaperSpeed + ReaperSpeedBoost));
                        Enemy[LocalEnemyCount].RenderTransform = FlipTransformRight; //setting gun animation to flip

                        await Task.Delay(10);
                    }


                    if (Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) > -200 && Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) < 0 &&
                        Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) > -200 && Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) < 20 &&
                        TheBullet.Opacity == 100 && HpReduced == false ) // if nearX+Y+bullet visble + no shoot CD
                    {
                        HpReduced = true;
                        Enemies[LocalEnemyCount].Hp--;
                        TheBullet.Opacity = 0;
                        await Task.Delay(500); //0.5second before damaging again
                        HpReduced = false;
                    }


                    if (Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) > -80 && Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) < 200 &&
                       Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) > -200 && Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) < 20 &&
                       Enemies[LocalEnemyCount].Hp > 0 && MainCharacterHpReduced == false && speed > 0) // if nearX+Y+enemy has hp + hp redution CD
                    {
                        ImageBehavior.SetAnimatedSource(Enemy[LocalEnemyCount], image2);

                        for (int i = 0; i < 25; i++)
                        {
                            if (Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) > -200 && Canvas.GetLeft(Enemy[LocalEnemyCount]) - Canvas.GetLeft(TheBullet) < 0 &&
                           Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) > -200 && Canvas.GetTop(Enemy[LocalEnemyCount]) - Canvas.GetTop(TheBullet) < 20 &&
                           TheBullet.Opacity == 100 && HpReduced == false) // if nearX+Y+bullet visble + no shoot CD
                            {
                                i = 25;

                                HpReduced = true;
                                Enemies[LocalEnemyCount].Hp--;
                                TheBullet.Opacity = 0;
                                await Task.Delay(500); //0.5second before damaging again
                                HpReduced = false;

                            }
                            await Task.Delay(1); //moment before damage
                        }

                        if (Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) > -80 && Canvas.GetLeft(MainCharacter) - Canvas.GetLeft(Enemy[LocalEnemyCount]) < 200 &&
                            Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) > -200 && Canvas.GetTop(MainCharacter) - Canvas.GetTop(Enemy[LocalEnemyCount]) < 20 &&
                            Enemies[LocalEnemyCount].Hp > 0 && MainCharacterHpReduced == false) // if nearX+Y+enemy has hp + hp redution CD
                        {
                            MainCharacterHpReduced = true;
                            if (MainCharacterHp > 1 && Vulnerability == false)
                            {
                                if (Vulnerability == false)
                                {
                                    MainCharacterHp--;
                                }
                                VulnerabilityEffect();
                            }
                            else if (MainCharacterHp == 1)
                            {
                                if (Vulnerability == false)
                                {
                                    Ending1();
                                }
                            }
                            HpBarXaml.Fill = HealthBarAnimation(MainCharacterHp);
                            await Task.Delay(1000); //second before damaging again
                            ImageBehavior.SetAnimatedSource(Enemy[LocalEnemyCount], image1);
                            MainCharacterHpReduced = false;
                        }
                        else
                        {
                            ImageBehavior.SetAnimatedSource(Enemy[LocalEnemyCount], image1);
                        }



                    }

                    if (Enemies[LocalEnemyCount].Hp == 0)
                    {
                        CanDamage = false;
                        Enemy[LocalEnemyCount].Opacity = 0;

                    }


                }

            }


        }



        public void ResetEnemies() // resets all enemy value
        {
            bool check = false; //checking if should do the reset or not

            for (int i = 0; i < Enemies.Length; i++)
            {
                if (Enemies[i] != null)
                {
                    check = true;
                    i = Enemies.Length;
                }
            }
            if (check == true)
            {
                for (int i = 0; i < Enemies.Length; i++)
                {
                    Enemies[i] = null;
                    ReaperEnemy.Opacity = 100;
                    ReaperEnemy2.Opacity = 100;
                    ReaperEnemy3.Opacity = 100;
                    ReaperEnemy4.Opacity = 100;
                    ReaperEnemy5.Opacity = 100;
                    ReaperEnemy6.Opacity = 100;
                    ReaperEnemy7.Opacity = 100;
                    ReaperEnemy8.Opacity = 100;
                    ReaperEnemy9.Opacity = 100;
                    ReaperEnemy10.Opacity = 100;
                    ReaperEnemy11.Opacity = 100;
                    ReaperEnemy12.Opacity = 100;
                    ReaperEnemy13.Opacity = 100;
                    EnemiesCount = 0;
                }
            }

        }
    }


    public class Enemies  //All About Enemies
    {

        public int Id { get; set; } //  id of enemy
        public string Name { get; set; } // name of enemy
        public int Location { get; set; } // location of enemy
        public int Hp { get; set; } // Enemy HP
        public int ReaperEnemySpeed { get; set; } //enemy speed
        public Enemies(int id, string name, int location, int hp, int reaperEnemySpeed)
        {
            this.Id = id;
            this.Name = name;
            this.Location = location;
            this.Hp = hp;
            this.ReaperEnemySpeed = reaperEnemySpeed;

        }
    }

}
