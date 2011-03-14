using System;
using System.Collections.Generic;

namespace zasz.me.Services
{
    public class Pairs<X, Y> : List<Pairs<X, Y>.Pair>
    {
        public class Pair
        {
            private Pair()
            {
            }

            public X One { get; set; }
            public Y Other { get; set; }

            #region Equality

            public bool Equals(Pair other)
            {
                if (other == null) throw new ArgumentNullException("other");
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other.One, One) && Equals(other.Other, Other);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (Pair)) return false;
                return Equals((Pair) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return (One.GetHashCode()*397) ^ Other.GetHashCode();
                }
            }

            public static bool operator ==(Pair Left, Pair Right)
            {
                return Equals(Left, Right);
            }

            public static bool operator !=(Pair Left, Pair Right)
            {
                return !Equals(Left, Right);
            }

            #endregion
        }

        public Pair WithOther(Y Other)
        {
            return Find(Item => EqualityComparer<Y>.Default.Equals(Item.Other, Other));
        }

        public Pair WithOne(X One)
        {
            return Find(Item => EqualityComparer<X>.Default.Equals(Item.One, One));
        }

        public X this[Y Other]
        {
            get { return WithOther(Other).One; }
            set { WithOther(Other).One = value; }
        }

        public Y this[X One]
        {
            get { return WithOne(One).Other; }
            set { WithOne(One).Other = value; }
        }
    }
}