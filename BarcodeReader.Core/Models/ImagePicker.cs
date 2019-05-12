using System.Reflection;
using Intersoft.Crosslight.Data.EntityModel;
using BarcodeReader.Core.Extensions;
using Intersoft.Crosslight;

namespace BarcodeReader.Core.Models
{
    [Serializable]
    public class ImagePicker : ModelBase
    {

        public ImagePicker()
        {
            //this.ProfilePicture = typeof(ImagePicker).GetTypeInfo().Assembly.GetManifestResourceStream("FormBuilderSamples.Core.Assets.Images.ProfilePhoto.png").ToByte();
        }
        #region Fields

        private string _image;
        internal byte[] _largeImage;
        internal byte[] _thumbnailImage;

        #endregion

        #region Properties



        //public byte[] ProfilePicture
        //{
        //    get { return (byte[])this.GetValue(ProfilePicturePropertyMetadata); }
        //    set { this.SetValue(ProfilePicturePropertyMetadata, value); }
        //}

        #endregion

        #region Constants

      //  public static EntityProperty ProfilePicturePropertyMetadata = EntityMetadata.Register(new DataEntityProperty<ImagePicker, byte[]>("ProfilePicture", false));

        #endregion

        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
        
        public byte[] LargeImage
        {
            get { return _largeImage; }
            set
            {
                _largeImage = value;

                if (value == null)
                    this.Image = null;
                //else
                //    this.Image = "image_"  + ".png";

                OnPropertyChanged("LargeImage");
            }
        }

        public byte[] ThumbnailImage
        {
            get { return _thumbnailImage; }
            set
            {
                if (_thumbnailImage != value)
                {
                    _thumbnailImage = value;
                    OnPropertyChanged("ThumbnailImage");

                    if (_thumbnailImage == null)
                        this.LargeImage = null;
                }
            }
        }
    }
}