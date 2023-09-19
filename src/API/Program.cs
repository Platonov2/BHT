using DataBase;

namespace API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Загрузка данных
            List<Pallet> pallets = Loader.GetPallets();



            //                              ЗАДАНИЕ 1
            Console.WriteLine("\t\tЗАДАНИЕ 1");

            // Группировка и сортировка
            var grouped1 = pallets.GroupBy(pallet => pallet.ExpirationDate)
                                 .OrderBy(group => group.Key)
                                 .ToDictionary(group => group.Key, group => group.OrderBy(x => x.TotalWeight).ToList());



            // Визуализация
            foreach (var nameGroup in grouped1)
            {
                Console.WriteLine(nameGroup.Key);
                foreach (var pallet in nameGroup.Value)
                {
                    Console.WriteLine("\tId паллеты: " + pallet.Id + " \tСуммарный вес: " + pallet.TotalWeight);
                }
            }
            Console.WriteLine();



            //                              ЗАДАНИЕ 2
            Console.WriteLine("\t\tЗАДАНИЕ 2");

            // Сортировка и выборка
            var sorted2 = pallets.OrderByDescending(x => x.boxes.Max(y => y.ExpirationDate)).Take(3).OrderBy(z => z.TotalVolume);

            // Взуализация
            foreach (var pallet in sorted2)
            {
                Console.WriteLine("Id паллеты: " + pallet.Id + " \tМакс. срок годности содержащейся коробки: " + pallet.boxes.Max(y => y.ExpirationDate)
                               + " \tСумм. объём палеты: " + pallet.TotalVolume);
            }
        }
    }
}