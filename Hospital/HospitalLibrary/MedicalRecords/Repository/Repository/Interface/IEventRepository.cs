﻿using Hospital_library.MedicalRecords.Model.Events;

namespace Hospital_library.MedicalRecords.Repository.Repository.Interface
{
    public interface IEventRepository 
    {
        AppointmentEvent AddEvent(AppointmentEvent e);
        
    }
}
