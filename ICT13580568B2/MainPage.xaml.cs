using System;
using System.Collections.Generic;
using ICT13580568B2.Models;
using Xamarin.Forms;

namespace ICT13580568B2
{
    public partial class MainPage : ContentPage
    {
		
        public MainPage()
        {
            InitializeComponent();

            newButton.Clicked += NewButton_Clicked;
        }
        void LoadData(){
            productListView.ItemsSource = App.DbHelper.GetProducts();
        }
        protected override void OnAppearing()
        {
            LoadData();
        }
        void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewPage());
        }

        async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;

            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบใช่มั้ย", "ใช่","ไม่ใช่");
        }

        void Edit_Clicked(object sender, System.EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductNewPage(product));
        }
    }
}
