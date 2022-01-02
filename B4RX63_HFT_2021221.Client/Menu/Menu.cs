using ConsoleTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Client
{
    public class Menu
    {
        public ConsoleMenu menu;
        public RestService rest;
        public CreateMethods cm;
        public ReadMethods rm;
        public UpdateMethods um;
        public DeleteMethods dm;
        public OtherActions om;

        public Menu(RestService rest, CreateMethods cm, ReadMethods rm, UpdateMethods um, DeleteMethods dm, OtherActions om)
        {
            this.menu = new ConsoleMenu();
            this.cm = cm;
            this.rm = rm;
            this.um = um;
            this.dm = dm;
            this.om = om;

            //create submenu
            var csubMenu = new ConsoleMenu()
            .Add("Create a dog", () => cm.CreateDog())
            .Add("Create an Owner", () => cm.CreateOwner())
            .Add("Create a Course", () => cm.CreateCourse())
            .Add("Back", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Create";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            //read submenu
            var rsubMenu = new ConsoleMenu()
           .Add("Read a Dog", () => rm.ReadDog())
           .Add("Read an Owner", () => rm.ReadOwner())
           .Add("Read a Course", () => rm.ReadCourse())
           .Add("Read all Dogs", () => rm.ReadAllDogs())
           .Add("Read all Owners", () => rm.ReadAllOwners())
           .Add("Read all Coursea", () => rm.ReadAllCourses())
           .Add("Back", ConsoleMenu.Close)
           .Configure(config =>
           {
               config.Selector = "--> ";
               config.EnableFilter = false;
               config.Title = "Read";
               config.EnableBreadcrumb = true;
               config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
           });

            //update submenu
            var usubMenu = new ConsoleMenu()
            .Add("Update a Dog", () => um.UpdateDog())
            .Add("Update an Owner", () => um.UpdateOwner())
            .Add("Update a Course", () => um.UpdateCourse())
            .Add("Back", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Update";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            //delete submenu
            var dsubMenu = new ConsoleMenu()
                 .Add("Delete a Dog", () => dm.DeleteDog())
                 .Add("Delete an Owner", () => dm.DeleteOwner())
                 .Add("Delete a Course", () => dm.DeleteCourse())
                 .Add("Back", ConsoleMenu.Close)
                 .Configure(config =>
                 {
                     config.Selector = "--> ";
                     config.EnableFilter = false;
                     config.Title = "Delete";
                     config.EnableBreadcrumb = true;
                     config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
                 });
            //other methods's submenus

            var osubMenu = new ConsoleMenu()
            .Add("Largest Dog", () => om.LargestDog())
            .Add("Smallest Female Dog's Breed", () => om.SmallestFemale())
            .Add("Most Common Breed", () => om.MostCommonBreed())
            .Add("Castrated Dog's Owners", () => om.CastratedDogssOwners())
            .Add("The Oldest Owner", () => om.OldestOwner())
            .Add("The Youngest Female Owner's Dogs", () => om.YoungestFemalesDogs())
            .Add("The Young Owners's Courses", () => om.YoungOwnersCourses())
            .Add("Courses And Their Groupnumber", () => om.CourseGroupNumber())
            .Add("Average Age In Courses", () => om.CourseAverageWeight())
            .Add("Back", ConsoleMenu.Close)
            .Configure(config =>
            {
                config.Selector = "--> ";
                config.EnableFilter = false;
                config.Title = "Other actions";
                config.EnableBreadcrumb = true;
                config.WriteBreadcrumbAction = titles => Console.WriteLine(string.Join(" / ", titles));
            });

            //add submenus
            menu
              .Add("Create", csubMenu.Show)
              .Add("Read", rsubMenu.Show)
              .Add("Update", usubMenu.Show)
              .Add("Delete", dsubMenu.Show)
              .Add("Others", osubMenu.Show)
              .Add("Close", ConsoleMenu.Close)
              .Add("Exit", () => Environment.Exit(0))
              .Configure(config =>
              {
                  config.Selector = "--> ";
                  config.EnableFilter = false;
                  config.Title = "Main menu";
                  config.EnableWriteTitle = true;
                  config.EnableBreadcrumb = true;
              });
        }
        public void OpenMenu()
        {
            menu.Show();
        }

        public static void SomeAction(string s)
        {
            Console.WriteLine(s);
        }
    }


}

