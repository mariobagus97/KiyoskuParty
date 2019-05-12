using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BarcodeReader.Core.BindingProviders;
using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using System;

namespace BarcodeReader.Android
{
    [ImportBinding(typeof(MainBindingProvider))]
    public class MainFragment : Intersoft.Crosslight.Android.v7.Fragment<MainViewModel>
    {
        #region Constructors

        public MainFragment()
            : base()
        {
        }

        

        public MainFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.Main; }
        }
        
        public Button ListButton { get; set; }
        public Button HomeButton { get; set; }

        #endregion

        #region Methods
            
        protected override void Initialize()
        {
            base.Initialize();

            this.ToolbarSettings.IsVisible = false;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);
            this.ListButton = view.FindViewById<Button>(Resource.Id.BtnList);
            this.ListButton.Focusable = false;
            this.ListButton.FocusableInTouchMode = false;

            this.HomeButton = view.FindViewById<Button>(Resource.Id.BtnHome);
            this.HomeButton.Focusable =true ;
            this.HomeButton.FocusableInTouchMode = true;///add this line

            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            GC.Collect();
        }

        protected override void OnViewCreated()
        {
            base.OnViewCreated();

            ServiceProvider.GetService<IViewService>().RunOnUIThread(() =>
            {
                this.HomeButton.RequestFocus();
            }, 500);
        }

        #endregion
    }
}