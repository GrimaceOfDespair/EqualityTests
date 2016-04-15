namespace EqualityTests.UnitTests
{
    using System;
    using System.Diagnostics;
    using Exception;
    using Xunit;

    public class EqualityAssertionTests
    {

        [Theory, AutoDomainData]
        public void ProperlyImplementedClassWithMultipleArgsShouldPassEquality()
        {
            EqualityTestsFor<ClassWithMultipleArgs>
                .Assert();
        }

        [Theory, AutoDomainData]
        public void FaultyImplementedClassWithMultipleArgsShouldNotPassEquality()
        {
            Assert.Throws<EqualsValueCheckException>(() =>
                EqualityTestsFor<FaultyClassWithMultipleArgs>
                .Assert());
        }

        public class FaultyClassWithMultipleArgs : IEquatable<FaultyClassWithMultipleArgs>
        {
            public FaultyClassWithMultipleArgs(string s, int i)
            {
            }

            public bool Equals(FaultyClassWithMultipleArgs other)
            {
                if (other == null)
                {
                    return false;
                }

                return true;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (obj.GetType() != GetType())
                {
                    return false;
                }

                return Equals(obj as FaultyClassWithMultipleArgs);
            }

            public static bool operator ==(FaultyClassWithMultipleArgs thisClassWithMultipleArgs, FaultyClassWithMultipleArgs otherClassWithMultipleArgs)
            {
                return Equals(thisClassWithMultipleArgs, otherClassWithMultipleArgs);
            }

            public static bool operator !=(FaultyClassWithMultipleArgs thisClassWithMultipleArgs, FaultyClassWithMultipleArgs otherClassWithMultipleArgs)
            {
                return Equals(thisClassWithMultipleArgs, otherClassWithMultipleArgs) == false;
            }

            public override int GetHashCode()
            {
                return 0;
            }
        }

        public class ClassWithMultipleArgs : IEquatable<ClassWithMultipleArgs>
        {
            public string S1 { get; private set; }

            public string S2 { get; private set; }

            public bool B1 { get; private set; }

            public bool B2 { get; private set; }

            public int I1 { get; private set; }

            public int I2 { get; private set; }

            public ClassWithMultipleArgs(string s1, string s2, bool b1, bool b2, int i1, int i2)
            {
                this.S1 = s1;
                this.S2 = s2;
                this.B1 = b1;
                this.B2 = b2;
                this.I1 = i1;
                this.I2 = i2;
            }

            public bool Equals(ClassWithMultipleArgs other)
            {
                if (other == null)
                {
                    return false;
                }

                return string.Equals(this.S1, other.S1, StringComparison.Ordinal) &&
                    string.Equals(this.S2, other.S2, StringComparison.Ordinal) &&
                    this.B1 == other.B1 &&
                    this.B2 == other.B2 &&
                    this.I1 == other.I1 &&
                    this.I2 == other.I2;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }
                if (ReferenceEquals(this, obj))
                {
                    return true;
                }
                if (obj.GetType() != GetType())
                {
                    return false;
                }

                return Equals(obj as ClassWithMultipleArgs);
            }

            public static bool operator ==(ClassWithMultipleArgs thisClassWithMultipleArgs, ClassWithMultipleArgs otherClassWithMultipleArgs)
            {
                return Equals(thisClassWithMultipleArgs, otherClassWithMultipleArgs);
            }

            public static bool operator !=(ClassWithMultipleArgs thisClassWithMultipleArgs, ClassWithMultipleArgs otherClassWithMultipleArgs)
            {
                return Equals(thisClassWithMultipleArgs, otherClassWithMultipleArgs) == false;
            }

            public override int GetHashCode()
            {
                var hashCode = 486187739 ^ (this.S1 ?? "").GetHashCode();

                hashCode = (hashCode * 486187739) ^ this.S2.GetHashCode();

                hashCode = (hashCode * 486187739) ^ this.B1.GetHashCode();

                hashCode = (hashCode * 486187739) ^ this.B2.GetHashCode();

                hashCode = (hashCode * 486187739) ^ this.I1.GetHashCode();

                hashCode = (hashCode * 486187739) ^ this.I2.GetHashCode();

                return hashCode;
            }
        }
    }
}
