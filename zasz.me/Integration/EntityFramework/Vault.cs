using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Vault : RepoBase<Passphrase>, IPassphraseRepository
    {
        public Vault(FullContext Session) : base(Session)
        {
        }

        public bool Authenticate(string IncomingPhraseDigest)
        {
            return Get(IncomingPhraseDigest) != null;
        }
    }
}