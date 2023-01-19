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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //Main Executer, keeping the definitions + main executer here
    {
        //Setting all arrays needed to keep track of images
        public ImageBrush[] BackGrounds;
        public ImageBrush[] MainCharactersImages;
        public ImageBrush[] AmmoBar;
        public ImageBrush[] HpBar;
        public ImageBrush[] Endings;
        public ImageBrush[] JumpScares;
        public ImageBrush[] Boss2Pictures;
        public ImageBrush[] TextImages;

        bool GoRight, GoLeft, Shoot, Jump; // bool for is going right or left
        bool RightDirection = false, LeftDirection = false;
        bool ShootingCooldown = false; //takes a moment from bullet to bullet, if false can shoot.
        bool ReloadCooldown = false;
        bool Reload = false; // reloading gun
        bool Skip = false;
        bool Menu = false; //opening menu
        bool DoAnimationRight = true, DoAnimationLeft = true, DoAnimationShooting = true, DoJump = true; //animation time cooldown
        bool Boss1Bool = true; //procing boss 1 or not?
        bool Boss2Bool = true; //procing boss 2 or not?
        bool Boss3Bool = true; //procing boss 3 or not?
        bool DecisionMade = false;
        bool Vulnerability = false; // if Vulnerability true cant get dmg
        bool Spinbool = true; //allows spinning
        bool Song1Play = true; //nice
        bool Song2Play = true; //medium
        bool Song3Play = true; //scaryvery
        bool Song4Play = true; //heaven
        bool Song5Play = true; //disotrion
        bool Song6Play = false; //violin

        public int speed = 20; // speed of character, change it from map tp map if size diffrent
        public int MainCharacterHp = 100; //max hp of character

        public int ReaperSpeed = 2;
        public int BrainSpeed = 3;
        public int GhostSpeed = 2;

        public int ReaperSpeedBoost = 0;
        public int BrainSpeedBoost = 0;
        public int GhostSpeedBoost = 0;

        public const int BoostValue = 1;

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayButton.Opacity == 1)
            {
                Menu = false;
            }
        }

        //private void SettingsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (SettingsButton.Opacity == 1)
        //    {
        //        //do stuff
        //    }
        //}

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExitButton.Opacity == 1)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void PlayAgainButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory+ @"TheMonsterSlayer.exe");
            System.Windows.Application.Current.Shutdown();

         

        }

        public int Image = 0; //resetting to default image

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveGame();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadGame();
        }

        public int CurrentLevel = 1; // keeps track of the lvl
        public int Ammotation = 8; // ammo for gun

        DispatcherTimer GameTimer = new DispatcherTimer(); //for time functions       

        Enemies[] Enemies = new Enemies[13]; //setting max enemies
        int[] EnemiesSpeedDataSaver = new int[13];
        public int EnemiesCount = 0;


        public MainWindow()
        {
            //Setting all the arrays for the image arrays
            BackGrounds = new ImageBrush[13]; //all level backgrounds
            MainCharactersImages = new ImageBrush[4]; //basic right/left walking animation
            AmmoBar = new ImageBrush[9]; //8 bullets + empty
            HpBar = new ImageBrush[4]; // 3 lives + empty
            Endings = new ImageBrush[4]; // 2 endings
            JumpScares = new ImageBrush[8]; // 2 endings
            this.EnemiesArray = new Enemies[13];
            Boss2Pictures = new ImageBrush[2];
            TextImages = new ImageBrush[10];
            InitializeComponent();

            CANVAS.Focus();
            GameTimer.Tick += GameTimerEvent;
            GameTimer.Interval = TimeSpan.FromMilliseconds(30);
            GameTimer.Start();      

            WindowState = WindowState.Maximized; //setting to maximized window
            WindowStyle = WindowStyle.ToolWindow; 

            LevelConditions(1); //setting to conditions of first level, others will auto trigger by game interaction

            Set_Background(CurrentLevel); //setting background (will do lvl 1 BG)

            MenuEffect();
                

        }


    }
}
