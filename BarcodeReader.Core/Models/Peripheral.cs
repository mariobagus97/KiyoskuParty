using Intersoft.Crosslight.Data.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Intersoft.Crosslight.Data;
using Intersoft.Crosslight.Data.ComponentModel;
using System.ComponentModel;
using Intersoft.Crosslight;
using System.Runtime.Serialization;
using Intersoft.AppFramework.Models;
using Intersoft.Crosslight.Services.Connectivity;

namespace BarcodeReader.Core.Models
{
    public partial class Peripheral : EntityBase
    {
        #region Constructors

        static Peripheral()
        {
            _Initialize();
        }

        internal static void _Initialize()
        {
            EntityMetadata.RegisterSynchronizationProperty(typeof(Peripheral), "SyncTime");
            EntityMetadata.RegisterLogicalDeleteProperty(typeof(Peripheral), "IsDeleted");
        }

        #endregion

        #region Property Definitions

        public static EntityProperty PeripheralIdPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, System.Guid>("PeripheralId", false, true, false));

        public static EntityProperty NamePropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("Name", false, false, false));

        public static EntityProperty TypePropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("Type", false, false, false));

        public static EntityProperty InterfaceTypePropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("InterfaceType", false, false, false));

        public static EntityProperty AddressPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("Address", false, false, false));

        public static EntityProperty PropertiesPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("Properties", true, false, false));

        public static EntityProperty DescriptionPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("Description", true, false, false));

        public static EntityProperty CreatedByPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("CreatedBy", false, false, false));

        public static EntityProperty CreatedDatePropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, System.DateTime>("CreatedDate", false, false, false));

        public static EntityProperty ModifiedByPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, string>("ModifiedBy", false, false, false));

        public static EntityProperty ModifiedDatePropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, System.DateTime>("ModifiedDate", false, false, false));

        public static EntityProperty SyncTimePropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, Nullable<System.DateTime>>("SyncTime", true, false, false));

        public static EntityProperty IsActivePropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, bool>("IsActive", false, false, false));

        public static EntityProperty IsDeletedPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, bool>("IsDeleted", false, false, false));

        public static EntityProperty TimestampPropertyMetadata =
            EntityMetadata.Register(new DataEntityProperty<Peripheral, byte[]>("Timestamp", false, false, false));

        #endregion

        #region Properties

        [PrimaryKey]
        public System.Guid PeripheralId
        {
            get { return (System.Guid)this.GetValue(PeripheralIdPropertyMetadata); }
            set { this.SetValue(PeripheralIdPropertyMetadata, value); }
        }

        [MaxLength(255)]
        public string Name
        {
            get { return (string)this.GetValue(NamePropertyMetadata); }
            set { this.SetValue(NamePropertyMetadata, value); }
        }

        [MaxLength(20)]
        public string Type
        {
            get { return (string)this.GetValue(TypePropertyMetadata); }
            set { this.SetValue(TypePropertyMetadata, value); }
        }

        [MaxLength(20)]
        public string InterfaceType
        {
            get { return (string)this.GetValue(InterfaceTypePropertyMetadata); }
            set { this.SetValue(InterfaceTypePropertyMetadata, value); }
        }

        [MaxLength(255)]
        public string Address
        {
            get { return (string)this.GetValue(AddressPropertyMetadata); }
            set { this.SetValue(AddressPropertyMetadata, value); }
        }

        public string Properties
        {
            get { return (string)this.GetValue(PropertiesPropertyMetadata); }
            set { this.SetValue(PropertiesPropertyMetadata, value); }
        }

        [MaxLength(500)]
        public string Description
        {
            get { return (string)this.GetValue(DescriptionPropertyMetadata); }
            set { this.SetValue(DescriptionPropertyMetadata, value); }
        }

        [MaxLength(255)]
        public string CreatedBy
        {
            get { return (string)this.GetValue(CreatedByPropertyMetadata); }
            set { this.SetValue(CreatedByPropertyMetadata, value); }
        }

        public System.DateTime CreatedDate
        {
            get { return (System.DateTime)this.GetValue(CreatedDatePropertyMetadata); }
            set { this.SetValue(CreatedDatePropertyMetadata, value); }
        }

        [MaxLength(255)]
        public string ModifiedBy
        {
            get { return (string)this.GetValue(ModifiedByPropertyMetadata); }
            set { this.SetValue(ModifiedByPropertyMetadata, value); }
        }

        public System.DateTime ModifiedDate
        {
            get { return (System.DateTime)this.GetValue(ModifiedDatePropertyMetadata); }
            set { this.SetValue(ModifiedDatePropertyMetadata, value); }
        }

        public Nullable<System.DateTime> SyncTime
        {
            get { return (Nullable<System.DateTime>)this.GetValue(SyncTimePropertyMetadata); }
            set { this.SetValue(SyncTimePropertyMetadata, value); }
        }

        public bool IsActive
        {
            get { return (bool)this.GetValue(IsActivePropertyMetadata); }
            set { this.SetValue(IsActivePropertyMetadata, value); }
        }

        public bool IsDeleted
        {
            get { return (bool)this.GetValue(IsDeletedPropertyMetadata); }
            set { this.SetValue(IsDeletedPropertyMetadata, value); }
        }

        [MaxLength(8)]
        public byte[] Timestamp
        {
            get { return (byte[])this.GetValue(TimestampPropertyMetadata); }
            set { this.SetValue(TimestampPropertyMetadata, value); }
        }

        #endregion

        #region partial



        private PeripheralProperties _propertiesModel;

        [IgnoreDataMember]
        public PeripheralProperties PropertiesModel
        {
            get
            {
                if (_propertiesModel == null)
                {
                    string propertyJson = this.Properties;

                    if (!string.IsNullOrEmpty(propertyJson))
                        try
                        {
                            _propertiesModel = SimpleJson.DeserializeObject<PeripheralProperties>(propertyJson);
                        }
                        catch (Exception) { }

                    if (_propertiesModel == null)
                        _propertiesModel = new PeripheralProperties();
                }

                return _propertiesModel;
            }
            set
            {
                if (_propertiesModel != value)
                {
                    _propertiesModel = value;
                    this.Properties = _propertiesModel != null ? SimpleJson.SerializeObject(_propertiesModel) : null;
                }
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == "Properties")
            {
                _propertiesModel = null;
            }
        }

        internal PeripheralDevice Device { get; set; }

        public PeripheralDevice GetDevice()
        {
            if (this.Device != null)
                return this.Device;

            PeripheralProperties propertiesModel = this.PropertiesModel;

            PeripheralDevice device = null;

            if (this.InterfaceType == "bluetooth")
                device = new PeripheralDevice(this.Name, this.Address, propertiesModel.Uuid);

            device.Tag = this;
            device.IsBatchPrinting = propertiesModel.BatchPrinting;

            this.Device = device;

            return device;
        }

        #endregion
    }

    public class PeripheralProperties : ModelBase
    {
        #region Properties

        public string HardwareAddress { get; set; }
        public string PaperSize { get; set; }
        public int Port { get; set; }
        public string PrinterType { get; set; }
        public string Uuid { get; set; }
        public bool PrintEachItemSeparately { get; set; }
        public bool UseLargerFont { get; set; }
        public bool BatchPrinting { get; set; }

        #endregion
    }

    public struct InterfaceType
    {
        public const string Bluetooth = "bluetooth";
        public const string Ethernet = "ethernet";
        public const string Usb = "usb";
        public const string Serial = "serial";
        public const string Integrated = "integrated";
    }

    public struct PeripheralType
    {
        public const string Printer = "printer";
        public const string BarcodeScanner = "barcode_scanner";
        public const string StarMPop = "star_mpop";
        public const string CardReader = "card_reader";
        public const string CustomerDisplay = "customer_display";
        public const string KitchenDisplay = "kitchen_display";
        public const string PointOfOrder = "point_order";
        public const string NfcCardReader = "nfc_card_reader";
        public const string Edc = "edc";
        public const string BillAcceptor = "bill_acceptor";
        public const string IoT = "iot";
        public const string IntegratedPrinter = "integrated_printer";
    }
}
