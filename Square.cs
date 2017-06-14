using OpenGL;
using System;

namespace OpenGLTutorial1
{
    class Square
    {
        public float x, y;
        public Vector3 size;
        public Vector3 color;
        public Vector2 dirrection;
        static Random rnd = new Random();
        const int bounds = 2;
        public Square(Square parent1, Square parent2)
        {
             this.x = (parent1.x + parent2.x ) / 2;
             this.y = (parent1.y + parent2.y) / 2;
             this.size = (parent1.size + parent2.size) / 2;
             this.dirrection = (parent1.dirrection + parent2.dirrection) / 2;
             this.color = (parent1.color + parent2.color) / 2;
        }
        public Square(float x, float y, float size, Vector3 color)
        {
            this.x = x;
            this.y = y;
            this.size = new Vector3(size, size, 1);
            this.color = color;
            this.dirrection = new Vector2(rnd.Next(-255, 256), rnd.Next(-255, 256)).Normalize() * 2;
            
        }
        public void move(float deltaTime)
        {
            x += dirrection.X * deltaTime;
            y += dirrection.Y * deltaTime;
        }
        public void CheckBounds()
        {
            if (Math.Abs(x) > bounds)
            {
                x = Math.Sign(x) * bounds;
                dirrection.X *= -1;
            }

            if (Math.Abs(y) > bounds)
            {
                y = Math.Sign(y) * bounds;
                dirrection.Y *= -1;
            }
        }
        public bool collide(Square other)
        {
             Vector2 dist = new Vector2(x - other.x, y - other.y);
            return (dist.Length <= (size.X + other.size.X));
              
             
        }
    }
}
