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

        public ViewAdmin(Admin admin)
        {
            this.admin = admin;
            _doctorService = new DoctorService();
            _registrationSectionService = new RegistrationSectionService();
            _sectionService = new SectionService();
            _hospitalInformationService = new HospitalInformationService();
        }

        public void MeniuAdmin()
        {
            Console.WriteLine("Apasati tasta 1 pentru edita programul spitalului");
            Console.WriteLine("Apasati tasta 2 pentru a edita numarul de telefon al unui doctor");
            Console.WriteLine("Apasati tasta 3 pentru a edita sectia spitalului dupa id-ul sectii");
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
                        EditInfoHospital();
                        break;

                    case "2":
                        EditDoctorNrPhone();
                        break;

                    case "3":
                        EditSectionByIdSection();
                        break;
                }
            }
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

            if(_doctorService.EditNrPhoneById(IdDrNrPhone, newNrPhone))
            {
                Console.WriteLine("Nr de telefol a fost modificat!");
                _doctorService.SaveData();
            }
            else
            {
                Console.WriteLine("Nr de telefol NU a fost modificat!");
            }
        }

        public void EditSectionByIdSection()
        {
            Console.WriteLine("Ce id are sectia pe care vrei sa o modifici? ");
            int idSectionWanted = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce nume o sa aiba noua sectia?");
            string newNameSection = Console.ReadLine();

            if(_sectionService.EditSectionByIdSection(idSectionWanted, newNameSection))
            {
                Console.WriteLine("Sectia a fost modificata cu succes");
                _sectionService.SaveData();
            }
            else
            {
                Console.WriteLine("Sectia NU a fost modificata");
            }
        }
    }
}
