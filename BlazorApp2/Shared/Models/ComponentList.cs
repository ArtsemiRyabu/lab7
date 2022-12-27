using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Shared.Models
{
    public class ComponentsList
    {
        public int ComponentsListId { get; set; }
        public int ComponentId { get; set; }
        public int ComputerOrderId { get; set; }
        public Component Component { get; set; }
        public ComputerOrder ComputerOrder { get; set; }
    }
}
