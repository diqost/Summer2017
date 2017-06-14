using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenGL;
namespace OpenGLTutorial1
{
    class Reader
    {
        public static List<Square> readFromFile(string filename)
        {
            List<Square> result = new List<Square>();

            var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] args = line.Split(' ');
                    
                    float x = float.Parse(args[0]);
                    float y = float.Parse(args[1]);
                    float size = float.Parse(args[2]);
                    float r = int.Parse(args[3]) / 255f;
                    float g = int.Parse(args[4]) / 255f;
                    float b = int.Parse(args[5]) / 255f;
                    int max_children = int.Parse(args[6]);
                    int max_age = int.Parse(args[7]);
                    result.Add(new Square(x,y,size,new Vector3(r,g,b), max_age, max_children));
                }
            }
            return result;
        }
    }
}
