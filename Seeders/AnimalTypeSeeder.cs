using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Farm.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Farm.Seeders;
public class AnimalTypeSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimalType>().HasData(
            new AnimalType
            {
                Id = 6,
                Name = "reptil",
                Description = "vertebrado de sangre fria con escamas"
            },
            new AnimalType
            {
                Id = 7,
                Name = "mamifero",
                Description = "animales que beben leche"
            },
            new AnimalType
            {
                Id = 8,
                Name = "carnivoros",
                Description = "animales que consumen exclusivamente carne"
            },
            new AnimalType
            {
                Id = 9,
                Name = "ominvoros",
                Description = "animales que consumen tanto carne como plantas"
            },
            new AnimalType
            {
                Id = 10,
                Name = "herbivoros",
                Description = "animales que consumen exclusivamente plantas"
            }
        );
    }
}