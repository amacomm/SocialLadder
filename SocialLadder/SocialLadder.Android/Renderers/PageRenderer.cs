using System;
using Android.Content;
using Android.Content.Res;
using SocialLadder.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentPage), typeof(SocialLadder.Droid.Renderers.PageRenderer))]
namespace SocialLadder.Droid.Renderers
{
    public class PageRenderer : Xamarin.Forms.Platform.Android.PageRenderer
    {
        public PageRenderer(Context context) : base(context) {}

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            SetAppTheme();
        }

        void SetAppTheme()
        {
            if (Resources.Configuration.UiMode.HasFlag(UiMode.NightYes))
            {
                SetTheme(SocialLadder.App.Theme.Dark);
            }
            else
            {
                SetTheme(SocialLadder.App.Theme.Light);
            }
        }

        void SetTheme(App.Theme mode)
        {
            if (mode == SocialLadder.App.Theme.Dark)
            {
                if (App.AppTheme == SocialLadder.App.Theme.Dark)
                    return;

                App.Current.Resources = new DarkTheme();

                App.AppTheme = App.Theme.Dark;
            }
            else
            {
                if (App.AppTheme != SocialLadder.App.Theme.Dark)
                    return;
                App.Current.Resources = new LightTheme();
                App.AppTheme = SocialLadder.App.Theme.Light;
            }
        }
    }
}
