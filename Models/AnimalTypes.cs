using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Farm.Models;
public class AnimalTypes
{
    public int Id {get; set;}
    public required string Name {get; set;}
    public string? Description {get; set;}
}