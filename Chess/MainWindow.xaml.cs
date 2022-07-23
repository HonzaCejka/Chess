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
        Dictionary<string, int> columnsToIndex = new Dictionary<string, int>();
        Dictionary<string, int> rowsToIndex = new Dictionary<string, int>();
        Dictionary<int, string> columnsFromIndex = new Dictionary<int, string>();
        Dictionary<int, string> rowsFromIndex = new Dictionary<int, string>();
        List<Figure> figures = new List<Figure>();
        Figure SelectedFigure;

        public MainWindow()
        {
            InitializeComponent();
            FigureList();
            CreateDictionaries();
            TextVypis();
            RefreshBoard(true);
        }

        private void RefreshBoard(bool firstRender)
        {
            ChessBoardGrid.Children.Clear();
            DrawBoard(firstRender);
            DrawFigures(figures);
        }

        private void TextVypis()
        {
            vypis.Text = "";
            foreach (Figure figure in figures)
            {
                vypis.Text += figure.ToString() + "\n";
            }
        }
        private void FigureList()
        {
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
            int indexcol = columnsToIndex[figure.Position.Substring(0, 1)];
            int indexrow = rowsToIndex[figure.Position.Substring(1,1)];
            Grid.SetColumn(rectangle, indexcol);
            Grid.SetRow(rectangle,indexrow);
            ChessBoardGrid.Children.Add(rectangle);
            rectangle.Tag = figure;
            rectangle.MouseDown += Rectangle_MouseDown;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender;
            Figure figure = (Figure)rectangle.Tag;
            
            if (SelectedFigure == null)
            {
                SelectedFigure = figure;
                rectangle.Stroke = new SolidColorBrush(Colors.Lime);
                rectangle.StrokeThickness = 4;
                rectangle.Margin = new Thickness(0);
            }
            else if (SelectedFigure == figure)
            {
                rectangle.StrokeThickness = 0;
                rectangle.Margin = new Thickness(5);
                SelectedFigure = null;
            }
            else 
            {
                SelectedFigure.Position = figure.Position;
                figure.Position = "";
                SelectedFigure = null;
                RefreshBoard(false);
            }
            
            //MessageBox.Show($"klik na {figure}");
            
        }

        public void CreateDictionaries()
        {
            columnsToIndex.Add("A", 0);
            columnsToIndex.Add("B", 1);
            columnsToIndex.Add("C", 2);
            columnsToIndex.Add("D", 3);
            columnsToIndex.Add("E", 4);
            columnsToIndex.Add("F", 5);
            columnsToIndex.Add("G", 6);
            columnsToIndex.Add("H", 7);
            rowsToIndex.Add("8", 0);
            rowsToIndex.Add("7", 1);
            rowsToIndex.Add("6", 2);
            rowsToIndex.Add("5", 3);
            rowsToIndex.Add("4", 4);
            rowsToIndex.Add("3", 5);
            rowsToIndex.Add("2", 6);
            rowsToIndex.Add("1", 7);
            columnsFromIndex.Add(0, "A");
            columnsFromIndex.Add(1, "B");
            columnsFromIndex.Add(2, "C");
            columnsFromIndex.Add(3, "D");
            columnsFromIndex.Add(4, "E");
            columnsFromIndex.Add(5, "F");
            columnsFromIndex.Add(6, "G");
            columnsFromIndex.Add(7, "H");
            rowsFromIndex.Add(0, "8");
            rowsFromIndex.Add(1, "7");
            rowsFromIndex.Add(2, "6");
            rowsFromIndex.Add(3, "5");
            rowsFromIndex.Add(4, "4");
            rowsFromIndex.Add(5, "3");
            rowsFromIndex.Add(6, "2");
            rowsFromIndex.Add(7, "1");
        }

        public void DrawBoard(bool CreateGrid)
        {
            if (CreateGrid)
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
                        rectangle.Fill = new SolidColorBrush(Color.FromRgb(236, 236, 208));                   
                    }
                    else
                    {
                        rectangle.Fill = new SolidColorBrush(Color.FromRgb(119, 149, 87));
                    }
                    
                    Grid.SetColumn(rectangle, x);
                    Grid.SetRow(rectangle, y);

                    ChessBoardGrid.Children.Add(rectangle);
                }               
            } 
        }

        private void Board_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rectangle = (Rectangle)sender;
            //MessageBox.Show($"Klik na desku pole {rectangle.Tag}");
            if (SelectedFigure != null)
            {
                SelectedFigure.Position = rectangle.Tag.ToString();
                SelectedFigure = null;
                RefreshBoard(false);
            }
        }

        private void ChessBoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

