namespace EASEncoder.Models.SAME
{
    public class SAMEMessageOriginator
    {
        public SAMEMessageOriginator(string id, string name, bool compilant = true)
        {
            Id = id;
            Name = name;
            Compliant = compilant;
        }

        public string Id { private set; get; }
        public string Name { private set; get; }
        public bool Compliant { private set; get; } = true;
    }
}