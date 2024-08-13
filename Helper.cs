using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//usamos todos los files para hacerlo dinamico
using PersonBuilder;
using FinancialEntityBuilder;
using AccountReconciler;
using TransferBuilder;
using Newtonsoft.Json;
namespace HelperFns
{

    public class Helper
    {
        public static string ReadDB(string jsonFilepath)
        {
            if (File.Exists(jsonFilepath))
            {
                string jsonData = System.IO.File.ReadAllText(jsonFilepath);
                return jsonData;
            }
            else
            {
                return "Could not find filepath";
            }
        }

        public static string WriteInDB(string jsonFilepath, byte targetDB, Person? person, FinancialEntity? financialEntity, Transfer? transfer) // targetDB recibiria un byte (8 bits) con el nombre (va de 0 a 255)
        { 
            if (File.Exists(jsonFilepath))
            {
                var dataFromDB = ReadDB(jsonFilepath);
                try
                {
                    //early return
                    if (person == null) return null;
                    if (financialEntity == null) return null;
                    if (transfer == null) return null;

                    //Person
                    if (targetDB == 1)
                    {
                        List<Person?> list;
                        list = JsonConvert.DeserializeObject<List<Person?>>(dataFromDB);
                        list.Add(person);
                        string updatedJson = JsonConvert.SerializeObject(list,Formatting.Indented);
                        File.WriteAllText(jsonFilepath, updatedJson);
                        return "Person successfully created";
                    }
                    
                    //FinancialEntity
                    else if (targetDB == 2)
                    {
                        List<FinancialEntity?> list;
                        list = JsonConvert.DeserializeObject<List<FinancialEntity?>>(dataFromDB);
                        list.Add(financialEntity);
                        string updatedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                        File.WriteAllText(jsonFilepath, updatedJson);
                        return "Financial institution successfully created";
                    }
                    
                    // Transfer
                    else if (targetDB == 3)
                    {

                    }
                    else
                    {
                        throw new ArgumentException("Something happened with targetDB");
                    }
                }
                catch
                {
                    throw new ArgumentException("Oops. Something happened");
                }

            }
            else
            {
                return "Could not find file;";
            }
            return null;
        }
    }
}
