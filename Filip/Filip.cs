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
    class Filipus
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
        public Direction direction { get; private set; }
        public Rectangle rectangle { get; private set; }

        public Filipus()
        {
            rectangle = new Rectangle
            {
                Width = 20,
                Height = 20,
                Fill = Brushes.Yellow,
                Margin = new System.Windows.Thickness(20, 20, 0, 0)
            };

            X = 0;
            Y = 0;
            direction = Direction.V;
        }

        private void CorrectRectagle(int Xcor, int Ycor)
        {
            rectangle.Margin = new System.Windows.Thickness(Xcor*60 + 20, Ycor * 60 + 20, 0, 0);
        }

        public void Step()
        {
            switch (direction)
            {
                case Direction.S:
                    if (Y + 1 > 9)
                    {
                        throw new CannotMakeStepExeption();
                    }
                    else
                    {
                        Y++;
                    }
                    break;
                case Direction.V:
                    if (X + 1 > 9)
                    {
                        throw new CannotMakeStepExeption();
                    }
                    else
                    {
                        X++;
                    }
                    break;
                case Direction.J:
                    if (Y - 1 < 0)
                    {
                        throw new CannotMakeStepExeption();
                    }
                    else
                    {
                        Y--;
                    }
                    break;
                case Direction.Z:
                    if (X - 1 < 0)
                    {
                        throw new CannotMakeStepExeption();
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
            switch (direction)
            {
                case Direction.S:
                    direction = Direction.V;
                    break;
                case Direction.V:
                    direction = Direction.J;
                    break;
                case Direction.J:
                    direction = Direction.Z;
                    break;
                case Direction.Z:
                    direction = Direction.S;
                    break;
            }
        }
    }

    public class CannotMakeStepExeption : Exception
    {
        public CannotMakeStepExeption()
        {
        }
        public CannotMakeStepExeption(string message)
        : base(message)
        {
        }

        public CannotMakeStepExeption(string message, Exception inner)
            : base(message, inner)
        {
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
