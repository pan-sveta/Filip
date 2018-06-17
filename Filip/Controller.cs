using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Filip
{
    static class Controller
    {
        public static FilipRobot FilipRobot;
        static Canvas Canvas;
        static FieldMap fieldMap;

        static Controller()
        {
            FilipRobot = new FilipRobot();
        }

        public static void SetCanvas(Canvas canvas)
        {
            Canvas = canvas;
            Canvas.Children.Add(FilipRobot.Rectangle);
            Canvas.SetZIndex(FilipRobot.Rectangle, 99);

            fieldMap = new FieldMap();
            List<Rectangle> recList = fieldMap.GetRectangles();

            foreach (Rectangle rectangle in recList)
            {
                Canvas.Children.Add(rectangle);
            }
        }
    }
}
