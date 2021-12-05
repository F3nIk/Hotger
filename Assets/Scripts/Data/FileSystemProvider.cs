using System.IO;

using UnityEngine;

public class FileSystemProvider
{
    private readonly string _path;

    public FileSystemProvider(string fileName) => _path = $"{Application.persistentDataPath}/{ fileName}.json";

    public bool HasData => File.Exists(_path);

    public void Write(string data)
    {
        using (StreamWriter writer = new StreamWriter(_path))
        {
            writer.WriteLine(data);
        }
    }

    public string Read()
    {
        using (StreamReader reader = new StreamReader(_path))
        {
            return reader.ReadLine();
        }
    }
}
