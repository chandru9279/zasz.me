using System;
using System.Collections.Generic;

namespace zasz.me.Services
{
    public class Pairs<X, Y> : List<Pair<X, Y>>
    {
        public Pairs(X[] Ones, Y[] Others)
        {
            if (Ones.Length != Others.Length) throw new ArgumentException("Matching arrays needed");
            for (var i = 0; i < Ones.Length; i++)
                Add(new Pair<X, Y>(Ones[i], Others[i]));
        }

        public Pairs()
        {
        }

        public Pairs(IEnumerable<Pair<X, Y>> collection)
            : base(collection)
        {
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

        public Pair<X, Y> WithOther(Y Other)
        {
            return Find(Item => EqualityComparer<Y>.Default.Equals(Item.Other, Other));
        }

        public Pair<X, Y> WithOne(X One)
        {
            return Find(Item => EqualityComparer<X>.Default.Equals(Item.One, One));
        }
    }

    public class Pair<X, Y>
    {
        public Pair(X One, Y Other)
        {
            this.One = One;
            this.Other = Other;
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