using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.ViewModels.For_models
{
   // [Table("Contacts")]
    class ContactViewModel:ViewModel
    {
        private Contact contact;
        public Contact Contact
        {
            get => contact;
            set
            {
                contact = value;
                OnPropertyChanged("Contact");
            }
        }
        public int Id
        {
            get => contact.Id;
            set
            {
                contact.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Email
        {
            get => contact.Email;
            set
            {
                contact.Email = value;
                OnPropertyChanged("Email");
            }
        }
        public string PhoneNumber
        {
            get => contact.PhoneNumber;
            set
            {
                contact.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public ContactViewModel()
        {
            contact = new Contact();
        }
    }
}
