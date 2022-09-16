using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charger.Application.Common.Exceptions {
    public class NotFoundException : Exception {
        public NotFoundException() :
            base() { }

        public NotFoundException(string message) :
            base(message) { }

        public NotFoundException(string entityName, int entityId) :
            base($"Entity {entityName} with id {entityId} was not found") { }
    }
}
