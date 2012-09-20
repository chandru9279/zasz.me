using System;
using System.ComponentModel.DataAnnotations;
using zasz.me.Integration.MVC;

namespace zasz.me.Models
{
    /* The new Creadential especially for personal sites*/

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
        bool Authenticate(string IncomingPassphraseDigest);
    }
}