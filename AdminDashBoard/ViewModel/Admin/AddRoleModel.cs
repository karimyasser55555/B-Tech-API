namespace AdminDashBoard.ViewModel.Admin
{
    public class AddRoleModel
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
        public AddRoleModel(int userId, string roleName)
        {
            UserId = userId;
            RoleName = roleName;
        }
    }
}
