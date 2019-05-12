using BarcodeReader.Core.Models;
using BarcodeReader.Core.ModelServices.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeReader.Core.ModelServices
{
    public interface IScannerBluetoothRepository : IRepository<ScannerBluetooth>
    {

    }

    public class ScannerBluetoothRepository : RepositoryBase<ScannerBluetooth>, IScannerBluetoothRepository
    {
    }
}
