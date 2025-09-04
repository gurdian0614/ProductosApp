using ProductosApp.Views;

namespace ProductosApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ProductoView();
        }
    }
}
