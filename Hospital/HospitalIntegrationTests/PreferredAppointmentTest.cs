using Hospital_library.MedicalRecords.Model;
using HospitalAPI.DTO;
using HospitalAPI.DTO.AppointmentDTO;
using HospitalAPI.ImplService;
using HospitalAPI.Repository;
using HospitalLibrary.GraphicalEditor.Model;
using HospitalLibrary.MedicalRecords.Model;
using HospitalLibrary.MedicalRecords.Model.Enums;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HospitalIntegrationTests
{
    public class PreferredAppointmentTest : IClassFixture<InjectionFixture>
    {
        private readonly InjectionFixture injection;
        public PreferredAppointmentTest(InjectionFixture injection)
        {
            this.injection = injection;
        }

        [Theory]
        [MemberData(nameof(DoctorPriorityDataSuccessfully))]
        public async Task Doctor_Priority_Request(FreeTermsRequestDTO freeTermsRequestDTO, AllFreeTerms expectedAllFreeTerms)
        {
            var json = JsonConvert.SerializeObject(freeTermsRequestDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment/priority";

            var response = await injection.Client.PostAsync(url, data);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AllFreeTerms>(resultString);

            Assert.NotNull(result);
            Assert.Equal(result.FreeTermsList[0].Date, expectedAllFreeTerms.FreeTermsList[0].Date);
            Assert.Equal(result.FreeTermsList[0].DoctorId, expectedAllFreeTerms.FreeTermsList[0].DoctorId);
            Assert.Equal(result.FreeTermsList[0].Terms.Count, expectedAllFreeTerms.FreeTermsList[0].Terms.Count);
        }

        [Theory]
        [MemberData(nameof(DatePriorityDataSuccessfully))]
        public async Task Date_Priority_Request(FreeTermsRequestDTO freeTermsRequestDTO, AllFreeTerms expectedAllFreeTerms)
        {
            var json = JsonConvert.SerializeObject(freeTermsRequestDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment/priority";

            var response = await injection.Client.PostAsync(url, data);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AllFreeTerms>(resultString);

            Assert.NotNull(result);
            Assert.Equal(result.FreeTermsList[0].Date, expectedAllFreeTerms.FreeTermsList[0].Date);
            Assert.Equal(result.FreeTermsList[0].DoctorId, expectedAllFreeTerms.FreeTermsList[0].DoctorId);
            Assert.Equal(result.FreeTermsList[0].Terms.Count, expectedAllFreeTerms.FreeTermsList[0].Terms.Count);
            Assert.Equal(result.FreeTermsList[1].DoctorId, expectedAllFreeTerms.FreeTermsList[1].DoctorId);
            Assert.Equal(result.FreeTermsList[1].Terms.Count, expectedAllFreeTerms.FreeTermsList[1].Terms.Count);
        }


        [Theory]
        [MemberData(nameof(DataBadRequest))]
        public async Task BadRequest(FreeTermsRequestDTO freeTermsRequestDTO)
        {
            var json = JsonConvert.SerializeObject(freeTermsRequestDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment/priority";

            var response = await injection.Client.PostAsync(url, data);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        public static IEnumerable<object[]> DoctorPriorityDataSuccessfully()
        {
            var retVal = new List<object[]>();

            Doctor doctor = new Doctor();
            doctor.Id = 1;
            FreeTermsRequestDTO freeTermsRequestDTO = new FreeTermsRequestDTO(
                    "01/12/2022", doctor.Id, "doctor"
                );

            //expected value
            List<string> expectedTerms = new List<string>{
                "07:00", "07:30",
                "08:00", "08:30",
                "09:00", "09:30",
                "10:00", "10:30",
                "11:00", "11:30",
                "12:00", "12:30",
                "13:00", "13:30",
                "14:00", "14:30",
                "15:00"
            };
            var dateString = "12/02/2022 12:00:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            FreeTerms expectedFreeTerms = new FreeTerms(date, doctor.Id, expectedTerms);
            List<FreeTerms> expectedAllFreeTermsList = new List<FreeTerms>() { expectedFreeTerms };

            AllFreeTerms expectedAllFreeTerms = new AllFreeTerms(expectedAllFreeTermsList);

            retVal.Add(new object[] { freeTermsRequestDTO, expectedAllFreeTerms });
            return retVal;
        }

        public static IEnumerable<object[]> DatePriorityDataSuccessfully()
        {
            var retVal = new List<object[]>();

            Doctor doctor = new Doctor();
            doctor.Id = 1;
            FreeTermsRequestDTO freeTermsRequestDTO = new FreeTermsRequestDTO(
                    "01/12/2022", doctor.Id, "date"
                );

            //expected value
            List<string> expectedTerms = new List<string>{
                "07:00", "07:30",
                "08:00", "08:30",
                "09:00", "09:30",
                "10:00", "10:30",
                "11:00", "11:30",
                "12:00", "12:30",
                "13:00", "13:30",
                "14:00", "14:30",
                "15:00"
            };
            var dateString = "12/01/2022 12:00:00 AM";
            DateTime date = DateTime.Parse(dateString,
                                      System.Globalization.CultureInfo.InvariantCulture);
            FreeTerms expectedFreeTerms1 = new FreeTerms(date, 2, expectedTerms);
            FreeTerms expectedFreeTerms2 = new FreeTerms(date, 3, expectedTerms);

            List<FreeTerms> expectedFreeTermsList = new List<FreeTerms>() { expectedFreeTerms1, expectedFreeTerms2 };
            AllFreeTerms expecetedAllFreeTerms = new AllFreeTerms(expectedFreeTermsList);

            retVal.Add(new object[] { freeTermsRequestDTO, expecetedAllFreeTerms });
            return retVal;
        }

        public static IEnumerable<object[]> DataBadRequest()
        {
            var retVal = new List<object[]>();

            Doctor doctor = new Doctor();
            doctor.Id = 1;
            FreeTermsRequestDTO freeTermsRequestDTO = new FreeTermsRequestDTO(
                    "01/12/2022", doctor.Id, "monkey"
                );

            retVal.Add(new object[] { freeTermsRequestDTO });
            return retVal;
        }
    }
}
