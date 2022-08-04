namespace ListForm.Domain
{
    public static class AppSettings
    {
        public static string DefaultConnectionString()
        {
            return "Data Source=(localdb)\\ProjectModels;Initial Catalog=ListForm;Integrated Security=True;MultipleActiveResultSets=True";
        }
    }
}
