using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Services
{
    public class KeyService
    {

        private static string keysPath = ConfigurationManager.AppSettings["KeysDirectoryPath"] + "keys.json";
        private static string contractsPath = ConfigurationManager.AppSettings["KeysDirectoryPath"] + "contracts.json";
              

        public static string GetNextkey()
        {
            List<string> keys = DeSerializeKey();

            Random rnd = new Random();
            int r = rnd.Next(keys.Count);
            string key = keys[r];
            keys.Remove(key);

            SerializeKeys(keys);

            return key;
        }

        /// <summary>
        /// Serializing the list in single go
        /// </summary>
        private static void SerializeKeys(List<string> keys)
        {
            string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(keys, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(keysPath, outputJSON + Environment.NewLine);
        }


        /// <summary>
        /// Read serialized data into list of objects
        /// </summary>
        private static List<string> DeSerializeKey()
        {
            Console.WriteLine("Deserializing keys from file: "+ keysPath);

            if (File.Exists(keysPath))
            {
                Console.WriteLine("File exists");

                String JSONtxt = File.ReadAllText(keysPath);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(JSONtxt);
            }
            Console.WriteLine("File does not exist");

            return null;
        }

        /// <summary>
        /// Add contract address to contracts file
        /// </summary>
        /// <param name="contract"></param>
        /// <param name="address"></param>
        public static void AddContractAddress(int contract, string address)
        {
            List<string> keys = DeSerializeContracts();

            keys[contract] = address;

            SerializeContracts(keys);
        }

        /// <summary>
        /// Get smart contract address
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public static string GetContractAddress(int contract)
        {
            List<string> keys = DeSerializeContracts();

            return keys[contract];
        }

        /// <summary>
        /// Serializing the list in single go
        /// </summary>
        private static void SerializeContracts(List<string> keys)
        {
            string outputJSON = Newtonsoft.Json.JsonConvert.SerializeObject(keys, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(contractsPath, outputJSON + Environment.NewLine);
        }


        /// <summary>
        /// Read serialized data into list of objects
        /// </summary>
        private static List<string> DeSerializeContracts()
        {
            if (File.Exists(contractsPath))
            {
                String JSONtxt = File.ReadAllText(contractsPath);
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(JSONtxt);
            }

            return null;
        }

    }
}
