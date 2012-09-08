using System;
using System.Linq.Expressions;
using zasz.me.Models;

namespace zasz.me.Integration.EntityFramework
{
    public class Vault : RepoBase<Passphrase, string>, IPassphraseRepository
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

        public override Expression<Func<Passphrase, bool>> NaturalKeyComparison(string PhraseDigest)
        {
            return x => x.PhraseDigest == PhraseDigest;
        }
    }
}