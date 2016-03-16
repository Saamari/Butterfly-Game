using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Butterfly.Game
{
    public sealed partial class Butterfly : UserControl
    {
        //animate 
        private DispatcherTimer timer;
        //offset
        private int currentFrame = 0;
        private int direction = 1; // 1 or -1
        private int frameheight = 132;
        //location
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        //speed
        private readonly double MaxSpeed = 10.0;
        private readonly double Accelarate = 0.5;
        private double speed;
        //Angle
        private double Angle = 0;
        private readonly double AngleStep = 5;


        // constructor
        public Butterfly()
        {
            this.InitializeComponent();

            //Start animation
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0,0,0,0,125);
            timer.Start();
        }

        private void Timer_Tick(object sender, object e)
        {
            //frame: 0,1,2,3,4
            if (direction == 1) currentFrame++;
            else currentFrame--;
            // direction
            if (currentFrame == 0 || currentFrame == 4) direction *= -1;
            // set offset
            SpriteSheetOffset.Y = currentFrame *- frameheight;
        }

        //show butterfly in right position in canvas
        public void UpdatePosition ()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        //Rotate
        public void Rotate(int angleDirection)
        {
            Angle += angleDirection * AngleStep; // changes alway for 5 or -5
            ButterflyRotateAngle.Angle = Angle;
        }

        //move
        public void Move()
        {
            speed += Accelarate;
            if (speed > MaxSpeed) speed = MaxSpeed;
            // Update location x and y
            LocationX -= (Math.Cos(Math.PI / 180* (Angle + 90)))*speed;
            LocationY -= (Math.Sin(Math.PI / 180 * (Angle + 90))) * speed;

        }


    }//class
}//namespace
