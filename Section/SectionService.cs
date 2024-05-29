using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital
{
    public class SectionService
    {
        private List <Section> _sections;

        public SectionService()
        {
            _sections = new List<Section>();
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
                        Section sectionService = new Section(line);
                        this._sections.Add(sectionService);
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

            string file = Path.Combine(folder, "section");

            return file;
        }

        public string ToSaveAll()
        {
            String save = "";

            for (int i = 0; i < _sections.Count - 1; i++)
            {
                save += _sections[i].ToSave() + "\n";
            }

            save += _sections[_sections.Count - 1].ToSave();

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

        public void AfisareSection()
        {
            foreach(Section x in _sections)
            {
                Console.WriteLine(x.SectionInfo());
            }
        }

        public int FindSectionById(int id)
        {
            for(int i = 0; i < _sections.Count; i++)
            {
                if(_sections[i].IdSection == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool AddSection(Section section)
        {
            if (FindSectionById(section.IdSection) == -1)
            {
                this._sections.Add(section);
                return true;
            }
            return false;
        }

        public bool EditPatientSection(int idPatient, string sectionName)
        {
            for(int i =0; i< _sections.Count;i++)
            {
                if (_sections[i].IdPatient == idPatient)
                {
                    sectionName = _sections[i].SectionName;
                    return true;
                }
            }
            return false;
        }

        public int FindSectionIdByNameSection(int idSection, string sectionName)
        {
            for(int i = 0; i< _sections.Count; i++)
            {
                if (_sections[i].SectionName == sectionName)
                {
                    idSection = _sections[i].IdSection;
                    return idSection;
                }
            }
            return -1;
        }

        public string FindSectionNameByIdSection(int idSection) //gasirea nume sectie dupa id sectie
        {
            string sectionNameWanted = " ";
            for (int i = 0; i < _sections.Count; ++i)
            {
                if (_sections[i].IdSection == idSection)
                {
                    sectionNameWanted = _sections[i].SectionName;
                    return sectionNameWanted;
                }
            }
            return null;
        }

        public int GenerateId()
        {
            Random rand = new Random();

            int id = rand.Next(1, 10000000);


            while (FindSectionById(id) != -1)
            {
                id = rand.Next(1, 10000000);
            }


            return id;
        }
    }
}
