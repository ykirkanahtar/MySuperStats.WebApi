using System;
using BasketballStats.WebApi.Data.Enum;

namespace BasketballStats.WebApi.Data.Contracts
{
    public interface IBaseModel<TKey>
    {
        TKey Id { get; set; }
        DateTime CreateDateTime { get; set; }
        DateTime? UpdateDateTime { get; set; }
        DateTime? DeleteDateTime { get; set; }
        Status Status { get; set; }
    }
}
