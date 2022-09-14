using Charger.Domain.Models.Request.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charger.Application.Contracts.Commands {

    public interface IStationCommand {
        Task<int> Create(RequestCreateStation requestCreateStation);
    }

}
