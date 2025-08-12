using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Prescription
{
    private int v1;
    private int v2;
    private string v3;
    private DateTime dateTime;

    public Prescription(int v1, int v2, string v3, DateTime dateTime)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.dateTime = dateTime;
    }

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

   
    public void LoadPrescriptions(List<Prescription> allPrescriptions)
    {
        _prescriptionMap = allPrescriptions
            .GroupBy(p => p.PatientId)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

   
    public List<Prescription> GetPrescriptionsByPatientId(int patientId)
    {
        if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
        {
            return prescriptions;
        }

        return new List<Prescription>();
    }
}