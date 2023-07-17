using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    [NotMapped]
    public class ExcludeClass
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
