using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class PassphraseRepository : RepoBase<Passphrase, string>, IPassphraseRepository
    {
        public PassphraseRepository(FullContext context) : base(context)
        {
        }

        #region IPassphraseRepository Members

        public bool Authenticate(string incomingPassphraseDigest)
        {
            return Get(incomingPassphraseDigest) != null;
        }

        #endregion
    }
}