using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MySuperStats.Contracts.Requests
{
    public class BaseBasketballStatRequest
    {

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int OnePoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? TwoPoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? MissingOnePoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? MissingTwoPoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? Rebound { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? StealBall { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? LooseBall { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? Assist { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "<field>{0}</field> <message>MinValueError</message> <const>{1}</const>")]
        public int? Interrupt { get; set; }

        public List<string> CheckNegativeValue()
        {
            var negativeValues = new List<string>();

            if (OnePoint < 0) negativeValues.Add("OnePoint");

            if (TwoPoint != null)
                if (TwoPoint < 0) negativeValues.Add("TwoPoint");

            if (MissingOnePoint != null)
                if (MissingOnePoint < 0) negativeValues.Add("MissingOnePoint");

            if (MissingTwoPoint != null)
                if (MissingTwoPoint < 0) negativeValues.Add("MissingTwoPoint");

            if (Rebound != null)
                if (Rebound < 0) negativeValues.Add("Rebound");

            if (StealBall != null)
                if (StealBall < 0) negativeValues.Add("StealBall");

            if (LooseBall != null)
                if (LooseBall < 0) negativeValues.Add("LooseBall");

            if (Assist != null)
                if (Assist < 0) negativeValues.Add("Assist");

            if (Interrupt != null)
                if (Interrupt < 0) negativeValues.Add("Interrupt");

            return negativeValues;
        }
    }

}
