using ListForm.Shared.Interfaces;

namespace ListForm.Blazor.Services
{
    public class PlatformService : IPlatformService
    {
        public string GetPlaformInfo()
        {
            return "WEB";
        }
    }
}
