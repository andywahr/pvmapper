﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pvPanel3DAngleCtl
{
    public partial class pvPanelAxisRotationCtl: UserControl
    {
        bool pick = false;
        private Bitmap image = null;
        private float angle = 0.0f;
        public float AxisAngle
        {
            get { return angle; }
            set 
            {
                angle = value;
                //RotateImage(pictureBox1, image, angle);
                angleNumericUpDown.Value = (int)angle;
                lblAngle.Text = angle.ToString() + " Deg.";
            }
        }
        public pvPanelAxisRotationCtl()
        {
            InitializeComponent();
            angleNumericUpDown.Value = (Decimal)angle;
        }

        private void pvPanelAngle_Load(object sender, EventArgs e)
        {
            image = (Bitmap)pictureBox2.Image;
            pictureBox1.Image = (Bitmap)image.Clone();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    RotateImage(pictureBox1, image, angle++);
                    break;
                case Keys.Down:
                    RotateImage(pictureBox1, image, angle--);
                    break;
                case Keys.Right:
                    RotateImage(pictureBox1, image, angle++);
                    break;
                case Keys.Left:
                    RotateImage(pictureBox1, image, angle--);
                    break;
            }
        }
        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;

            Image oldImage = pb.Image;
            pb.Image = Utilities.RotateImage(img, angle);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }

        private void Angle_Change(object sender, EventArgs e)
        {
            if (angle >= -5 & angle <= 5) image = (Bitmap)pictureBox2.Image;
            if (5 < angle & angle <= 30) image = (Bitmap)pictureBox4.Image;
            if (30 < angle) image = (Bitmap)pictureBox6.Image;
            if (-5 > angle & angle >= -30) image = (Bitmap)pictureBox3.Image;
            if (-30 > angle) image = (Bitmap)pictureBox5.Image; 
            pictureBox1.Image = (Bitmap)image.Clone(); 
            angle = (float)angleNumericUpDown.Value;
            RotateImage(pictureBox1, image, angle);
        }

        private void AngPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (pick == true)
            {
                pickAng(e.X, e.Y);
            }
        }

        private void AngPanel_MouseDown(object sender, MouseEventArgs e)
        {
            pick = true;
            pickAng(e.X, e.Y);
        }

        private void AngPanel_MouseUp(object sender, MouseEventArgs e)
        {
            pick = false;
            pickAng(e.X, e.Y);

        }

        float pickAng(int x, int y)
        {
            if (x== 50)
            {
                if (y > 50)
                {
                    angle = 90;
                }
                else
                {
                    angle = 270;
                }
            }
            else
            {
                angle = (float)(int)(Math.Atan((double )(y - 50) / (double )(x - 50)) * 180 / Math.PI);
            }
            //if (angle<0) lblAngle.Text = angle.ToString() + " Deg. (W)";
            //if (angle>0) lblAngle.Text = angle.ToString() + " Deg. (E)";
            lblAngle.Text = angle.ToString() + " Deg.";
            //angleNumericUpDown.Value = (int)angle;
            //RotateImage(pictureBox1, image, angle);
            angleNumericUpDown.Value = (int)angle;
            return angle;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
