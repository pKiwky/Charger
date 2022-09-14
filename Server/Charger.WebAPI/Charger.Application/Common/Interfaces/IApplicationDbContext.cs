﻿using Charger.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charger.Application.Common.Interfaces {

    public interface IApplicationDbContext {
        DbSet<StationEntity> Stations { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}