using System.Collections.Generic;
using Newtonsoft.Json;
using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using System.Net.Http;
using System;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    internal class BuildingRepository : IBuildingRepository
    {
        HttpClient httpClient = new HttpClient();
        public List<Building> GetBuildings()
        {
            List<Building> buildings = new List<Building>();

            // Request for the api
            var response = httpClient.GetAsync("https://localhost:7003/listbuildings").Result;
            response.EnsureSuccessStatusCode();

            // JsonFile conversion to a readable object
            var jsonContent = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(jsonContent);
            var jsonData = JsonConvert.DeserializeObject<BuildingListDto>(jsonContent);
            var results = jsonData.buildings;
            foreach (var result in results)
            {

                Location location = new Location(result.locationx, result.locationy, result.locationz);
                Rotation rotation = new Rotation(result.rotationw, result.rotationx, result.rotationy, result.rotationz);
                Scale scale = new Scale(result.scalex, result.scaley, result.scalez);
                Characteristics characteristics = new Characteristics(result.name, result.description, result.id, result.color, result.acronym);

                Building building = new Building(result.status, result.typeBuilding, scale, rotation, location, characteristics, result.floors);
                buildings.Add(building);

            }
            return buildings;
        }
    }
}