using System;
using Android.Runtime;
using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.OS;
using System.ComponentModel;
using System.Timers;

namespace BarcodeReader.Android
{
    [ImportBinding(typeof(Core.BindingProviders.ClientDetailBindingProvider))]
    public class ClientDetailFragment : Intersoft.Crosslight.Android.v7.Fragment<ClientDetailViewModel>
    {
        #region Constructors

        public ClientDetailFragment()
            : base()
        {
        }
        

        public ClientDetailFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.ClientDetail; }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();
            this.ToolbarSettings.IsVisible = false;
        }

        private TextView NameLabel;
        private TextView WelcomeLabel;
        private Button BtnClose;
        private Button Spacer;
        
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);

            NameLabel = view.FindViewById<TextView>(Resource.Id.NameLabel);
            WelcomeLabel = view.FindViewById<TextView>(Resource.Id.WelcomeLabel);

            BtnClose = view.FindViewById<Button>(Resource.Id.BtnClose);
            Spacer = view.FindViewById<Button>(Resource.Id.Spacer);

            Typeface customfont = Typeface.CreateFromAsset(this.Context.Assets, "BirdsofParadise.ttf");
            NameLabel.SetTypeface(customfont, TypefaceStyle.Normal);
            WelcomeLabel.SetTypeface(customfont, TypefaceStyle.Normal);

            return view;
        }

      
        protected override void OnViewCreated()
        {
            base.OnViewCreated();
            Spacer.RequestFocus();
        }

        #endregion
    }
}