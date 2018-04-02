﻿using System;
using System.Collections.Generic;
using BasketballStats.WebApi.Data;
using Newtonsoft.Json;

namespace BasketballStats.WebApi.Models
{
    public class Match : BaseModel<int>
    {
        private DateTime _matchDateTime;

        public DateTime MatchDate
        {
            get => _matchDateTime;
            set => _matchDateTime = value.Date;
        }

        public int Order { get; set; }
        public int DurationInMinutes { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string VideoLink { get; set; }

        public virtual Team HomeTeam { get; set; }

        public virtual Team AwayTeam { get; set; }

        [JsonIgnore]
        public virtual ICollection<Stat> Stats { get; set; }

    }
}
