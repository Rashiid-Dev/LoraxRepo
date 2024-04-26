using InterviewTestQA.InterviewTestAutomation.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTestQA.InterviewTestAutomation.Methods
{
    class JSONMethods
    {
        public List<JSONTestModel> DeSerializeJSON() 
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            var jsonLocation = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(currentDirectory)));

            var jsonFile = File.ReadAllText($"{jsonLocation}/InterviewTestAutomation/Data/Cost Analysis.json");

            List<JSONTestModel> deserializedModel = JsonConvert.DeserializeObject<List<JSONTestModel>>(jsonFile);

            return deserializedModel;
        }

    }
}
