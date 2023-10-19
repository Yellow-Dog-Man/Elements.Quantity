using System;
using System.Text;
using Elements.Quantity;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var u = Distance.Parse("1 R☉");
            Console.WriteLine(u.FormatAs("km"));

            //Console.WriteLine(pos.FormatAuto());
            //Console.WriteLine(pos.FormatAs(Distance.Meter));

            //Console.WriteLine("Magnitude: " + pos.Magnitude.FormatAuto());

            //pos /= 10000;

            //Console.WriteLine(pos.FormatAuto());

            //Console.WriteLine("Magnitude: " + pos.Magnitude.FormatAuto());

            //pos = pos.Normalized;

            //Console.WriteLine(pos.FormatAuto());
            //Console.WriteLine("Magnitude: " + pos.Magnitude.FormatAuto());

            //Temperature t = Temperature.Celsius * 20;

            //Console.WriteLine(t.FormatAs(Temperature.Celsius, "#.##"));
            //Console.WriteLine(t.FormatAs(Temperature.Kelvin, "#.##"));
            //Console.WriteLine(t.FormatAs(Temperature.Fahrenheit, "#.##"));

            //t = Temperature.Kelvin * 0;

            //Console.WriteLine(t.FormatAs(Temperature.Celsius, "#.##"));
            //Console.WriteLine(t.FormatAs(Temperature.Kelvin, "#.##"));
            //Console.WriteLine(t.FormatAs(Temperature.Fahrenheit, "#.##"));

            //Length l = SI<Length>.Kilo * 10;

            //try
            //{
            //    Console.WriteLine(l.FormatAs("km"));
            //    Console.WriteLine(l.FormatAs("trm"));
            //}
            //catch(UnitNameNotFoundException uex)
            //{
            //    Console.WriteLine(uex.ToString());
            //}

            //for (; ; )
            //{
            //    Voltage v;
            //    Current i;

            //    bool okay = false;

            //    do
            //    {
            //        Console.Write("Enter Voltage: ");
            //        okay = Unit<Voltage>.TryParse(Console.ReadLine(), out v);
            //        if(!okay)
            //            Console.WriteLine("Invalid!");
            //    } while (!okay);

            //    do
            //    {
            //        Console.Write("Enter Current: ");
            //        okay = Unit<Current>.TryParse(Console.ReadLine(), out i);
            //        if(!okay)
            //            Console.WriteLine("Invalid!");
            //    } while (!okay);

            //    Resistance r = v/i;

            //    Console.Write("Resistance: ");
            //    Console.WriteLine(r.FormatAuto("#.###"));
            //    Console.WriteLine("--------------------");
            //}


            //Length l = Length.Angstrom * 0.25;

            //StringBuilder str = new StringBuilder();

            //for (int i = 0; i < 30; i++)
            //{
            //    string line = l.FormatAs(Length.Meter, "e1")
            //        + "  \t|  " + l.FormatAuto("0.##", false, UnitGroup.MetricThousands)
            //        + "  \t|  " + l.FormatAuto("0.##", false, UnitGroup.Common)
            //        + "  \t|  " + l.FormatAuto("0.##", false, UnitGroup.Imperial);

            //    str.AppendLine(line);
            //    Console.WriteLine(line);
            //    l *= 10;
            //}

            //System.IO.File.WriteAllText("TestOutput.txt", str.ToString());

            //for (; ; )
            //{
            //    Length length;
            //    if (Unit<Length>.TryParse(Console.ReadLine(), out length))
            //        Console.WriteLine(length.FormatAuto("0.###", true, UnitGroup.Metric));
            //    else
            //        Console.WriteLine("Invalid");
            //}

            Console.Read();
        }
    }
}
