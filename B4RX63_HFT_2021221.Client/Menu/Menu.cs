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

        public Menu(RestService rest, CreateMethods cm)
        {
            this.menu = new ConsoleMenu();
            this.cm = cm;

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
           .Add("Read a Dog", () => SomeAction("Sub_One"))
           .Add("Read an Owner", () => SomeAction("Sub_Two"))
           .Add("Read a Course", () => SomeAction("Sub_Three"))
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
            .Add("Update a Dog", () => SomeAction("Sub_One"))
            .Add("Update an Owner", () => SomeAction("Sub_Two"))
            .Add("Update a Course", () => SomeAction("Sub_Three"))
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
                 .Add("Delete a Dog", () => SomeAction("Sub_One"))
                 .Add("Delete an Owner", () => SomeAction("Sub_Two"))
                 .Add("Delete a Course", () => SomeAction("Sub_Three"))
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
            .Add("Largest Dog", () => SomeAction("Sub_One"))
            .Add("Smallest Female Dog's Breed", () => SomeAction("Sub_Two"))
            .Add("Most Common Breed", () => SomeAction("Sub_Three"))
            .Add("Castrated Dog's Owners", () => SomeAction("Sub_Three"))
            .Add("Most Common Breed", () => SomeAction("Sub_Three"))
            .Add("The Oldest Owner", () => SomeAction("Sub_Three"))
            .Add("The Youngest Female Owner's Dogs", () => SomeAction("Sub_Three"))
            .Add("The Young Owners's Courses", () => SomeAction("Sub_Three"))
            .Add("Courses And Their Groupnumber", () => SomeAction("Sub_Three"))
            .Add("Average Age In Courses", () => SomeAction("Sub_Three"))
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

