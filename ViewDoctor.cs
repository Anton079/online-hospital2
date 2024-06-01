using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class ViewDoctor
    {
        private Doctor doctor;
        private PatientService _patientService;
        private RegistrationSectionService _registrationSectionService;
        private SectionService _sectionService;

        public ViewDoctor(Doctor doctor)
        {
            this.doctor = doctor;
            _patientService = new PatientService();
            _registrationSectionService = new RegistrationSectionService();
            _sectionService = new SectionService();
        }

        public void MeniuDoctor()
        {
            Console.WriteLine("Apasati tasta 1 pentru a vedea toti pacientii tai");
            Console.WriteLine("Apasati tasta 2 pentru a edita sectia unde se afla un pacient");
            Console.WriteLine("Apasati tasta 3 pentru a edita boala unui pacient");
            Console.WriteLine("Apasati tasta 4 pentru a edita gradul de sanatate al unui pacient");
            Console.WriteLine("Apasati tasta 5 pentru a arata pacientii dupa gradul de problema (bun-ok-rau)");
            Console.WriteLine("Apasati tasta 6 pentru a adauga un pacient intr-o sectie");
        }

        public void play()
        {
            bool running = true;
            while (running)
            {
                MeniuDoctor();
                string alegere = Console.ReadLine();

                switch(alegere)
                {
                    case "1":
                        AfisareaPacientilorTai();
                        break;

                    case "2":
                        EditPatientSection();
                        break;

                    case "3":
                        EditPatientHealthProblem();
                        break;

                    case "4":
                        EditDegreeOfHealth();
                        break;

                    case "5":
                        ShowPatientByDegreeHealth();
                        break;

                    case "6":
                        AddPatientInASection();
                        break;
                }
            }
        }

        public void AfisareaPacientilorTai()
        {
            int yourId = doctor.IdDoctor;

            if(yourId != 0)
            {
                List<int> yourPatient= _patientService.SortareaPacientilorTai(yourId);
                _patientService.AfisareaPacientilorTai(yourPatient);
            }
            else
            {
                Console.WriteLine("Pacientii nu au fost gasiti");
            }
        }

        public void EditPatientSection()
        {
            Console.WriteLine("Ce id are pacientul pe care vrei sa il modifici?");
            int idPatient = Int32.Parse(Console.ReadLine());

            Console.WriteLine("In ce sectie vrei sa il muti");
            string sectionName = Console.ReadLine();

            if(_sectionService.EditPatientSection(idPatient, sectionName))
            {
                Console.WriteLine($"Sectia pacientului cu id {idPatient} a fost modificata");
            }
            else
            {
                Console.WriteLine($"Sectia pacientului cu id {idPatient} nu a fost modificata");
            }
        } 

        public void EditPatientHealthProblem()
        {
            Console.WriteLine("Ce id are pacientul?");
            int idPatient = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Cu ce problema de sanatate vrei sa modifici?");
            string healthProblem = Console.ReadLine();

            if(_patientService.EditProblemHealth(idPatient, healthProblem))
            {
                Console.WriteLine("Problema de sanatate a pacientului a fost modificata");
            }
            else
            {
                Console.WriteLine("Problema de sanatate a pacientului a fost modificata");
            }
        } 

        public void EditDegreeOfHealth()
        {
            Console.WriteLine("Ce id are pacientul?");
            int idPatient = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce grad vrei sa pui in schimb(mic, mediu, grav)");
            string degreeOfHealth = Console.ReadLine();

            if(_patientService.EditDegreeHealthProblem(idPatient, degreeOfHealth))
            {
                Console.WriteLine("Modificarea de grad a pacientului a reusit");
            }
            else
            {
                Console.WriteLine("Modificarea pacientului la grad nu a reusit");
            }
        } 

        public void ShowPatientByDegreeHealth()
        {
            Console.WriteLine("Ce grad de problema a sanatatii o cauti?");
            string degreeHealth = Console.ReadLine();

            List<int> patients = _patientService.SortPatientByDegreeHealth(degreeHealth);

            _patientService.SortPatientByDegreeHealth(degreeHealth);
        } 

        public void AddPatientInASection()
        {
            int idSection = ' ';

            int idRegiGenerat = _registrationSectionService.GenerateId();

            Console.WriteLine("What id patient you want to add?");
            int idPatient = Int32.Parse(Console.ReadLine());

            Console.WriteLine("In wat section you want to add?");
            string sectionName = Console.ReadLine();

            int idSectionWanted = _sectionService.FindSectionIdByNameSection(idSection ,sectionName);

            RegistrationSection newPatientAdd = new RegistrationSection(idRegiGenerat, idSectionWanted, idPatient);

            _registrationSectionService.AddPatientInSection(newPatientAdd);

            _registrationSectionService.SaveData();
        } 
    }
}
