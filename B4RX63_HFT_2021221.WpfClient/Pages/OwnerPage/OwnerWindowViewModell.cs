using B4RX63_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace B4RX63_HFT_2021221.WpfClient.Pages.OwnerPage
{
    public class OwnerWindowViewModell : ObservableRecipient
    {
        public RestCollection<Dog> Dogs { get; set; }
        public RestCollection<Owner> Owners { get; set; }
        public RestCollection<Course> Courses { get; set; }
        public List<Gender> Genders { get; }
        public ICommand CreateOwnerCommand { get; set; }
        public ICommand UpdateOwnerCommand { get; set; }
        public ICommand DeleteOwnerCommand { get; set; }

        private Owner selectedOwner;

        public Owner SelectedOwner
        {
            get { return selectedOwner; }
            set
            {
                if (value != null)
                {
                    selectedOwner = new Owner()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Sex = value.Sex,
                        Age = value.Age,
                        Dogs = value.Dogs,
                        CourseId = value.CourseId

                    };
                }
                OnPropertyChanged();
                (DeleteOwnerCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public OwnerWindowViewModell()
        {

            if (!IsInDesignMode)
            {
                Genders = new List<Gender> { Gender.male, Gender.female };
                Owners = new RestCollection<Owner>("http://localhost:25294/", "owner", "hub");
                Courses = new RestCollection<Course>("http://localhost:25294/", "course", "hub");
                CreateOwnerCommand = new RelayCommand(() =>
                {
                    Owners.Add(new Owner()
                    {
                        Name = SelectedOwner.Name,
                        Sex = SelectedOwner.Sex,
                        Age = SelectedOwner.Age,
                        Dogs = SelectedOwner.Dogs,
                        CourseId = SelectedOwner.CourseId
                    }
                        );
                }
                );
                DeleteOwnerCommand = new RelayCommand(() =>

                {
                    Owners.Delete(SelectedOwner.Id);
                },
                    () => { return SelectedOwner != null; }
                );
                UpdateOwnerCommand = new RelayCommand(
                    () => { Owners.Add(SelectedOwner); }
                    );
                SelectedOwner = new Owner();
            }
        }
    }
}
