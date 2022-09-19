// use this function for compile all in one *.exe file
// dotnet publish -r win10-x64 -p:Configuration=Release -p:PublishSingleFile=true

namespace WinFormsApp1 {
	public partial class Form1 :Form {
		
		eq bigger = new eq();

		PointF start_pnt = new PointF(-2, 1);
		PointF final_pnt = new PointF(1, 1.5f);
		PointF center_clck = new PointF(0, 0);

		public Form1() {
			InitializeComponent();
			bigger.X = pictureBox1.Width / (final_pnt.X - start_pnt.X);
			bigger.Y = pictureBox1.Width / (final_pnt.Y - start_pnt.Y);
		}

		public struct eq {
			 public double X = 0, Y = 0;

			public eq() {

            }

            public eq(double _X, double _Y) {
				X = _X;
				Y = _Y;
            }

        }

		

		private void pictureBox1_DoubleClick(object sender, EventArgs e) {
			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Graphics drawobj = Graphics.FromImage(pictureBox1.Image);

			FractalDrawing.alter_draw(ref drawobj, ref pictureBox1, start_pnt, final_pnt);
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e) {
			pictureBox1.Image = null;
		}

		private void saveAsPngToolStripMenuItem_Click(object sender, EventArgs e) {
			if (pictureBox1.Image == null) {
				return;
			}

			SaveFileDialog save_dialog = new SaveFileDialog();

			save_dialog.Title = "Fractal picture as";
			save_dialog.OverwritePrompt = true;
			save_dialog.CheckPathExists = true;
			save_dialog.Filter = "Image files(*.png)|*.png";
			if (save_dialog.ShowDialog() == DialogResult.OK) {
				try {
					pictureBox1.Image.Save(save_dialog.FileName);
				}
				catch {
					MessageBox.Show("Save fatal error", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void ScaleUp_toolStripMenuItem_Click(object sender, EventArgs e) {

			start_pnt.X = (center_clck.X - pictureBox1.Width / 2 - 0.0f) / (float)bigger.X;
			start_pnt.Y = (center_clck.Y + pictureBox1.Height / 2 - 0.0f) / (float)bigger.Y;

			final_pnt.X = (center_clck.X - pictureBox1.Width / 2 + 0.0f) / (float)bigger.X;
			final_pnt.Y = (center_clck.Y + pictureBox1.Height / 2 + 0.0f) / (float)bigger.Y;

			bigger.X = pictureBox1.Width / (final_pnt.X - start_pnt.X);
			bigger.X = pictureBox1.Height / (final_pnt.Y - start_pnt.Y);

			//x = cord.x / bigger.X;
			//y = cord.y / bigger.Y;

			//bigger.X = Width / x;
		}

        private void pictureBox1_Click(object sender, EventArgs e) {
			center_clck = Cursor.Position;
        }

		private void draw_toolStripMenuItem_Click(object sender, EventArgs e) {
			pictureBox1_DoubleClick(sender, e);

			decimal a;
		}
    }
}