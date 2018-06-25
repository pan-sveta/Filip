using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Filip
{
    class FilipRobot
    {
        private int x;
        public int X
        {
            get { return x; }
            set
            {
                CorrectRectagle(value, Y);
                x = value;
            }
        }
        private int y;
        public int Y
        {
            get { return y; }
            set
            {
                CorrectRectagle(X, value);
                y = value;
            }
        }
        public Direction Direction { get; private set; }
        public Rectangle Rectangle { get; private set; }

        public FilipRobot()
        {
            Rectangle = new Rectangle
            {
                Width = 20,
                Height = 20,
                Fill = Brushes.Yellow,
                Margin = new System.Windows.Thickness(20, 20, 0, 0)
            };

            X = 0;
            Y = 0;
            Direction = Direction.V;
        }

        private void CorrectRectagle(int Xcor, int Ycor)
        {
            Rectangle.Margin = new System.Windows.Thickness(Xcor * 60 + 20, Ycor * 60 + 20, 0, 0);
        }

        public void Step()
        {
            switch (Direction)
            {
                case Direction.S:
                    if (Y + 1 > 9)
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else if (Controller.FieldMap.IsWall(X, Y + 1))
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else
                    {
                        Y++;
                    }
                    break;
                case Direction.V:
                    if (X + 1 > 9)
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else if (Controller.FieldMap.IsWall(X + 1, Y))
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else
                    {
                        X++;
                    }
                    break;
                case Direction.J:
                    if (Y - 1 < 0)
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else if (Controller.FieldMap.IsWall(X, Y - 1))
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else
                    {
                        Y--;
                    }
                    break;
                case Direction.Z:
                    if (X - 1 < 0)
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else if (Controller.FieldMap.IsWall(X - 1, Y))
                    {
                        throw new Exception("Nelze udělat krok. V čele je zeď.");
                    }
                    else
                    {
                        X--;
                    }
                    break;
            }
        }

        public void Turn()
        {
            switch (Direction)
            {
                case Direction.S:
                    Direction = Direction.Z;
                    break;
                case Direction.Z:
                    Direction = Direction.J;
                    break;
                case Direction.J:
                    Direction = Direction.V;
                    break;
                case Direction.V:
                    Direction = Direction.S;
                    break;
            }
        }
    }

    public enum Direction
    {
        S,
        V,
        J,
        Z
    }
}
