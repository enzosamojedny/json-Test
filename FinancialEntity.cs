using Newtonsoft.Json;
using PersonBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PersonBuilder;
// usar newtonsoft para traer el nombre de la entity de db, y solo mandar el id por parametro a  FinancialEntity
namespace FinancialEntityBuilder
{
    public class FinancialEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }

        private static string jsonFilepath = "FinancialEntitiesDB.json";
        


        public FinancialEntity(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public static void CreateFinancialEntity(FinancialEntity financialEntity)
        {
            if (File.Exists(jsonFilepath))
            {
                List<FinancialEntity> financialList = new List<FinancialEntity>();
                
                string jsonData = File.ReadAllText(jsonFilepath);

            }
        }


        //metodos
        public static string GetEntityByID(int ID)
        {
            List<FinancialEntity> entities = JsonConvert.DeserializeObject<List<FinancialEntity>>(jsonData);
            string result = "";
           
           var foundEntity =  entities.Find(f => f.ID == ID);
            if(foundEntity is null)
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
