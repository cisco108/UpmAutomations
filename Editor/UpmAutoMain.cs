using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class UpmAutoMain
{
    private static GitBashInterface _terminal;
    private static GitBashCommandBuilder _commandBuilder;

    static UpmAutoMain()
    {
        _terminal = new GitBashInterface();
        _commandBuilder = new GitBashCommandBuilder();
        UpmAutoGui.OnPublish += Main;
    }

  
    private static void Main()
    {
        Debug.Log("Main");
    }

}

public static class Configs
{
    public static string gitBashExe = @"C:\Program Files\Git\git-bash.exe";
    public static string branchName;
    public static string version;
    public static string packagePath = @"Assets\";
}