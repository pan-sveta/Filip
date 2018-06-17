using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Filip
{
    class Controller
    {
        public Filipus filipus { get; private set; }

        Canvas canvas;
        FieldMap fieldMap;

        public Controller(Canvas canvas)
        {
            this.canvas = canvas;

            Inicialization();
        }

        private void Inicialization()
        {
            filipus = new Filipus();
            canvas.Children.Add(filipus.rectangle);
            Canvas.SetZIndex(filipus.rectangle, 99);
            

            fieldMap = new FieldMap();
            List<Rectangle> recList = fieldMap.GetRectangles();

            foreach (Rectangle rectangle in recList)
            {
                canvas.Children.Add(rectangle);
            }
        }
    }
}
