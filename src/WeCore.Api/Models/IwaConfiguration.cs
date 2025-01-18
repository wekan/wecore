using System.ComponentModel.DataAnnotations;

namespace WeCore.Api.Models
{
    public class IwaConfiguration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Domain { get; set; }

        [Required]
        public string LdapServer { get; set; }

        public int LdapPort { get; set; } = 389;

        public bool UseSsl { get; set; }

        public string SearchBase { get; set; }

        public string BindDn { get; set; }

        public string BindCredentials { get; set; }
    }
}
