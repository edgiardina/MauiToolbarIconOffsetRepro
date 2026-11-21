namespace MauiToolbarTitleRepro;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		// Shown on screen so every screenshot records the MAUI and iOS versions it came from.
		var mauiVersion = typeof(Shell).Assembly
			.GetCustomAttributes(typeof(System.Reflection.AssemblyInformationalVersionAttribute), false)
			.OfType<System.Reflection.AssemblyInformationalVersionAttribute>()
			.FirstOrDefault()?.InformationalVersion?.Split('+')[0];

		VersionLabel.Text = $"MAUI {mauiVersion} / {DeviceInfo.Platform} {DeviceInfo.VersionString}";
	}

	bool autoPushed;

	// CI can't tap the simulator, so `SIMCTL_CHILD_REPRO_PUSH=1 xcrun simctl launch ...` opens the
	// detail page on start instead.
	protected override void OnAppearing()
	{
		base.OnAppearing();

		if (!autoPushed && Environment.GetEnvironmentVariable("REPRO_PUSH") == "1")
		{
			autoPushed = true;
			Dispatcher.DispatchDelayed(TimeSpan.FromSeconds(1), () => OnPushClicked(null, EventArgs.Empty));
		}
	}

	// A typical detail page: one titled icon item alone in its button group.
	async void OnPushClicked(object? sender, EventArgs e)
	{
		var page = new ContentPage
		{
			Title = "Detail",
			Content = new Label { Text = "One ToolbarItem with Text and an icon", Margin = 30 },
		};
		page.ToolbarItems.Add(new ToolbarItem
		{
			Text = "Filter",
			IconImageSource = new FontImageSource { Glyph = "≡", Size = 22 },
		});

		await Navigation.PushAsync(page);
	}
}
