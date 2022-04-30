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

namespace B4RX63_HFT_2021221.WpfClient.Pages.DogPage
{
    class DogWindowViewModell : ObservableRecipient
    {
       

            public RestCollection<Dog> Dogs { get; set; }
            public RestCollection<Owner> Owners { get; set; }
            public RestCollection<Course> Courses { get; set; }
            public List<Gender> Genders { get; }
            public ICommand CreateDogCommand { get; set; }
            public ICommand UpdateDogCommand { get; set; }
            public ICommand DeleteDogCommand { get; set; }

            private Dog selectedDog;

            public Dog SelectedDog
            {
                get { return selectedDog; }
                set
                {
                    if (value != null)
                    {
                        selectedDog = new Dog()
                        {
                            Id = value.Id,
                            Name = value.Name,
                            Breed = value.Breed,
                            Sex = value.Sex,
                            Castrated = value.Castrated,
                            Weight = value.Weight,
                            Height = value.Height,
                            OwnerId = value.OwnerId,
                            CourseId = value.CourseId

                        };
                    }
                    OnPropertyChanged();
                    (DeleteDogCommand as RelayCommand).NotifyCanExecuteChanged();
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

            public DogWindowViewModell()
            {

                if (!IsInDesignMode)
                {
                    Genders = new List<Gender> { Gender.male, Gender.female };
                    Dogs = new RestCollection<Dog>("http://localhost:25294/", "dog", "hub");
                    Owners = new RestCollection<Owner>("http://localhost:25294/", "owner", "hub");
                    Courses = new RestCollection<Course>("http://localhost:25294/", "course", "hub");
                    CreateDogCommand = new RelayCommand(() =>
                    {
                        Dogs.Add(new Dog()
                        {
                            Name = SelectedDog.Name,
                            Breed = SelectedDog.Breed,
                            Sex = SelectedDog.Sex,
                            Castrated = SelectedDog.Castrated,
                            Weight = SelectedDog.Weight,
                            Height = SelectedDog.Height,
                            OwnerId = SelectedDog.OwnerId,
                            CourseId = SelectedDog.CourseId
                        }
                            );
                    }
                    );
                    DeleteDogCommand = new RelayCommand(() =>

                    {
                        Dogs.Delete(SelectedDog.Id);
                    },
                        () => { return SelectedDog != null; }
                    );
                    UpdateDogCommand = new RelayCommand(
                        () => { Dogs.Add(SelectedDog); }
                        );
                    SelectedDog = new Dog();
                }
            }
        
    }
}
