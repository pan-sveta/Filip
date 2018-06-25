using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Filip
{
    class Field
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Rectangle Rectangle { get; private set; }
        private FieldType fieldType;
        public FieldType FieldType
        {
            get
            {
                return fieldType;
            }
            private set
            {
                fieldType = value;
                UpdateRectangleView();
            }
        }

        private void UpdateRectangleView()
        {
            switch (FieldType)
            {
                case FieldType.Blank:
                    Rectangle.Fill = Brushes.Gray;
                    Rectangle.Stroke = Brushes.Black;
                    break;
                case FieldType.Wall:
                    Rectangle.Fill = Brushes.DarkOrange;
                    Rectangle.Stroke = Brushes.OrangeRed;
                    break;
            }
        }

        public Field(int x, int y)
        {
            X = x;
            Y = y;
            Rectangle = new Rectangle
            {
                Width = 60,
                Height = 60,
                Fill = Brushes.Gray,
                Stroke = Brushes.Black,
                Margin = new System.Windows.Thickness(x * 60, y * 60, 0, 0)
            };
            Rectangle.MouseUp += Rectangle_MouseUp;
            Rectangle.MouseEnter += Rectangle_MouseEnter;
            Rectangle.MouseLeave += Rectangle_MouseLeave;
            FieldType = FieldType.Blank;
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle.Stroke = Brushes.Black;
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle.Stroke = Brushes.Red;
        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch (FieldType)
            {
                case FieldType.Blank:
                    FieldType = FieldType.Wall;
                    break;
                case FieldType.Wall:
                    FieldType = FieldType.Blank;
                    break;
            }
        }
    }

    enum FieldType
    {
        Blank,
        Wall
    }
}
