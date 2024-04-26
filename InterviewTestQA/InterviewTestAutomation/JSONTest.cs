using System;
using System.Linq;
using System.IO;
using InterviewTestQA.InterviewTestAutomation.Model;
using Newtonsoft.Json;
using Xunit.Abstractions;
using InterviewTestQA.InterviewTestAutomation.Methods;

namespace InterviewTestQA
{
    public class JSONTest
    {
        JSONMethods _jsonMethods = new JSONMethods();

        [Fact]
        public void AssertCount()
        {      
            Assert.Equal(53, _jsonMethods.DeSerializeJSON().Count);
        }

        [Fact]
        public void LinqSortTopItemCostDescending()
        {
            var deserializedModel = _jsonMethods.DeSerializeJSON();

            JSONTestModel topItem = deserializedModel.OrderByDescending(deserializedModel => deserializedModel.Cost).FirstOrDefault();

            Assert.Equal(0, topItem.CountryId);

        }

        [Fact]
        public void LinqSum2016()
        {
            var deserializedModel = _jsonMethods.DeSerializeJSON();

            var totalCostFor2016 = deserializedModel
                .Where(deserializedModel => deserializedModel.YearId == "2016")
                .Sum(deserializedModel => deserializedModel.Cost);

            Assert.Equal((decimal)77911.3744561, totalCostFor2016);
        }
    }
}