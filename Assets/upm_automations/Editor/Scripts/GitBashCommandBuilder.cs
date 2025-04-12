using System;
using UnityEngine;

public class GitBashCommandBuilder 
{

    public string GetCommit(string contentPath)
    {
        //TODO: this has to have the version in it 
        return GitCommands.add + contentPath
                               + " && " + GitCommands.commit_m
                               + $" \' added {contentPath} on {DateTime.Now} \'";
    }

    public string GetPush(string branchName = default)
    {
        if (branchName == default)
        {
            return GitCommands.push_origin;
        }
        return GitCommands.push_origin + branchName;
    }

    public string GetPushAllBranches()
    {
        return GitCommands.push_origin + GitFlags.all;
    }

    public string GetCreateBranch(string branchName)
    {
        return GitCommands.branch + branchName;
    }

    public string GetCurrentBranch()
    {
        return GitCommands.branch + GitFlags.show_current;
    }

    public string GetSwitch(string branch)
    {
        return GitCommands.g_switch + branch;
    }

    public string GetSubtreeSplitNewBranch(string prefix, string newBranchName)
    {
        return GitCommands.subtree_split_prefix + prefix + GitFlags.branch + newBranchName;
    }

}