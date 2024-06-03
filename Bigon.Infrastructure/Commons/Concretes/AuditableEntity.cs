﻿using Bigon.Infrastructure.Commons.Abstracts;

namespace Bigon.Infrastructure.Commons
{
    public abstract class AuditableEntity: IAuditableEntity
    {


        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
