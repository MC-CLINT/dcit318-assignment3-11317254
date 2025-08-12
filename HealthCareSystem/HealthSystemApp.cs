using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCareSystem.Models;

namespace HealthCareSystem
{
    public class HealthSystemApp
    {
        private Repository<Patient> _patientRepo = new();
        private Repository<Prescription> _prescriptionRepo = new();
        private Dictionary<int, List<Prescription>> _prescriptionMap = new();

        // Seed sample data
        public void SeedData()
        {
            _patientRepo.Add(new Patient(101, "Jackie Appiah", 28, "Female"));
            _patientRepo.Add(new Patient(102, "Clinton Vidam", 35, "Male"));
            _patientRepo.Add(new Patient(103, "Nadia Buari", 42, "Female"));

            _prescriptionRepo.Add(new Prescription(1, 101, "Amoxicillin", DateTime.Today.AddDays(-10)));
            _prescriptionRepo.Add(new Prescription(2, 102, "Ibuprofen", DateTime.Today.AddDays(-5)));
            _prescriptionRepo.Add(new Prescription(3, 101, "Paracetamol", DateTime.Today.AddDays(-2)));
            _prescriptionRepo.Add(new Prescription(4, 103, "Metformin", DateTime.Today.AddDays(-7)));
            _prescriptionRepo.Add(new Prescription(5, 102, "Lisinopril", DateTime.Today.AddDays(-3)));
        }

       
        public void BuildPrescriptionMap()
        {
            var allPrescriptions = _prescriptionRepo.GetAll();

            foreach (var prescription in allPrescriptions)
            {
                if (!_prescriptionMap.ContainsKey(prescription.PatientId))
                {
                    _prescriptionMap[prescription.PatientId] = new List<Prescription>();
                }

                _prescriptionMap[prescription.PatientId].Add(prescription);
            }
        }

       
        public void PrintAllPatients()
        {
            var patients = _patientRepo.GetAll();
            Console.WriteLine("All Patients:");
            foreach (var patient in patients)
            {
                Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}, Age: {patient.Age}, Gender: {patient.Gender}");
            }
        }

        // Print prescriptions for a specific patient
        public void PrintPrescriptionsForPatient(int patientId)
        {
            if (_prescriptionMap.TryGetValue(patientId, out var prescriptions))
            {
                Console.WriteLine($"\nPrescriptions for Patient ID {patientId}:");
                foreach (var p in prescriptions)
                {
                    Console.WriteLine($"- {p.MedicationName} issued on {p.DateIssued.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine($"\nNo prescriptions found for Patient ID {patientId}.");
            }
        }
    }






}
