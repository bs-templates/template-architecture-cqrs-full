
using BAYSOFT.Abstractions.Infrastructures.Data;
using BAYSOFT.Core.Domain.DefaultDb.Interfaces.Infrastructures.Data;

namespace BAYSOFT.Infrastructures.Data.DefaultDb
{
    public sealed class DefaultDbContextWriter : Writer, IDefaultDbContextWriter
    {
        public DefaultDbContextWriter(DefaultDbContext context)
            : base(context)
        {
        }
    }
}