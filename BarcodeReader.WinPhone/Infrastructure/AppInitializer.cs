using BarcodeReader.Infrastructure;
using Intersoft.Crosslight;
using Intersoft.Crosslight.WinPhone;

namespace BarcodeReader.WinPhone.Infrastructure
{
    public sealed class AppInitializer : IApplicationInitializer
    {
        #region Methods

        public IApplicationService GetApplicationService(IApplicationContext context)
        {
            return new CrosslightAppAppService(context);
        }

        public void InitializeApplication(IApplicationHost appHost)
        {
        }

        public void InitializeComponents(IApplicationHost appHost)
        {
        }

        public void InitializeServices(IApplicationHost appHost)
        {
            Application.PreserveAssembly((typeof(Intersoft.Crosslight.Services.Barcode.WinPhone.ServiceInitializer).Assembly));
        }

        #endregion
    }
}