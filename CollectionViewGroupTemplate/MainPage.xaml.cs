using CollectionViewGroupTemplate.ViewModels;

namespace CollectionViewGroupTemplate
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ItemsViewModel viewModel)
        {
            BindingContext = viewModel;
            InitializeComponent();
        }
    }

}
