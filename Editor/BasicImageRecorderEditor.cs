using UnityEditor.Recorder;
using UnityEngine;

namespace UnityEditor.RecorderPluginStarter
{
    [CustomEditor(typeof(BasicImageRecorderSettings))]
    class BasicImageRecorderEditor : RecorderEditor
    {
        protected override void FileTypeAndFormatGUI()
        {
            base.FileTypeAndFormatGUI();
            GUILayout.Label("PNG is the only supported image format.");
        }
    }
}
