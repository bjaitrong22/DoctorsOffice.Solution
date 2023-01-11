using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace DoctorsOffice.Models
{
  public class Patient
  {
    public int PatientId { get; set;}
    [Required(ErrorMessage = "The Patient's Name can't be empty!")]
    public string Name { get; set;}
    public Doctor Doctor{ get; set; }
    [Required(ErrorMessage = "Patient's birthdate is required!")]
    public DateTime? BirthDate { get; set; }

    public List<DoctorPatient> JoinEntities { get; }
  }
}