using System;
using Raven.Client;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class Vault : RepoBase<Passphrase>, IPassphraseRepository
    {
        public Vault(IDocumentStore Store) : base(Store)
        {
        }

        public bool IsValid(Passphrase Incoming)
        {
            throw new NotImplementedException();
        }
    }
}