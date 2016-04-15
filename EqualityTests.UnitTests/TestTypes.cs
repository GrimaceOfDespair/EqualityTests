namespace EqualityTests.UnitTests
{
    public class SimpleType
    {
        public SimpleType(string s1, string s2, int x)
        {
            S1 = s1;
            S2 = s2;
            X = x;
        }

        public int X { get; private set; }

        public string S1 { get; private set; }

        public string S2 { get; private set; }
    }
}
