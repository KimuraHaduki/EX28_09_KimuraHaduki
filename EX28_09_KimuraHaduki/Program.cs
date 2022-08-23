using System;

namespace EX28
{
    class Program
    {
        static void Main(string[] args)
        {
            TriangularPrism triangularPrism = new TriangularPrism();
            int number = (int)Input("計算方法を入力してください\n１：底辺、底面の高さ、高さ\n２：底面の3辺、高さ\n", 1, 2);

            switch (number)
            {
                case 1:
                    triangularPrism = new TriangularPrism(Input("\n\n底辺", 1, 1000), Input("底面の高さ", 1, 1000), Input("高さ", 1, 1000));
                    break;
                case 2:
                    triangularPrism = new TriangularPrism(Input("\n\n辺１", 1, 1000), Input("辺２", 1, 1000), Input("辺３", 1, 1000),Input("高さ",1,1000));
                    break ;

            }

            Console.WriteLine("\n三角柱\n表面積 :" + triangularPrism.GetSurface() + "cm²\n体積 :" + triangularPrism.GetVolume() + "cm³");
        }

        static float Input(string message, float min, float max)
        {
            while (true)
            {
                float number;
                Console.Write(message + "(" + min + "～" + max + ")  : ");
                try
                {
                    number = float.Parse(Console.ReadLine());


                    if (min <= number && number <= max)
                    {
                        return number;
                    }
                    else
                    {
                        Console.WriteLine("入力エラーです");
                    }

                }
                catch (Exception)
                {
                    Console.WriteLine("えらー");
                }
            }
        }
    }

    class TriangularPrism
    {
        float a;
        float b;
        float c;
        float bottom;

        float top;

        public TriangularPrism(float a,float b,float c,float t)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            float s = (a+b+c)/2;

            this.bottom = (float)Math.Sqrt(s * (s-a) * (s-b) * (s-c));
            this.top = t;
        }
        public TriangularPrism(float b, float h, float t)
        {
            this.a = b;
            this.b = h;
            this.c = (float)Math.Sqrt(a * a + b * b);
            this.bottom = a * b / 2;
            this.top = t;
        }

        public TriangularPrism()
        {

        }
        public float GetSurface()
        {
            return bottom * 2 + (a + b + c) * top;
        }

        public float GetVolume()
        {
            return bottom * top;
        }
    }
}