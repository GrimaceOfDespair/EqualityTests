using System;
using System.Collections.Generic;
using Ploeh.AutoFixture.Kernel;

namespace EqualityTests.Extensions
{
    public static class SpecimenBuilderExtensions
    {
        public static object CreateInstanceOfType(this ISpecimenBuilder builder, Type type)
        {
            return builder.Create(type, new SpecimenContext(builder));
        }

        public static object DifferentFrom(this object thisObject, object otherObject)
        {
            if (thisObject.Equals(otherObject))
            {
                if (otherObject is bool)
                {
                    return !(bool)otherObject;
                }

                if (otherObject is byte)
                {
                    return (byte)otherObject * 2 + 1;
                }

                if (otherObject is sbyte)
                {
                    return (sbyte)otherObject * 2 + 1;
                }

                if (otherObject is uint)
                {
                    return (uint)otherObject * 2 + 1;
                }

                if (otherObject is int)
                {
                    return (int)otherObject * 2 + 1;
                }

                if (otherObject is decimal)
                {
                    return (decimal)otherObject * 2 + 1;
                }

                if (otherObject is float)
                {
                    return (float)otherObject * 2 + 1;
                }

                if (otherObject is double)
                {
                    return (double)otherObject * 2 + 1;
                }
            }

            return thisObject;
        }
    }
}
