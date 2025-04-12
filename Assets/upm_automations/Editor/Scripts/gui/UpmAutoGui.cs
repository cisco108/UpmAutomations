using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using ClickEvent = UnityEngine.UIElements.ClickEvent;
 
namespace UpmAuto {
public class UpmAutoGui : EditorWindow
{
    private TextField GitExe => rootVisualElement.Q<TextField>("git-exe");
    private TextField PackagePath => rootVisualElement.Q<TextField>("package-path");
    private TextField PackageVersion => rootVisualElement.Q<TextField>("package-version");
    private Button PublishBtn => rootVisualElement.Q<Button>("publish-btn");
    public static event Action OnPublish;

    [MenuItem("Tools/\u23e9 Upm Automations \u23e9")]
    public static void ShowWindow()
    {
        UpmAutoGui wnd = GetWindow<UpmAutoGui>();
        wnd.titleContent = new GUIContent("\u23e9 Upm Automations \u23e9");
    }

    public void CreateGUI()
    {
        VisualElement root = rootVisualElement;
        VisualTreeAsset asset = Resources.Load<VisualTreeAsset>("GitinityUI");

        asset.CloneTree(root);

        GitExe.SetValueWithoutNotify(UpmAutoConfigs.gitBashExe);
        GitExe.RegisterValueChangedCallback(UpdateGitExe);

        PackagePath.SetValueWithoutNotify(UpmAutoConfigs.packagePath);
        PackagePath.RegisterValueChangedCallback(UpdatePackagePath);

        PackageVersion.SetValueWithoutNotify(UpmAutoConfigs.version);
        PackageVersion.RegisterValueChangedCallback(evt => UpmAutoConfigs.version = evt.newValue);

        PublishBtn.RegisterCallback<ClickEvent>(FirePublish);

    }

    private void UpdatePackagePath(ChangeEvent<string> evt)
    {
        UpmAutoConfigs.packagePath = evt.newValue;
    }

    private void UpdateGitExe(ChangeEvent<string> evt)
    {
        UpmAutoConfigs.gitBashExe = evt.newValue;
    }

    private static void FirePublish(ClickEvent _)
    {
        OnPublish.Invoke();
    }

}
}