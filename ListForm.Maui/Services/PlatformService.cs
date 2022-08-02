using ListForm.Shared.Interfaces;

namespace ListForm.Maui.Services
{
    public class PlatformService : IPlatformService
    {
        public string GetPlaformInfo()
        {
            return DeviceInfo.Current.Platform.ToString();
        }
    }
}
