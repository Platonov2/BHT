using Newtonsoft.Json;

namespace DataBase
{
    public class Loader
    {
        private static readonly string jsonPath = "..\\..\\..\\..\\..\\data.json";

        public static List<Pallet> GetPallets()
        {
            using StreamReader reader = new(jsonPath);
            string json = reader.ReadToEnd();
            List<Pallet> pallets = JsonConvert.DeserializeObject<List<Pallet>>(json);

            return pallets;
        }
    }
}