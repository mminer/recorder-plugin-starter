using System.Collections.Generic;
using UnityEditor.Recorder;
using UnityEngine;

namespace UnityEditor.RecorderPluginStarter
{
    [RecorderSettings(typeof(BasicImageRecorder), "Basic Image Sequence", "imagesequence_16")]
    class BasicImageRecorderSettings : RecorderSettings
    {
        [SerializeField] BasicImageInputSelector imageInputSelector = new BasicImageInputSelector();

        protected override string Extension => "png";

        public override IEnumerable<RecorderInputSettings> InputsSettings
        {
            get { yield return imageInputSelector.Selected; }
        }

        public BasicImageRecorderSettings()
        {
            FileNameGenerator.FileName = $"image_{DefaultWildcard.Frame}";
        }
    }
}
