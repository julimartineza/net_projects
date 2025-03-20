using System.Collections.Generic;
using System.Net.Http;
using UCR.ECCI.PI.frontend.Domain.Value_Objects;
using UCR.ECCI.PI.frontend.Unity.Domain;
using UCR.ECCI.PI.frontend.Unity.Infrastructure.Assets.Scripts.UCR.ECCI.PI.frontend.Infrastructure.Responses;
using Newtonsoft.Json;

namespace UCR.ECCI.PI.frontend.Unity.Infrastructure
{
    internal class LearningObjectRepository : ILearningObjectRepository
    {
        HttpClient httpClient = new HttpClient();

        public List<Learning_Object> GetLearningObject(string nameLS)
        {
            List<Learning_Object> learningObjects = new List<Learning_Object>();


            var response = httpClient.GetAsync($"https://localhost:7003/getlearningobjects?search={nameLS}").Result; // TODO: Revisar URL
            response.EnsureSuccessStatusCode();

            var jsonContent = response.Content.ReadAsStringAsync().Result;
            var jsonData = JsonConvert.DeserializeObject<ListLearningObjectsResponse>(jsonContent);
            IEnumerable<LearningObjectDto> learningObjectsDto = jsonData.LearningObjects;
            //Learning_Object learningObject = new Learning_Object("1", "1", new Scale(1, 1, 1), new Rotation(1, 1, 1, 1), new Location(1, 1, 1), "1");

            foreach (var value in learningObjectsDto)
            {
                Location location = new Location(value.locationX, value.locationY, value.locationZ);
                Rotation rotation = new Rotation(value.rotationW, value.rotationX, value.rotationY, value.rotationZ);
                Scale scale = new Scale(value.scaleX, value.scaleY, value.scaleZ);
                Learning_Object learningObject = new Learning_Object(value.id, value.typeLO, scale, rotation, location, value.nameLS);
                learningObjects.Add(learningObject);
            }

            return learningObjects;
        }
    }
}
