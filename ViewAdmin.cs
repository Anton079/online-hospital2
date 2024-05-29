using online_hospital.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class ViewAdmin
    {
        private Admin admin;
        private DoctorService _doctorService;
        private RegistrationSectionService _registrationSectionService;
        private SectionService _sectionService;
        private HospitalInformationService _hospitalInformationService;

        public ViewAdmin()
        {
            admin = new Admin(3, "Vlad", "vlad312@gmail.com");
            _doctorService = new DoctorService();
            _registrationSectionService = new RegistrationSectionService();
            _sectionService = new SectionService();
            _hospitalInformationService = new HospitalInformationService();
        }

        public void MeniuAdmin()
        {
            Console.WriteLine("Apasati tasta 1 pentru a adauga un doctor");
            Console.WriteLine("Apasati tasta 2 pentru edita programul spitalului");
            Console.WriteLine("Apasati tasta 3 pentru a edita numarul de telefon al unui doctor");
            //sectia nu o pot edita sau adauga ca am legat restul functiilor de ea si in sectie sunt adauati pacientii
        }

        public void play()
        {
            bool running = true;
            while (running)
            {
                MeniuAdmin();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        AddDoctor();
                        break;

                    case "2":
                        EditInfoHospital();
                        break;

                    case "3":
                        EditDoctorNrPhone();
                        break;


                }
            }
        }

        public void AddDoctor()
        {
            int idGenerator = _doctorService.GenerateId();

            Console.WriteLine($"Id ul doctorului o sa fie {idGenerator}");

            Console.WriteLine("Numele doctorului este ?");
            string doctorName = Console.ReadLine();

            Console.WriteLine("Prenumele doctorului este?");
            string lastName = Console.ReadLine();

            Console.WriteLine("Nr de telefon al doctorului este?");
            int nrPhone= Int32.Parse(Console.ReadLine());

            Doctor newDoctor = new Doctor(idGenerator, doctorName, lastName, nrPhone);

            _doctorService.AddDoctor(newDoctor);
            _doctorService.SaveData();
        }

        public void EditInfoHospital()
        {
            Console.WriteLine($"Programul vechi este acesta{_hospitalInformationService.AfisareProgram}");

            Console.WriteLine("Scrie mai jos noul program");
            string newHospitalInfo = Console.ReadLine();

            _hospitalInformationService.EditInfoHospital(newHospitalInfo);
            _hospitalInformationService.SaveData();
        }

        public void EditDoctorNrPhone()
        {
            Console.WriteLine("Ce id are doctorul pe care vrei sa il editezi?");
            int IdDrNrPhone = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Cu ce nr vrei sa il schimbi?");
            int newNrPhone = Int32.Parse(Console.ReadLine());

            _doctorService.EditNrPhoneById(IdDrNrPhone, newNrPhone);
            _doctorService.SaveData();
        }
    }
}
