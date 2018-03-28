using System;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Data.Enum;

namespace BasketballStats.WebApi.Data
{
    public class BaseModel<TKey> : IBaseModel<TKey>
    {
        public TKey Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public Status Status { get; set; }
    }
}
