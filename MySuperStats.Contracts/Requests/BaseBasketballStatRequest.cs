using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CustomFramework.BaseWebApi.Contracts.Constants;

namespace MySuperStats.Contracts.Requests
{
    public class BaseBasketballStatRequest
    {

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(OnePoint))]
        public int OnePoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(TwoPoint))]        
        public int? TwoPoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(MissingOnePoint))]        
        public int? MissingOnePoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(MissingTwoPoint))]        
        public int? MissingTwoPoint { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(Rebound))]        
        public int? Rebound { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(StealBall))]        
        public int? StealBall { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(LooseBall))]        
        public int? LooseBall { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(Assist))]        
        public int? Assist { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(Interrupt))]        
        public int? Interrupt { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(Lane))]        
        public int? Lane { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.RangeWithMinValue)]
        [Display(Name = nameof(LaneWithoutPoint))]        
        public int? LaneWithoutPoint { get; set; }
        public List<string> CheckNegativeValue()
        {
            var negativeValues = new List<string>();

            if (OnePoint < 0) negativeValues.Add(nameof(OnePoint));

            if (TwoPoint != null)
                if (TwoPoint < 0) negativeValues.Add(nameof(TwoPoint));

            if (MissingOnePoint != null)
                if (MissingOnePoint < 0) negativeValues.Add(nameof(MissingOnePoint));

            if (MissingTwoPoint != null)
                if (MissingTwoPoint < 0) negativeValues.Add(nameof(MissingTwoPoint));

            if (Rebound != null)
                if (Rebound < 0) negativeValues.Add(nameof(Rebound));

            if (StealBall != null)
                if (StealBall < 0) negativeValues.Add(nameof(StealBall));

            if (LooseBall != null)
                if (LooseBall < 0) negativeValues.Add(nameof(LooseBall));

            if (Assist != null)
                if (Assist < 0) negativeValues.Add(nameof(Assist));

            if (Interrupt != null)
                if (Interrupt < 0) negativeValues.Add(nameof(Interrupt));

            if (Lane != null)
                if (Lane < 0) negativeValues.Add(nameof(Lane));

            if (LaneWithoutPoint != null)
                if (LaneWithoutPoint < 0) negativeValues.Add(nameof(LaneWithoutPoint));                

            return negativeValues;
        }
    }

}
