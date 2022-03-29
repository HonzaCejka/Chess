using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class figure
    {
        public FigureType Type { get; set; }

        public figure()
        {
           
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
}
