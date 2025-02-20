namespace Entities
{
    public class RoleMenu
    {
        public int Id { get; set; }
        public int MenuId {  get; set; }
        public Menu Menu { get; set; }
        public int RolId {  get; set; }
        public Rol Rol { get; set; }
    }
}
