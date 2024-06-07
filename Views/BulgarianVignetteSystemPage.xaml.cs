using VignetteSystem.ViewModel;

namespace VignetteSystem.Views;

public partial class BulgarianVignetteSystemPage : ContentPage
{
	public BulgarianVignetteSystemPage(BulgarianVignetteSystemViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}