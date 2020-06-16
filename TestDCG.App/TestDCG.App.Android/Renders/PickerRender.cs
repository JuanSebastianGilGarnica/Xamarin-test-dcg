using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Support.V4.Content;
using TestDCG.App.Droid.Renders;
using TestDCG.App.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPickerRender), typeof(PickerRender))]
namespace TestDCG.App.Droid.Renders
{
    public class PickerRender : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        public PickerRender(Context context) : base(context)
        {
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Picker}"/> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null || e.NewElement == null)
            {
                return;
            }
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#EFEFEF"));
            }
            else
            {
                Control.Background.SetColorFilter(Android.Graphics.Color.ParseColor("#EFEFEF"), PorterDuff.Mode.SrcAtop);
            }

            Drawable drawable = ContextCompat.GetDrawable(Context, Resources.GetIdentifier("arrow", "drawable", Context.PackageName));
            Bitmap bitmap = ((BitmapDrawable)drawable).Bitmap;
            BitmapDrawable bitmapDraw = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 7, 7, true));
            Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(null, null, bitmapDraw, null);
            Control.SetHintTextColor(Android.Graphics.Color.ParseColor("#EFEFEF"));
            Control.SetTextColor(Android.Graphics.Color.ParseColor("#EFEFEF"));
        }
    }
}