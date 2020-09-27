using System;
using System.Collections;
using System.Collections.Generic;
using Meaf75.Unity;
using UnityEditor;
using UnityEngine;

namespace Meaf75.Unity{
    [CustomEditor(typeof(TimeRecorder))]
//    [custom]
    public class TimeRecorderWindow : Editor{
        public override void OnInspectorGUI(){
            GUILayout.Button("hey");
        }
    }
}

