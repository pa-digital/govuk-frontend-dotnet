namespace GDS.Components.Enum
{
    public class NotificationOutcomeTypeExtensionsAttribute : Attribute
    {
        public string ClassName { get; set; }
        public string AriaRole { get; set; }
    }

    public enum NotificationOutcomeType
    {
        [NotificationOutcomeTypeExtensions(ClassName = "govuk-notification-banner", AriaRole = "region")]
        Alert,
        [NotificationOutcomeTypeExtensions(ClassName = "govuk-notification-banner govuk-notification-banner--success", AriaRole = "alert")]
        Success
    }
}
