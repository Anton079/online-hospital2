using online_hospital.Administration;

internal class Program
{
    private static void Main(string[] args)
    {
        AdminService adminService = new AdminService();

        //admin.AfisareAdmins();

        Admin adminNew = new Admin(3, "Raluca", "Raluca@gmail.com");

        adminService.AddAdmin(adminNew);
        adminService.SaveData();
        
    }
}