namespace EASEncoder.Models.SAME
{
    public class SAMEMessageAlertCode
    {
        public SAMEMessageAlertCode(string id, string name, SevereType severity, bool compliant = true)
        {
            Id = id;
            Name = name;
            Severity = severity;
            Compliant = compliant;
        }

        public enum SevereType
        {
            Test,
            Statement,
            Advisory,
            Watch,
            Warning,
            Emergency,
        }

        public string Id { private set; get; }
        public string Name { private set; get; }
        public SevereType Severity { private set; get; }
        public bool Compliant { private set; get; } = true;
    }
}