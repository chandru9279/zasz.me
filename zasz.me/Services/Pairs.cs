using System;
using System.Collections.Generic;

namespace zasz.me.Services
{
    public class Pairs<X, Y> : List<Pair<X, Y>>
    {
        public Pairs(X[] ones, Y[] others)
        {
            if (ones.Length != others.Length) throw new ArgumentException("Matching arrays needed");
            for (var i = 0; i < ones.Length; i++)
                Add(new Pair<X, Y>(ones[i], others[i]));
        }

        public Pairs()
        {
        }

        public Pairs(IEnumerable<Pair<X, Y>> collection)
            : base(collection)
        {
        }

        public X this[Y other]
        {
            get { return WithOther(other).One; }
            set { WithOther(other).One = value; }
        }

        public Y this[X one]
        {
            get { return WithOne(one).Other; }
            set { WithOne(one).Other = value; }
        }

        public Pair<X, Y> WithOther(Y other)
        {
            return Find(item => EqualityComparer<Y>.Default.Equals(item.Other, other));
        }

        public Pair<X, Y> WithOne(X One)
        {
            return Find(item => EqualityComparer<X>.Default.Equals(item.One, One));
        }
    }

    public class Pair<X, Y>
    {
        public Pair(X one, Y other)
        {
            One = one;
            Other = other;
        }

        public X One { get; set; }
        public Y Other { get; set; }

        #region Equality

        public bool Equals(Pair<X, Y> Target)
        {
            if (ReferenceEquals(null, Target)) return false;
            if (ReferenceEquals(this, Target)) return true;
            return Equals(Target.One, One) && Equals(Target.Other, Target);
        }

        public override bool Equals(object Obj)
        {
            if (ReferenceEquals(null, Obj)) return false;
            if (ReferenceEquals(this, Obj)) return true;
            if (Obj.GetType() != typeof (Pair<X, Y>)) return false;
            return Equals((Pair<X, Y>) Obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (One.GetHashCode()*397) ^ Other.GetHashCode();
            }
        }

        public static bool operator ==(Pair<X, Y> Left, Pair<X, Y> Right)
        {
            return Equals(Left, Right);
        }

        public static bool operator !=(Pair<X, Y> Left, Pair<X, Y> Right)
        {
            return !Equals(Left, Right);
        }

        #endregion
    }
}