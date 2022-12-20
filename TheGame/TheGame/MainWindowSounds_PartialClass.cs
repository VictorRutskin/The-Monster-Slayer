using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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
    public partial class MainWindow : Window //Sounds
    {

        public async void Play(string audioPath, bool play)
        {
            await Task.Delay(1);
            MediaPlayer myPlayer = new MediaPlayer();
            myPlayer.Open(new System.Uri(audioPath));

            if (play == true)
            {
                if (audioPath == AppDomain.CurrentDomain.BaseDirectory + @"Sounds\GatesToHeaven.wav")
                {

                    myPlayer.Play();
                    await Task.Delay(1);

                    while (MainCharacterHp > 0 && Song4Play == true)
                    {
                        while (Song4Play == true)
                        {
                            bool playornot = true;
                            for (int i = 0; i < 2400; i++)
                            {

                                await Task.Delay(1);
                                if (Song4Play == false)
                                {
                                    playornot = false;
                                    i = 2400;
                                    break;
                                }
                            }
                            if (playornot == true)
                            {
                                myPlayer.Open(new System.Uri(audioPath));

                                myPlayer.Play();
                            }

                            if (playornot == false)
                            {
                                myPlayer.Stop();

                            }



                        }

                    }

                   
                }


                else if (audioPath == AppDomain.CurrentDomain.BaseDirectory + @"Sounds\HorrorSoundsDisortionLong.wav")
                {
                    myPlayer.Play();
                    await Task.Delay(1);

                    while (MainCharacterHp > 0 && Song5Play == true)
                    {
                        while (Song5Play == true)
                        {
                            bool playornot = true;
                            for (int i = 0; i < 1200; i++)
                            {

                                await Task.Delay(1);
                                if (Song5Play == false)
                                {
                                    playornot = false;
                                    i = 1200;
                                    break;
                                }
                            }
                            if (playornot == true)
                            {
                                myPlayer.Open(new System.Uri(audioPath));

                                myPlayer.Play();
                            }

                            if (playornot == false)
                            {
                                myPlayer.Stop();

                            }



                        }

                    }

                }
                else if (audioPath == AppDomain.CurrentDomain.BaseDirectory + @"Sounds\ScaryMusic.wav")
                {
                    myPlayer.Play();
                    await Task.Delay(1);

                    while (MainCharacterHp > 0 && Song3Play == true)
                    {
                        while (Song3Play == true)
                        {
                            bool playornot = true;
                            for (int i = 0; i < 15000; i++)
                            {

                                await Task.Delay(1);
                                if (Song3Play == false)
                                {
                                    playornot = false;
                                    i = 15000;
                                    break;
                                }
                            }
                            if (playornot == true)
                            {
                                myPlayer.Open(new System.Uri(audioPath));

                                myPlayer.Play();
                            }

                            if (playornot == false)
                            {
                                myPlayer.Stop();

                            }



                        }

                    }

                }
                else if (audioPath == AppDomain.CurrentDomain.BaseDirectory + @"Sounds\NiceMusic1.wav")
                {

                        myPlayer.Play();
                        await Task.Delay(1);
                    

                    while (MainCharacterHp > 0 && Song1Play ==true)
                    {
                        while (Song1Play == true)
                        {
                            bool playornot = true;
                            for(int i = 0; i < 14000; i++)
                            {

                                await Task.Delay(1);
                                if (Song1Play == false)
                                {
                                    playornot = false;
                                    i = 14000;
                                    break;
                                }
                            }
                            if(playornot == true)
                            {
                                myPlayer.Open(new System.Uri(audioPath));

                                myPlayer.Play();
                            }

                            if (playornot == false)
                            {
                                myPlayer.Stop();

                            }



                        }

                    }

                }
                else if (audioPath == AppDomain.CurrentDomain.BaseDirectory + @"Sounds\MediumMusic.wav")
                {
                    myPlayer.Play();
                    await Task.Delay(1);

                    while (MainCharacterHp > 0 && Song2Play == true)
                    {
                        while (Song2Play == true)
                        {
                            bool playornot = true;
                            for (int i = 0; i < 8000; i++)
                            {

                                await Task.Delay(1);
                                if (Song2Play == false)
                                {
                                    playornot = false;
                                    i = 8000;
                                    break;
                                }
                            }
                            if (playornot == true)
                            {
                                myPlayer.Open(new System.Uri(audioPath));

                                myPlayer.Play();
                            }

                            if (playornot == false)
                            {
                                myPlayer.Stop();

                            }



                        }

                    }

                }

                else if (audioPath == AppDomain.CurrentDomain.BaseDirectory + @"Sounds\scaryviolin.wav")
                {
                    myPlayer.Play();
                    await Task.Delay(1);

                    while (MainCharacterHp > 0 && Song6Play == true)
                    {
                        while (Song6Play == true)
                        {
                            bool playornot = true;
                            for (int i = 0; i < 900; i++)
                            {

                                await Task.Delay(1);
                                if (Song6Play == false)
                                {
                                    playornot = false;
                                    i = 900;
                                    break;
                                }
                            }
                            if (playornot == true)
                            {
                                myPlayer.Open(new System.Uri(audioPath));

                                myPlayer.Play();
                            }

                            if (playornot == false)
                            {
                                myPlayer.Stop();

                            }



                        }

                    }

                   
                }
                else
                {
                    while (MainCharacterHp>0)
                    {
                        myPlayer.Play();
                        await Task.Delay(1);

                    }
                }
            }
        }

        //public void PlaySound2(string audiopath, bool play) // Dying from monsters = dying from insanity
        //{
        //    //setting up all sounds
        //    MediaPlayer NiceMusic1 = new MediaPlayer();
        //    MediaPlayer MediumMusic = new MediaPlayer();
        //    MediaPlayer ScaryMusic = new MediaPlayer();
        //    MediaPlayer GatesToHeaven = new MediaPlayer();
        //    MediaPlayer GunShot = new MediaPlayer();
        //    MediaPlayer Reload = new MediaPlayer();
        //    MediaPlayer WomanScream = new MediaPlayer();
        //    MediaPlayer MonsterScream = new MediaPlayer();
        //    MediaPlayer PoliceOfficerScream = new MediaPlayer();
        //    MediaPlayer scarylaugh = new MediaPlayer();
        //    MediaPlayer scaryviolin = new MediaPlayer();
        //    MediaPlayer HorrorSoundsDisortionLong = new MediaPlayer();

        //    //NiceMusic1.Open(new System.Uri(@"Sounds\NiceMusic1.wav"));
        //    //NiceMusic1.Play();

        //    //Play(Application.StartupPath + "\\Track1.wav");

        //    if (play == true)
        //    {
        //        if (audiopath == @"Sounds\NiceMusic1.wav")
        //        {
        //            NiceMusic1.Open(new System.Uri(AppDomain.CurrentDomain.BaseDirectory + audiopath));

        //            NiceMusic1.Play(); 

        //        }

        //        //else if (audiopath == @"Sounds\MediumMusic.wav")
        //        //{
        //        //    MediumMusic.SoundLocation = (@"Sounds\MediumMusic.wav");

        //        //    MediumMusic.LoadAsync();
        //        //    MediumMusic.PlayLooping();
        //        //}

        //        //else if (audiopath == @"Sounds\ScaryMusic.wav")
        //        //{
        //        //    ScaryMusic.SoundLocation = (@"Sounds\ScaryMusic.wav");

        //        //    ScaryMusic.LoadAsync();
        //        //    ScaryMusic.PlayLooping();
        //        //}
        //        //else if (audiopath == @"Sounds\GatesToHeaven.wav")
        //        //{
        //        //    GatesToHeaven.SoundLocation = (@"Sounds\GatesToHeaven.wav");

        //        //    GatesToHeaven.LoadAsync();
        //        //    GatesToHeaven.PlayLooping();
        //        //}
        //        else if (audiopath == @"Sounds\GunShot.wav")
        //        {
        //            GunShot.Open(new System.Uri(AppDomain.CurrentDomain.BaseDirectory + audiopath));

        //            GunShot.Play();
        //        }
        //        //else if (audiopath == "Reload")
        //        //{
        //        //    Reload.LoadAsync();
        //        //    Reload.Play();
        //        //}
        //        //else if (audiopath == "WomanScream")
        //        //{
        //        //    WomanScream.LoadAsync();
        //        //    WomanScream.Play();
        //        //}
        //        //else if (audiopath == "MonsterScream")
        //        //{
        //        //    MonsterScream.LoadAsync();
        //        //    MonsterScream.Play();
        //        //}
        //        //else if (audiopath == "PoliceOfficerScream")
        //        //{
        //        //    PoliceOfficerScream.LoadAsync();
        //        //    PoliceOfficerScream.Play();
        //        //}
        //        //else if (audiopath == "scarylaugh")
        //        //{
        //        //    scarylaugh.LoadAsync();
        //        //    scarylaugh.Play();
        //        //}
        //        //else if (audiopath == "scaryviolin")
        //        //{
        //        //    scaryviolin.LoadAsync();
        //        //    scaryviolin.PlayLooping();
        //        //}
        //        //else if (audiopath == "HorrorSoundsDisortionLong")
        //        //{
        //        //    HorrorSoundsDisortionLong.LoadAsync();
        //        //    HorrorSoundsDisortionLong.PlayLooping();
        //        //}
        //    }

        //    else if (play == false)
        //    {
        //        if (audiopath == "NiceMusic1")
        //        {
        //            NiceMusic1.Stop();

        //        }

        //        else if (audiopath == "MediumMusic")
        //        {
        //            MediumMusic.Stop();

        //        }

        //        else if (audiopath == "ScaryMusic")
        //        {
        //            ScaryMusic.Stop();

        //        }
        //        else if (audiopath == "GatesToHeaven")
        //        {
        //            GatesToHeaven.Stop();

        //        }
        //        else if (audiopath == "GunShot")
        //        {
        //            GunShot.Stop();

        //        }
        //        else if (audiopath == "Reload")
        //        {
        //            Reload.Stop();

        //        }
        //        else if (audiopath == "WomanScream")
        //        {
        //            WomanScream.Stop();

        //        }
        //        else if (audiopath == "MonsterScream")
        //        {
        //            MonsterScream.Stop();

        //        }
        //        else if (audiopath == "PoliceOfficerScream")
        //        {
        //            PoliceOfficerScream.Stop();

        //        }
        //        else if (audiopath == "scarylaugh")
        //        {
        //            scarylaugh.Stop();

        //        }
        //        else if (audiopath == "scaryviolin")
        //        {
        //            scaryviolin.Stop();

        //        }
        //        else if (audiopath == "HorrorSoundsDisortionLong")
        //        {
        //            HorrorSoundsDisortionLong.Stop();

        //        }
        //    }
        


        //}

        //public  void PlaySound(string name,bool play) // Dying from monsters = dying from insanity
        //{
        //    //setting up all sounds
        //    SoundPlayer NiceMusic1 = new SoundPlayer(@"Sounds\NiceMusic1.wav");
        //    SoundPlayer MediumMusic = new SoundPlayer(@"Sounds\MediumMusic.wav");
        //    SoundPlayer ScaryMusic = new SoundPlayer(@"Sounds\ScaryMusic.wav");
        //    SoundPlayer GatesToHeaven = new SoundPlayer(@"Sounds\GatesToHeaven.wav");
        //    SoundPlayer GunShot = new SoundPlayer(@"Sounds\GunShot.wav");
        //    SoundPlayer Reload = new SoundPlayer(@"Sounds\Reload.wav");
        //    SoundPlayer WomanScream = new SoundPlayer(@"Sounds\WomanScream.wav");
        //    SoundPlayer MonsterScream = new SoundPlayer(@"Sounds\MonsterScream.wav");
        //    SoundPlayer PoliceOfficerScream = new SoundPlayer(@"Sounds\PoliceOfficerScream.wav");
        //    SoundPlayer scarylaugh = new SoundPlayer(@"Sounds\scarylaugh.wav");
        //    SoundPlayer scaryviolin = new SoundPlayer(@"Sounds\scaryviolin.wav");
        //    SoundPlayer HorrorSoundsDisortionLong = new SoundPlayer(@"Sounds\HorrorSoundsDisortionLong.wav");

        //    if (play == true)
        //    {
        //        if (name == "NiceMusic1")
        //        {
        //            NiceMusic1.SoundLocation = (@"Sounds\NiceMusic1.wav");

        //            NiceMusic1.LoadAsync();
        //            NiceMusic1.Play(); //plays endlessly

        //        }

        //        else if (name == "MediumMusic")
        //        {
        //            MediumMusic.SoundLocation = (@"Sounds\MediumMusic.wav");

        //            MediumMusic.LoadAsync();
        //            MediumMusic.PlayLooping();
        //        }

        //        else if (name == "ScaryMusic")
        //        {
        //            ScaryMusic.SoundLocation = (@"Sounds\ScaryMusic.wav");

        //            ScaryMusic.LoadAsync();
        //            ScaryMusic.PlayLooping();
        //        }
        //        else if (name == "GatesToHeaven")
        //        {
        //            GatesToHeaven.SoundLocation = (@"Sounds\GatesToHeaven.wav");

        //            GatesToHeaven.LoadAsync();
        //            GatesToHeaven.PlayLooping();
        //        }
        //        else if (name == "GunShot")
        //        {
        //            GunShot.SoundLocation = (@"Sounds\GunShot.wav");

        //            GunShot.LoadAsync();
        //            GunShot.Play();
        //        }
        //        else if (name == "Reload")
        //        {
        //            Reload.LoadAsync();
        //            Reload.Play();
        //        }
        //        else if (name == "WomanScream")
        //        {
        //            WomanScream.LoadAsync();
        //            WomanScream.Play();
        //        }
        //        else if (name == "MonsterScream")
        //        {
        //            MonsterScream.LoadAsync();
        //            MonsterScream.Play();
        //        }
        //        else if (name == "PoliceOfficerScream")
        //        {
        //            PoliceOfficerScream.LoadAsync();
        //            PoliceOfficerScream.Play();
        //        }
        //        else if (name == "scarylaugh")
        //        {
        //            scarylaugh.LoadAsync();
        //            scarylaugh.Play();
        //        }
        //        else if (name == "scaryviolin")
        //        {
        //            scaryviolin.LoadAsync();
        //            scaryviolin.PlayLooping();
        //        }
        //        else if (name == "HorrorSoundsDisortionLong")
        //        {
        //            HorrorSoundsDisortionLong.LoadAsync();
        //            HorrorSoundsDisortionLong.PlayLooping();
        //        }
        //    }

        //    else if (play == false)
        //    {
        //        if (name == "NiceMusic1")
        //        {
        //            NiceMusic1.Stop();

        //        }

        //        else if (name == "MediumMusic")
        //        {
        //            MediumMusic.Stop();

        //        }

        //        else if (name == "ScaryMusic")
        //        {
        //            ScaryMusic.Stop();

        //        }
        //        else if (name == "GatesToHeaven")
        //        {
        //            GatesToHeaven.Stop();

        //        }
        //        else if (name == "GunShot")
        //        {
        //            GunShot.Stop();

        //        }
        //        else if (name == "Reload")
        //        {
        //            Reload.Stop();

        //        }
        //        else if (name == "WomanScream")
        //        {
        //            WomanScream.Stop();

        //        }
        //        else if (name == "MonsterScream")
        //        {
        //            MonsterScream.Stop();

        //        }
        //        else if (name == "PoliceOfficerScream")
        //        {
        //            PoliceOfficerScream.Stop();

        //        }
        //        else if (name == "scarylaugh")
        //        {
        //            scarylaugh.Stop();

        //        }
        //        else if (name == "scaryviolin")
        //        {
        //            scaryviolin.Stop();

        //        }
        //        else if (name == "HorrorSoundsDisortionLong")
        //        {
        //            HorrorSoundsDisortionLong.Stop();

        //        }
        //    }
        //}
    }
}
