# MauiToolbarTitleRepro

This project is a reproduction for a .NET MAUI issue on iOS 27.1 and later. A primary `ToolbarItem` that has `Text` and an `IconImageSource` shows its icon above the vertical center of the toolbar button.

The project starts from the .NET 11 `maui` template (File > New). These are the changes:

- The project targets iOS only. The XAML files have explicit `xmlns` declarations, so the project also compiles with MAUI 10.
- `MainPage` has two primary toolbar items with the same `FontImageSource` icon. The left item has `Text="Filter"`. The right item has no `Text`. The page also has two `Secondary` items, which make the "..." overflow button.
- The **Push** button opens a detail page that has one item with text and an icon.
- `AppShell` sets `Shell.ForegroundColor`, so you can compare the tint of the "..." button with the tint of the primary icons.
- A label on the page shows the MAUI version and the iOS version.

## Run the project

```
dotnet build -t:Run -f net11.0-ios -p:MauiVersion=11.0.10
```

To build with MAUI 10, use this command:

```
dotnet build -t:Run -f net10.0-ios -p:ReproDotNet=10 -p:MauiVersion=10.0.100
```

Expected result: both toolbar icons are at the vertical center of the toolbar.

## Screenshots

The `iOS toolbar screenshots` workflow builds the project with MAUI 10.0.100, 10.0.130 and 11.0.10, with Xcode 27.2. It takes screenshots on an iOS 27.0 simulator and on an iOS 27.2 simulator. MAUI sets the bar button title only on iOS 27.1 and later, so iOS 27.0 is the control. The `screenshots` folder contains the results.
