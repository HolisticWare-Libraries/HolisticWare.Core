/*
#########################################################################################
Installing

	Windows - powershell
		
        Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
        .\build.ps1

	Windows - cmd.exe prompt	
	
        powershell ^
			Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
        powershell ^
			.\build.ps1
	
	Mac OSX 

        rm -fr tools/; mkdir ./tools/ ; \
        cp cake.packages.config ./tools/packages.config ; \
        curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/osx ; \
        chmod +x ./build.sh ;
        ./build.sh

	Linux

        curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/linux
        chmod +x ./build.sh && ./build.sh

Running Cake to Build targets

	Windows

		tools\Cake\Cake.exe --verbosity=diagnostic --target=libs
		tools\Cake\Cake.exe --verbosity=diagnostic --target=nuget
		tools\Cake\Cake.exe --verbosity=diagnostic --target=samples

		tools\Cake\Cake.exe -experimental --verbosity=diagnostic --target=libs
		tools\Cake\Cake.exe -experimental --verbosity=diagnostic --target=nuget
		tools\Cake\Cake.exe -experimental --verbosity=diagnostic --target=samples
		
	Mac OSX 
	
		mono tools/Cake/Cake.exe --verbosity=diagnostic --target=libs
		mono tools/Cake/Cake.exe --verbosity=diagnostic --target=nuget
#########################################################################################
*/
#addin nuget:?package=Cake.Git

string target = null;

try
{
    target = Argument<string>("target");
}
catch (System.Exception)
{    
    StringBuilder sb = new StringBuilder();
    sb.AppendLine($"usage:");
    if (IsRunningOnWindows())
    {
        sb.AppendLine($@".\tools\Cake\Cake.exe clone.cake --target=externals-git-clone");
    }
    else
    {        
        sb.AppendLine($@"mono ./tools/Cake/Cake.exe clone.cake --target=externals-git-clone");
    }
    sb.AppendLine(Environment.NewLine);
    Information(sb.ToString());
    
    Information($"target - not set!");
    Information($"         target = {target}");
    Information($"setting  target = externals-git-clone");
    target = "externals-git-clone";
}
finally
{
    Information($"target = {target}");
    target = "externals-git-clone";
}


Dictionary<string, string> repositories = new Dictionary<string, string>
{
    {
        "01-HWC.Platforms",
        "https://github.com/moljac/HolisticWare.Core.Platforms.git"
    },
    {
        "11-HWC.Collections.Generic",
        "https://github.com/moljac/HolisticWare.Core.Collections.Generic.git"
    },
    {
        "11-HWC.Collections.Net",
        "https://github.com/moljac/HolisticWare.Core.Net.git"
    },


    {
        "21-HWC.Math",
        "https://github.com/moljac/HolisticWare.Core.Math.git"
    },
    {
        "22-HWC.Math.Polynomials",
        "https://github.com/moljac/HolisticWare.Core.Math.Polynomials.git"
    },
    {
        "23-HWC.Math.Numerics",
        "https://github.com/moljac/HolisticWare.Core.Math.Numerics.git"
    },
    {
        "23-HWC.Math.Statistics",
        "https://github.com/moljac/HolisticWare.Core.Math.Statistics.git"
    },
    {
        "231-HWC.Math.Statistics.Descriptive",
        "https://github.com/moljac/HolisticWare.Core.Math.Statistics.Descriptive.git"
    },
    {
        "2311-HWC.Math.Statistics.Descriptive.Sequential",
        "https://github.com/moljac/HolisticWare.Core.Math.Statistics.Descriptive.Sequential.git"
    },
    {
        "2312-HWC.Math.Statistics.Descriptive.Parallel",
        "https://github.com/moljac/HolisticWare.Core.Math.Statistics.Descriptive.Parallel.git"
    },

    {
        "21-HWC.Serialization",
        "https://github.com/moljac/HolisticWare.Core.Serialization.git"
    },
    {
        "21-HWC.Serialization.SharpSerializer",
        "https://github.com/moljac/HolisticWare.Core.Serialization.SharpSerializer.git"
    },

};


Task("externals-git-clone")
.Does
(
    () =>
    {
        foreach (KeyValuePair<string, string> repo in repositories)
        {
            Information($"git clone .....");
            Information($"         repo = {repo.Value}");
            Information($"         dir  = ../{repo.Key}");
            
            GitClone
                (
                    repo.Value, 
                    $"../{repo.Key}",
                    new GitCloneSettings
                    { 
                        RecurseSubmodules = true,
                    }
                );
        }
    }
);

Task("Default")
.Does
(
    () =>
    {
        Information("Hi");
    }
);

RunTarget(target);
