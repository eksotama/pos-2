﻿using Xamarin.Forms;

namespace pos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            var db = PosDb.Connect();

            db.CreateTable<Product>();
            db.CreateTable<Client>();
            db.CreateTable<Sell>();

            db.Close();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
