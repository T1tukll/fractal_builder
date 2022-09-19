
namespace WinFormsApp1 {
    internal class FractalDrawing {
        public static void alter_draw(ref Graphics draw_obj, ref PictureBox pictureBox1,
                                        PointF left_corn_up, PointF right_corn_down) {
            long points_cout = 0;
            
            double less_x = (right_corn_down.X - left_corn_up.X) / pictureBox1.Width;
            double bigger_x = (double)pictureBox1.Width / (right_corn_down.X - left_corn_up.X);

            double less_y = (right_corn_down.Y - left_corn_up.Y) / pictureBox1.Height;
            double bigger_y = (double)pictureBox1.Height / (right_corn_down.Y - left_corn_up.Y);

            for (double y = left_corn_up.Y; y < right_corn_down.Y; y += less_y) {
                for (double x = left_corn_up.X; x < right_corn_down.X; x += less_x) {
                    int iter_bord = 255;    // iterations value for reaching 2 by complex number

                    double y_center = (left_corn_up.Y + right_corn_down.Y) / 2;
                    double x_center = (left_corn_up.X + right_corn_down.X) / 2;

                    double real_prt = (x - x_center); /// (double)pictureBox1.Width / .5;// real part
					double image_prt = (y - y_center); /// (double)pictureBox1.Width / .5;//complex part
					complex c = new complex(real_prt, image_prt);
                    complex z = new complex(0, 0);

                    int iter = 0;
                    for (; iter < iter_bord; ++iter) {
                        z.sqrt();
                        z.add(c);

                        if (z.magnitude() > 2.0) {
                            break;
                        }
                    }

                    //int r1 = Convert.ToInt32(toolStripTextBox1.Text) == -1 ? iter : Convert.ToInt32(toolStripTextBox1.Text);
                    //int g1 = Convert.ToInt32(toolStripTextBox2.Text) == -1 ? 0 : Convert.ToInt32(toolStripTextBox2.Text);
                    //int b1 = Convert.ToInt32(toolStripTextBox3.Text) == -1 ? (iter * 2 <= 255 ? iter * 2 : 255) : Convert.ToInt32(toolStripTextBox3.Text);

                    //int r2 = Convert.ToInt32(toolStripTextBox4.Text) == -1 ? iter : Convert.ToInt32(toolStripTextBox4.Text);
                    //int g2 = Convert.ToInt32(toolStripTextBox5.Text) == -1 ? iter : Convert.ToInt32(toolStripTextBox5.Text);
                    //int b2 = Convert.ToInt32(toolStripTextBox6.Text) == -1 ? iter : Convert.ToInt32(toolStripTextBox6.Text);
                    int r1 = iter;
                    int g1 = iter;
                    int b1 = iter;

                    int r2 = iter;
                    int g2 = iter;
                    int b2 = iter;

                    int dig_x = pictureBox1.Width / 2 + Convert.ToInt32(real_prt * bigger_x);
                    int dig_y = pictureBox1.Height / 2 - Convert.ToInt32(image_prt * bigger_y);

                    draw_obj.DrawEllipse(new Pen(iter < 255 ? Color.FromArgb(r1, g1, b1)
                                                            : Color.FromArgb(r2, g2, b2)),
                                                            dig_x, dig_y, 1, 1);
                    ++points_cout;
                }
            }
            MessageBox.Show(points_cout.ToString() + " : " + (pictureBox1.Width * pictureBox1.Height).ToString());

        }
    }
}
