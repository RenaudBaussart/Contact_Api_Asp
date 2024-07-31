using System.ComponentModel.DataAnnotations;
using Contact_api_asp.net.Controllers;
namespace Contact_api_asp.net.Classes;

    public class Contact
{
       
        [Key]public int id_contact { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime date_naissance { get; set; }
        public int age { get; set; }
        public bool sexe { get; set; }
        public string avatar { get; set; }
}