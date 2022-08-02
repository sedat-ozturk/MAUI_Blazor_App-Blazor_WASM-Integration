using ListForm.Shared.Interfaces;

namespace ListForm.BlazorWasm.Services
{
    public class PlatformService : IPlatformService
    {
        public string GetPlaformInfo()
        {
            return "WEB";
        }
    }
}
