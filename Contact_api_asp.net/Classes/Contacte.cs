using System.ComponentModel.DataAnnotations;

namespace Contact_api_asp.net.Classes
{
        public class Contacte
        {
            [Key]public int Id_contact { get; set; }
            public string nom { get; set; }
            public string prenom { get; set; }
            public DateTime date_naissance { get; set; }
            public int age { get; set; }
            public bool sexe { get; set; }
            public string avatar { get; set; }
        }
}
