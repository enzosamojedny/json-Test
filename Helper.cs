﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//usamos todos los files para hacerlo dinamico
using Client.Entities;
using Transference.Entities;
using Reconciler.Entities;
using Financial.Entities;
using Newtonsoft.Json;

namespace HelperFns
{
    //hacer la logica para el autoincrement cuando se cree una nueva persona, y el saldo debe ser un numero random entre 10000 y 99999 (maybe)
    //hacer la logica para un update de persona
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
        // targetDB recibiria un byte (8 bits) con el nombre (va de 0 a 255)
        //implementar la creacion en db de reconciler
        public static string WriteInDB(string jsonFilepath, byte targetDB, Person? person, FinancialEntity? financialEntity, Transfer? transfer, ReconcileAccounts? reconciler) 
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
                        if (string.IsNullOrWhiteSpace(dataFromDB))
                        {
                            list = new List<Person?>();
                        }
                        else
                        {
                            list = JsonConvert.DeserializeObject<List<Person?>>(dataFromDB)?? new List<Person?>();
                        }
                        list.Add(person);
                        string updatedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
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
                        List<Transfer?> list;
                        list = JsonConvert.DeserializeObject<List<Transfer?>>(dataFromDB);
                        list.Add(transfer);
                        string updatedJson = JsonConvert.SerializeObject(list, Formatting.Indented);
                        File.WriteAllText(jsonFilepath, updatedJson);
                        return "Transfer successfully registered";
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
