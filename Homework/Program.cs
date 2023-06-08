/*



 * Задание 4
Создать абстрактный базовый класс Worker (работника) с методом Print(). 
Создайте четыре производных класса: President, Security, Manager, Engineer. 
Переопределите метод Print() для вывода информации, соответствующей каждому типу работника.
 */


namespace Homework
{
    /*
     * Задание 1
    Запрограммируйте класс Money (объект класса оперирует одной валютой) для работы с деньгами.
    В классе должны быть предусмотрены поле для хранения целой части денег (доллары, евро, гривны и т.д.) 
    и поле для хранения копеек (центы, евроценты, копейки и т.д.).
    Реализовать методы для вывода суммы на экран, задания значений для частей. 
    На базе класса Money создать класс Product для работы с продуктом или товаром. 
    Реализовать метод, позволяющий уменьшить цену на заданное число.
    Для каждого из классов реализовать необходимые методы и поля.
    */

    public class Money
    {
        public ulong rubles { set; get; }
        public ushort pennies { set; get; }

        public Money()
        {
            this.rubles = 0;
            this.pennies = 0;
        }

        public Money(ulong rubles, ushort pennies)
        {
            try
            {
                if (pennies >= 100)
                {
                    throw new OverflowException($"ОШИБКА: копеек не может быть больше или равно 100! (Вы задали: {pennies})");
                }

                this.rubles = rubles;
                this.pennies = pennies;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static Money operator- (Money m, decimal money)
        {
            try
            {
                ulong rubles = (ulong) (m.rubles - Math.Round(money));
                ushort pennies = (ushort) (m.pennies - (money - Math.Round(money)) * 100);

                return new Money(rubles, pennies);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write($"Вы выходите за все разумные рамки! "); Console.ResetColor();
                return new Money(m.rubles, m.pennies);
            }
        }

        public static Money operator +(Money m, decimal money)
        {
            try
            {
                ulong rubles = (ulong)(m.rubles + Math.Round(money));
                ushort pennies = (ushort)(m.pennies + (money - Math.Round(money)) * 100);

                return new Money(rubles, pennies);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red; Console.Write($"Вы выходите за все разумные рамки! "); Console.ResetColor();
                return new Money(m.rubles, m.pennies);
            }
        }

        public override string ToString()
        {
            return $"{this.rubles} руб. {this.pennies} коп.";
        }
    }


    public class Product
    {
        private string name;
        private Money price;

        public Product(string name, Money price)
        {
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return $"{this.name} - {this.price}";
        }
    }




    /*
    * Задание 2
    Создать базовый класс «Устройство» и производные классы «Чайник», «Микроволновка», «Автомобиль», «Пароход». 
    С помощью конструктора установить имя каждого устройства и его характеристики.

    Реализуйте для каждого из классов методы:
    ■ Sound — издает звук устройства (пишем текстом в консоль);
    ■ Show — отображает название устройства;
    ■ Desc — отображает описание устройства.
    */

    public abstract class Device
    {
        protected string name;

        public abstract void Show();
        public abstract void Desc();
        public abstract void Sound();

        public Device(string name)
        {
            this.name = name;
        }
    }


    public class Kettle : Device
    {
        public Kettle(string name) : base(name) { }

        public override void Show()
        {
            Console.WriteLine(this.name);
        }

        public override void Desc()
        {
            Console.WriteLine("Электрический чайник — бытовой электрический прибор для нагревания и кипячения питьевой воды, работающий на электроэнергии.");
        }

        public override void Sound()
        {
            Console.WriteLine("*звук кипящей воды*");
        }
    }

    public class Microwave : Device
    {
        public Microwave(string name) : base(name) { }

        public override void Show()
        {
            Console.WriteLine(this.name);
        }

        public override void Desc()
        {
            Console.WriteLine("Микроволновая печь (микроволновка) или СВЧ-печь — электроприбор,\n" +
                              "позволяющий совершать разогрев водосодержащих веществ благодаря электромагнитному излучению дециметрового диапазона\n" +
                              "и предназначенный для быстрого приготовления, подогрева или размораживания пищи.");
        }

        public override void Sound()
        {
            Console.WriteLine("*звук трансформаторной будки*");
        }
    }

    public class Car : Device
    {
        public Car(string name) : base(name) { }

        public override void Show()
        {
            Console.WriteLine(this.name);
        }

        public override void Desc()
        {
            Console.WriteLine("Автомобиль — моторное безрельсовое дорожное и/или внедорожное, чаще всего автономное, транспортное средство,\n" +
                              "используемое для перевозки людей и/или грузов, имеющее от четырёх колёс.");
        }

        public override void Sound()
        {
            Console.WriteLine("*рёв мотора, вибрация, звук сцепления колёс с дорогой, звук разрезаемого кузовом потока воздуха, возможно грохот частей салона*");
        }
    }





    /*
    * Задание 3
    Создать базовый класс «Музыкальный инструмент» и производные классы «Скрипка», «Тромбон», «Укулеле», «Виолончель». 
    С помощью конструктора установить имя каждого музыкального инструмента и его характеристики.

    Реализуйте для каждого из классов методы:
    ■ Sound — издает звук музыкального инструмента (пишем текстом в консоль);
    ■ Show — отображает название музыкального инструмента;
    ■ Desc — отображает описание музыкального инструмента;
    ■ History — отображает историю создания музыкального инструмента.    
     */

    public abstract class MusicalInstrument
    {
        protected string name;

        public abstract void Show();
        public abstract void Desc();
        public abstract void History();
        public abstract void Sound();

        public MusicalInstrument(string name)
        {
            this.name = name;
        }
    }


    public class Violin : MusicalInstrument
    {
        public Violin(string name) : base(name) { }

        public override void Show()
        {
            Console.WriteLine(this.name);
        }

        public override void Desc()
        {
            Console.WriteLine("Скрипка — смычковый музыкальный инструмент с четырьмя струнами, настроенными по квинтам: Gм D1 A1 E2.\n" +
                              "Самая высокая регистровая разновидность скрипичного семейства, ниже которой располагаются альт, виолончель и контрабас.");
        }

        public override void History()
        {
            Console.WriteLine("Первые упоминания о скрипке содержат русские летописи и другие источники XVII века.");
        }

        public override void Sound()
        {
            Console.WriteLine("*скрип*");
        }
    }

    public class Trombone : MusicalInstrument
    {
        public Trombone(string name) : base(name) { }

        public override void Show()
        {
            Console.WriteLine(this.name);
        }

        public override void Desc()
        {
            Console.WriteLine("Тромбон — европейский духовой амбушюрный инструмент.\n" +
                              "Входит в оркестровую группу медных духовых музыкальных инструментов басово-тенорового регистра.");
        }

        public override void History()
        {
            Console.WriteLine("Появление тромбона относится к XV веку.");
        }

        public override void Sound()
        {
            Console.WriteLine("*дудение*");
        }
    }

    public class Ukulele : MusicalInstrument
    {
        public Ukulele(string name) : base(name) { }

        public override void Show()
        {
            Console.WriteLine(this.name);
        }

        public override void Desc()
        {
            Console.WriteLine("Укулеле — гавайская четырёхструнная разновидность гитары, используемая для аккордового сопровождения песен и игры соло.");
        }

        public override void History()
        {
            Console.WriteLine("Укулеле появилась на Гавайских островах во второй половине XIX века.");
        }

        public override void Sound()
        {
            Console.WriteLine("*дрожжание струны*");
        }
    }


    internal class Program
    {
        static void Main()
        {
            // ЗАДАНИЕ 1.
            //Money m = new Money(211, 546); // не получится
            //Console.WriteLine(m + "\n");

            //Money money = new Money(352, 32);
            //Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine($"ВСЕГО MONEY:\t\t{money}\n"); Console.ResetColor();


            //// оператор -
            //money -= 4294967296; // не получится
            //Console.WriteLine($"Money - 4294967296:\t{money}");

            //money -= 0.3523m; // и так тоже не получится
            //Console.WriteLine($"Money - 0.3523m:\t{money}\n");


            //money -= 10;
            //Console.WriteLine($"Money - 10:\t\t{money}");

            //money -= 0.28m; // decimal - точный тип данных для десятичных чисел, иначе вычисления некорректны
            //Console.WriteLine($"Money - 0.28:\t\t{money}");

            //money -= (decimal) 42.04;
            //Console.WriteLine($"Money - 42.04:\t\t{money}\n");


            //// оператор +
            //money += ulong.MaxValue; // не получится
            //Console.WriteLine($"Money + {ulong.MaxValue}:\t\t{money}");

            //money += decimal.MaxValue; // и так тоже не получится
            //Console.WriteLine($"Money + {decimal.MaxValue}:\t{money}\n");


            //money += 10;
            //Console.WriteLine($"Money + 10:\t\t{money}");

            //money += 0.28m;
            //Console.WriteLine($"Money + 0.28:\t\t{money}");

            //money += (decimal)42.04;
            //Console.WriteLine($"Money + 42.04:\t\t{money}");


            //// класс Product
            //Product[] products = 
            //    { 
            //    new Product("Хлеб", new Money(20, 99)),
            //    new Product("Молоко", new Money(106, 49)),
            //    new Product("Сосиски", new Money(356, 19))
            //    };

            //Console.WriteLine("\n\n\nПродукты: ");
            //foreach (Product product in products)
            //{
            //    Console.WriteLine(product);
            //}






            // ЗАДАНИЕ 2.
            //Device[] devices =
            //    {
            //    new Kettle("Электрочайник"),
            //    new Microwave("Микроволоновка"),
            //    new Car("Автомобиль")
            //    };

            //Console.WriteLine("Девайсы: ");
            //foreach (Device device in devices)
            //{
            //    device.Show();
            //    device.Desc();
            //    device.Sound();
            //    Console.WriteLine("\n");
            //}





            // ЗАДАНИЕ 3.
            MusicalInstrument[] musicalInstruments =
                {
                new Violin("Скрипка"),
                new Trombone("Тромбон"),
                new Ukulele("Укулеле")
                };

            Console.WriteLine("Музыкальные инструменты: ");
            foreach (MusicalInstrument musicalInstrument in musicalInstruments)
            {
                musicalInstrument.Show();
                musicalInstrument.Desc();
                musicalInstrument.History();
                musicalInstrument.Sound();
                Console.WriteLine("\n");
            }
        }
    }
}