using NPOI.SS.Formula.Functions;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiernikWychylowy2
{
	public partial class Component2 : Panel
	{
		//private const string V1 = "C:\\Users\\Piotr\\source\\repos\\MiernikWychylowy\\tarcza-01.png";
		private Color testCol;
		private int szer;
		private int wyso;
		private int x1=150, x2=150, y1=40, y2=150;
		
		private Graphics g;
		private int[][] coords = new int[][]
		{
			new int[] {40,90},
			new int[] {75,80},
			new int[] {105,70},
			new int[] {135,60},
			new int[] {170,50},
			new int[] {200,50},
			new int[] {235,50},
			new int[] {270,60},
			new int[] {300,70},
			new int[] {330,80},
			new int[] {360,90}


		}; 
	
		
		private Color arrowCol;
		public void startTimer()
		{

		}


		



		public Component2()
		{
			Width = 300;
			Height = 200;
			BackgroundImage = Image.FromFile("C:\\Users\\Piotr\\source\\repos\\MiernikWychylowy2\\tarcza-01.png");
			BackgroundImageLayout = ImageLayout.Stretch;

			InitializeComponent();
			
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			g = e.Graphics;
			 var nodes = new[] { new Node { Code = 'A', Position = new Point(x2, y2) }, new Node { Code = 'B', Position = new Point(x1, y1) } };

			using (Pen Pencil = new Pen(Color.Green, 3))
			{
				//Pencil.Width = 5;
				Pencil.StartCap = LineCap.NoAnchor;
				Pencil.Color = arrowCol;


				Pencil.CustomEndCap = new AdjustableArrowCap(4, 8, false);
				Pencil.CustomEndCap = new AdjustableArrowCap(4, 8, false);

				for (int i = 0; i < nodes.Length; i++)
				{
					var node = nodes[i];
					for (int j = i; j < nodes.Length; j++)
					{
						var node2 = nodes[j];
						if (node == node2)
							continue;
						Point startPoint = new Point(node.Position.X, node.Position.Y);
						Point endPoint = new Point(node2.Position.X, node2.Position.Y);
						g.DrawLine(Pencil, startPoint, endPoint);
					}
				}
			
				
			}


		}
		public void SetCoordinates(int i)
		{
			this.x1 = coords[i+5][0];
			this.y1 = coords[i+5][1];
			Invalidate();
			
		}
		
		public Color TestCol
		{
			get
			{
				return testCol;
			}
			set
			{
				testCol = value;
				BackColor = value;
			}


		}
		public int Szer
		{
			set
			{
				szer = value;
				Width = szer;
				x1 = Convert.ToInt32(0.5 * szer);
				x2 = Convert.ToInt32(0.5 * szer);
			}
			get { return szer; }

		}
		public int Wyso
		{
			set
			{
				wyso = value;
				Height = wyso;
				y1 = Convert.ToInt32(0.2 * wyso);
				y2 = Convert.ToInt32(0.75 * wyso);

			}
			get
			{
				return wyso;
			}
		}
		public Color ArrowCol
		{
			set
			{
				arrowCol = value;
				Invalidate();
				
			}
			get
			{
				return arrowCol;
			}
		}
		public int X1
		{
			set { x1 = value;
				Invalidate();
			}
			get { return x1; }
			
		}
		public int Y1
		{
			set { y1 = value;
				Invalidate();
			}
			get { return y1; }
		}
		


	}
}
