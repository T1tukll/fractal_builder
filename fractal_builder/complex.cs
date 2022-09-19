namespace WinFormsApp1 {
	internal class complex {
		public double real, imag;
		public complex(double real, double imag) {
			this.real = real;
			this.imag = imag;
		}

		public void sqrt() {
			// from (real * imag)^2 real will be (real^2 + imag^2), complex will be 2ab 
			double tmp = real*real - imag*imag;
			imag = imag * 2.0 * real;
			real = tmp;
		}

		public double magnitude() {
			return Math.Sqrt(real * real + imag * imag);
		}
		public void add(complex c) {
			real += c.real;
			imag += c.imag;
		}
	}
}
