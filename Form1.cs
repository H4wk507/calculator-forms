using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator2
{
	public partial class Form1 : Form
	{
		private bool startNewNumber;
		private string op;
		private double num1;
		private double num2;
		private string divisionByZeroErrorMessage;
		public Form1()
		{
			InitializeComponent();
			// set '.' as decimal separator instead of ','
			System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
			customCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

			startNewNumber = true;
			input.Text = "0";
			divisionByZeroErrorMessage = "Dzielenie przez zero!";
		}

		private void buttonC_Click(object sender, EventArgs e)
		{
			input.Text = "0";
			output.Text = String.Empty;
			this.op = String.Empty;
			startNewNumber = true;
		}

		private void buttonDel_Click(object sender, EventArgs e)
		{
			if (input.Text.Length == 0) return;
			if (input.Text == divisionByZeroErrorMessage) {
				input.Text = "0";
				startNewNumber = true;
			} else if (input.Text.Length == 1) {
				input.Text = "0";
			} else {
				input.Text = input.Text.Remove(input.Text.Length - 1);
			}
		}

		private void buttonDiv_Click(object sender, EventArgs e)
		{
			operatorClicked("/");
		}

		private void button7_Click(object sender, EventArgs e)
		{
			numberClicked("7");
		}

		private void button8_Click(object sender, EventArgs e)
		{
			numberClicked("8");
		}

		private void button9_Click(object sender, EventArgs e)
		{
			numberClicked("9");
		}

		private void buttonMul_Click(object sender, EventArgs e)
		{
			operatorClicked("*");
		}

		private void button4_Click(object sender, EventArgs e)
		{
			numberClicked("4");
		}

		private void button5_Click(object sender, EventArgs e)
		{
			numberClicked("5");
		}

		private void button6_Click(object sender, EventArgs e)
		{
			numberClicked("6");
		}

		private void buttonSub_Click(object sender, EventArgs e)
		{
			operatorClicked("-");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			numberClicked("1");
		}

		private void button2_Click(object sender, EventArgs e)
		{
			numberClicked("2");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			numberClicked("3");
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			operatorClicked("+");
		}

		private void buttonSign_Click(object sender, EventArgs e)
		{
			if (input.Text.Length == 0 || input.Text == divisionByZeroErrorMessage) return;
			input.Text = Convert.ToString(Convert.ToDouble(input.Text) * -1);
		}

		private void button0_Click(object sender, EventArgs e)
		{
			numberClicked("0");
		}

		private void buttonDot_Click(object sender, EventArgs e)
		{
			if (input.Text == divisionByZeroErrorMessage){
				input.Text = "0";
			} 
			if (input.Text.IndexOf(".") == -1) {
				input.Text += ".";
				startNewNumber = false;
			}
		}

		private void buttonEqual_Click(object sender, EventArgs e)
		{
			if (input.Text.Length == 0 || input.Text == divisionByZeroErrorMessage) return;
			num2 = Convert.ToDouble(input.Text);
			output.Text = String.Empty;
			switch (op) {
				case "+": input.Text = Convert.ToString(num1 + num2); break;
				case "-": input.Text = Convert.ToString(num1 - num2); break;
				case "*": input.Text = Convert.ToString(num1 * num2); break;
				case "/":
					if (num2 == 0) {
						input.Text = divisionByZeroErrorMessage;
					}
					else {
						input.Text = Convert.ToString(num1 / num2);
					}
					break;
				default: break;
			}
			op = String.Empty;
			startNewNumber = true;
		}

		private void numberClicked(string number) {
			if (input.Text == "0" && number == "0") return;
			if (input.Text == divisionByZeroErrorMessage) {
				input.Text = number;
				startNewNumber = false;
			} else if (startNewNumber) {
				input.Text = number;
				startNewNumber = false;
			} else if (input.Text == "0") {
				input.Text = number;
			} 
			else {
				input.Text += number;
			}
		}
		private void operatorClicked(string op) {
			if (input.Text.Length == 0 || input.Text == divisionByZeroErrorMessage) return;
			if (input.Text[input.Text.Length - 1] == '.') {
				input.Text = input.Text.Remove(input.Text.Length - 1);
			}
			num1 = Convert.ToDouble(input.Text);
			output.Text = input.Text;
			output.Text += op;
			this.op = op;
			startNewNumber = true;
		}
	}
}
