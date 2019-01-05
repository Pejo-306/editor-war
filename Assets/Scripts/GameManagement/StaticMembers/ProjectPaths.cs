using UnityEngine;

public class ProjectPaths : MonoBehaviour
{
    public static string spritesRPath { get; private set; }
    public static string viSpritesRPath {  get; private set; } 

    void Awake()
    {
        spritesRPath = @"Sprites/";
        viSpritesRPath = spritesRPath + @"Bosses/Vi/";
    }

    public static string EscapePath(string path)
    {
        return path.Replace(" ", @"\ ");
    }
}

