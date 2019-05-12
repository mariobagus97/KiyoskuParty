using System;
using System.Runtime.Serialization;

namespace BarcodeReader.Core.Models
{
    public class GeneralSettings : ModelBase
    {
        #region Fields

        private byte[] _mainBackgroundImage;
        private string _mainBackgroundImageData;
        private byte[] _scanQrCodeBackgroundImage;
        private string _scanQrCodeBackgroundImageData;
        private byte[] _tableLayoutImage;
        private string _tableLayoutImageData;

        #endregion
        
        public byte[] MainBackgroundImage
        {
            get { return _mainBackgroundImage; }
            set
            {
                if (_mainBackgroundImage != value)
                {
                    _mainBackgroundImage = value;
                    this.OnPropertyChanged("MainBackgroundImage");
                }
            }
        }

        public string MainBackgroundImageData
        {
            get { return _mainBackgroundImageData; }
            set
            {
                if (_mainBackgroundImageData != value)
                {
                    _mainBackgroundImageData = value;
                    this.OnPropertyChanged("MainBackgroundImageData");
                }
            }
        }
        
        public byte[] ScanQrCodeBackgroundImage
        {
            get { return _scanQrCodeBackgroundImage; }
            set
            {
                if (_scanQrCodeBackgroundImage != value)
                {
                    _scanQrCodeBackgroundImage = value;
                    this.OnPropertyChanged("ScanQrCodeBackgroundImage");
                }
            }
        }

        public string ScanQrCodeBackgroundImageData
        {
            get { return _scanQrCodeBackgroundImageData; }
            set
            {
                if (_scanQrCodeBackgroundImageData != value)
                {
                    _scanQrCodeBackgroundImageData = value;
                    this.OnPropertyChanged("ScanQrCodeBackgroundImageData");
                }
            }
        }

        public byte[] TableLayoutImage
        {
            get { return _tableLayoutImage; }
            set
            {
                if (_tableLayoutImage != value)
                {
                    _tableLayoutImage = value;
                    this.OnPropertyChanged("TableLayoutImage");
                }
            }
        }


        public string TableLayoutImageData
        {
            get { return _tableLayoutImageData; }
            set
            {
                if (_tableLayoutImageData != value)
                {
                    _tableLayoutImageData = value;
                    this.OnPropertyChanged("TableLayoutImageData");
                }
            }
        }

        public void ConvertToByte()
        {
            if (!string.IsNullOrEmpty(this.MainBackgroundImageData))
                this.MainBackgroundImage = Convert.FromBase64String(this.MainBackgroundImageData);
            else
                this.MainBackgroundImage = null;

            if (!string.IsNullOrEmpty(this.ScanQrCodeBackgroundImageData))
                this.ScanQrCodeBackgroundImage = Convert.FromBase64String(this.ScanQrCodeBackgroundImageData);
            else
                this.ScanQrCodeBackgroundImage = null;

            if (!string.IsNullOrEmpty(this.TableLayoutImageData))
                this.TableLayoutImage = Convert.FromBase64String(this.TableLayoutImageData);
            else
                this.TableLayoutImage = null;
        }

        public void ConvertToBase64String()
        {
            if (this.MainBackgroundImage != null)
                this.MainBackgroundImageData = Convert.ToBase64String(this.MainBackgroundImage);
            else
                this.MainBackgroundImageData = null;

            if (this.ScanQrCodeBackgroundImage != null)
                this.ScanQrCodeBackgroundImageData = Convert.ToBase64String(this.ScanQrCodeBackgroundImage);
            else
                this.ScanQrCodeBackgroundImageData = null;
            
            if (this.TableLayoutImage != null)
                this.TableLayoutImageData = Convert.ToBase64String(this.TableLayoutImage);
            else
                this.TableLayoutImageData = null;

        }
    }
}
