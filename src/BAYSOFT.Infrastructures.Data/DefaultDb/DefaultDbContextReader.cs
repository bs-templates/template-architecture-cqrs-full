
using BAYSOFT.Abstractions.Infrastructures.Data;
using BAYSOFT.Core.Domain.DefaultDb.Interfaces.Infrastructures.Data;

namespace BAYSOFT.Infrastructures.Data.DefaultDb
{
    public sealed class DefaultDbContextReader : Reader, IDefaultDbContextReader
    {
        public DefaultDbContextReader(DefaultDbContext context)
            : base(context)
        {
        }
    }
}