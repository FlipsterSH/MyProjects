using System.Net.NetworkInformation;

namespace BlazorWebapp.Pages
{
    public class Calculator1
    {
        public string Description = "This program calculates the average percent return on an investment. Meant for investment in Real Estate, but works for other investments aswell.";
        public double Egenkapital { get; set; }
        public double Laan { get; set; }
        public int Antall_aar { get; set; }
        public double Estimert_verdi { get; set; }



        public string calculate_percent_return_own()
        {
            if (Egenkapital != 0.0 & Estimert_verdi != 0.0)
            {
                double total_gain = Estimert_verdi - Laan;
                double gain_to_egenkap = total_gain / Egenkapital;
                double anual_growth = Math.Pow(gain_to_egenkap, 1.0 / Antall_aar);
                double percent_anual_growth = (anual_growth - 1) * 100;
                double rounded = Math.Round(percent_anual_growth, 2);


                return $"The anual percent return on own capital is: {rounded.ToString()}%";
            }

            return "No value submitted";
        }

        public string calculate_percent_return_all()
        {
            if (Egenkapital != 0.0 & Estimert_verdi != 0.0)
            {
                double gain_to_egenkap = Estimert_verdi / (Egenkapital + Laan);
                double anual_growth = Math.Pow(gain_to_egenkap, 1.0 / Antall_aar);
                double percent_anual_growth = (anual_growth - 1) * 100;
                double rounded = Math.Round(percent_anual_growth, 2);


                return $"The anual percent return on total investment is: {rounded.ToString()}%";
            }

            return "No value submitted";
        }
    }
}
