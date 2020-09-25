using System;
using System.Collections.Generic;

namespace Task_36
{
    class Program
    {
        static void Main(string[] args)
        {
            Aquarium aquarium = new Aquarium();
            bool exitOrEnter = true;

            Console.WriteLine("Сколько рыб у вас в аквариуме ? : ");
            int countFish = Convert.ToInt32(Console.ReadLine());
            aquarium.AddFish(countFish);

            Console.Clear();

            while (exitOrEnter)
            {
                aquarium.ShowAquarium();
                Console.WriteLine("\n\nВыберите что хотите сделать : \n\n1. Добавить рыбку в аквариум\n\n2. Убрать рыбку из аквариума\n\n3. Прокрутить время\n\n4. Выйти из приложения");
                
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Console.Write("Сколько рыб вы хотите добавить ? : ");
                        aquarium.AddFish(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 2:
                        Console.WriteLine("Введите номер рыбки которую хотите убрать из аквариума : ");
                        int numberFish = Convert.ToInt32(Console.ReadLine());

                        aquarium.DeleteFish(numberFish);
                        break;
                    case 3:
                        
                        break;                    
                    case 4:
                        exitOrEnter = false;
                        break;
                }
                aquarium.SkipTimeAllFish();

                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    class Aquarium
    {
        protected List<Fish> _fish = new List<Fish>();
        protected int _countFish;
        protected int _maxAge;
        public Aquarium()
        {
            Random rand = new Random();

            _countFish = rand.Next(1,10);
        }
        public void ShowAquarium()
        {
            for (int i = 0; i < _fish.Count; i++)
            {
                string liveOrDie = Convert.ToString(_fish[i].Age) + " лет";

                if (_fish[i].IsDie == true)
                {
                    liveOrDie = "Умерла";
                }
                Console.WriteLine($"номер рыбки {i}, {liveOrDie}, максимальный срок жизни {_fish[i].MaxAge}");
            }
        }        
        public void AddFish(int countFish)
        {
            for (int i = 0; i < countFish; i++)
            {
                _fish.Add(new Fish());
            }
        }
        public void DeleteFish(int numberFish)
        {
            _fish.RemoveAt(numberFish);
        }
        public void SkipTimeAllFish()
        {
            for (int i = 0; i < _fish.Count; i++)
            {
                _fish[i].SkipTime();
            }                
        }
    }
    class Fish : Aquarium
    {
        private int _age;        
        private bool _isDie = false;
        public bool IsDie
        {
            get
            {
                return _isDie;
            }
            private set
            {

            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            private set
            {

            }
        }
        public int MaxAge
        {
            get
            {
                return _maxAge;
            }
            private set
            {

            }
        }
        public Fish()
        {
            Random rand = new Random();

            _age = rand.Next(1, 10);
            _maxAge = rand.Next(15, 30);
        }
        public void SkipTime()
        {
            if (_age >= _maxAge)
            {
                _isDie = true;
            }
            else
            {
                _age += 1;
            }
        }
    }

}
