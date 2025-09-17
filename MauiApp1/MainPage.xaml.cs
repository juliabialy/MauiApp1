using System;
using System.Collections.Generic;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        List<string> items = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            Lista.ItemsSource = items;
        }

        private async void Dodaj_Clicked(object sender, EventArgs e)
        {
            string tekst = InputBox.Text?.Trim();

            if (!string.IsNullOrEmpty(tekst))
            {
                items.Add(tekst);

                Lista.ItemsSource = null;
                Lista.ItemsSource = items;

                InputBox.Text = string.Empty;
            }
            else
            {
                await DisplayAlert("!", "Wpisz coś","ok");
            }
        }
        private async void Usun_Clicked(object sender, EventArgs e)
        {
            if (items.Count > 0)
            {
                items.RemoveAt(items.Count - 1);

                Lista.ItemsSource = null;
                Lista.ItemsSource = items;
                Console.WriteLine("usuń");

            }
            else
            {
                await DisplayAlert("!", "Lista jest pusta", "ok");
            }
        }



    }
}

