using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;



namespace Core
{

	/// <summary>
	/// Represents assembly, application, or other version information,
	/// compliant with the Semantic Versioning specifications.
	/// </summary>
	/// <remarks>
	/// See http://semver.org/ for specifications.
	/// 
	///		major.minor[.patch]
	///		
	/// c# Version class
	/// 
	///		major.minor[.build[.revision]]
	///		
	/// </remarks>
	/// <see cref="https://msdn.microsoft.com/en-us/library/system.version%28v=vs.110%29.aspx?f=255&MSPPError=-2147217396"/>
	/// <see cref="https://gist.github.com/yadyn/959467"/>
	public partial class VersionSemantic : IComparable, IFormattable
	{
        public System.Version VersionNative
        {
            get;
            set;
        }
	}
}
