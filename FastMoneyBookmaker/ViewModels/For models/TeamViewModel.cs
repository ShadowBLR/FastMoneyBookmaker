using CourseWork.ViewModels.Base;
using FastMoneyBookmaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastMoneyBookmaker.ViewModels.For_models
{
    class TeamViewModel:ViewModel
    {
        private Team team;
        public Team Team
        {
            get => team;
            set => Set(ref team, value);
        }
        public int Id
        {
            get => team.Id;
            set
            {
                team.Id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get => team.Name;
            set
            {
                team.Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
