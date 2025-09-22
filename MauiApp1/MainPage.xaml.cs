using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingItem> Items { get; set; } = new();
        private ShoppingItem selectedItem;

        public MainPage()
        {
            InitializeComponent();
            ItemsCollection.ItemsSource = Items;
        }

        private void OnAddButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(ItemEntry.Text))
            {
                Items.Add(new ShoppingItem { Name = ItemEntry.Text });
                ItemEntry.Text = string.Empty;
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs el)
        {
            selectedItem = el.CurrentSelection.FirstOrDefault() as ShoppingItem;
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs el)
        {
            if (selectedItem != null)
            {
                Items.Remove(selectedItem);
                selectedItem = null;
            }
            else
            {
                await DisplayAlert("Info", "Wybierz co chcesz usunąć", "OK");
            }
        }
    }

    public class ShoppingItem
    {
        public string Name { get; set; }
    }
}
