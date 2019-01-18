using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Week2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InfoPage : ContentPage
	{
		public InfoPage ()
		{
			InitializeComponent ();
        }
        async void CharacterPageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterPage());
        }

        async void ScorePageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScorePage());
        }
        async void ItemsPageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }
	}
}