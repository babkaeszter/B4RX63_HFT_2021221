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
        public virtual DbSet<Models.Dog> Dogs { get; set; } 
        public virtual DbSet<Models.Owner> Owners { get; set; }
        public virtual DbSet<Models.Course> Courses { get; set; }

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
            modelBuilder.Entity<Models.Dog>(entity =>
            {
                entity
                .HasOne(dog => dog.Owner)
                .WithMany(owner => owner.Dogs)
                .HasForeignKey(dog => dog.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            }
            );
            modelBuilder.Entity<Models.Owner>(entity =>
            {
                entity.HasOne(owner => owner.Course)
                .WithMany(course => course.ParticipantOwners)
                .HasForeignKey(owner => owner.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            }
            );
            modelBuilder.Entity<Models.Dog>(entity =>
            {
                entity.HasOne(dog => dog.Course)
                .WithMany(course => course.ParticipantDogs)
                .HasForeignKey(dog => dog.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
            }
            );
            Models.Course alap = new Models.Course { Id = 1, Name = "Alapozó tanfolyam", Organizer = "Fővárosi Kutyások Egyesülete", Trainer = "Szűcs Zoltán" };
            Models.Course halado = new Models.Course { Id = 2, Name = "Haladó tanfolyam", Organizer = "Kutyás Élet Kutyaiskola", Trainer = "Lengyel Pálné" };
            Models.Course agility = new Models.Course { Id = 3, Name = "Agility tanfolyam", Organizer = "Sportkutyások Egyesülete", Trainer = "Kiss Bettina" };
            Models.Course ovt = new Models.Course { Id = 4, Name = "őrző-védő tanfolyam", Organizer = "Heroic Dogs Sportegyesület", Trainer = "Soós Miklós" };

            Models.Owner tamas = new Models.Owner() { Id = 1, Name = "Kiss Tamás", Sex = Models.Gender.male, Age = 34, CourseId = alap.Id };
            Models.Owner eniko = new Models.Owner() { Id = 2, Name = "Szabó Enikő", Sex = Models.Gender.female, Age = 22, CourseId = alap.Id };
            Models.Owner istvan = new Models.Owner() { Id = 3, Name = "Varga István", Sex = Models.Gender.male, Age = 29, CourseId = alap.Id };
            Models.Owner dora = new Models.Owner() { Id = 4, Name = "Nagy Dóra", Sex = Models.Gender.female, Age = 43, CourseId = alap.Id };
            Models.Owner anna = new Models.Owner() { Id = 5, Name = "Kovács Anna", Sex = Models.Gender.female, Age = 19, CourseId = halado.Id };
            Models.Owner erno = new Models.Owner() { Id = 6, Name = "Magyar Ernő", Sex = Models.Gender.male, Age = 26, CourseId = halado.Id };
            Models.Owner bela = new Models.Owner() { Id = 7, Name = "Váci Béla", Sex = Models.Gender.male, Age = 32, CourseId = halado.Id };
            Models.Owner miklos = new Models.Owner() { Id = 8, Name = "Varró Miklós", Sex = Models.Gender.male, Age = 27, CourseId = agility.Id };
            Models.Owner csaba = new Models.Owner() { Id = 9, Name = "Tóth Csaba", Sex = Models.Gender.male, Age = 23, CourseId = agility.Id };
            Models.Owner kitti = new Models.Owner() { Id = 10, Name = "Csorba Kitti", Sex = Models.Gender.female, Age = 30, CourseId = agility.Id };
            Models.Owner zoltan = new Models.Owner() { Id = 11, Name = "Nemes Zoltán", Sex = Models.Gender.male, Age = 21, CourseId = ovt.Id };
            Models.Owner agnes = new Models.Owner() { Id = 12, Name = "Kókai Ágnes", Sex = Models.Gender.female, Age = 27, CourseId = ovt.Id };
            Models.Owner adam = new Models.Owner() { Id = 13, Name = "Komor Adam", Sex = Models.Gender.male, Age = 35, CourseId = ovt.Id };
            Models.Owner akos = new Models.Owner() { Id = 14, Name = "Horváth Ákos", Sex = Models.Gender.male, Age = 24, CourseId = ovt.Id };

            Models.Dog buksi = new Models.Dog() { Id = 1, Name = "Buksi", Breed = "Puli", Sex = Models.Gender.male, Castrated = true, Weight = 13.4, Height = 42, OwnerId = tamas.Id, CourseId = alap.Id };
            Models.Dog poppy = new Models.Dog() { Id = 2, Name = "Poppy", Breed = "Dalmata", Sex = Models.Gender.female, Castrated = false, Weight = 20.3, Height = 56, OwnerId = eniko.Id, CourseId = alap.Id };
            Models.Dog athos = new Models.Dog() { Id = 3, Name = "Athos", Breed = "Német juhászkutya", Sex = Models.Gender.male, Castrated = false, Weight = 39, Height = 62.5, OwnerId = istvan.Id, CourseId = alap.Id };
            Models.Dog picur = new Models.Dog() { Id = 4, Name = "Picúr", Breed = "Yorkshire terrier", Sex = Models.Gender.female, Castrated = true, Weight = 2.8, Height = 20, OwnerId = dora.Id, CourseId = alap.Id };
            Models.Dog baba = new Models.Dog() { Id = 5, Name = "Baba", Breed = "Border collie", Sex = Models.Gender.female, Castrated = false, Weight = 16.7, Height = 48, OwnerId = anna.Id, CourseId = halado.Id };
            Models.Dog rex = new Models.Dog() { Id = 6, Name = "Rex", Breed = "Német juhászkutya", Sex = Models.Gender.male, Castrated = true, Weight = 37.8, Height = 61.3, OwnerId = erno.Id, CourseId = halado.Id };
            Models.Dog ludwig = new Models.Dog() { Id = 7, Name = "Ludwig", Breed = "Bichon Bolognese", Sex = Models.Gender.male, Castrated = true, Weight = 3, Height = 28, OwnerId = bela.Id, CourseId = halado.Id };
            Models.Dog ariel = new Models.Dog() { Id = 8, Name = "Ariel", Breed = "Border collie", Sex = Models.Gender.female, Castrated = false, Weight = 17.3, Height = 50.5, OwnerId = miklos.Id, CourseId = agility.Id };
            Models.Dog barna = new Models.Dog() { Id = 9, Name = "Barna", Breed = "Mudi", Sex = Models.Gender.male, Castrated = true, Weight = 12.6, Height = 45.6, OwnerId = csaba.Id, CourseId = agility.Id };
            Models.Dog cuki = new Models.Dog() { Id = 10, Name = "Cuki", Breed = "Ausztrál juhászkutya", Sex = Models.Gender.female, Castrated = true, Weight = 23.4, Height = 49.7, OwnerId = kitti.Id, CourseId = agility.Id };
            Models.Dog xanthos = new Models.Dog() { Id = 11, Name = "Xanthos", Breed = "Kaukázusi juhászkutya", Sex = Models.Gender.male, Castrated = false, Weight = 63.1, Height = 73.4, OwnerId = zoltan.Id, CourseId = ovt.Id };
            Models.Dog potyi = new Models.Dog() { Id = 12, Name = "Pötyi", Breed = "Kuvasz", Sex = Models.Gender.female, Castrated = true, Weight = 38.5, Height = 67, OwnerId = agnes.Id, CourseId = ovt.Id };
            Models.Dog ravasz = new Models.Dog() { Id = 13, Name = "Ravasz", Breed = "Óriás schnauzer", Sex = Models.Gender.male, Castrated = false, Weight = 45.3, Height = 66.5, OwnerId = adam.Id, CourseId = ovt.Id };
            Models.Dog ace = new Models.Dog() { Id = 14, Name = "Ace", Breed = "Belga juhászkutya", Sex = Models.Gender.male, Castrated = true, Weight = 27, Height = 61.4, OwnerId = akos.Id, CourseId = ovt.Id };

            modelBuilder.Entity<Models.Owner>().HasData(tamas, eniko, istvan, dora, anna, erno, bela, miklos, csaba, kitti, zoltan, agnes, adam, akos);
            modelBuilder.Entity<Models.Dog>().HasData(buksi, poppy, athos, picur, baba, rex, ludwig, ariel, barna, cuki, xanthos, potyi, ravasz, ace);
            modelBuilder.Entity<Models.Course>().HasData(alap, halado, agility, ovt);

        }
    }
}
