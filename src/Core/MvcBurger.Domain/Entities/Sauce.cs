using MvcBurger.Domain.Entities.Common;

namespace MvcBurger.Domain.Entities
{
    public class Sauce : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public ICollection<SauceOrder> SauceOrder { get; set; }
    }

}
