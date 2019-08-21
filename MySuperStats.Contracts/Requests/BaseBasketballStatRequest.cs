using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class BaseBasketballStatRequest
    {

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int OnePoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? TwoPoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? MissingOnePoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? MissingTwoPoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? Rebound { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? StealBall { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? LooseBall { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? Assist { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Değer sıfırdan küçük olamaz")]
        public int? Interrupt { get; set; }

        public List<string> CheckNegativeValue()
        {
            var negativeValues = new List<string>();

            if (OnePoint < 0) negativeValues.Add("Bir sayı");

            if (TwoPoint != null)
                if (TwoPoint < 0) negativeValues.Add("İki sayı");

            if (MissingOnePoint != null)
                if (MissingOnePoint < 0) negativeValues.Add("Kaçan bir sayı");

            if (MissingTwoPoint != null)
                if (MissingTwoPoint < 0) negativeValues.Add("Kaçan iki sayı");

            if (Rebound != null)
                if (Rebound < 0) negativeValues.Add("Rebound");

            if (StealBall != null)
                if (StealBall < 0) negativeValues.Add("Top Çalma");

            if (LooseBall != null)
                if (LooseBall < 0) negativeValues.Add("Top Kaybı");

            if (Assist != null)
                if (Assist < 0) negativeValues.Add("Asist");

            if (Interrupt != null)
                if (Interrupt < 0) negativeValues.Add("Top Kesme");

            return negativeValues;
        }
    }

}
