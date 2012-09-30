using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using zasz.me.Integration.MVC;

namespace zasz.me.Models
{
    [Table("Passphrases", Schema = "Manage")]
    public class Passphrase : IModel
    {
        [Required]
        [NaturalKey]
        public string PhraseDigest { get; set; }

        public string Name { get; set; }

        public bool OneTime { get; set; }

        #region IModel Members

        [Key]
        public Guid Id { get; set; }

        #endregion
    }

    public interface IPassphraseRepository : IRepository<Passphrase, string>
    {
        bool Authenticate(string incomingPassphraseDigest);
    }
}