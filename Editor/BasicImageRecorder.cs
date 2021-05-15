using System.IO;
using UnityEditor.Recorder;
using UnityEngine;

namespace UnityEditor.RecorderPluginStarter
{
    class BasicImageRecorder : GenericRecorder<BasicImageRecorderSettings>
    {
        protected override void RecordFrame(RecordingSession session)
        {
            var input = m_Inputs[0] as TaggedCameraInput;
            var path = Settings.FileNameGenerator.BuildAbsolutePath(session);
            var texture = RenderTextureToTexture2D(input.OutputRenderTexture);
            var bytes = texture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);
        }

        static Texture2D RenderTextureToTexture2D(RenderTexture renderTexture)
        {
            var texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
            texture.Apply();
            return texture;
        }
    }
}
