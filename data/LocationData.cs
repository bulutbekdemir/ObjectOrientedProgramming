using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using personal_info.model;

namespace personal_info.data
{
    public class LocationData
    {
        private readonly List<City> cities;

        public LocationData(string filePath)
        {
            string json = File.ReadAllText(filePath);

            cities = JsonSerializer.Deserialize<List<City>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            ) ?? new List<City>();
        }

        public List<City> GetCities()
        {
            return cities;
        }

        public List<District> GetDistricts(int cityId)
        {
            City city = cities.FirstOrDefault(c => c.Id == cityId);

            return city?.Districts ?? new List<District>();
        }
    }
}