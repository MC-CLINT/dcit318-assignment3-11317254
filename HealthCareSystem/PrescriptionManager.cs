using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Prescription
{
    public int PatientId { get; set; }
    public string MedicationName { get; set; }
    public DateTime DateIssued { get; set; }

    public override string ToString()
    {
        return $"{MedicationName} issued on {DateIssued.ToShortDateString()}";
    }
}

public class PrescriptionManager
{
    private Dictionary<int, List<Prescription>> _prescriptionMap = new();

    // Populate the dictionary from a flat list
    public void LoadPrescriptions(List<Prescription> allPrescriptions)
    {
        _prescriptionMap = allPrescriptions
            .GroupBy(p => p.PatientId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Retrieve prescriptions for a specific patient
    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
        {
            return prescriptions;
        }

        return new List<Prescription>();
    }
}