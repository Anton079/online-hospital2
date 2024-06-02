using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class DoctorService
    {
        private List<Doctor> _doctor;

        public DoctorService()
        {
            _doctor = new List<Doctor>();
            this.LoadData();
        }

        public void LoadData()
        {
            try
            {
                using(StreamReader sr = new StreamReader(this.GetFilePath()))
                {
                    string line = " ";
                    while((line = sr.ReadLine()) != null)
                    {
                        Doctor doctor = new Doctor(line);
                        this._doctor.Add(doctor);
                    }
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public string GetFilePath()
        {
            string currentDictory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDictory, "data");

            string file = Path.Combine(folder, "doctor");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _doctor.Count - 1; i++)
            {
                save += _doctor[i].ToSave() + "\n";
            }

            save += _doctor[_doctor.Count - 1].ToSave();

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

        public void AfisareDoctor()
        {
            foreach (Doctor x in _doctor)
            {
                Console.WriteLine(x.DoctorInfo());
            }
        }

        public bool AddDoctor(Doctor newDoctor)
        {
            if (FindDoctorById(newDoctor.IdDoctor) == -1)
            {
                this._doctor.Add(newDoctor);
                return true;
            }
            return false;
        }

        public int FindDoctorById(int idDoctor)
        {
            for(int i=0; i< _doctor.Count; i++)
            {
                if (_doctor[i].IdDoctor == idDoctor)
                {
                    return i;
                }
            }
            return -1;
        }

        public string FindDoctorNameByHisId(int idDoctor)
        {
            string doctorName = " ";

            for(int i =0; i < _doctor.Count; i++)
            {
                if (_doctor[i].IdDoctor == idDoctor)
                {
                    doctorName = _doctor[i].DoctorName;
                    return doctorName;
                }
            }
            return null;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);


            while (FindDoctorById(id) != -1)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }

        public bool EditNrPhoneById(int idDr, int newNrPhone)
        {
            for(int i = 0; i < _doctor.Count; i++)
            {
                if (_doctor[i].IdDoctor == idDr)
                {
                    newNrPhone = _doctor[i].NumarTelefon;
                    return true;
                }
                else
                {
                    Console.WriteLine("Doctorul nu a fost gasit");
                }
            }
            return false;
        }

        public Doctor CheckIfDoctor(int idDr, string parola)
        {
            for(int i =0; i < _doctor.Count ; i++)
            {
                if (_doctor[i].IdDoctor == idDr && _doctor[i].Parola == parola)
                {
                    return _doctor[i];
                }
            }
            return null;
        }

        public bool EditPasswordDoctor(int idDr, string newParola)
        {
            for(int i = 0; i < _doctor.Count; i++)
            {
                if (_doctor[i].IdDoctor == idDr)
                {
                    _doctor[i].Parola = newParola;
                    return true;
                }
            }
            return false;
        }
    }
}
