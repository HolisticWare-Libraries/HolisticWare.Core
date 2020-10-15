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
	public class SemanticVersion : IComparable, IFormattable
	{
		/// <summary>
		/// Gets the major version.
		/// </summary>
		/// <remarks>
		/// The major version only increments on backwards-incompatible changes.
		/// </remarks>
		public int Major { get; private set; }


		/// <summary>
		/// Gets the minor version.
		/// </summary>
		/// <remarks>
		/// The minor version increments on backwards-compatible changes.
		/// </remarks>
		public int Minor { get; private set; }


		/// <summary>
		/// Gets the patch version.
		/// </summary>
		/// <remarks>
		/// The patch version increments when changes include only fixes.
		/// </remarks>
		public int Patch { get; private set; }


		/// <summary>
		/// Gets the development stage, if any.
		/// </summary>
		/// <remarks>
		/// The development stage relates only to the changes since the last release.
		/// Thus it is possible to have a 2.1.0beta where the beta only applies to
		/// the new changes since 2.0.0.
		/// </remarks>
		public DevelopmentStage Stage { get; private set; }
		/// <summary>
		/// Gets the development step, provided a development stage was specified.
		/// </summary>
		public int? Step { get; private set; }


		/// <summary>
		/// Initializes a new instance of the <see cref="SemanticVersion"/> class.
		/// </summary>
		/// <param name="major">The major version.</param>
		/// <param name="minor">The minor version.</param>
		/// <param name="patch">The patch version.</param>
		public SemanticVersion(int major, int minor, int patch)
		{
			if (major < 0)
				throw new ArgumentOutOfRangeException("major", "Version parts cannot be negative.");
			if (minor < 0)
				throw new ArgumentOutOfRangeException("minor", "Version parts cannot be negative.");
			if (patch < 0)
				throw new ArgumentOutOfRangeException("patch", "Version parts cannot be negative.");

			this.Major = major;
			this.Minor = minor;
			this.Patch = patch;

			return;
		}

		public SemanticVersion()
			:
			this(0, 0, 0)
		{
			return;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SemanticVersion"/> class.
		/// </summary>
		/// <param name="major">The major version.</param>
		/// <param name="minor">The minor version.</param>
		/// <param name="patch">The patch version.</param>
		/// <param name="stage">The development stage.</param>
		public SemanticVersion(int major, int minor, int patch, DevelopmentStage stage)
			: this(major, minor, patch)
		{
			this.Stage = stage;
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="SemanticVersion"/> class.
		/// </summary>
		/// <param name="major">The major version.</param>
		/// <param name="minor">The minor version.</param>
		/// <param name="patch">The patch version.</param>
		/// <param name="stage">The development stage.</param>
		/// <param name="step">The development step.</param>
		public SemanticVersion(int major, int minor, int patch, DevelopmentStage stage, int step)
			: this(major, minor, patch, stage)
		{
			if (step < 1)
				throw new ArgumentOutOfRangeException("step", "Step cannot be negative or zero.");

			// None/Final don't support steps, so ignore the value in those cases
			// Should it throw ArgumentException instead?
			if (stage != DevelopmentStage.None && stage != DevelopmentStage.Final)
				this.Step = step;
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="a">The first operand.</param>
		/// <param name="b">The second operand.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SemanticVersion a, SemanticVersion b)
		{
			if (ReferenceEquals(a, b)) return true;

			// Must cast a as object to avoid an infinite loop calling this operator again
			if ((object)a == null) return false;

			return a.Equals(b);
		}
		/// <summary>
		/// Implements the operator !=.
		/// </summary>
		/// <param name="a">The first operand.</param>
		/// <param name="b">The second operand.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SemanticVersion a, SemanticVersion b)
		{
			return !(a == b);
		}
		/// <summary>
		/// Implements the operator &lt;.
		/// </summary>
		/// <param name="a">The first operand.</param>
		/// <param name="b">The second operand.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator <(SemanticVersion a, SemanticVersion b)
		{
			return a.CompareTo(b) < 0;
		}
		/// <summary>
		/// Implements the operator &gt;.
		/// </summary>
		/// <param name="a">The first operand.</param>
		/// <param name="b">The second operand.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator >(SemanticVersion a, SemanticVersion b)
		{
			return a.CompareTo(b) > 0;
		}

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings:
		/// Value
		/// Meaning
		/// Less than zero
		/// This instance is less than <paramref name="obj"/>.
		/// Zero
		/// This instance is equal to <paramref name="obj"/>.
		/// Greater than zero
		/// This instance is greater than <paramref name="obj"/>.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">
		/// 	<paramref name="obj"/> is not the same type as this instance.
		/// </exception>
		public int CompareTo(object obj)
		{
			SemanticVersion other = (SemanticVersion)obj;

			if (other == null)
				throw new ArgumentException("obj");

			if (this.Major != other.Major)
				return this.Major.CompareTo(other.Major);
			if (this.Minor != other.Minor)
				return this.Minor.CompareTo(other.Minor);
			if (this.Patch != other.Patch)
				return this.Patch.CompareTo(other.Patch);
			if (this.Stage != other.Stage)
				return this.Stage.CompareTo(other.Stage);
			if ((this.Step ?? 0) != (other.Step ?? 0))
				return (this.Step ?? 0).CompareTo((other.Step ?? 0));

			return 0;
		}
		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// The <paramref name="obj"/> parameter is null.
		/// </exception>
		public override bool Equals(object obj)
		{
			if (obj == null) return false;

			SemanticVersion semVer = (SemanticVersion) obj;

			if (semVer == null) return false;

			if (ReferenceEquals(this, obj)) return true;

			return (this.Major == semVer.Major
				&& this.Minor == semVer.Minor
				&& this.Patch == semVer.Patch
				&& this.Stage == semVer.Stage
				&& ((!this.Step.HasValue && !semVer.Step.HasValue) || this.Step == semVer.Step));
		}
		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return this.Major.GetHashCode() ^ this.Minor.GetHashCode()
				^ this.Patch.GetHashCode() ^ this.Stage.GetHashCode()
				^ this.Step.GetHashCode();
		}
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="System.String"/> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return ToString("G");
		}
		/// <summary>
		/// Formats the value of the current instance using the specified format.
		/// </summary>
		/// <param name="format">The <see cref="T:System.String"/> specifying the format to use.</param>
		/// <returns>
		/// A <see cref="T:System.String"/> containing the value of the current instance in the specified format.
		/// </returns>
		public string ToString(string format)
		{
			return ToString(format, null);
		}
		/// <summary>
		/// Formats the value of the current instance using the specified format.
		/// </summary>
		/// <param name="format">The <see cref="T:System.String"/> specifying the format to use.</param>
		/// <param name="formatProvider">The <see cref="T:System.IFormatProvider"/> to use to format the value.</param>
		/// <returns>
		/// A <see cref="T:System.String"/> containing the value of the current instance in the specified format.
		/// </returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			if (String.IsNullOrEmpty(format))
				format = "G";
			if (formatProvider == null)
				formatProvider = System.Globalization.CultureInfo.CurrentCulture;

			switch (format.ToUpperInvariant())
			{
				case "G":
					return String.Format(formatProvider, "{0}.{1}.{2}", Major, Minor, Patch);
				case "F":
					return String.Format(formatProvider, "{0}.{1}.{2}{3}{4}", Major, Minor, Patch,
						GetDisplayFriendlyDevelopmentStage(), Step.HasValue ? Step.Value.ToString() : "");
				default:
					throw new FormatException(String.Format("The '{0}' format string is not supported.", format));
			}
		}

		private string GetDisplayFriendlyDevelopmentStage()
		{
			switch (Stage)
			{
				default:
				case DevelopmentStage.None:
				case DevelopmentStage.Final:
					return String.Empty;
				case DevelopmentStage.PreAlpha:
					return "pre";
				case DevelopmentStage.Alpha:
					return "alpha";
				case DevelopmentStage.Beta:
					return "beta";
				case DevelopmentStage.RC:
					return "rc";
			}
		}

		/// <summary>
		/// Converts the string representation of a semantic version in a specified culture-specific
		/// format to its semantic version equivalent. A return value indicates
		/// whether the conversion succeeded.
		/// </summary>
		/// <param name="s">A string containing a semantic version to convert. The string is interpreted using
		/// the style specified by style.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information about <paramref name="s" />.</param>
		/// <param name="result">When this method returns, contains the semantic version value equivalent
		/// to the number contained in <paramref name="s" />, if the conversion succeeded, or <c>null</c> if the
		/// conversion failed. The conversion fails if the s parameter is <c>null</c>, is not
		/// in a format compliant with style.</param>
		/// <returns>
		///   <c>true</c> if <paramref name="s" /> was converted successfully; otherwise, <c>false</c>.
		/// </returns>
		public static bool TryParse(string s, IFormatProvider provider, out SemanticVersion result)
		{
			const int major = 0;
			const int minor = 1;
			const int patch = 2;
			const int dev = 3;
			const int step = 4;
			const int build = 5;

			Func<string, string, bool> compare = (x, y) => string.Equals(x, y, StringComparison.Ordinal);
			CultureInfo ci = provider as CultureInfo;
			if (ci != null) compare = 
				(x, y) 
				=> 
				// string.Compare(x, y , false, ci) == 0
				string.Compare(x, y, StringComparison.CurrentCultureIgnoreCase) == 0
				;

			int state = 0;
			StringBuilder sb = new StringBuilder();
			SemanticVersion ver = new SemanticVersion();
			var tmp = 0;
			result = null;

			for (var i = 0; i < s.Length; i++)
			{
				var c = s[i].ToString();
				switch (state)
				{
					case major:
						if (compare(c, "."))
						{
							if (!int.TryParse(sb.ToString(), NumberStyles.None, provider, out tmp))
								return false;
							ver.Major = tmp;
							state = minor;
							sb.Clear();
						}
						else
						{
							sb.Append(c);
						}
						break;
					case minor:
						if (compare(c, "."))
						{
							if (!int.TryParse(sb.ToString(), NumberStyles.None, provider, out tmp))
								return false;
							ver.Minor = tmp;
							state = patch;
							sb.Clear();
						}
						else
						{
							sb.Append(c);
						}
						break;
					case patch:
						if (compare(c, "-") || compare(c, "+"))
						{
							if (!int.TryParse(sb.ToString(), NumberStyles.None, provider, out tmp))
								return false;
							ver.Patch = tmp;
							state = compare(c, "-") ? dev : build;
							sb.Clear();
						}
						else
						{
							sb.Append(c);
						}
						break;
					case dev:
						if (compare(c, "+") || compare(c, "."))
						{
							if (sb.Length == 0)
								return false;
							switch (sb.ToString())
							{
								case "alpha": ver.Stage = DevelopmentStage.Alpha; break;
								case "beta": ver.Stage = DevelopmentStage.Beta; break;
								case "final": ver.Stage = DevelopmentStage.Final; break;
								case "pre": ver.Stage = DevelopmentStage.PreAlpha; break;
								case "rc": ver.Stage = DevelopmentStage.RC; break;
								default: return false;
							}
							state = compare(c, "+") ? build : step;
							sb.Clear();
						}
						else
						{
							sb.Append(c);
						}
						break;
					case step:
						if (compare(c, "+"))
						{
							if (!int.TryParse(sb.ToString(), NumberStyles.None, provider, out tmp))
								return false;
							ver.Step = tmp;
							state = build;
							sb.Clear();
						}
						else
						{
							sb.Append(c);
						}
						break;
					case build:
						sb.Append(c);
						break;
				}
			}

			switch (state)
			{
				case major:
				case minor: return false;
				case patch:

					if (!int.TryParse(sb.ToString(), NumberStyles.None, provider, out tmp))
						return false;
					ver.Patch = tmp;
					break;
				case dev:
					if (sb.Length == 0)
						return false;
					switch (sb.ToString())
					{
						case "alpha": ver.Stage = DevelopmentStage.Alpha; break;
						case "beta": ver.Stage = DevelopmentStage.Beta; break;
						case "final": ver.Stage = DevelopmentStage.Final; break;
						case "pre": ver.Stage = DevelopmentStage.PreAlpha; break;
						case "rc": ver.Stage = DevelopmentStage.RC; break;
						default: return false;
					}
					break;
				case step:
					if (!int.TryParse(sb.ToString(), NumberStyles.None, provider, out tmp))
						return false;
					ver.Step = tmp;
					break;
				case build:
					var str = sb.ToString();
					if (!str.StartsWith("build.", StringComparison.CurrentCultureIgnoreCase))
						return false;
					str = str.Substring(6);
					if (str == string.Empty)
						return false;
					//mc++ ver.Build = str;
					//mc+ ver.Patch = str;
					throw new NotImplementedException("Build in SemVer?");
			}

			result = ver;
			return true;
		} 
	}
	/// <summary>
	/// A list of development stages.
	/// </summary>
	public enum DevelopmentStage
	{
		/// <summary>
		/// This is the default or unspecified value.
		/// </summary>
		None = 0,
		/// <summary>
		/// <para>
		/// Usually akin to a prototype, this has either very little
		/// functionality, is a mock-up, or is still otherwise in the
		/// design stages.
		/// </para>
		/// </summary>
		PreAlpha = 1,
		/// <summary>
		/// This typically means that work on major features is still
		/// ongoing.
		/// </summary>
		Alpha = 2,
		/// <summary>
		/// This typically means that major features are complete, though
		/// not necessarily bug-free or tested, and may or may not mean
		/// that minor features are done or tested.
		/// </summary>
		Beta = 3,
		/// <summary>
		/// This typically means that all planned features or changes are
		/// either done or cut, as well as tested and mostly ready.  Code
		/// should be mainly stable.
		/// </summary>
		RC = 4,
		/// <summary>
		/// This typically means a shipping or production version.
		/// </summary>
		Final = 5
	}
}
