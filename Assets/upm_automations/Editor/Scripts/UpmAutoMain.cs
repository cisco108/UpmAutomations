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
        string commitCmd = _commandBuilder.GetCommit(" . ");
        _terminal.Execute(commitCmd);
        
        string prefix = Configs.packagePath;
        string branchName = Configs.branchName;
        string subtreeSplitCmd = _commandBuilder.GetSubtreeSplitNewBranch(prefix, branchName);
        _terminal.Execute(subtreeSplitCmd);
        
        string pushCmd = _commandBuilder.GetPushAllBranches();
        _terminal.Execute(pushCmd);
    }

}

public static class Configs
{
    public static string gitBashExe = @"C:\Program Files\Git\git-bash.exe";
    public static string branchName = "upm";
    public static string version;
    public static string packagePath = @"Assets\";
}