using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Figure> figures = new List<Figure>();


        public MainWindow()
        {
            InitializeComponent();
            figures.Add(new Figure(FigureType.Rook, "A8", FigureColor.black));
            figures.Add(new Figure(FigureType.Rook, "H8", FigureColor.black));
            figures.Add(new Figure(FigureType.Knight, "B8", FigureColor.black));
            figures.Add(new Figure(FigureType.Knight, "G8", FigureColor.black));
            figures.Add(new Figure(FigureType.Bishop, "C8", FigureColor.black));
            figures.Add(new Figure(FigureType.Bishop, "F8", FigureColor.black));
            figures.Add(new Figure(FigureType.King, "E8", FigureColor.black));
            figures.Add(new Figure(FigureType.Queen, "D8", FigureColor.black));
                            
                            
            figures.Add(new Figure(FigureType.Pawn, "H7", FigureColor.black));
            figures.Add(new Figure(FigureType.Pawn, "B7", FigureColor.black));
            figures.Add(new Figure(FigureType.Pawn, "G7", FigureColor.black));
            figures.Add(new Figure(FigureType.Pawn, "C7", FigureColor.black));
            figures.Add(new Figure(FigureType.Pawn, "F7", FigureColor.black));
            figures.Add(new Figure(FigureType.Pawn, "E7", FigureColor.black));
            figures.Add(new Figure(FigureType.Pawn, "A7", FigureColor.black));
            figures.Add(new Figure(FigureType.Pawn, "D7", FigureColor.black));
                            
            figures.Add(new Figure(FigureType.Rook, "A1", FigureColor.white));
            figures.Add(new Figure(FigureType.Rook, "H1", FigureColor.white));
            figures.Add(new Figure(FigureType.Knight, "B1", FigureColor.white));
            figures.Add(new Figure(FigureType.Knight, "G1", FigureColor.white));
            figures.Add(new Figure(FigureType.Bishop, "C1", FigureColor.white));
            figures.Add(new Figure(FigureType.Bishop, "F1", FigureColor.white));
            figures.Add(new Figure(FigureType.King, "E1", FigureColor.white));
            figures.Add(new Figure(FigureType.Queen, "D1", FigureColor.white));
                            
            figures.Add(new Figure(FigureType.Pawn, "H2", FigureColor.white));
            figures.Add(new Figure(FigureType.Pawn, "B2", FigureColor.white));
            figures.Add(new Figure(FigureType.Pawn, "G2", FigureColor.white));
            figures.Add(new Figure(FigureType.Pawn, "C2", FigureColor.white));
            figures.Add(new Figure(FigureType.Pawn, "F2", FigureColor.white));
            figures.Add(new Figure(FigureType.Pawn, "E2", FigureColor.white));
            figures.Add(new Figure(FigureType.Pawn, "A2", FigureColor.white));
            figures.Add(new Figure(FigureType.Pawn, "D2", FigureColor.white));
                            
            vypis.Text = "";
            foreach (Figure figure in figures)
            {
                vypis.Text += figure.ToString() + "\n";
            }
        }
        public void DrawBoard(Canvas canvas)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.
        }
    }
}
