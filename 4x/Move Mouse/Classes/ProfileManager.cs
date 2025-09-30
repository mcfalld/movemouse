using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ellabi.Classes
{
    public class ProfileManager
    {
        public List<ActionProfile> Profiles { get; set; } = new List<ActionProfile>();
        public ActionProfile ActiveProfile { get; private set; }

        public void AddProfile(ActionProfile profile)
        {
            Profiles.Add(profile);
        }

        public void RemoveProfile(ActionProfile profile)
        {
            Profiles.Remove(profile);
        }

        public void SetActiveProfile(ActionProfile profile)
        {
            ActiveProfile = profile;
        }

        public IEnumerable<string> GetProfileNames()
        {
            return Profiles.Select(p => p.Name);
        }

        // Save all profiles to a file
        public void SaveProfiles(string filePath)
        {
            var serializer = new XmlSerializer(typeof(List<ActionProfile>));
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(stream, Profiles);
            }
        }

        // Load profiles from a file
        public void LoadProfiles(string filePath)
        {
            if (!File.Exists(filePath)) return;
            var serializer = new XmlSerializer(typeof(List<ActionProfile>));
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                Profiles = (List<ActionProfile>)serializer.Deserialize(stream);
            }
        }
    }
}