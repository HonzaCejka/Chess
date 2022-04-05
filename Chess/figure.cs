using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class figure
    {
        private List<string> numbers = new List<string>() {"1", "2", "3", "4", "5", "6", "7", "8"};
        private List<string> letters = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
        private string position ="";

        public FigureType Type { get; }
        public string Position
        {
            set
            {
                if (string.IsNullOrEmpty(value))    //hodnota v proměnné value je null nebo ""
                {
                    position = value;
                }
                else if (value.Length == 2)
                {
                    if (letters.Contains(value.Substring(0, 1).ToUpper()) && numbers.Contains(value.Substring(1,1)))  //druhý znak je v listu numbers a první znak je v listu letters
                    {
                        position = value;
                    }
                    else
                    {
                        throw new Exception("Figure position value has to be valid chess position!");
                    }
                }
                else
                {
                    throw new Exception("Figure position value has to be 2 letters valid chess position!");
                }
            }
            get => position;     
        }
        public FigureColor Color { get; }

        public figure(FigureType type, FigureColor color)
        {
            Type = type;
            Color = color;
        }

        public figure(FigureType type, string position, FigureColor color)
        {
            Type = type;
            Position = position;
            Color = color;
        }
    }

    public enum FigureType 
    { 
        Pawn, //pěšec
        Rook, //věž
        Knight, //jezdec
        Bishop, //střelec
        Queen, //Dáma
        King //král
    }
    public enum FigureColor
    {
        white,black
    }
}
