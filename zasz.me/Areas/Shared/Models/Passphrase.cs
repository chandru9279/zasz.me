using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace zasz.me.Areas.Shared.Models
{
    /* The new Creadential especially for personal sites*/

    public class Passphrase : IModel<Passphrase, string>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string PhraseDigest { get; set; }

        public string Name { get; set; }

        public bool OneTime { get; set; }

        public Func<Passphrase, bool> NaturalEquals(string IncomingDigest)
        {
            return It => It.PhraseDigest == IncomingDigest;
        }
    }

    public interface IPassphraseRepository : IRepository<Passphrase, string>
    {
        bool Authenticate(string IncomingPassphraseDigest);
    }
}