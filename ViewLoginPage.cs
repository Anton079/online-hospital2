using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class ViewLoginPage
    {
        //private Patient _patient;

        //public ViewLoginPage()
        //{
        //    _patient = new Patient();
        //}

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

                }
            }

        }

        public void Login()
        {
            Console.WriteLine("Introde-ti id-ul tau");
            int idLogin = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Introduce-ti parola ta");
            string parolaLogin = Console.ReadLine();

            //if ()
            //{

            //}
            //else
            //{
            //    Console.WriteLine("Datele nu sunt corecte sau nu detineti un cont");
            //}
        }
    }
}
