using System.Collections.Generic;
using Newtonsoft.Json;
using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using System.Net.Http;
using System;
using System.Diagnostics;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    internal class TreeRepository : ITreeRepository
    {
        private readonly HttpClient httpClient = new HttpClient();

        public List<Tree> GetTrees()
        {
            List<Tree> trees = new List<Tree>();

            try
            {
                // Request to the API endpoint
                var response = httpClient.GetAsync("https://localhost:7003/listtrees").Result;
                response.EnsureSuccessStatusCode();

                // Parse JSON content
                var jsonContent = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(jsonContent);
                var jsonData = JsonConvert.DeserializeObject<TreeListDto>(jsonContent);

                // Convert the JSON data into domain objects
                foreach (var result in jsonData.trees)
                {
                    //Console.WriteLine(result.Type);
                    Tree tree = new Tree(result.Id, result.LocationX, result.LocationY, result.LocationZ, result.Scale);
                    trees.Add(tree);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching trees: {ex.Message}");
            }

            return trees;
        }
    }

}
