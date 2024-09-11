namespace GDS.Components.Enum
{
    public class RegexValidatorExtensionsAttribute : Attribute
    {
        public string Pattern { get; set; }
        public string Error { get; set; }
    }

    public enum Regex
    {
       [RegexValidatorExtensions(Pattern = @"^[a-zA-Z \-\']{2,}$", Error = "Your name must contain at least two characters and can include (A-Z) (a-z) a space, a hyphen and an apostrophe")]
       Name,
       [RegexValidatorExtensions(Pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{1,}$", Error = "Please enter a valid email containing a username, an @ symbol a domain and top level domain")]
       Email,
       [RegexValidatorExtensions(Pattern = @"^[a-zA-Z0-9\-]{8,}$", Error = "Your password must contain at least 8 characters from (A-Z)(a-z)(0-9) and a -")]
       Password
    }
}
