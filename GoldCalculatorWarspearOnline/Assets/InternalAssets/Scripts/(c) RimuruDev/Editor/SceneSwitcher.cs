// **************************************************************** //
//
//   Copyright (c) RimuruDev. All rights reserved.
//   Project: Infinity Dead
//   Contact me: rimuru.dev@gmail.com
//
// **************************************************************** //

using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;

namespace Development.RimuruDev.WarspearOnline.Editors
{
    internal sealed class SceneSwitcher : EditorWindow
    {
        private bool showAllScenes = false;

        [MenuItem("RimuruDev/SceneSwitcher")]
        private static void ShowWindow() => EditorWindow.GetWindow(typeof(SceneSwitcher));

        private void OnGUI()
        {
            GUILayout.Label("Scene Switcher", EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();
            showAllScenes = EditorGUILayout.Toggle("Show All Scenes", showAllScenes);

            if (EditorGUI.EndChangeCheck())
                Repaint();

            string[] scenePaths = showAllScenes ? GetAllScenePaths() : GetScenePathsByBuildSettings();

            foreach (string scenePath in scenePaths)
            {
                if (GUILayout.Button(Path.GetFileNameWithoutExtension(scenePath)))
                    EditorSceneManager.OpenScene(scenePath);
            }
        }

        private string[] GetScenePathsByBuildSettings()
        {
            string[] paths = new string[EditorBuildSettings.scenes.Length];

            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
                paths[i] = EditorBuildSettings.scenes[i].path;

            return paths;
        }

        private string[] GetAllScenePaths()
        {
            string[] scenePaths;

            string[] guids = AssetDatabase.FindAssets("t:Scene");

            scenePaths = new string[guids.Length];
            for (int i = 0; i < scenePaths.Length; i++)
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                scenePaths[i] = path;
            }

            return scenePaths;
        }
    }
}