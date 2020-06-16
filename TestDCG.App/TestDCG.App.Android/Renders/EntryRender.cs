using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using TestDCG.App.Droid.Renders;
using TestDCG.App.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CustomEntryRender), typeof(EntryRender))]
namespace TestDCG.App.Droid.Renders
{
    public class EntryRender : EntryRenderer
    {
        public EntryRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null)
            {
                return;
            }

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Control.BackgroundTintList = ColorStateList.ValueOf(Color.White);
            }
            else
            {
                Control.Background.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);
            }
        }
    }
}