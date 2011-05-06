using zasz.me.Areas.Shared.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Vault : RepoBase<Passphrase>, IPassphraseRepository
    {
        public Vault(FullContext Session) : base(Session)
        {
        }

        #region IPassphraseRepository Members

        public bool Authenticate(string IncomingPhraseDigest)
        {
            return Get(IncomingPhraseDigest) != null;
        }

        #endregion
    }
}