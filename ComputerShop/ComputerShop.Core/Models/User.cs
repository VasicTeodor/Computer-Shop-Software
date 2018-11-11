using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Core.Models
{
    [DataContract]
    public class User : INotifyPropertyChanged
    {
        [DataMember]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [DataMember]
        public String Username { get; set; }
        [DataMember]
        public String Password { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public String Surname { get; set; }
        [DataMember]
        public String Role { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
