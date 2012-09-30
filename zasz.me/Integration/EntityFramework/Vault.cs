using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Vault : RepoBase<Passphrase, string>, IPassphraseRepository
    {
        public Vault(FullContext context) : base(context)
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