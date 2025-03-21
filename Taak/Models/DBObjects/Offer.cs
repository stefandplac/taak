﻿using System;
using System.Collections.Generic;

namespace Taak.Models.DBObjects
{
    public partial class Offer
    {
        public Guid IdOffer { get; set; }
        public Guid IdTask { get; set; }
        public Guid IdTaskWorker { get; set; }
        public decimal Buget { get; set; }
        public string? SpecialRequirements { get; set; }
        public DateTime? TaskStartDate { get; set; }
        public string? EstimatedTime { get; set; }
        public bool? IsAccepted { get; set; }
        public bool? IsOriginalOfferAccepted { get; set; }

        public virtual TaakTask IdTaskNavigation { get; set; } = null!;
        public virtual TasksWorker IdTaskWorkerNavigation { get; set; } = null!;
    }
}
