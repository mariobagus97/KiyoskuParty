using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Intersoft.Crosslight.Android.v7;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using BarcodeReader.Core.BindingProviders;
using BarcodeReader.Core.ViewModels;

namespace BarcodeReader.Android.Fragments
{
    [ImportBinding(typeof(ListGuestBindingProvider))]
    public class ListGuestFragment : RecyclerViewFragment<ListGuestViewModel>
    {
        
        #region Constructors
        public ListGuestFragment()
        {

        }

        public ListGuestFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        #endregion

        #region Properties

        protected override int ItemLayoutId
        {
            get { return Resource.Layout.ListGuestReception; }
        }
        

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.ImageLoaderSettings.AnimateOnLoad = true;


            this.AddBarItem(new BarItem("BtnEmail", "Send Email") { ShowAsAction = ShowAsAction.Never });
            this.AddBarItem(new BarItem("BtnClearData", "Clear Data") { ShowAsAction = ShowAsAction.Never });

            
            this.ToolbarSettings.IsVisible = false;
        }
        #endregion
        
        //protected override int FooterLayoutId
        //{
        //    get
        //    {
        //        return Resource.Layout.Footer_layout;
        //    }
        //}
    }
}