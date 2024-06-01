using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class ViewUser
    {
        private Patient patient;
        private DoctorService _doctorService;
        private RegistrationSectionService _registrationSectionService;
        private SectionService _sectionService;
        private HospitalInformationService _hospitalInformationService;

        public ViewUser(Patient patient)                                    
        {                                           
            this.patient = patient;
            _doctorService = new DoctorService();
            _registrationSectionService = new RegistrationSectionService();
            _sectionService = new SectionService();
            _hospitalInformationService = new HospitalInformationService();
        }

        public void MeniuUser()
        {
            Console.WriteLine("Apasati tasta 1 pentru a vedea problema de sanatate");
            Console.WriteLine("Apasati tasta 2 pentru a vedea sectia pe care se afla pacientul");
            Console.WriteLine("Apasati tasta 3 pentru a vedea gradul de problema al pacientului (bun-ok-rau)");
            Console.WriteLine("Apasati tasta 4 pentru a vedea programul de vizita si alte informatii de contact");
            Console.WriteLine("Apasati tasta 5 pentru a vedea la ce doctor se afla pacietnul");
        }

        public void play()
        {
            bool running = true;
            while(running)
            {
                MeniuUser();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        ShowHealthProblem();
                        break;

                    case "2":
                        ShowSectionPatient();
                        break;

                    case "3":
                        ShowDegreeProblemPacient();
                        break;

                    case "4":
                        ShowInformation();
                        break;

                    case "5":
                        ShowDoctorPatient();
                        break;
                }
            }
        }

        public void ShowHealthProblem()
        {
            Console.WriteLine($"Problema de sanatate este {patient.HealthProblem}");
        }

        public void ShowSectionPatient()
        {
            int idPatient = patient.IdPatient;

            int idSection = _registrationSectionService.FindIdSectionPatientByHisId(idPatient);

            Console.WriteLine($"Pacientul se afla pe sectia {_sectionService.FindSectionNameByIdSection(idSection)}");
        }

        public void ShowDegreeProblemPacient()
        {
            Console.WriteLine($"Pacientul are gradul de problema de {patient.DegreeProblem}");
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Mai multe informatii despre program de urgenta si vizita il puteti vedea aici: {_hospitalInformationService.AfisareHospitalInformation}");
        }

        public void ShowDoctorPatient()
        {
            Console.WriteLine($"Pacientul este in vizorul doctorului{_doctorService.FindDoctorNameByHisId(patient.DoctorForPatient)}");
        }

    }
}
