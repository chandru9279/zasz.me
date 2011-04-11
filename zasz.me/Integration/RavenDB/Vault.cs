using Raven.Client;
using zasz.me.Models;

namespace zasz.me.Integration.RavenDB
{
    public class Vault : RepoBase<Passphrase>, IPassphraseRepository
    {
        public Vault(IDocumentSession Session) : base(Session)
        {
        }

        public bool Authenticate(string IncomingPhraseDigest)
        {
            return Get(IncomingPhraseDigest) != null;
        }
    }
}