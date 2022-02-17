using Microcharts;
using SkiaSharp;
using System.Collections.Generic;
using Entry = Microcharts.Entry;
using Xamarin.Forms.Xaml;

namespace SocialLadder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopGraf
    {
        public PopGraf()
        {
            InitializeComponent();
            Chart.Chart = new LineChart() { Entries = entries, LineSize = 8, MaxValue = 100, LabelTextSize = 40 };
        }

        List<Entry> entries = new List<Entry>
        {
            new Entry(78){
                Label = "28.03",
                ValueLabel = "8",
                Color = SKColor.Parse("#ff6666")
            }, new Entry(89) {
                Label = "29.03",
                ValueLabel = "9",
                Color = SKColor.Parse("#ff6666")
            }, new Entry(72) {
                Label = "30.03",
                ValueLabel = "7",
                Color = SKColor.Parse("#ff6666")
            }, new Entry(54) {
                Label = "31.03",
                ValueLabel = "5",
                Color = SKColor.Parse("#ff6666")
            }, new Entry(34) {
                Label = "1.03",
                ValueLabel = "4",
                Color = SKColor.Parse("#ff6666")
            }
           
        };

        List<Entry> entriesIcon = new List<Entry>
        {
            new Entry(78) {
                Label = "Charism",
                ValueLabel = "78",
                Color = SKColor.Parse("#ff6666")
            }, new Entry(89) {
                Label = "Intelligence",
                ValueLabel = "89",
                Color = SKColor.Parse("#ff6e4a")
            }, new Entry(72) {
                Label = "Friendly",
                ValueLabel = "72",
                Color = SKColor.Parse("#ffff66")
            }, new Entry(54) {
                Label = "Active",
                ValueLabel = "54",
                Color = SKColor.Parse("#d1e231")
            }, new Entry(34) {
                Label = "Dialogue",
                ValueLabel = "34",
                Color = SKColor.Parse("#75c1ff")
            }, new Entry(90) {
                Label = "Trust",
                ValueLabel = "90",
                Color = SKColor.Parse("#6495ed")
            }, new Entry(83) {
                Label = "Beauty",
                ValueLabel = "83",
                Color = SKColor.Parse("#7366bd")
            }, new Entry(52) {
                Label = "Strong",
                ValueLabel = "52",
                Color = SKColor.Parse("#9966cc")
            }
        };
    }
}