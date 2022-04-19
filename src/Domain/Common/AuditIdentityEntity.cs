using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPProject.Domain.Common;
public abstract class AuditIdentityEntity : AuditableEntity
{
    public int Id { get; set; }
}
