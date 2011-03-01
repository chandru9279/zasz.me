using System;
using Raven.Client.Document;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class Vault : RepoBase<Passphrase>, IPassphraseRepository
    {
        public Vault(DocumentStore Store) : base(Store)
        {
        }

        public bool IsValid(Passphrase Incoming)
        {
            throw new NotImplementedException();
        }
    }
}