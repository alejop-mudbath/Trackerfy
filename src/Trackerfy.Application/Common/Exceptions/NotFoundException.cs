using System;

namespace Trackerfy.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity {name} Id:({key}) does not exits.")
        {
        }
    }
}