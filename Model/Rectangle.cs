using System.Text.Json.Serialization;

namespace challenge.Model
{

    public class Rectangle
    {
        public int x { set; get; }
        public int y { set; get; }
        public int width { set; get; }
        public int height { set; get; }
        public DateTime time { get; set; }

        public bool intersective(Rectangle rectangle)
        {
            rectangle.time = DateTime.Now;
            int maxXMain = x + width;
            int maxYMain = y + height;

            if (width <= 0 || height <= 0 || rectangle.width <= 0 || rectangle.height <= 0)
            {
                return false;
            }

            if (rectangle.x > x && rectangle.x < maxXMain)
            {
                if (rectangle.y > y && rectangle.y < maxYMain)
                {
                    return true;
                }
                else
                {
                    int leftUpYPoint = rectangle.y + rectangle.height;
                    if (leftUpYPoint > y && rectangle.y < maxYMain)
                    {
                        return true;
                    }
                }
            }
            else if (rectangle.x <= x)
            {
                int rightButtonXPoint = rectangle.x + rectangle.width;
                if (rightButtonXPoint > x)
                {
                    if (rectangle.y >= y && rectangle.y < maxYMain)
                    {
                        return true;
                    }
                    else if (rectangle.y < y)
                    {
                        int rightTopYPoint = rectangle.y + rectangle.height;
                        if (rightTopYPoint > y)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        public bool intersective2(Rectangle rectangle)
        {
            int xMax = x + width;
            int yMax = y + height;
            int xMaxTest = rectangle.x + rectangle.width;
            int yMaxTest = rectangle.y + rectangle.height;
            rectangle.time = DateTime.Now;
            if (width <= 0 || height <= 0 || rectangle.width <= 0 || rectangle.height <= 0)
            {
                return false;
            }
            return xMaxTest > x && yMaxTest > y && xMax > rectangle.x && yMax > rectangle.y;
        }
    }
}