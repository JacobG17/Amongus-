using InstantFood.Pantallas;

namespace InstantFood;

public partial class App : Application
{
	public App()
	{
		Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHJqVk1hXk5Hd0BLVGpAblJ3T2ZQdVt5ZDU7a15RRnVfR11mSX9WdkZkUH5XdA==;Mgo+DSMBPh8sVXJ1S0R+X1pFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jTH5WdkRmWXxZeXFdQg==;ORg4AjUWIQA/Gnt2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtTc0ViXH9deHRWRWQ=;MTkyOTU1MUAzMjMxMmUzMjJlMzNrSDZpYitGbXhzT09zaFNvb2tEUXRBbFErM2xSdkdpN1lWa3lEaVpFbWNrPQ==;MTkyOTU1MkAzMjMxMmUzMjJlMzNhQWJ6Qys0c0Y5ZlBzMVpZRE5ibThoQ1AwelZ5eTB2UVIwVlVYMmQ5VW44PQ==;NRAiBiAaIQQuGjN/V0d+Xk9HfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hSn5WdkBjWHpec3xXRGlZ;MTkyOTU1NEAzMjMxMmUzMjJlMzNJSFZhS2NlZ2czVUdjVm10QzczZDUvb3RTRnhKOGFEMkFmay8vY1pudklNPQ==;MTkyOTU1NUAzMjMxMmUzMjJlMzNlVXppcndUOG5XVW5Dd1lGWHhmT3ZxRlVuQlB2NCs2QXZDcDZwUHRKMk5FPQ==;Mgo+DSMBMAY9C3t2VFhiQlJPd11dXmJWd1p/THNYflR1fV9DaUwxOX1dQl9gSXtTc0ViXH9deHdVRGU=;MTkyOTU1N0AzMjMxMmUzMjJlMzNNTWxIcFFvaHdCOGo5T09HTk1aSDJ1K3haSWFrL0plVHAzOFp5K0haanhBPQ==;MTkyOTU1OEAzMjMxMmUzMjJlMzNPbCtoQmwwNStBOUNnS0RYRzNGMDhKZHJnK0I2UE9uVXhQTVZGc3FqOENBPQ==;MTkyOTU1OUAzMjMxMmUzMjJlMzNJSFZhS2NlZ2czVUdjVm10QzczZDUvb3RTRnhKOGFEMkFmay8vY1pudklNPQ==");
        InitializeComponent();
		//MainPage = new Login();
        var nav = new NavigationPage(new Login());
		nav.BarBackgroundColor = Colors.White;
		nav.BarTextColor = Color.FromArgb("#5135d1");

		MainPage = nav;

		
		
    }
}

