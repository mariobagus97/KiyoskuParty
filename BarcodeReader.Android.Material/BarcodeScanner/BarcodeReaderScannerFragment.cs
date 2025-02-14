using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using ZXing;
using BarcodeReader.Android;

namespace BarcodeScanner
{
    public class BarcodeReaderScannerFragment : Fragment
    {
        public BarcodeReaderScannerFragment()
        {
            ScanningOptions = MobileBarcodeScanningOptions.Default;
            UseCustomView = false;
        }

        public BarcodeReaderScannerFragment(Action<Result> scanResultCallback, MobileBarcodeScanningOptions options = null)
        {
            Callback = scanResultCallback;
            ScanningOptions = options ?? MobileBarcodeScanningOptions.Default;
            UseCustomView = false;
        }

        public Action<Result> Callback { get; set; }
        FrameLayout frame;

        public override View OnCreateView(LayoutInflater layoutInflater, ViewGroup viewGroup, Bundle bundle)
        {
            frame = (FrameLayout)layoutInflater.Inflate(Resource.Layout.barcodereaderfragmentlayout, viewGroup, false);

            return frame;
        }

        public override void OnResume()
        {
            base.OnResume();

            var layoutParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent);
            layoutParams.Weight = 1;

            try
            {
                scanner = new BarcodeReaderSurfaceView(this.Activity, ScanningOptions, Callback);

                frame.AddView(scanner, layoutParams);


                if (!UseCustomView)
                {
                    zxingOverlay = new BarcodeReaderOverlayView(this.Activity);
                    zxingOverlay.TopText = TopText ?? "";
                    zxingOverlay.BottomText = BottomText ?? "";

                    frame.AddView(zxingOverlay, layoutParams);
                }
                else if (CustomOverlayView != null)
                {
                    frame.AddView(CustomOverlayView, layoutParams);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Create Surface View Failed: " + ex);
            }
        }

        public override void OnPause()
        {
            base.OnPause();

            scanner.ShutdownCamera();

            frame.RemoveView(scanner);

            if (!UseCustomView)
                frame.RemoveView(zxingOverlay);
            else if (CustomOverlayView != null)
                frame.RemoveView(CustomOverlayView);
        }

        public View CustomOverlayView { get; set; }
        public bool UseCustomView { get; set; }
        public MobileBarcodeScanningOptions ScanningOptions { get; set; }
        public string TopText { get; set; }
        public string BottomText { get; set; }

        BarcodeReaderSurfaceView scanner;
        BarcodeReaderOverlayView zxingOverlay;

        public void SetTorch(bool on)
        {
            this.scanner.Torch(on);
        }

        public void AutoFocus()
        {
            this.scanner.AutoFocus();
        }

        public void Shutdown()
        {
            scanner.ShutdownCamera();
        }
    }
}

