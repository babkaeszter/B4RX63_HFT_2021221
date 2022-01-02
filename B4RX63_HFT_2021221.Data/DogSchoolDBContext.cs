using B4RX63_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4RX63_HFT_2021221.Data
{
    public class DogSchoolDBContext : DbContext 
    {
        public virtual DbSet< Dog> Dogs { get; set; } 
        public virtual DbSet< Owner> Owners { get; set; }
        public virtual DbSet< Course> Courses { get; set; }

        public DogSchoolDBContext()
        {
            this.Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DogSchoolDB.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>(entity =>
            {
                entity
                .HasOne(dog => dog.Owner)
                .WithMany(owner => owner.Dogs)
                .HasForeignKey(dog => dog.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            }
            );
            modelBuilder.Entity< Owner>(entity =>
            {
                entity.HasOne(owner => owner.Course)
                .WithMany(course => course.ParticipantOwners)
                .HasForeignKey(owner => owner.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            }
            );
            modelBuilder.Entity< Dog>(entity =>
            {
                entity.HasOne(dog => dog.Course)
                .WithMany(course => course.ParticipantDogs)
                .HasForeignKey(dog => dog.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            }
            );
            //Courses
            Course alap = new Course { Id = 1, Name = "Alapozó tanfolyam", Organizer = "Fővárosi Kutyások Egyesülete", Trainer = "Szűcs Zoltán" };
            Course halado = new Course { Id = 2, Name = "Haladó tanfolyam", Organizer = "Kutyás Élet Kutyaiskola", Trainer = "Lengyel Pálné" };
            Course agility = new Course { Id = 3, Name = "Agility tanfolyam", Organizer = "Sportkutyások Egyesülete", Trainer = "Kiss Bettina" };
            Course ovt = new Course { Id = 4, Name = "Őrző-védő tanfolyam", Organizer = "Heroic Dogs Sportegyesület", Trainer = "Soós Miklós" };
            //Owners
             Owner tamas = new  Owner() { Id = 1, Name = "Kiss Tamás", Sex =  Gender.male, Age = 34, CourseId = alap.Id };
             Owner eniko = new  Owner() { Id = 2, Name = "Szabó Enikő", Sex =  Gender.female, Age = 22, CourseId = alap.Id };
             Owner istvan = new  Owner() { Id = 3, Name = "Varga István", Sex =  Gender.male, Age = 29, CourseId = alap.Id };
             Owner dora = new  Owner() { Id = 4, Name = "Nagy Dóra", Sex =  Gender.female, Age = 43, CourseId = alap.Id };
             Owner anna = new  Owner() { Id = 5, Name = "Kovács Anna", Sex =  Gender.female, Age = 19, CourseId = halado.Id };
             Owner erno = new  Owner() { Id = 6, Name = "Magyar Ernő", Sex =  Gender.male, Age = 26, CourseId = halado.Id };
             Owner bela = new  Owner() { Id = 7, Name = "Váci Béla", Sex =  Gender.male, Age = 32, CourseId = halado.Id };
             Owner miklos = new  Owner() { Id = 8, Name = "Varró Miklós", Sex =  Gender.male, Age = 27, CourseId = agility.Id };
             Owner csaba = new  Owner() { Id = 9, Name = "Tóth Csaba", Sex =  Gender.male, Age = 23, CourseId = agility.Id };
             Owner kitti = new  Owner() { Id = 10, Name = "Csorba Kitti", Sex =  Gender.female, Age = 30, CourseId = agility.Id };
             Owner zoltan = new  Owner() { Id = 11, Name = "Nemes Zoltán", Sex =  Gender.male, Age = 21, CourseId = ovt.Id };
             Owner agnes = new  Owner() { Id = 12, Name = "Kókai Ágnes", Sex =  Gender.female, Age = 27, CourseId = ovt.Id };
             Owner adam = new  Owner() { Id = 13, Name = "Komor Adam", Sex =  Gender.male, Age = 35, CourseId = ovt.Id };
             Owner akos = new  Owner() { Id = 14, Name = "Horváth Ákos", Sex =  Gender.male, Age = 24, CourseId = ovt.Id };
            //Dogs
             Dog buksi = new  Dog() { Id = 1, Name = "Buksi", Breed = "Puli", Sex =  Gender.male, Castrated = true, Weight = 13.4, Height = 42, OwnerId = tamas.Id, CourseId = alap.Id };
             Dog poppy = new  Dog() { Id = 2, Name = "Poppy", Breed = "Dalmata", Sex =  Gender.female, Castrated = false, Weight = 20.3, Height = 56, OwnerId = eniko.Id, CourseId = alap.Id };
             Dog athos = new  Dog() { Id = 3, Name = "Athos", Breed = "Német juhászkutya", Sex =  Gender.male, Castrated = false, Weight = 39, Height = 62.5, OwnerId = istvan.Id, CourseId = alap.Id };
             Dog picur = new  Dog() { Id = 4, Name = "Picúr", Breed = "Yorkshire terrier", Sex =  Gender.female, Castrated = true, Weight = 2.8, Height = 20, OwnerId = dora.Id, CourseId = alap.Id };
             Dog baba = new  Dog() { Id = 5, Name = "Baba", Breed = "Border collie", Sex =  Gender.female, Castrated = false, Weight = 16.7, Height = 48, OwnerId = anna.Id, CourseId = halado.Id };
             Dog rex = new  Dog() { Id = 6, Name = "Rex", Breed = "Német juhászkutya", Sex =  Gender.male, Castrated = true, Weight = 37.8, Height = 61.3, OwnerId = erno.Id, CourseId = halado.Id };
             Dog ludwig = new  Dog() { Id = 7, Name = "Ludwig", Breed = "Bichon Bolognese", Sex =  Gender.male, Castrated = true, Weight = 3, Height = 28, OwnerId = bela.Id, CourseId = halado.Id };
             Dog ariel = new  Dog() { Id = 8, Name = "Ariel", Breed = "Border collie", Sex =  Gender.female, Castrated = false, Weight = 17.3, Height = 50.5, OwnerId = miklos.Id, CourseId = agility.Id };
             Dog barna = new  Dog() { Id = 9, Name = "Barna", Breed = "Mudi", Sex =  Gender.male, Castrated = true, Weight = 12.6, Height = 45.6, OwnerId = csaba.Id, CourseId = agility.Id };
             Dog cuki = new  Dog() { Id = 10, Name = "Cuki", Breed = "Ausztrál juhászkutya", Sex =  Gender.female, Castrated = true, Weight = 23.4, Height = 49.7, OwnerId = kitti.Id, CourseId = agility.Id };
             Dog xanthos = new  Dog() { Id = 11, Name = "Xanthos", Breed = "Kaukázusi juhászkutya", Sex =  Gender.male, Castrated = false, Weight = 63.1, Height = 73.4, OwnerId = zoltan.Id, CourseId = ovt.Id };
             Dog potyi = new  Dog() { Id = 12, Name = "Pötyi", Breed = "Kuvasz", Sex =  Gender.female, Castrated = true, Weight = 38.5, Height = 67, OwnerId = agnes.Id, CourseId = ovt.Id };
             Dog ravasz = new  Dog() { Id = 13, Name = "Ravasz", Breed = "Óriás schnauzer", Sex =  Gender.male, Castrated = false, Weight = 45.3, Height = 66.5, OwnerId = adam.Id, CourseId = ovt.Id };
             Dog ace = new  Dog() { Id = 14, Name = "Ace", Breed = "Belga juhászkutya", Sex =  Gender.male, Castrated = true, Weight = 27, Height = 61.4, OwnerId = akos.Id, CourseId = ovt.Id };

            modelBuilder.Entity< Owner>().HasData(tamas, eniko, istvan, dora, anna, erno, bela, miklos, csaba, kitti, zoltan, agnes, adam, akos);
            modelBuilder.Entity< Dog>().HasData(buksi, poppy, athos, picur, baba, rex, ludwig, ariel, barna, cuki, xanthos, potyi, ravasz, ace);
            modelBuilder.Entity< Course>().HasData(alap, halado, agility, ovt);

        }
    }
}
