namespace Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoleMenu> RoleMenus { get; set; }
        public ICollection<Usuario> Users { get; set; }
    }
}
