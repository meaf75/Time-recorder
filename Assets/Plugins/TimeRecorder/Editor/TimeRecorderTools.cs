using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Meaf75.Unity {

    public class TimeRecorderTools : EditorWindow {

        private string backupFileName = "time_recorder_backup.json";
        private TextAsset backupTextAsset;

        [MenuItem("Window/Meaf75/Time recorder tools")]
        static void Init() {
            // Get existing open window or if none, make a new one:
            var window = (TimeRecorderTools) GetWindow(typeof(TimeRecorderTools));
            window.titleContent = new GUIContent("Time recorder tools");

        }

        private void OnGUI() {
            EditorGUILayout.LabelField("Time recorder tools");

            GUILayout.Space(15);

            EditorGUILayout.LabelField("Backup", EditorStyles.boldLabel);

            backupFileName = EditorGUILayout.TextField("Backup file name: ", backupFileName);

            if (GUILayout.Button("Generate backup")) {
                GenerateBackup();
            }

            GUILayout.Space(15);

            EditorGUILayout.LabelField("Restore from file", EditorStyles.boldLabel);

            backupTextAsset = EditorGUILayout.ObjectField ("Backup file",backupTextAsset,typeof(TextAsset),false) as TextAsset;

            if (GUILayout.Button("Restore from backup")) {
                RestoreFromBackup();
            }
        }

        void GenerateBackup() {
            string path = Path.Combine(Application.dataPath, backupFileName);

            string timeRecorderJson = PlayerPrefs.GetString(TimeRecorderExtras.TIME_RECORDER_REGISTRY, "");

            if (string.IsNullOrEmpty(timeRecorderJson)) {
                Debug.LogWarning("There is nothing to backup");
                return;
            }

            File.WriteAllText(path,timeRecorderJson);
            Debug.Log("Your time recorder backup was written at "+path);
        }

        void RestoreFromBackup() {

            if (!backupTextAsset) {
                Debug.LogError("First select a backup file");
            }

            string timeRecorderJson = backupTextAsset.text;

            TimeRecorderInfo timeRecorderInfoData;

            try{
                // Get data
                timeRecorderInfoData = JsonUtility.FromJson<TimeRecorderInfo>(timeRecorderJson);
            } catch(Exception){
                Debug.LogError("Your time recorder registry JSON file data is corrupted, please try another valid file. I'm sorry");
                return;
            }

            PlayerPrefs.SetString(TimeRecorderExtras.TIME_RECORDER_REGISTRY, timeRecorderJson);
            PlayerPrefs.Save();

            // Override loaded data with file data new one
            TimeRecorder.timeRecorderInfo = timeRecorderInfoData;

            Debug.Log("Your time recorder registry was restored from the given file");

            if (TimeRecorderWindow.Instance) {
                TimeRecorderWindow.Instance.RepaintWindow();
            }
        }
    }
}