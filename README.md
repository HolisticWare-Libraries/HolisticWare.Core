# Dotnet new template of the Xamarin Components team

This is folder structure used by Xamarin Components team:


*   source
    
    bindings libraries and/or cross platform libraries with extensions

    NOTE: assembly-names and namespaces are prepared for nuget bait-n-switch

*   samples

    Samples for the libraries

*   tests

    *   unit tests

    *   ui tests




## Structure

    ├── External-Dependency-Info.txt
    ├── LICENSE.md
    ├── build.cake
    ├── docs
    ├── nuget
    │   └── HolisticWare.HolisticWare_Core.nuspec
    ├── readme.md
    ├── samples
    │   ├── HolisticWare_Core.Sample.XamarinAndroid
    │   │   ├── Assets
    │   │   │   └── AboutAssets.txt
    │   │   ├── MainActivity.cs
    │   │   ├── Properties
    │   │   │   ├── AndroidManifest.xml
    │   │   │   └── AssemblyInfo.cs
    │   │   ├── Resources
    │   │   │   ├── AboutResources.txt
    │   │   │   ├── Resource.designer.cs
    │   │   │   ├── drawable
    │   │   │   ├── layout
    │   │   │   │   └── Main.axml
    │   │   │   ├── mipmap-hdpi
    │   │   │   │   └── Icon.png
    │   │   │   ├── mipmap-mdpi
    │   │   │   │   └── Icon.png
    │   │   │   ├── mipmap-xhdpi
    │   │   │   │   └── Icon.png
    │   │   │   ├── mipmap-xxhdpi
    │   │   │   │   └── Icon.png
    │   │   │   ├── mipmap-xxxhdpi
    │   │   │   │   └── Icon.png
    │   │   │   └── values
    │   │   │       └── Strings.xml
    │   │   ├── HolisticWare_Core.Sample.XamarinAndroid.csproj
    │   │   ├── HolisticWare_Core.Sample.XamarinAndroid.csproj.user
    │   │   └── packages.config
    │   ├── HolisticWare_Core.Sample.XamarinIOS
    │   │   ├── AppDelegate.cs
    │   │   ├── Assets.xcassets
    │   │   │   ├── AppIcon.appiconset
    │   │   │   │   └── Contents.json
    │   │   │   ├── Contents.json
    │   │   │   ├── First.imageset
    │   │   │   │   ├── Contents.json
    │   │   │   │   └── vector.pdf
    │   │   │   └── Second.imageset
    │   │   │       ├── Contents.json
    │   │   │       └── vector.pdf
    │   │   ├── Entitlements.plist
    │   │   ├── FirstViewController.cs
    │   │   ├── FirstViewController.designer.cs
    │   │   ├── Info.plist
    │   │   ├── LaunchScreen.storyboard
    │   │   ├── Main.cs
    │   │   ├── Main.storyboard
    │   │   ├── Resources
    │   │   ├── SecondViewController.cs
    │   │   ├── SecondViewController.designer.cs
    │   │   ├── HolisticWare_Core.Sample.XamarinIOS.csproj
    │   │   └── packages.config
    │   └── HolisticWare_Core.Samples.sln
    ├── source
    │   ├── HolisticWare_Core.Bindings.NetStandard10
    │   │   └── HolisticWare_Core.Bindings.NetStandard10.csproj
    │   ├── HolisticWare_Core.Bindings.XamarinAndroid
    │   │   ├── Additions
    │   │   │   └── AboutAdditions.txt
    │   │   ├── Jars
    │   │   │   └── AboutJars.txt
    │   │   ├── Properties
    │   │   │   └── AssemblyInfo.cs
    │   │   ├── Transforms
    │   │   │   ├── EnumFields.xml
    │   │   │   ├── EnumMethods.xml
    │   │   │   └── Metadata.xml
    │   │   └── HolisticWare_Core.Bindings.XamarinAndroid.csproj
    │   ├── HolisticWare_Core.Bindings.XamarinIOS
    │   │   ├── ApiDefinition.cs
    │   │   ├── Properties
    │   │   │   └── AssemblyInfo.cs
    │   │   ├── Structs.cs
    │   │   └── HolisticWare_Core.Bindings.XamarinIOS.csproj
    │   ├── HolisticWare_Core.NetStandard10
    │   │   └── HolisticWare_Core.NetStandard10.csproj
    │   ├── HolisticWare_Core.Source.sln
    │   ├── HolisticWare_Core.XamarinAndroid
    │   │   ├── Properties
    │   │   │   └── AssemblyInfo.cs
    │   │   ├── Resources
    │   │   │   ├── AboutResources.txt
    │   │   │   ├── Resource.designer.cs
    │   │   │   └── values
    │   │   │       └── Strings.xml
    │   │   └── HolisticWare_Core.XamarinAndroid.csproj
    │   └── HolisticWare_Core.XamarinIOS
    │       ├── Properties
    │       │   └── AssemblyInfo.cs
    │       ├── Resources
    │       └── HolisticWare_Core.XamarinIOS.csproj
    └── tests
        ├── ui-tests
        │   ├── HolisticWare_Core.Sample.XamarinAndroid.UITests
        │   │   ├── Tests.cs
        │   │   ├── HolisticWare_Core.Sample.XamarinAndroid.UITests.csproj
        │   │   └── packages.config
        │   ├── HolisticWare_Core.Sample.XamarinIOS.UITests
        │   │   ├── Tests.cs
        │   │   ├── HolisticWare_Core.Sample.XamarinIOS.UITests.csproj
        │   │   └── packages.config
        │   └── HolisticWare_Core.UITests.sln
        └── unit-tests
            └── HolisticWare_Core.UnitTests.sln
