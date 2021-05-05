using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using FastMoneyBookmaker.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.ViewModels.For_models
{
    class PassportViewModel : ViewModel
    {
        private Passport passport;
        public Passport Passport
        {
            get => passport;
            set => Set(ref passport, value);
        }
        public int Id
        {
            get => Passport.Id;
            set
            {
                Passport.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public string FirstName
        {
            get => Passport.FirstName;
            set
            {
                Passport.FirstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string SurName
        {
            get => Passport.SurName;
            set
            {
                Passport.SurName = value;
                OnPropertyChanged("SurName");
            }
        }
        public string LastName
        {
            get => Passport.LastName;
            set
            {
                Passport.LastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public Gender Gender
        {
            get => passport.Gender;
            set
            {
                passport.Gender = value;
                OnPropertyChanged("Gender");
            }
        }
        public DateTime DateOfBirth
        {
            get => passport.DateOfBIrth;
            set
            {
                passport.DateOfBIrth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }
        public PassportViewModel()
        {
            passport = new Passport();
        }
        
    }
}
