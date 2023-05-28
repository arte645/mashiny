using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mashiny
{
    internal class Program
    {
        public class Car
        {
            public int id;
            public string color;
            public string marka;

            public Car Constract(int id, string color, string marka)
            {
                this.id = id;
                this.color = color;
                this.marka = marka;
                return this;
            }
        }

        public class Person
        {
            public int id;
            public string name;

            public Person Constract(int id, string name)
            {
                this.id = id;
                this.name = name;
                return this;
            }
        }
        static void Main(string[] args)
        {
            /*Два класса, первый класс описание машины( идентификатор, цвет, марка)
            Второй класс айди машины и владельцы( айди машины, ФИО владельца)
            С использованием запросов необходимо:
            Выполнить отбор машин по заданной марке,
            сгруппировать владельцев по идентификатору машины(машинк- владельцы)*/

            List<Person> list = new List<Person>();
            Person potato = new Person().Constract(1,"картошка");
            Person potato1 = new Person().Constract(2, "картошка1");
            Person potato2 = new Person().Constract(1, "картошка2");
            Person potato3 = new Person().Constract(3, "картошка3");
            list.Add(potato);
            list.Add(potato1);
            list.Add(potato2);
            list.Add(potato3);

            List<Car> cars = new List<Car>();
            Car car= new Car().Constract(1, "синий","жигуль");
            Car car1 = new Car().Constract(2, "красный", "уазик");
            Car car2 = new Car().Constract(3, "вишнёвый", "жигуль");
            cars.Add(car);
            cars.Add(car1);
            cars.Add(car2);

            string marka = "жигуль";

            List<Car> right_cars= (from cr in cars
                                  where cr.marka==marka
                                  select cr).ToList();

            foreach (var i in right_cars)
            {
                Console.WriteLine($"{i.marka}: айдишник-{i.id}, цвет-{i.color}");
            }

            Console.WriteLine();

            var maker = from para in list
                        group para.name by para.id into g
                        select new {id=g.Key, name = from pers in g 
                                                     select pers };
            foreach (var z in maker)
            {
                Console.Write(z.id+":");
                foreach (var pers in z.name)
                {
                    Console.Write(pers+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
