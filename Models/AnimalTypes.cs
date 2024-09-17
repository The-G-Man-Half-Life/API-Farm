using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Farm.Models;

[Table("animal_types")]
public class AnimalTypes
{
    [Column("id")]
    public int Id {get; set;}

    [Column("name")]
    public required string Name {get; set;}

    [Column("description")]
    public string? Description {get; set;}
}