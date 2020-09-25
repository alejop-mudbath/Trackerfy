using System;

namespace Trackerfy.Domain
{
    public static class SystemClock
    {
        private static DateTime? _now;

        public static DateTime Now => _now ?? DateTime.UtcNow;

        public static void Set(DateTime customDate) => _now = customDate;

        public static void Clean()
        {
            _now = null;
        }
    }
}