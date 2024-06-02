using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class PatientService
    {
        private List <Patient> _patient;

        public PatientService()
        {
            _patient = new List <Patient>();
            this.LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(this.GetFilePath()))
                {
                    string line = " ";
                    while ((line = sr.ReadLine()) != null)
                    {
                        Patient patient = new Patient(line);
                        this._patient.Add(patient);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDictory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDictory, "data");

            string file = Path.Combine(folder, "patient");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _patient.Count - 1; i++)
            {
                save += _patient[i].ToSave() + "\n";
            }

            save += _patient[_patient.Count - 1].ToSave();

            return save;
        }

        public void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this.GetFilePath()))
                {
                    sw.Write(ToSaveAll());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //CRUD

        public void AfisarePatient()
        {
            foreach(Patient x in _patient)
            {
                Console.WriteLine(x.PatientInfo());
            }
        }

        public List<int> SortareaPacientilorTai(int yourId)
        {
            List <int> wantedPacient = new List<int>();

            for(int i = 0; i < _patient.Count; i++)
            {
                if (_patient[i].DoctorForPatient == yourId)
                {
                    wantedPacient.Add(_patient[i].IdPatient);
                }
            }
            return wantedPacient;
        }

        public void AfisareaPacientilorTai(List<int> wantedPacient)
        {
            if (wantedPacient.Count == 0)
            {
                Console.WriteLine("Lista este goala");
                return;
            }

            for(int i = 0;i < wantedPacient.Count;i++)
            {
                Console.WriteLine($"Pacientul {i} cu numele {_patient[i].FirstName}, {_patient[i].LastName} si boala {_patient[i].HealthProblem} cu gradul problema al sanatatii {_patient[i].DegreeProblem}");
                Console.WriteLine(" ");
            }
        }

        public int FindPatientById(int idPatient)
        {
            for(int i = 0; i < _patient.Count;i++)
            {
                if (_patient[i].IdPatient ==  idPatient)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool AddPatient(Patient newPatient)
        {
            if(FindPatientById(newPatient.IdPatient) == -1)
            {
                this._patient.Add(newPatient);
                return true;
            }
            return false;
        }

        public bool EditProblemHealth(int idPatient, string nameHealhProblem) 
        {
            for(int i =0;i < _patient.Count; i++)
            {
                if (_patient[i].IdPatient == idPatient)
                {
                    nameHealhProblem = _patient[i].HealthProblem;
                    return true;
                }
            }
            return false;
        }

        public bool EditDegreeHealthProblem(int idPatient, string nameDegreeProblem) 
        {
            for(int i = 0; i < _patient.Count; i++)
            {
                if (_patient[i].IdPatient == idPatient)
                {
                    nameDegreeProblem = _patient[i].DegreeProblem;
                    return true;
                }
            }
            return false;
        }

        public List<int> SortPatientByDegreeHealth(string degreeHealth)
        {
            List <int> patientSortByDegree = new List <int>();

            for(int i =0; i < _patient.Count; i++)
            {
                if (_patient[i].DegreeProblem == degreeHealth)
                {
                    patientSortByDegree.Add(_patient[i].IdPatient);
                }
                else
                {
                    Console.WriteLine("Nu se afla pacienti cu acest grad de sanatate");
                }
            }
            return patientSortByDegree;
        }  

        public void ShowSortedPatientByDegree(List <int> patientSortByDegree)
        {
            if(patientSortByDegree.Count == 0)
            {
                Console.WriteLine("Lista este goala");
                return;
            }

            for(int i = 0;i < patientSortByDegree.Count;i++)
            {
                Console.WriteLine($"Pacientul {_patient[i].FirstName}, {_patient[i].LastName}, are gradul de problema de sanatate {_patient[i].DegreeProblem}");
                Console.WriteLine(" ");
            }
        } 

        public Patient CheckIfPatient(int id, string parola)
        {
            for(int i = 0; i < _patient.Count;i++)
            {
                if(_patient[i].IdPatient == id && _patient[i].Parola == parola)
                {
                    return _patient[i];
                }
            }
            return null;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);


            while (FindPatientById(id) != -1)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }

        public bool EditPatientFirstNameById(int idWanted, string newFirstName)
        {
            for (int i = 0; i < _patient.Count; i++)
            {
                if (_patient[i].IdPatient == idWanted)
                {
                    newFirstName = _patient[i].FirstName;
                    return true;
                }
            }
            return false;
        }
    }
}
