using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using ClickEvent = UnityEngine.UIElements.ClickEvent;

public class UpmAutoGui : EditorWindow
{
    private TextField GitExe => rootVisualElement.Q<TextField>("git-exe");
    private TextField PackagePath => rootVisualElement.Q<TextField>("package-path");
    private Button PublishBtn => rootVisualElement.Q<Button>("publish-btn");
    public static event Action OnPublish;

    [MenuItem("Tools/Upm Automations")]
    public static void ShowWindow()
    {
        UpmAutoGui wnd = GetWindow<UpmAutoGui>();
        wnd.titleContent = new GUIContent("🚀Upm Automations🚀");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        VisualTreeAsset asset = Resources.Load<VisualTreeAsset>("GitinityUI");

        asset.CloneTree(root);
        
        GitExe.SetValueWithoutNotify(Configs.gitBashExe);
        GitExe.RegisterValueChangedCallback(UpdateGitExe);
        
        PackagePath.SetValueWithoutNotify(Configs.packagePath);
        PackagePath.RegisterValueChangedCallback(UpdatePackagePath);

        PublishBtn.RegisterCallback<ClickEvent>(FirePublish);

    }

    private void UpdatePackagePath(ChangeEvent<string> evt)
    {
        Configs.packagePath = evt.newValue;
    }

    private void UpdateGitExe(ChangeEvent<string> evt)
    {
        Configs.gitBashExe = evt.newValue;
    }

    private static void FirePublish(ClickEvent _)
    {
        OnPublish.Invoke();
    }

}