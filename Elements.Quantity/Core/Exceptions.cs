using System;
using System.Collections.Generic;

using System.Text;

namespace Elements.Quantity
{
    public class SmartQuantityException : Exception
    {
        public SmartQuantityException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }

    public class UnitNameNotFoundException : SmartQuantityException
    {
        public string UnitName { get; private set; }

        public UnitNameNotFoundException(string unitName, Exception? innerException = null)
            : base("Specified unit name isn't defined by any of the units.", innerException)
        {
            this.UnitName = unitName;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine(Message);
            str.AppendLine("Unit Name: " + UnitName);
            str.AppendLine(base.ToString());

            return str.ToString();
        }
    }
}
