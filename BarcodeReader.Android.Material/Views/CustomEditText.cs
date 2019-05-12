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
using Android.Util;

namespace BarcodeReader.Android.Views
{
    public class CustomEditText : EditText
    {
        #region Constructors

        public CustomEditText(Context context) : base(context)
        {
        }

        public CustomEditText(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public CustomEditText(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
        }

        public CustomEditText(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
        }

        public CustomEditText(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        public override bool OnCheckIsTextEditor()
        {
            return false;
        }

        #endregion
    }
}