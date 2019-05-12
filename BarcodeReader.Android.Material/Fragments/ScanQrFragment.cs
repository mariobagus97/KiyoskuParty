using System;
using Android.Runtime;
using BarcodeReader.ViewModels;
using Intersoft.Crosslight;
using Android.Widget;
using Android.Views.InputMethods;
using Android.OS;
using Android.Views;
using System.ComponentModel;
using Android.App;
using Android.Content.PM;

namespace BarcodeReader.Android
{
    [ImportBinding(typeof(ScanQrBindingProvider))]
    public class ScanQrFragment : Intersoft.Crosslight.Android.v7.Fragment<ScanQrViewModel>
    {
        #region Constructors

        public ScanQrFragment()
            : base()
        {
        }

        public ScanQrFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.Home; }
        }
        public override void OnStop()
        {
            this.ViewModel.Removelistener();
            base.OnStop();
        }

        public override void OnPause()
        {
            base.OnPause();
        }

        public override void OnResume()
        {
            this.ViewModel.AddListener();
            base.OnResume();
        }
        
        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();
            this.ToolbarSettings.IsVisible = false;
        }

        //private EditText SearchText;

        //protected override void OnViewModelPropertyChanged(PropertyChangedEventArgs e)
        //{
        //    base.OnViewModelPropertyChanged(e);
        //    if (e.PropertyName == "Focus")
        //    {
        //        if (SearchText != null)
        //        {
        //            SearchText.RequestFocus();

        //        }
        //    }

        //    //if (e.PropertyName == "LostFocus")
        //    //{
        //    //    if (SearchText != null)
        //    //    {
        //    //        this.View.RequestFocus();

        //    //    }
        //    //}
        //}


        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    View view = base.OnCreateView(inflater, container, savedInstanceState);

        //    SearchText = view.FindViewById<EditText>(Resource.Id.SearchText);

        //    SearchText.RequestFocus();

        //    ((InputMethodManager)this.Context.GetSystemService(("input_method"))).HideSoftInputFromWindow(this.SearchText.WindowToken, 0);


        //    //InputMethodManager imm = (InputMethodManager)this.Activity.GetSystemService(Context.InputMethodService);
        //    //imm.HideSoftInputFromWindow(SearchText.WindowToken, 0);



        //    //InputMethodManager mgr = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
        //    //mgr.ShowSoftInput(SearchText, InputMethodManager.ShowForced);


        //    // var SearchText = inflater.Inflate(Resource.Id.SearchText, container, false);

        //    // EditText SearchText = view.FindViewById<EditText>(Resource.Id.SearchText);

        //    //  view.SetOnTouchListener(new ViewClickListener(this.Context, SearchText));

        //    return view;
        //}

        //public class ViewClickListener : Java.Lang.Object, View.IOnTouchListener
        //{
        //    private Context mContext;
        //    private EditText mEdittext;

        //    public ViewClickListener(Context context, EditText edittext)
        //    {
        //        mEdittext = edittext;
        //        mContext = context;
        //    }

        //    public bool OnTouch(View v, MotionEvent e)
        //    {
        //        InputMethodManager imm = (InputMethodManager)mContext.GetSystemService(Context.InputMethodService);
        //        imm.HideSoftInputFromWindow(mEdittext.WindowToken, 0);
        //        return true;
        //    }
        //}

        //public override void OnResume()
        //{
        //    base.OnResume();
        //    ServiceProvider.GetService<IViewService>().RunOnUIThread(() =>
        //    {
        //        Intersoft.Crosslight.Android.AndroidUtility.HideKeyboard(this.Context, SearchText);
        //    }, 300);

        //}

        //public override void OnStart()
        //{
        //    base.OnStart();

        //    ServiceProvider.GetService<IViewService>().RunOnUIThread(() =>
        //    {
        //        Intersoft.Crosslight.Android.AndroidUtility.HideKeyboard(this.Context, SearchText);
        //    }, 1000);

        //}

        protected override void OnViewCreated()
        {
            base.OnViewCreated();
            //SearchText.RequestFocus();

            // SearchText.ShowSoftInputOnFocus(false);

        }
        #endregion
    }
}