using NETcourse.Classes;
using NETcourse.Collections;
using NETcourse.Exceptions;
using NETcourse.Factories;
using NETcourse.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NETcourse
{
    class Program
    {
        class CountryComparer : IComparer<Country>
        {
            Func<Country, Country, int> comparer;

            public CountryComparer(Func<Country, Country, int> comparerFunc)
            {
                this.comparer = comparerFunc;
            }

            public int Compare(Country x, Country y)
                => comparer.Invoke(x, y);            
        }

        static int CountryNameComparer(Country a, Country b) {
            if (a == null && b == null) return 0;
            if (a == null && b != null) return -1;
            if (a != null && b == null) return 1;
            return a.GetName().CompareTo(b.GetName());
        }

        static int CountryPopulationComparer(Country a, Country b)
        {
            if (a == null && b == null) return 0;
            if (a == null && b != null) return -1;
            if (a != null && b == null) return 1;
            return a.GetPopulation().CompareTo(b.GetPopulation());
        }

        static uint countryListSize = 10;
        static CountryComparer defaultComparer = new CountryComparer(CountryNameComparer);
        static TextWriter logFile = null;

        static void Main(string[] args)
        {
            try
            {
                ConfigureApplication("config.ini");
                if (countryListSize == 0)
                    Debug.Log("Country list size is set to 0. Is that right?", Debug.MessageLayer.WARNING);
            }
            catch (ConfigurationException e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
                Environment.Exit(-1);
            }

            CountryAbstractFactory factory = new DualisticCountryFactory();
            Confederacy<Country> countryList = new Confederacy<Country>("Republican Union");
            for (int i = 0; i < countryListSize; ++i)
                countryList.Add(factory.CreateRepublic());

            Console.WriteLine("Initial collection:");
            Console.WriteLine(countryList.ToString());

            Task<bool> x = countryList.Sort(defaultComparer);
            Console.WriteLine("Main thread is waiting for sort...");
            bool isFinished = x.Result;

            Console.WriteLine("Sorted by name:");
            Console.WriteLine(countryList.ToString());
            Console.ReadLine();

            logFile?.Close();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Confederacy<Country>), 
                new Type[] { typeof(AbsoluteMonarchy), typeof(DualisticMonarchy), typeof(ParliamentaryMonarchy),
                typeof(ParliamentaryRepublic), typeof(MixedRepublic), typeof(PresidentialRepublic)});
            using (FileStream fs = new FileStream(countryList.name + ".xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, countryList);
            }

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Confederacy<Country>),
                new Type[] { typeof(AbsoluteMonarchy), typeof(DualisticMonarchy), typeof(ParliamentaryMonarchy),
                typeof(ParliamentaryRepublic), typeof(MixedRepublic), typeof(PresidentialRepublic)});
            using (FileStream fs = new FileStream(countryList.name + ".json", FileMode.OpenOrCreate))
            {
                jsonSerializer.WriteObject(fs, countryList);
            }

            xmlSerializer = new XmlSerializer(typeof(AbsoluteMonarchy));
            jsonSerializer = new DataContractJsonSerializer(typeof(AbsoluteMonarchy));
            using (FileStream fs = new FileStream("arabia.xml", FileMode.Open))
            {
                Country xmlArabia = xmlSerializer.Deserialize(fs) as Country;
                Console.WriteLine(xmlArabia.ToString());
                Console.ReadLine();
            }
            using (FileStream fs = new FileStream("arabia.json", FileMode.Open))
            {
                Country jsonArabia = jsonSerializer.ReadObject(fs) as Country;
                Console.WriteLine(jsonArabia.ToString());
                Console.ReadLine();
            }

        }

        private static void ConfigureApplication(string configFileName)
        {
            try
            {
                TextReader configFile = new StreamReader(configFileName);
                string line;
                while ((line = configFile.ReadLine()) != null)
                {
                    string[] contents = Regex.Split(line, @"\s*=\s*");
                    if (contents.Length < 2)
                        throw new ConfigurationException("The configuration file line \'" + line + "\' seems to be invalid");
                    string configProperty = contents[0], configValue = contents[1];
                    switch (configProperty)
                    {
                        case "DefaultLogStream": ConfigureLogStream(configValue); break;
                        case "DefaultComparer": ConfigureComparer(configValue); break;
                        case "CountryListSize": ConfigureListSize(configValue); break;
                    }
                }
                configFile.Close();
            }
            catch (FileNotFoundException e)
            {
                throw new ConfigurationException("Configuration file not found", e);
            }
            
        }

        private static void ConfigureListSize(string configValue)
        {
            try
            {
                countryListSize = UInt32.Parse(configValue);
            }
            catch (Exception e)
            {
                throw new ConfigurationException("Error occured when parsing \'" + configValue + "\' to unsigned integer", e);
            }
        }

        private static void ConfigureComparer(string configValue)
        {
            switch(configValue.ToLower())
            {
                case "name": defaultComparer = new CountryComparer(CountryNameComparer); break;
                case "population": defaultComparer = new CountryComparer(CountryPopulationComparer); break;
                default: throw new ConfigurationException("Unknown comparement property \'" + configValue + "\'");
            }
        }

        private static void ConfigureLogStream(string configValue)
        {
            configValue = configValue.ToLower();
            if (configValue.Equals("console"))
                Debug.LogAction = Console.WriteLine;
            else
            {
                try
                {
                    logFile = new StreamWriter(configValue);
                    Debug.LogAction = logFile.WriteLine;
                }
                catch
                {
                    throw new ConfigurationException("File \'" + configValue + "\' is invalid or disk writing permission denied");
                }
            }
        }
    }
}
