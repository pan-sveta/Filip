using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Filip
{
    class Field
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Rectangle Rectangle { get; private set; }

        public Field(int x, int y)
        {
            X = x;
            Y = y;
            Rectangle = new Rectangle
            {
                Width = 60,
                Height = 60,
                Fill = Brushes.Red,
                Stroke = Brushes.Black,
                Margin = new System.Windows.Thickness(x * 60, y * 60, 0, 0)
            };
        }
    }
}
