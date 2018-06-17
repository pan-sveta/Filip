using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Filip
{
    class FieldMap
    {
        Field[,] fieldMapArray;

        public FieldMap()
        {
            fieldMapArray = new Field[10,10];

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    fieldMapArray[x, y] = new Field(x, y);
                }
            }
        }

        public List<Rectangle> GetRectangles()
        {
            List<Rectangle> recList = new List<Rectangle>();
            foreach (Field field in fieldMapArray)
            {
                recList.Add(field.Rectangle);
            }
            return recList;
        }

    }
}
