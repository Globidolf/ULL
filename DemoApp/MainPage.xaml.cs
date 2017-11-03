using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ULL.Timers;
using ULL.Vector;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x407 dokumentiert.

namespace DemoApp
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class MainPage : Page
	{
		Vec2 offset = 245;
		public MainPage()
        {
            this.InitializeComponent();
			ValueChanged(null, null);
        }

		private void ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
		{

			float scale = 4;
			obj_p1.Margin = Convert(P1          /   scale + offset);
			obj_p2.Margin = Convert(P2          /   scale + offset);
			obj_p_add.Margin = Convert((P1 + P2)  / scale + offset);
			obj_p_sub.Margin = Convert((P1 - P2)  / scale + offset);
			obj_p_mult.Margin = Convert(P1 * P2 /   scale + offset);
			obj_p_div.Margin = Convert(P1 / P2 /    scale + offset);

			obj_info.Text = 
				"Punkt 1:\t" + P1 + "\tNormal:\t"+P1.Normalize()+
				"\nPunkt 2:\t"+P2 + "\tNormal:\t"+P2.Normalize()+
				"\nDistance Squared:\t"+P1.DistanceSquared(P2)+"\tDistance:\t"+P1.Distance(P2)+
				"\nDot Product:\t"+P1.Dot(P2)+
				"\nMagnitude 1:\t"+P1.Distance(Vec2.ZERO) +
				"\nMagnitude 2:\t" + P2.Distance(Vec2.ZERO);
		}

		private Vec2 P1 { get { return new Vec2((float)obj_p1_x.Value, (float)obj_p1_y.Value); } }
		private Vec2 P2 { get { return new Vec2((float)obj_p2_x.Value, (float)obj_p2_y.Value); } }
		private Thickness Convert(Vec2 val) { return new Thickness(val.X, val.Y, 0, 0); }

		int temp = 0;
		async private void timerAction()
		{
			await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
			{
				obj_info.Text = "Invoked " + ++temp + " Times...";
			});
		}

		private void ele_timersingle_Click(object sender, RoutedEventArgs e)
		{
			SingleTimer ST = new SingleTimer(timerAction, 1000);
			ST.Start();
		}

		private void ele_timerxTimesinterval_Click(object sender, RoutedEventArgs e)
		{
			IntervalTimer IT = new IntervalTimer(timerAction, 3000);
		}
	}
}
