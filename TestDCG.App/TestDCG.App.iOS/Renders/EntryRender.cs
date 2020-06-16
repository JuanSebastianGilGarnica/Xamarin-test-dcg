using CoreAnimation;
using CoreGraphics;
using TestDCG.App.Renders;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntryRender), typeof(EntryRenderer))]
namespace TestDCG.App.iOS.Renders
{
    public class EntryRender : EntryRenderer
    {
        private CALayer _line;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            _line = null;

            if (Control == null || e.NewElement == null)
                return;

            Control.BorderStyle = UITextBorderStyle.None;

            _line = new CALayer
            {
                BorderColor = UIColor.FromRGB(174, 174, 174).CGColor,
                BackgroundColor = UIColor.FromRGB(174, 174, 174).CGColor,
                Frame = new CGRect(0, Frame.Height / 2, Frame.Width * 2, 1f)
            };

            Control.Layer.AddSublayer(_line);
        }
    }
}