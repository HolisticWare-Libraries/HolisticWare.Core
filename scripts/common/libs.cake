#load "./nuget-restore.cake"

LibSourceSolutions = GetFiles(source_solutions);
LibSourceProjects = GetFiles(source_projects);

string[] configs = new string[] 
{ 
    "Debug", 
    "Release" 
};

//---------------------------------------------------------------------------------------
Task("libs")
    .IsDependentOn ("nuget-restore-libs")
    .IsDependentOn ("libs-msbuild-solutions")
    .IsDependentOn ("libs-msbuild-projects")
    .IsDependentOn ("libs-dotnet-solutions")
    .IsDependentOn ("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            return;
        }
    );


Task("libs-msbuild-solutions")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in LibSourceSolutions)
            {
				foreach (string config in configs)
                {
                    MSBuild
                    (
                        sln.ToString(),
                        new MSBuildSettings
                        {
                            Configuration = config,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

Task("libs-dotnet-solutions")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in LibSourceSolutions)
            {
				foreach (string config in configs)
                {
                    DotNetCoreBuild
                    (
                        sln.ToString(),
                        new DotNetCoreBuildSettings
                        {
                            Configuration = config,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

Task("libs-msbuild-projects")
    .Does
    (
        () =>
        {
            foreach(FilePath prj in LibSourceProjects)
            {
                MSBuild
                (
                    prj.ToString(),
                    new MSBuildSettings
                    {
                        Configuration = "Debug",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
                MSBuild
                (
                    prj.ToString(),
                    new MSBuildSettings
                    {
                        Configuration = "Release",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
            }

            return;
        }
    );

Task("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            foreach(FilePath prj in LibSourceProjects)
            {
                DotNetCoreBuild
                (
                    prj.ToString(),
                    new DotNetCoreBuildSettings
                    {
                        Configuration = "Debug",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
                DotNetCoreBuild
                (
                    prj.ToString(),
                    new DotNetCoreBuildSettings
                    {
                        Configuration = "Release",
                    }
                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                );
            }

            return;
        }
    );

public void Build(string pattern)
{
	FilePathCollection files = GetFiles(pattern);

	foreach(FilePath file in files)
	{
		foreach (string config in configs)
		{
			MSBuild
			(
				file.ToString(),
				new MSBuildSettings
				{
					Configuration = config,
				}
				//.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
				.WithProperty("AndroidClassParser", "jar2xml")
				
			);
		}
	}
	
	return;
}
//---------------------------------------------------------------------------------------
