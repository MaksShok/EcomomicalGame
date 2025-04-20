using System.Collections.Generic;
using System.Xml.Serialization;
using Game.Scripts.PlayerStatMechanics;
using UnityEngine.UI;

namespace Game.Scripts.DialogMechanics
{
    [XmlRoot("Story")]
    public class Story
    {
        [XmlElement("Segment")] 
        public DialogSegment[] DialogSegments;
    }

    public class DialogSegment
    { 
        [XmlArray("Dialogs")] [XmlArrayItem("Dialog")]
        public Dialog[] Dialogs;

        [XmlAttribute("id")]
        public int Id;

        [XmlAttribute("nextId")] 
        public int NextId;

        [XmlAttribute("mood")]
        public ChoiceMood Mood;

        [XmlAttribute("end")] 
        public bool IsEnd;
    }

    public class Dialog
    {
        [XmlArray("Choices")] [XmlArrayItem("Choice")]
        public Choice[] Choices;
    
        [XmlElement("Speaker")]
        public string SpeakerName;
    
        [XmlElement("Text")]
        public string Text;

        [XmlElement("SpriteId")]
        public string SpriteId;

        [XmlAttribute("withChoice")]
        public bool WithChoice;
    }

    public class Choice
    {
        [XmlElement("Text")]
        public string Text;

        [XmlAttribute("nextSegmentId")]
        public int NextSegmentId;

        [XmlAttribute("mood")]
        public ChoiceMood Mood;
        
        [XmlArray("Conditions")] [XmlArrayItem("Condition")]
        public Condition[] Conditions;

        [XmlArray("Consequences")] [XmlArrayItem("Consequence")]
        public Consequence[] Consequences;
    }
    
    public class Condition
    {
        [XmlAttribute("stat")]
        public PlayerStat Stat;
        
        [XmlAttribute("minValue")]
        public int MinValue;
    }
    
    public class Consequence
    {
        [XmlAttribute("stat")]
        public PlayerStat Stat;
        
        [XmlAttribute("value")]
        public string ValueString;
    }

    public enum ChoiceMood
    {
        None = 0,
        Positive = 1,
        Negative = 2,
        Agree = 3,
        Refuse = 4,
    }
}