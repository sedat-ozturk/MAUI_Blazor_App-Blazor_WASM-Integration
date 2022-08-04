namespace ListForm.Domain
{
    public static class AppSettings
    {
        public static string DefaultConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ListForm;Trusted_Connection=True;MultipleActiveResultSets=True";
        }
    }
}
