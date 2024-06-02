using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital.Administration
{
    public class AdminService
    {
        private List <Admin> _admin;

        public AdminService()
        {
            _admin = new List<Admin>();
            this.LoadData();
        }

        public void LoadData()
        {
            try
            {
                using (StreamReader sr = new StreamReader(GetFilePath()))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Admin admin = new Admin(line);
                        _admin.Add(admin);
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
            string currentDirectory = Directory.GetCurrentDirectory();

            string folder = Path.Combine(currentDirectory, "data");

            string file = Path.Combine(folder, "admin");

            return file;
        }

        public void SaveData()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(GetFilePath()))
                {
                    foreach (Admin admin in _admin)
                    {
                        sw.WriteLine(admin.ToSave());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //CRUD

        public void AfisareAdmins()
        {
            foreach (Admin x in _admin)
            {
                Console.WriteLine(x.AdminInfo());
            }
        }

        public bool AddAdmin(Admin admin)
        {
            if(FindAdminById(admin.Id) == -1)
            {
                this._admin.Add(admin);
                return true;
            }
            return false;
        }

        public int FindAdminById(int adminId)
        {
            for(int i = 0; i < _admin.Count; i++)
            {
                if (_admin[i].Id == adminId)
                {
                    return i;
                }
            }
            return -1;
        }

        public Admin CheckIfAdmin(int idAdmin, string parola)
        {
            for(int i = 0; i < _admin.Count;i++)
            {
                if (_admin[i].Id == idAdmin && _admin[i].Parola == parola)
                {
                    return _admin[i];
                }
            }
            return null;
        }

        public bool EditAdminPassword(int idWanted, string newPassword)
        {
            for(int i= 0; i< _admin.Count;i++)
            {
                if (_admin[i].Id == idWanted)
                {
                    _admin[i].Parola = newPassword;
                    return true;
                }
            }
            return false;
        }
    }
}
