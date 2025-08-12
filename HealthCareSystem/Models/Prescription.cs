using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCareSystem.Models
{
    public class Prescription
    {
        public int Id { get; }
        public int PatientId { get;  }
        public string MedicationName { get;  }
        public DateTime DateIssued { get;  }

        public Prescription(int id, int patientId, string medicationName,  DateTime dateIssued)
        {
            Id = id;
            PatientId = patientId;
            MedicationName = medicationName;
            DateIssued = dateIssued;        }
    }
}
