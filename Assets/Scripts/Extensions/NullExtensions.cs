#nullable enable
using System;

namespace Extensions
{
    public static class NullExtensions
    {
        public static T EnsureNotNull<T>(this T value, string? message = null)
        {
            if (value == null)
            {
                throw new NullReferenceException(message ?? $"Null for {typeof(T).FullName}");
            }

            return value;
        }
    }
}