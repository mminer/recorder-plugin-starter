using System;
using UnityEditor.Recorder;
using UnityEngine;

namespace UnityEditor.RecorderPluginStarter
{
    [Serializable]
    class BasicImageInputSelector : InputSettingsSelector
    {
        [SerializeField] TaggedCameraInputSettings cameraInputSettings = new TaggedCameraInputSettings();
    }
}
