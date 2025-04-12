using UnityEngine;
using UnityEditor;

namespace UpmAuto
{
    public class UpmAutoConfigs : ScriptableObject
    {
        private static string assetName => nameof(UpmAutoConfigs);
        private static UpmAutoConfigs _instance;
        public static UpmAutoConfigs instance
        {
            get
            {
                if (_instance != null) return _instance;
                _instance = CreateInstance<UpmAutoConfigs>();
                AssetDatabase.CreateAsset(_instance, $"Assets/{assetName}.asset");
                return _instance;
            }
        } 
        
        public static string gitBashExe = @"C:\Program Files\Git\git-bash.exe";
        public static string branchName = "upm";
        public static string version = "0.0.0";
        public static string packagePath = @"Assets/";
    }
}