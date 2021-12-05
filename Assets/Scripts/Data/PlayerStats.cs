using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [HideInInspector] public int playCount = 0;


    public void Save()
    {
        FileSystemProvider provider = new FileSystemProvider(name);
        provider.Write(JsonUtility.ToJson(this));
    }

    public void Load()
    {
        FileSystemProvider provider = new FileSystemProvider(name);

        if(provider.HasData) JsonUtility.FromJsonOverwrite(provider.Read(), this);
    }
}
