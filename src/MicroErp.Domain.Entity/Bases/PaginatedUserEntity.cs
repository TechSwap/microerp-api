using MicroErp.Domain.Entity.Users;

namespace MicroErp.Domain.Entity.Bases;

public class PaginatedUserEntity
{
    public PaginatedMetaDataEntity MetaData { get; set; }
    public IEnumerable<User> Items { get; set; }
}
