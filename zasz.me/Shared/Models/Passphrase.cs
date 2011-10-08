using System;
using System.ComponentModel.DataAnnotations;

namespace zasz.me.Areas.Shared.Models
{
    /* The new Creadential especially for personal sites*/

    public class Passphrase : IModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string PhraseDigest { get; set; }

        public string Name { get; set; }

        public bool OneTime { get; set; }
    }

    public interface IPassphraseRepository : IRepository<Passphrase, string>
    {
        bool Authenticate(string IncomingPassphraseDigest);
    }
}