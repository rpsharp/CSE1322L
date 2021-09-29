using System;

namespace rsharp8_CSE1322L_Assignment3
{
    class Driver
    {
        static void Main(string[] args)
        {
            double calculateHeatIndex(double T, double R)
            {
                const double c1 = -42.379;
                const double c2 = 2.04901523;
                const double c3 = 10.14333127;
                const double c4 = -0.22475541;
                const double c5 = -0.00683783;
                const double c6 = -0.05481717;
                const double c7 = 0.0012274;
                const double c8 = 0.00085282;
                const double c9 = -0.00000199;

                double HI = c1 + (c2 * T) + (c3 * R) + (c4 * T * R) + (c5 * T * T) + (c6 * R * R) + (c7 * T * T * R) + (c8 * T * R * R) + (c9 * T * T * R * R);

                return HI;
            }

            double calculateWindChill (double T, double W)
            {
                double WC = 35.74 + (0.6215 * T) - (35.75 * Math.Pow(W, 0.16)) + (0.4275 * T * Math.Pow(W, 0.16));

                return WC;
            }

            Console.WriteLine("What is the current temperature in Fahrenheit?");
            double inputTemp = double.Parse(Console.ReadLine());

            Temperature t = new Temperature(inputTemp, 'f');

            if (inputTemp >= 80)
            {
                Console.WriteLine("What is the current humidity percentage (0-100)?");
                double hum = double.Parse(Console.ReadLine());
                if (hum >= 40)
                {
                    Temperature hi = new Temperature(calculateHeatIndex(t.getTempInF(), hum), 'f');
                    Console.WriteLine($"The current Heat Index is: {hi.getTempInF()}f and {hi.getTempInC()}c and {hi.getTempInK()}k");
                }
                else
                {
                    Console.WriteLine($"The current Heat Index is: {t.getTempInF()}f and {t.getTempInC()}c and {t.getTempInK()}k");
                }
            }
            else if (inputTemp <= 50)
            {
                Console.WriteLine("What is the current wind speed in mph?");
                double ws = double.Parse(Console.ReadLine());

                if (ws >= 3)
                {
                    Temperature wc = new Temperature(calculateWindChill(t.getTempInF(), ws), 'f');
                    Console.WriteLine($"The current Wind Chill is: {wc.getTempInF()}f and {wc.getTempInC()}c and {wc.getTempInK()}k");
                }
                else
                {
                    Console.WriteLine($"There is no Wind Chill, the current temperature is: {t.getTempInF()}f and {t.getTempInC()}c and {t.getTempInK()}k");
                }
            }
            else
            {
                Console.WriteLine($"There is currently no Heat Index nor Wind Chill. The temperature you entered is {t.getTempInF()}f and {t.getTempInC()}c and {t.getTempInK()}k");

            }
        }
    }

    class Temperature
    {
        private double Temp;

        public Temperature()
        {
            Temp = 72;
        }

        public Temperature(double newTemperature, char unit)
        {
            if (unit == 'f') { Temp = newTemperature; }
            else if (unit == 'c') { Temp = convertCToF(newTemperature); }
            else if (unit == 'k') { Temp = convertCToF(convertKToC(newTemperature)); }
        }

        public double convertCToF(double cTemp)
        {
            double fTemp = (9f / (5f * cTemp)) + 32;
            return fTemp;
        }

        public double convertFToC(double fTemp)
        {
            double cTemp = (fTemp - 32) * (5f / 9f);
            return cTemp;
        }

        public double convertKToC(double kTemp)
        {
            double cTemp = kTemp - 273.15;
            return cTemp;
        }

        public double convertCToK(double cTemp)
        {
            double kTemp = cTemp + 273.15;
            return kTemp;
        }

        public double getTempInF()
        {
            return Temp;
        }

        public double getTempInC()
        {
            return convertFToC(Temp);
        }

        public double getTempInK()
        {
            return convertCToK(getTempInC());
        }
    }
}
