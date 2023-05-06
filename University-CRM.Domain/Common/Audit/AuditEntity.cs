using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_CRM.Domain.Common.Audit
{
    public class AuditEntity
    {
        public string? CreatedBy { get; private set; }
        public string? ModifiedBy { get; private set; }
        public string? DeletedBy { get; private set; }
        public DateTimeOffset CreatedDate { get; private set; }
        public DateTimeOffset? ModifiedDate { get; private set; }
        public DateTimeOffset? DeletedDate { get; private set; }
        public bool IsDeleted { get; set; }

        public void Created()
        {
            CreatedDate = DateTimeOffset.Now; 
        }
        public void Modified()
        {
            ModifiedDate = DateTimeOffset.Now;
        }

    }
}
