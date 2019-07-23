//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UASMiniProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ApplicationForm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApplicationForm()
        {
            this.Participants = new HashSet<Participant>();
        }

        public int Application_Id { get; set; }
        [Required]
        public string Full_Name { get; set; }
        [Required]
        public Nullable<System.DateTime> Date_Of_Birth { get; set; }
        [Required]
        public string Highest_Qualification { get; set; }
        [Required]
        public Nullable<int> Marks_Obtained { get; set; }
        [Required]
        public string Goals { get; set; }
        [Required]
        public string Email_Id { get; set; }
        public string Scheduled_Program_Id { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> Date_Of_Interview { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participant> Participants { get; set; }
    }
}
