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
            Console.WriteLine("");
                //int idPatient, string firstName, string lastName,string parola ,string healthProblem, string degreeProblem, int dateHospitalization, int idDoctorPatient
        }
    }
}
