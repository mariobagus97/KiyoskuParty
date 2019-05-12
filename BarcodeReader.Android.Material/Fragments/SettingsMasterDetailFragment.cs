using Android.Runtime;
using BarcodeReader.Core.ViewModels;
using Intersoft.Crosslight.Android.v7;
using System;

namespace BarcodeReader.Android.Fragments
{
    public class SettingsMasterDetailFragment : MasterDetailFragment<SettingsViewModel>
    {
        public SettingsMasterDetailFragment()
        {

        }

        public SettingsMasterDetailFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

       
    }
}