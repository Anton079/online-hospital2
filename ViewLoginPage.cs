using online_hospital.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class ViewLoginPage
    {
       
        private PatientService _patientService;
        private DoctorService _doctorService;
        private AdminService _adminService;


        public ViewLoginPage()
        {
            _patientService = new PatientService();
            _doctorService = new DoctorService();
            _adminService = new AdminService();
        }
           
            

        public void LoginMeniu()
        {
            Console.WriteLine("Apasati tasta 1 pentru logare");
            Console.WriteLine("Apasati tasta 2 pentru a va inregista");
        }

        public void play()
        {
            bool running = true;
            while (running)
            {
                LoginMeniu();
                string alegere = Console.ReadLine();

                switch (alegere)
                {
                    case "1":
                        Login();
                        break;

                    case "2":
                        NewRegistration();
                        break;
                }
            }

        }

        public void Login()
        {
            Console.WriteLine("Introde-ti id-ul tau");
            int idLogin = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduce-ti parola ta");
            string parolaLogin = Console.ReadLine();


            Patient patient= _patientService.CheckIfPatient(idLogin, parolaLogin);

            if(patient != null)
            {
                ViewUser viewUser = new ViewUser(patient);
                Console.WriteLine("V ati logat cu succes!");
                viewUser.play();
            }
            else
            {
                Console.WriteLine("");
            }

            Admin admin = _adminService.CheckIfAdmin(idLogin, parolaLogin);

            if(admin != null)
            {
                ViewAdmin viewAdmin = new ViewAdmin(admin);
                Console.WriteLine("V ati logat cu succes!");
                viewAdmin.play();
            }
            else
            {
                Console.WriteLine("Datele nu sunt corecte sau nu nu sunteti inregistrat");
            }

            Doctor doctor = _doctorService.CheckIfDoctor(idLogin, parolaLogin);

            if(doctor != null)
            {
                ViewDoctor viewDoctor = new ViewDoctor(doctor);
                Console.WriteLine("V ati logat cu succes!");
                viewDoctor.play();
            }
            else
            {
                Console.WriteLine("Datele sunt gresite sau nu sunteti inregistrat");
            }
        }

        public void NewRegistration()
        {
            int idGenerat = _patientService.GenerateId();

            Console.WriteLine("Care iti este numele de familie? ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Care iti este prenumele? ");
            string lastname = Console.ReadLine();

            Console.WriteLine("Care o sa fie parola? ");
            string newPassword = Console.ReadLine();

            Console.WriteLine("Aveti o problema de sanatate deja?");
            string newHealthProblem = Console.ReadLine();

            Console.WriteLine("La ce grad de dificultate este problema dumneavoastra de sanatate? ");
            string degreeProblem = Console.ReadLine();

            Console.WriteLine("In ce data v ati spitalizat? ");
            int newDateHospitalzation = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Ce id are doctorul care este in tratarea acientului? ");
            int newIdDoctorPatient = Int32.Parse(Console.ReadLine());

            Patient newPatient = new Patient(idGenerat, firstName, lastname, newPassword, newHealthProblem, degreeProblem, newDateHospitalzation, newIdDoctorPatient);

            if (_patientService.AddPatient(newPatient))
            {
                Console.WriteLine("Pacientul a fos adaugat!");
            }
            else
            {
                Console.WriteLine("Pacientul nu a putut fi adaugat!");
            }

            _patientService.SaveData();
        }

        public void ResetareParola()
        {
            Console.WriteLine("Ce grad de user ai? (User, Doctor, Admin)");
            string userWanted = Console.ReadLine();

            Console.WriteLine("Care este id ul tau?");
            int idWanted = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Care sa fie noua parola");
            string newPassword = Console.ReadLine();

            switch (userWanted)
            {
                //case "User":                                                                      //cum il modific?
                    
                //    Console.WriteLine("Resetarea parolei pentru utilizator.");
                //    break;

                case "Doctor":
                    _doctorService.EditPasswordDoctor(idWanted, newPassword);
                    Console.WriteLine("Resetarea parolei pentru doctor.");
                    break;

                case "Admin":
                    _adminService.EditAdminPassword(idWanted, newPassword);
                    Console.WriteLine("Resetarea parolei pentru administrator.");
                    break;

                default:
                    Console.WriteLine("Nu te-am putut gasi pentru ati reseta parola!");
                    break;
            }
        }
    }
}
