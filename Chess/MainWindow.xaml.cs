using System;
using System.Collections.Generic;
using System.IO;
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
        Dictionary<string, int> columns = new Dictionary<string, int>();
        Dictionary<string, int> rows = new Dictionary<string, int>();
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

            createDictionary();

            vypis.Text = "";
            foreach (Figure figure in figures)
            {
                vypis.Text += figure.ToString() + "\n";
            }
            DrawBoard();
            DrawFigures(figures);

        }

        private ImageSource GetImage(byte[] resource)
        {
            MemoryStream memoryStream = new MemoryStream(resource);
            BitmapFrame bitmapFrame = BitmapFrame.Create(memoryStream);
            Image image = new Image();
            image.Source = bitmapFrame;
            return image.Source;
        }

        private void DrawFigures(List<Figure> figures)
        {
            foreach (var figure in figures)
            {
                DrawFigure(figure);
            }
        }

        private void DrawFigure(Figure figure)
        { 
            Rectangle rectangle = new Rectangle();
            rectangle.VerticalAlignment = VerticalAlignment.Stretch;
            rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
            rectangle.Margin = new Thickness(5);
            rectangle.Fill = new ImageBrush(GetImage(figure.Resource));
            int indexcol = columns[figure.Position.Substring(0, 1)];
            int indexrow = rows[figure.Position.Substring(1,1)];
            Grid.SetColumn(rectangle, indexcol);
            Grid.SetRow(rectangle,indexrow);

            ChessBoardGrid.Children.Add(rectangle);   
        }

        public void createDictionary()
        {
            columns.Add("A", 0);
            columns.Add("B", 1);
            columns.Add("C", 2);
            columns.Add("D", 3);
            columns.Add("E", 4);
            columns.Add("F", 5);
            columns.Add("G", 6);
            columns.Add("H", 7);

            rows.Add("8", 0);
            rows.Add("7", 1);
            rows.Add("6", 2);
            rows.Add("5", 3);
            rows.Add("4", 4);
            rows.Add("3", 5);
            rows.Add("2", 6);
            rows.Add("1", 7);

        }

        public void DrawBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                ChessBoardGrid.ColumnDefinitions.Add(
                new ColumnDefinition()
                {
                    Width = new GridLength(1, GridUnitType.Star)
                });

                ChessBoardGrid.RowDefinitions.Add(
                new RowDefinition()
                {
                    Height = new GridLength(3, GridUnitType.Star)
                });
            }
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Stroke = new SolidColorBrush(Colors.Black);
                    rectangle.StrokeThickness = 3;
                    rectangle.Margin = new Thickness(-1.5);
                    
                    rectangle.VerticalAlignment = VerticalAlignment.Stretch;
                    rectangle.HorizontalAlignment = HorizontalAlignment.Stretch;
                    if ((x+y) % 2 == 0)
                    { 
                        rectangle.Fill = new SolidColorBrush(Color.FromRgb(255,255,255));                   
                    }
                    else
                    {
                        rectangle.Fill = new SolidColorBrush(Color.FromRgb(65, 43, 21));
                    }
                    
                    Grid.SetColumn(rectangle, x);
                    Grid.SetRow(rectangle, y);

                    ChessBoardGrid.Children.Add(rectangle);
                }
                
            }
            
            
        }
        }
    }

