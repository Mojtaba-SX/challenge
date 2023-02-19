using System.Text.Json;
using challenge.Model;
using Microsoft.AspNetCore.Mvc;

namespace challenge.Controllers
{

    [ApiController]
    public class RectangleController : ControllerBase
    {

        private List<Rectangle> intersectiveRectangle;

        private readonly string DBPath = "db.json";

        public RectangleController()
        {
            string data = System.IO.File.ReadAllText(DBPath);
            if (data.Length == 0)
            {
                this.intersectiveRectangle = new List<Rectangle>();
            }
            else
            {
                List<Rectangle>? rectangles = System.Text.Json.JsonSerializer.Deserialize<List<Rectangle>>(data);
                this.intersectiveRectangle = rectangles == null ? new List<Rectangle>() : rectangles;
            }
        }


        [HttpPost("")]
        public string intersectionRectangle(RectangleDTO rectangleDTO)
        {
            Rectangle? main = rectangleDTO.main;
            IEnumerable<Rectangle>? testcaseRec = rectangleDTO.input;
            if (main != null && testcaseRec != null)
            {
                foreach (Rectangle testRectangle in testcaseRec)
                {
                    // U can use another method intersective(...) in Rectangle class!
                    if (main.intersective2(testRectangle))
                    {
                        intersectiveRectangle.Add(testRectangle);
                    }
                }
            }
            string data = JsonSerializer.Serialize(intersectiveRectangle);
            System.IO.File.WriteAllText(DBPath, data);
            return "Done!";
        }

        [HttpGet("")]
        public List<Rectangle> listOfREctangle()
        {
            string data = System.IO.File.ReadAllText(DBPath);
            if (data.Length == 0)
            {
                return new List<Rectangle>();
            }
            List<Rectangle>? rectangles = JsonSerializer.Deserialize<List<Rectangle>>(data);
            return rectangles == null ? new List<Rectangle>() : rectangles;
        }

    }

}