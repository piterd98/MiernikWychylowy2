using AppTest2.Properties;
using MiernikWychylowy2;
using NPOI.SS.Formula.Functions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppTest2
{		//Klasa aplikacji testującej
	public partial class Form1 : Form
	{
		private int AValue, mAvalue, basicValue,Value;

		public Form1()
		{	//Inicjalizacja kompponentu, Skalowanie strzałki w komponencie
			InitializeComponent();
			//component21.ChangeBackground(Resources.tarcza_01);
			component21.UpdateCoords();
		}
		

		
		// Metoda obsługująca błąd wybrania wartości spoza zakresu
		public void WrongValueException()
		{
			 MessageBox.Show("Wprowadzono niepoprawną wartość", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
			textBox1.Text = String.Empty;
		}

		
		// Metoda określająca zdarzenie wciśniecia guzika wskazującego
		private void button1_Click(object sender, EventArgs e)
		{
			// Przelicznik dla róznych zakresów na tarczach
			try
			{
				 mAvalue = (int)Math.Round(Convert.ToDouble(textBox1.Text) / 5);
				 AValue = (int)Math.Round((Convert.ToDouble(textBox1.Text) * 2) / 5) * 5;
				 basicValue = Convert.ToInt32(textBox1.Text);
				
				Console.WriteLine(basicValue);
				
				if ((mAvalue < 25 && mAvalue > -25) || (AValue < 3 && AValue > -3) || (basicValue > -6 && basicValue < 6))
				{
					if (comboBox1.SelectedItem == "25mA")
					{
						Value = mAvalue;
						component21.AnimateArrow(Value + 5);
					}
					else if (comboBox1.SelectedItem == "2.5A")
					{
						Value = AValue;
						component21.AnimateArrow(Value + 5);
					}
					else
					{
						Value = basicValue;
						component21.AnimateArrow(Value + 5);
					}

					
				}
				else {
					
						WrongValueException();
						textBox1.Text = "0";


				}
			}
			catch(FormatException ex)
			{
				Console.Write(ex);
				WrongValueException();
				
			}
			
			
			
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		
		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void component21_Paint_1(object sender, PaintEventArgs e)
		{
			Invalidate();
		}

		// Metoda weryfikująca wpisywany tekst do pola
		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}
			else
			{
				//WrongValueException();
			}
			if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
			{
				e.Handled = true;
			}
		}
		// Zmiana zakresu miernika
		private void comboBox1_SelectedItemChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem == "5A")
			{
				
				component21.ChangeBackground(Resources.tarcza_01);
				//component21.setScale(5);
				component21.BackgroundImageLayout = ImageLayout.Stretch;
				Invalidate();
			}
			else if (comboBox1.SelectedItem == "25mA") {
				component21.ChangeBackground(Resources.tarcza_25mA);
				component21.BackgroundImageLayout = ImageLayout.Stretch;
				Invalidate();

			}
			else if(comboBox1.SelectedItem == "2.5A") { 
				component21.ChangeBackground(Resources.tarcza_25A);
				component21.BackgroundImageLayout = ImageLayout.Stretch;
				Invalidate();
			}
			else {
				component21.ChangeBackground(Resources.tarcza_01);
				component21.setScale(5);
				

			}
		}

		private void component21_Paint(object sender, PaintEventArgs e)
		{

		}

	}
}
