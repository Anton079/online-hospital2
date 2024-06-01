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
                        EditInfoHospital();
                        break;

                    case "2":
                        EditDoctorNrPhone();
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

            _doctorService.EditNrPhoneById(IdDrNrPhone, newNrPhone);
            _doctorService.SaveData();
        }
    }
}
