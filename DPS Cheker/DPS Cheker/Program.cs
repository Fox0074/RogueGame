using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DPS_Cheker
{
    class Program
    {
        static int damage;
        static float hitChance;
        static float criticalChance;
        static float criticalModifly;
        public static Random random = new Random();

        static void Main(string[] args)
        {


            while (true)
            {
                Console.Write("Введите урон от оружия: ");
                damage = int.Parse(Console.ReadLine());
                Console.Write("Введите шанс попадания: ");
                hitChance = float.Parse(Console.ReadLine().Replace('.',','));
                Console.Write("Введите шанс крита: ");
                criticalChance = float.Parse(Console.ReadLine().Replace('.', ','));
                Console.Write("Введите крит модификатор: ");
                criticalModifly = float.Parse(Console.ReadLine().Replace('.', ','));
                Console.WriteLine();

                double sum = 0;
                for (int i = 0; i<=1000;i++)
                {
                    sum += GetDamage();
                }
                Console.WriteLine("Дпс оружия: " + sum/1000);


                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadLine();
                Console.Clear();
            }

        }

        private static int GetDamage()
        {
            if (random.Next(0, 101) <= (hitChance) * 100)
            {
                var damageInflicted = damage;

                damageInflicted = (random.Next(0, 101) <= (criticalChance ) * 100) ? (int)(damageInflicted * criticalModifly) : damageInflicted;

                return damageInflicted;
            }

            return 0;

        }

    }
}