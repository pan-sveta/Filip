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
        public static FieldMap FieldMap;

        static Controller()
        {
            FilipRobot = new FilipRobot();
        }

        public static void SetCanvas(Canvas canvas)
        {
            Canvas = canvas;
            Canvas.Children.Add(FilipRobot.Rectangle);
            Canvas.SetZIndex(FilipRobot.Rectangle, 99);

            FieldMap = new FieldMap();
            List<Rectangle> recList = FieldMap.GetRectangles();

            foreach (Rectangle rectangle in recList)
            {
                Canvas.Children.Add(rectangle);
            }
        }
    }
}
