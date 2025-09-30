using System;
using System.Collections.Generic;
using ellabi.Actions;

namespace ellabi.Classes
{
    [Serializable]
    public class ActionProfile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public List<ActionBase> Actions { get; set; } = new List<ActionBase>();

        public ActionProfile() { }

        public ActionProfile(string name)
        {
            Name = name;
        }
    }
}