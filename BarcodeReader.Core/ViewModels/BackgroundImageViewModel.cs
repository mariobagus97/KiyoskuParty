using BarcodeReader.Core.FormMetaData;
using BarcodeReader.Core.Models;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Forms;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using System;
using System.IO;

namespace BarcodeReader.Core.ViewModels
{
    public class BackgroundImageViewModel : EditorViewModelBase<ImagePicker>
    {
        #region Constructors

        public BackgroundImageViewModel()
        {
            this.FinishImagePickerCommand = new DelegateCommand(ExecuteFinishImagePickerCommand);
        }

        #endregion

        #region Properties

        public override Type FormMetadataType
        {
            get { return typeof(ImagePickerFormMetadata); }
        }

        public DelegateCommand FinishImagePickerCommand { get; set; }
        #endregion

        #region Methods

        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);

            this.Item = new ImagePicker();
        }

        public byte[] imagearray;

       

        protected override void ExecuteSave(object parameter)
        {

            this.Validate();

            // Perform save if there are no validation errors
            if (!this.HasErrors)
            {
                if (this.IsDirty)
                {
                    if (this.Item == null)

                        //if (this.IsNewItem)
                        //    this.ItemRepository.Insert(this.Item);
                        //else
                        //{
                        //    this.ItemRepository.Update(this.Item);
                        //    this.OnDataChanged(this.Item);
                        //}

                        // show quick status
                        this.ToastPresenter.Show("Changes saved", ToastDisplayDuration.Immediate);

                    string base64String = Convert.ToBase64String(this.Item.ThumbnailImage);

                    imagearray = this.Item.ThumbnailImage;
                    

                    MemoryStream ms = new MemoryStream(this.Item.ThumbnailImage, 0, this.Item.ThumbnailImage.Length);
                    //ms.Write(this.Item.ThumbnailImage, 0, this.Item.ThumbnailImage.Length);
                    ////Image image = new Bitmap(ms);

                    //Image image;
                    //using (MemoryStream mss = new MemoryStream(this.Item.ThumbnailImage))
                    //{
                    //    //image =  ImageSource.FromStream(mss);
                    //}
                    //ImageSource.FromStream(() => new MemoryStream(this.Item.ThumbnailImage));


                }

                this.IsDirty = false;
                

                // this.NavigationService.Close(new NavigationResult(NavigationResultAction.Done));
            }
            else
                this.MessagePresenter.Show(ErrorMessage);
        }


        private void ExecuteFinishImagePickerCommand(object parameter)
        {
            ImagePickerResultParameter resultParameter = parameter as ImagePickerResultParameter;

            if (resultParameter != null && resultParameter.Result != null)
                this.Item.LargeImage = resultParameter.Result.ImageData;


            if (resultParameter.Result != null)
            {
                this.Item.Image = Guid.NewGuid().ToString("N") + ".jpg";
                this.Item.ThumbnailImage = resultParameter.Result.ThumbnailImageData;
                this.Item.LargeImage = resultParameter.Result.ImageData;

            }

            #endregion
        }
    }
}