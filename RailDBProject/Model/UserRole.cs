using System.ComponentModel;

namespace RailDBProject.Model
{
    public enum UserRole
    {
        [Description("Неверифицированный пользователь")]
        newUser,
        [Description("Администратор")]
        Administrator,
        [Description("Руководитель управления дороги")]
        AdministrationSupervisor,
        [Description("Руководитель отделения дороги")]
        NodeSupervisor,
        [Description("Мастер участка дефектоскопии")]
        LineSupervisor
    }
}
