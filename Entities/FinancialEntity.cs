using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

// usar newtonsoft para traer el nombre de la entity de db, y solo mandar el id por parametro a  FinancialEntity
namespace Financial.Entities
{
    public class FinancialEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private static string jsonFilepath = Environment.GetEnvironmentVariable("FINANCIAL_PATH");



        public FinancialEntity(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public static void CreateFinancialEntity(FinancialEntity financialEntity)
        {
            HelperFns.Helper.WriteInDB(jsonFilepath, 2, null, financialEntity, null,null);
        }


        //metodos
        public static string GetEntityByID(int ID)
        {
            string jsonData = File.ReadAllText(jsonFilepath);
            List<FinancialEntity> entities = JsonConvert.DeserializeObject<List<FinancialEntity>>(jsonData);
            string result = "";

            var foundEntity = entities.Find(f => f.ID == ID);
            if (foundEntity is null)
            {
                return "Entity not found ";
            }
            return foundEntity.Name;
        }

        public string GetFinancialEntity()
        {
            return $"ID: {ID}, Entity name: {Name}";
        }
    }
}
