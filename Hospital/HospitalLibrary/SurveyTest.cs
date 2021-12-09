using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using HospitalLibrary.MedicalRecords.Model;
using HospitalAPI.DTO.SurveyDTO;
using Newtonsoft.Json;
using System.Net.Http;

namespace HospitalIntegrationTests
{
    public class SurveyTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;

        public SurveyTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public async Task Checks_Successful_Taken_Survey(List<TakeSurveyDTO> surveyQuestions, int notExpectedRate)
        {
            var json = JsonConvert.SerializeObject(surveyQuestions);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/survey/TakeSurvey";

            var response = await injection.Client.PostAsync(url, data);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<SurveyQuestion>>(resultString);

            foreach (var r in result)
            {
                Assert.NotEqual(r.Rate, notExpectedRate);
                Assert.NotNull(r.PersonId);
            }
        }

        public static IEnumerable<object[]> Data()
        {
            var retVal = new List<object[]>();

            Patient patient = new Patient();
            patient.Id = 1;

            TakeSurveyDTO takeSurveyDTOHospital = new TakeSurveyDTO("1", "Question 1", 5, HospitalLibrary.MedicalRecords.Model.Enums.SurveyQuestionCategory.hospital);
            TakeSurveyDTO takeSurveyDTOApplication = new TakeSurveyDTO("1", "Question 2", 5, HospitalLibrary.MedicalRecords.Model.Enums.SurveyQuestionCategory.application);
            TakeSurveyDTO takeSurveyDTOStaff = new TakeSurveyDTO("1", "Question 3", 5, HospitalLibrary.MedicalRecords.Model.Enums.SurveyQuestionCategory.staff);
            List<TakeSurveyDTO> Survey = new List<TakeSurveyDTO> { takeSurveyDTOHospital, takeSurveyDTOApplication, takeSurveyDTOStaff };

            int notExpectedRate = 0;

            retVal.Add(new object[] { Survey, notExpectedRate });
            return retVal;
        }
    }
}