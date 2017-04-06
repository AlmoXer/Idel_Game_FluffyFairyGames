using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

[XmlRoot("PlayerContainer")]
public class PlayerContainer
{

    public PlayerContainer() { }

    [XmlArray("Players"), XmlArrayItem("Player")]
    public List<Player> Players = new List<Player>();

    public void Save(string path)
    {
        var serializer = new XmlSerializer(typeof(PlayerContainer));
        using (var stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }

    public PlayerContainer Load(string path)
    {
        var serializer = new XmlSerializer(typeof(PlayerContainer));
       if(File.Exists(path))
        using (var stream = new FileStream(path, FileMode.Open))
        {
            var a = serializer.Deserialize(stream) as PlayerContainer;
            return a ;
        }
        return null;
    }
}
