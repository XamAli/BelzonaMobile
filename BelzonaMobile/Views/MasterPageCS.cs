using System.Collections.Generic;
using Xamarin.Forms;
using BelzonaMobile.Models;

namespace BelzonaMobile.Views
{
    public class MasterPageCS : ContentPage
    {
        public ListView ListView { get { return _listView; } }

        private ListView _listView;
        //_listView.BackgroundColor = Color.FromHex("eff2f3");
        public MasterPageCS()
        {
            //this.BackgroundColor = Color.Gray;
            var menuItems = new List<MasterMenuItem>();
            menuItems.Add(new MasterMenuItem
			{
				Title = "Product Page",
                IconSource = "Favorites.png",
                TargetType = typeof(TabbedPageCS)
			});
            menuItems.Add(new MasterMenuItem
            {
                Title = "Contacts Us",
                IconSource = "contacts.png",
                TargetType = typeof(ContactPage)
            });
            menuItems.Add(new MasterMenuItem
            {
                Title = "About Us",
                IconSource = "todo.png",
                TargetType = typeof(ContactPage)
            });
            menuItems.Add(new MasterMenuItem
            {
                Title = "Help/Learning",
                IconSource = "todo.png",
                TargetType = typeof(ContactPage)
            });
            menuItems.Add(new MasterMenuItem
            {
                Title = "Settings",
                IconSource = "reminders.png",
                TargetType = typeof(ContactPage)
            });

            _listView = new ListView
            {
                BackgroundColor = Color.FromHex("eff2f3"),

                ItemsSource = menuItems,
                ItemTemplate = new DataTemplate(() =>
                {
                    var grid = new Grid { Padding = new Thickness(5, 10) };
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(30) });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    var image = new Image();
                    image.SetBinding(Image.SourceProperty, "IconSource");
                    var label = new Label { VerticalOptions = LayoutOptions.FillAndExpand };
                    label.SetBinding(Label.TextProperty, "Title");

                    grid.Children.Add(image);
                    grid.Children.Add(label, 1, 0);

                    return new ViewCell { View = grid };
                }),
                SeparatorVisibility = SeparatorVisibility.None
            };

            Icon = "hamburger@2x.png";
            Title = "more .....";
            //BackgroundColor = Color.FromHex("eff2f3");
            Padding = new Thickness(0, 20, 0, 0);
            Content = new StackLayout
            {
                BackgroundColor = Color.FromHex("eff2f3"),
                Padding = new Thickness(0,50,0,0),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = { _listView }
            };
            //
        }

    }
}
