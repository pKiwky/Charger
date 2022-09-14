using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charger.Application.Contracts.Commands {

    public interface IAuthenticationCommand {
        Task<string> LoginIfUserExists(string username, string password);
    }

}
