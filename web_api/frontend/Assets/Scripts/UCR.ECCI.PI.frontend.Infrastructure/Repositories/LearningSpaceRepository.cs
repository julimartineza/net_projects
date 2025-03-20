using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Newtonsoft.Json;
using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using System.Net.Http;


namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    internal class LearningSpaceRepository : ILearningSpaceRepository
    {
        HttpClient httpClient = new HttpClient();
        public Learning_Space GetLearningSpace(string name)
        {
            int defaultScale = 1;
            // Request for the api
            var response = httpClient.GetAsync($"https://localhost:7003/listlearningspace?id={name}").Result; // TODO: Cambiar URL
            
            response.EnsureSuccessStatusCode();

            // Read JSON file
            var jsonContent = response.Content.ReadAsStringAsync().Result;
            var jsonData = JsonConvert.DeserializeObject<ListLearningSpaceResponse>(jsonContent);
            IEnumerable<LearningSpaceDto> learningSpaces = jsonData.LearningSpaces;
            Learning_Space learningSpace= new Learning_Space("",new Scale(defaultScale,defaultScale,defaultScale));

           
            foreach (var item in learningSpaces) {
                if (item.buildingId == name)
                {
                    Scale scale = new Scale(item.scaleX, item.scaleY, item.scaleZ);
                    learningSpace = new Learning_Space(item.name, scale);
                    return learningSpace;
                }
            }

            return learningSpace;
        }
    }
}