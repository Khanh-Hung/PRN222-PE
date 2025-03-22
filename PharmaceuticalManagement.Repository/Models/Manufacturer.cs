﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace PharmaceuticalManagement.Repositories.Models;

public partial class Manufacturer
{
    public string ManufacturerId { get; set; }

    public string ManufacturerName { get; set; }

    public string ShortDescription { get; set; }

    public int? YearEstablished { get; set; }

    public string ContactInformation { get; set; }

    public string CountryofOrigin { get; set; }

    public virtual ICollection<MedicineInformation> MedicineInformations { get; set; } = new List<MedicineInformation>();
}