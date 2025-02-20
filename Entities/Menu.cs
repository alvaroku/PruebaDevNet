namespace Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ruta { get; set; }
        public ICollection<RoleMenu> RoleMenus {  get; set; }
    }
}
