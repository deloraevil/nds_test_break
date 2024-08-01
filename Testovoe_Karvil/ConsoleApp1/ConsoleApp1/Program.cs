using System.Diagnostics;

namespace ConsoleApp1
{
    internal class Program
    {
        public static void CalcPrices(decimal InputPriceWithNDS, int ProcNDS, out decimal CorrectedPriceWithNDS, out decimal CorrectedPriceWithoutNDS)
        {
            if (ProcNDS >= 0  && ProcNDS <= 99)
            {
                decimal priceWithoutNDS = InputPriceWithNDS / (1.0m + ProcNDS / 100.0m);

                CorrectedPriceWithoutNDS = Math.Truncate(priceWithoutNDS * 100m) / 100m;

                CorrectedPriceWithNDS = CorrectedPriceWithoutNDS * (1m + ProcNDS / 100.0m);

                CorrectedPriceWithNDS = Math.Truncate(CorrectedPriceWithNDS * 100m) / 100m;
            }
            else
            {
                CorrectedPriceWithNDS = 0;
                CorrectedPriceWithoutNDS = 0;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                decimal CorrectedPriceWithNDS, CorrectedPriceWithoutNDS;

                Console.Write("InputPriceWithNDS: ");
                decimal InputPriceWithNDS = Convert.ToDecimal(Console.ReadLine());

                Console.Write("ProcNDS: ");
                int ProcNDS = Convert.ToInt32(Console.ReadLine());

                CalcPrices(InputPriceWithNDS, ProcNDS, out CorrectedPriceWithNDS, out CorrectedPriceWithoutNDS);

                Console.WriteLine("CorrectedPriceWithNDS: " + CorrectedPriceWithNDS);
                Console.WriteLine("CorrectedPriceWithoutNDS: " + CorrectedPriceWithoutNDS);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
