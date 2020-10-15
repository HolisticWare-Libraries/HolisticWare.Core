
//---------------------------------------------------------------------------------------
Task("nuget-pack")
    .Does
    (
        () =>
        {
			MSBuild
			(
				"./source/Xamarin.Grpc.Protobuf.Lite.Bindings.XamarinAndroid/Xamarin.Grpc.Protobuf.Lite.Bindings.XamarinAndroid.csproj", 
				configuration => 
					configuration
						.SetConfiguration("Release")
						.WithTarget("Pack")
						.WithProperty("PackageVersion", NUGET_VERSION)
						.WithProperty("PackageOutputPath", "../../output")
			);

            return;
        }
    );

//---------------------------------------------------------------------------------------
