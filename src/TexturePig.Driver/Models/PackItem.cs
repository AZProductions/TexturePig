namespace TexturePig.Driver.Models
{
    public class PackItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Resolution { get; set; }
        public bool Verified { get; set; }
        public string Cover { get; set; }
        public string ID { get; set; }
        public string Version { get; set; }
        public string Profile { get; set; }

        public PackItem(string Name, string Resolution, bool Verified, string Description, string Cover, string ID, string Version, string Profile)
        {
            this.Name = Name;
            this.Resolution = Resolution;
            this.Verified = Verified;
            this.Description = Description;
            this.Cover = Cover;
            this.ID = ID;
            this.Version = Version;
            this.Profile = Profile;
        }
    }
}
