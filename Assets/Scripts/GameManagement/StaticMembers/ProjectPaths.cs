/*
 * Contains paths to several resources.
 */
public static class ProjectPaths
{
    // Relative paths to all scenes.
    public const string scenesRPath = @"Scenes/";

    // Relative path to main menu scene.
    public const string mainMenuSceneRPath = scenesRPath + @"MainMenu";

    // Relative path to intermission scene.
    public const string intermissionSceneRPath = scenesRPath + @"Intermission";

    // Relative path to continue scene.
    public const string continueSceneRPath = scenesRPath + @"Continue";

    // Relative path to game over scene.
    public const string gameOverSceneRPath = scenesRPath + @"GameOver";

    // Relative path to game win scene.
    public const string gameWinSceneRPath = scenesRPath + @"GameWin";

    // Relative paths to all sprites.
    public const string spritesRPath = @"Sprites/";

    // Relative paths to background sprites.
    public const string backgroundSpritesRPath = spritesRPath + @"Background/";

    // Relative paths to Vi's sprites.
    public const string viSpritesRPath = spritesRPath + @"Bosses/Vi/";

    /*
     * Escape the parsed path.
     */
    public static string EscapePath(string path)
    {
        return path.Replace(" ", @"\ ");
    }
}

