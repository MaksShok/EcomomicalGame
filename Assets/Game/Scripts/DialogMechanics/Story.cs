using System.Xml.Serialization;
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
        public DialogMood Mood;

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
        public DialogMood Mood;
    }

    public enum DialogMood
    {
        None = 0,
        Positive = 1,
        Negative = 2,
        Agree = 3,
        Refuse = 4,
    }
}