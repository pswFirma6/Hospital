using HospitalAPI.DTO.EventDTO;


namespace HospitalAPI.Validation
{
    public class EventValidation
    {
        public bool IsValid(EventAppointmentDTO dto)
        {

            if (dto.ApplicationName == null || dto.Name == null || dto.ApplicationName.Length < 0  || dto.Name.Length < 0 || dto.ClickTime == null || dto.TimeSpan <= 0)
            {
                return false;
            }

            return true;
        }

        public bool IsValidStep(EventStepDTO dto)
        {
            if (dto.AppointmentEventId <= 0  || dto.TimeSpan <= 0 || dto.Name == null || dto.Name.Length < 0 || dto.ClickTime  == null)
            {
                return false;
            }

            return true;
        }
    }
}
