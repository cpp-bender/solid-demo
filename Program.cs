namespace SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 -  Single Responsibility Principle
            Logger.Log("SOLID: Single Responsibility Principle " + (char)171);
            var calorieTracker = new CalorieTracker(5000);
            calorieTracker.TrackCalories(52000);

            Logger.Log("-------------------------------------------");

            // 2 - Open Closed Principle
            Logger.Log("SOLID: Open Closed Principle " + (char)171);
            var quiz = new Quiz();
            quiz.PrintQuiz(new CPlusPlus());

            Logger.Log("-------------------------------------------");

            //3 - Liskov Subsitution Principle
            Logger.Log("SOLID: Liskov Subsitution Principle " + (char)171);
            var shape0 = new Rectangle(10, 10);
            var shape1 = new Square(5);
            var shape2 = new Sphere(4);

            var h = new Helper();

            shape0.PrintArea();
            shape1.PrintArea();
            shape2.PrintArea();

            Logger.Log("-------------------------------------------");

            h.PrintName(shape0);
            h.PrintName(shape1);
            h.PrintName(shape2);

            Logger.Log("-------------------------------------------");

        }
    }

    #region SINGLE RESPONSIBILITY

    class CalorieTracker
    {
        public int maxCalories;

        public CalorieTracker(int cals)
        {
            maxCalories = cals;
        }

        public void TrackCalories(int cals)
        {
            if (maxCalories < cals)
            {
                Logger.Log("Cals exceeded");
            }
        }
    }

    static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    #endregion

    #region OPEN CLOSED

    class Quiz
    {
        public void PrintQuiz(Language lang)
        {
            lang.Answer();
        }
    }

    interface Language
    {
        void Answer();
    }

    class JS : Language
    {
        public void Answer()
        {
            Logger.Log("I LOVE JS");
        }
    }

    class CSharp : Language
    {
        public void Answer()
        {
            Logger.Log("I LOVE C#");
        }
    }

    class CPlusPlus : Language
    {
        public void Answer()
        {
            Logger.Log("I LOVE C++");
        }
    }

    #endregion

    #region LISKOV SUBSTITUTION

    class Rectangle : Shape
    {
        private int x, y;

        public Rectangle(int x, int y)
        {
            name = "Rect";
            this.x = x;
            this.y = y;
        }
        public override void PrintArea()
        {
            Logger.Log($"Rectangle | {x} by {y} Area: " + (x * y).ToString());
        }
    }

    class Square : Shape
    {
        private int x;

        public Square(int x)
        {
            name = "Square";
            this.x = x;
        }

        public override void PrintArea()
        {
            Logger.Log($"Square | {x} Area: " + (x * x).ToString());
        }
    }

    class Sphere : Shape
    {
        const float PI = 3.14f;
        private int r;

        public Sphere(int r)
        {
            name = "Sphere";
            this.r = r;
        }

        public override void PrintArea()
        {
            Logger.Log($"Sphere | {r} Area: " + (PI * r * r).ToString());
        }
    }

    class Shape
    {
        public string name = string.Empty;
        public virtual void PrintArea() {; }
    }

    class Helper
    {
        public void PrintName(Shape shape) { Logger.Log(shape.name); }
    }

    #endregion

    #region INTERFACE SEGREGATION
    
    // Divide interfaces
    class Character : MovingEntity
    {
        public void Attack()
        {
        }

        public void Damage()
        {
        }

        public void Move()
        {
        }
    }

    class Turret : Entity
    {
        public void Damage()
        {
        }
    }

    interface Entity
    {
        void Damage();
    }

    interface MovingEntity : Entity
    {
        void Move();
        void Attack();
    }

    #endregion

    #region DEPENDENCY INVERSION

    // Decrease dependencies

    class Store
    {

    }

    class Stripe
    {
        public void MakePayment(int amount)
        {
            Logger.Log($"{amount} br. money deposited!");
        }
    }

    class Paypal
    {

    }

    #endregion
}