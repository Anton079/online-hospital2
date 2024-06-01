﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_hospital.Administration
{
    public class Admin
    {
        private int _id;
        private string _parola;
        private string _name;
        private string _email;

        public Admin(string proprietati)
        {
            string[] token = proprietati.Split(',');

            _id = int.Parse(token[0]);
            _parola = token[1];
            _name = token[2];
            _email = token[3];
        }

        public Admin(int id,string parola ,string name, string email)
        {
            _id = id;
            _parola = parola;
            _name = name;
            _email = email;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Parola
        {
            get { return _parola; }
            set { _parola = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string AdminInfo()
        {
            string text = " ";
            text += "Id administrator: " + _id + "\n";
            text += "Parola " + _parola + "\n";
            text += "Nume administrator: " + _name + "\n";
            text += "Email administrator: " + _email + "\n";
            return text;
        }

        public string ToSave()
        {
            return _id + "," +this._parola +"," + _name + "," + _email;
        }
    }

}
