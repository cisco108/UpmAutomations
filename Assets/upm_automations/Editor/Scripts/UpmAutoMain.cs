using UnityEditor;
using UnityEngine;

namespace UpmAuto
{
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

            string prefix = UpmAutoConfigs.packagePath;
            string branchName = UpmAutoConfigs.branchName;
            string subtreeSplitCmd = _commandBuilder.GetSubtreeSplitNewBranch(prefix, branchName);
            _terminal.Execute(subtreeSplitCmd);

            string pushCmd = _commandBuilder.GetPushAllBranches();
            _terminal.Execute(pushCmd);
        }

    }


}