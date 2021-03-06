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
        public async Task Doctor_Priority_Request(FreeTermsRequestDTO freeTermsRequestDTO, FreeTerms expectedFreeTerms)
        {
            var json = JsonConvert.SerializeObject(freeTermsRequestDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment/priority";

            var response = await injection.Client.PostAsync(url, data);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FreeTerms>(resultString);

            Assert.NotNull(result);
            Assert.Equal(result.Date, expectedFreeTerms.Date);
            Assert.Equal(result.DoctorId, expectedFreeTerms.DoctorId);
        }

        [Theory]
        [MemberData(nameof(DatePriorityDataSuccessfully))]
        public async Task Date_Priority_Request(FreeTermsRequestDTO freeTermsRequestDTO, FreeTerms expectedFreeTerms)
        {
            var json = JsonConvert.SerializeObject(freeTermsRequestDTO);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "api/appointment/priority";

            var response = await injection.Client.PostAsync(url, data);

            response.EnsureSuccessStatusCode();

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<FreeTerms>(resultString);

            Assert.NotNull(result);
            Assert.Equal(result.Date, expectedFreeTerms.Date);
            Assert.Equal(result.DoctorId, expectedFreeTerms.DoctorId);
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
            

            retVal.Add(new object[] { freeTermsRequestDTO, expectedFreeTerms });
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
            FreeTerms expectedFreeTerms = new FreeTerms(date, 2, expectedTerms);


            retVal.Add(new object[] { freeTermsRequestDTO, expectedFreeTerms });
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
