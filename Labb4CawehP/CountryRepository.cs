using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace Labb4CawehP
{
    public class CountryRepository
    {

        public List<Country> Countries { get; set; }

        public void ReadJson()
        {

            var assembly = typeof(CountryRepository).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{"rawData.json"}");

            using (var reader = new StreamReader(stream))
            {
                var countriesJson = JsonConvert.DeserializeObject<CountryRepository>(reader.ReadToEnd());
                Countries = countriesJson.Countries;
            }

            
        }

        public List<Country> GetCountries()
        {
            ReadJson();
            return Countries;
        }
    }
}
