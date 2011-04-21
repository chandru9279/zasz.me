﻿using System.ComponentModel.DataAnnotations;

namespace zasz.me.Models
{
    /* The new Creadential especially for personal sites*/

    public class Passphrase : IModel
    {
        [Key]
        public string PhraseDigest { get; set; }

        public string Name { get; set; }

        public bool OneTime { get; set; }
    }

    public interface IPassphraseRepository : IRepository<Passphrase>
    {
        bool Authenticate(string IncomingPassphraseDigest);
    }
}