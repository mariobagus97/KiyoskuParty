using Android.Runtime;
using BarcodeReader.Core.BindingProviders;
using BarcodeReader.Core.ViewModels;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.Android.v7;
using System;

namespace BarcodeReader.Android.Fragments
{
    [ImportBinding(typeof(SettingsBindingProvider))]
    public class SettingsListFragment : RecyclerViewFragment<SettingsViewModel>
    {
        #region Constructors

        public SettingsListFragment()
        {
        }

        public SettingsListFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            // Recycler View configuration
            this.InteractionMode = ListViewInteraction.Navigation;
            this.AutoSelectFirstItem = true;
        }

        #endregion
    }
}