using Intersoft.Crosslight;
using Intersoft.Crosslight.Forms;

namespace BarcodeReader.Core.FormMetaData
{
    public class GeneralSettingsFormMetadata
    {
        #region Sections

        [Section(Style = SectionLayoutStyle.ImageWithFields, Header = "            MainBackground Image")]
        public MainBackgroundImageSection MainBackgroundImage;
        

        [Section(Style = SectionLayoutStyle.ImageWithFields, Header = "  ScanQrCode BackgroundImage")]
        public ScanQrCodeBackgroundImageSection ScanQrCodeBackgroundImage;

        [Section(Style = SectionLayoutStyle.ImageWithFields, Header = "            Table Layout Image")]
        public TableLayoutImageSection TableLayoutImage;
        #endregion

        public class MainBackgroundImageSection
        {
            [Editor(EditorType.Image)]
            [Image(Height  = 200, Width = 200, Placeholder = "item_placeholder.png", Frame = "frame.png", FramePadding = 6, FrameShadowHeight = 3)]
            [ImagePicker(ImageResultMode = ImageResultMode.FullSize)]
            public static byte[] MainBackgroundImage;
        }

        public class ScanQrCodeBackgroundImageSection
        {
            [Editor(EditorType.Image)]
            [Image(Height = 200, Width = 200, Placeholder = "item_placeholder.png", Frame = "frame.png", FramePadding = 6, FrameShadowHeight = 3)]
            [ImagePicker(ImageResultMode = ImageResultMode.FullSize)]
            public static byte[] ScanQrCodeBackgroundImage;
        }

        public class TableLayoutImageSection
        {
            [Editor(EditorType.Image)]
            [Image(Height = 200, Width = 200, Placeholder = "item_placeholder.png", Frame = "frame.png", FramePadding = 6, FrameShadowHeight = 3)]
            [ImagePicker(ImageResultMode = ImageResultMode.FullSize)]
            public static byte[] TableLayoutImage;
        }
    }
}
