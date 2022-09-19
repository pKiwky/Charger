using Charger.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charger.Domain.Models.Response.Commands {

    public class ResponseRegisterModel {
        public ERegisterResponse RegisterResponse { get; set; }
        public string Data { get; set; }
    }

}
