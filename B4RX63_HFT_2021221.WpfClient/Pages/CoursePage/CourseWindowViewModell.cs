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

namespace B4RX63_HFT_2021221.WpfClient.Pages.CoursePage
{
    public class CourseWindowViewModell : ObservableRecipient
    {
        public RestCollection<Course> Courses { get; set; }
        public ICommand CreateCourseCommand { get; set; }
        public ICommand UpdateCourseCommand { get; set; }
        public ICommand DeleteCourseCommand { get; set; }

        private Course selectedCourse;

        public Course SelectedCourse
        {
            get { return selectedCourse; }
            set
            {
                if (value != null)
                {
                    selectedCourse = new Course()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Organizer = value.Organizer,
                        Trainer = value.Trainer
                    };
                }
                OnPropertyChanged();
                (DeleteCourseCommand as RelayCommand).NotifyCanExecuteChanged();
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

        public CourseWindowViewModell()
        {

            if (!IsInDesignMode)
            {
                
                Courses = new RestCollection<Course>("http://localhost:25294/", "course", "hub");
                CreateCourseCommand = new RelayCommand(() =>
                {
                    Courses.Add(new Course()
                    {
                        Name = SelectedCourse.Name,
                        Organizer = SelectedCourse.Organizer,
                        Trainer = SelectedCourse.Trainer
                    }
                        );
                }
                );
                DeleteCourseCommand = new RelayCommand(() =>

                {
                    Courses.Delete(SelectedCourse.Id);
                },
                    () => { return SelectedCourse != null; }
                );
                UpdateCourseCommand = new RelayCommand(
                    () => { Courses.Update(SelectedCourse); }
                    );
                SelectedCourse = new Course();
            }
        }
    }
}
