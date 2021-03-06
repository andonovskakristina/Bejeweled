﻿using Bejeweled.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Media;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bejeweled
{
    public partial class SnakeForm : Form
    {    
        Snake s;
      //  int left, top, width, height;
        Timer moveTimer;
        Timer removeTimer;
        Timer TimeLeft;
        Rectangle bound;
        public  SoundPlayer soundPlayerSnake;
        int NumberTicks;
        public int TimeToAdd;
        public SnakeForm()
        {
            TimeToAdd = 0;
            soundPlayerSnake = new SoundPlayer(Resources.On_Off_Snake);
            this.BackgroundImage = Resources.BG4;
            InitializeComponent();
            int top = 10;
            int left = 10;
            int width = this.Width - left * 4;
            int height = this.Height - (int)(top * 10.5);
            bound = new Rectangle(left, top, width, height);
            s = new Snake(new Point(Width / 2, Height / 2), bound);
            DoubleBuffered = true;
            moveTimer = new Timer();
            moveTimer.Interval = 100;
            moveTimer.Tick += new EventHandler(moveTimer_Tick);
            moveTimer.Start();
            TimeLeft = new Timer();
            TimeLeft.Interval = 100;
            pbTimeLeft.Value = 100;
            TimeLeft.Tick += new EventHandler(TimeLeft_Tick);
            TimeLeft.Start();
            removeTimer = new Timer();
            removeTimer.Interval = 100;
            removeTimer.Tick += new EventHandler(removeTimer_Tick);
            NumberTicks = 150;
            checkSound();
        }

        private void checkSound()
        {
            if (Game.flagSoundIcon)
            {
                soundPlayerSnake.Play();
            }
            else
            {
                soundPlayerSnake.Stop();
            }
        }

        private void TimeLeft_Tick(object sender, EventArgs e)
        {
            NumberTicks--;
            pbTimeLeft.Value = NumberTicks / 2;
            if(pbTimeLeft.Value == 0)
            {
                ShowPoints();
                this.Close();
            }
            if (!Game.flagSoundIcon)
            {
                soundPlayerSnake.Stop();
            }
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            s.Move(bound);
            Invalidate();
            //ako se izede sam
            if (s.EndGame)
            {
                moveTimer.Stop();
                TimeLeft.Stop();
                pbTimeLeft.Value = 0;
                removeTimer.Start();
                soundPlayerSnake.Stop();
            }
            //ako istece vreme
            else if (pbTimeLeft.Value == 0)
            {
                moveTimer.Stop();
                TimeLeft.Stop();
                soundPlayerSnake.Stop();
            }
        }

        private void removeTimer_Tick(object sender, EventArgs e)
        {
            if (s.squares.Count != 0)
            {
                s.squares.RemoveAt(s.squares.Count - 1);
                Invalidate();
            }
            else
            {
                removeTimer.Stop();
                ShowPoints();
            }
        }
        public void ShowPoints()
        {
                TimeToAdd = s.StarsEaten * 5;
                DialogResult = DialogResult.OK;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Green, 3);
            e.Graphics.DrawRectangle(p, bound);
            s.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && s.squares[0].position != Square.Position.Up)
            {
                s.squares[0].position = Square.Position.Down;
            }
            if (e.KeyCode == Keys.Up && s.squares[0].position != Square.Position.Down)
            {
                s.squares[0].position = Square.Position.Up;
            }
            if (e.KeyCode == Keys.Left && s.squares[0].position != Square.Position.Right)
            {
                s.squares[0].position = Square.Position.Left;
            }
            if (e.KeyCode == Keys.Right && s.squares[0].position != Square.Position.Left)
            {
                s.squares[0].position = Square.Position.Right;
            }
            Invalidate();
        }

        private void SnakeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void SnakeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
            TimeLeft.Stop();
            soundPlayerSnake.Stop();
        }
    }
}
