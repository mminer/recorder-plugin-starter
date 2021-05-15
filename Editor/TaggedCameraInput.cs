using System.Linq;
using UnityEditor.Recorder;
using UnityEngine;

namespace UnityEditor.RecorderPluginStarter
{
    class TaggedCameraInput : RecorderInput
    {
        public RenderTexture OutputRenderTexture { get; private set; }
        TaggedCameraInputSettings InputSettings => settings as TaggedCameraInputSettings;

        protected override void BeginRecording(RecordingSession session)
        {
            base.BeginRecording(session);

            OutputRenderTexture = new RenderTexture(
                InputSettings.OutputWidth,
                InputSettings.OutputHeight,
                0,
                RenderTextureFormat.ARGB32,
                RenderTextureReadWrite.Default);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            OutputRenderTexture.Release();
            OutputRenderTexture = null;
        }

        protected override void NewFrameReady(RecordingSession session)
        {
            base.NewFrameReady(session);
            var camera = GetTargetCamera(InputSettings.CameraTag);
            var originalTargetTexture = camera.targetTexture;
            camera.targetTexture = OutputRenderTexture;
            camera.Render();
            camera.targetTexture = originalTargetTexture;
        }

        static Camera GetTargetCamera(string cameraTag)
        {
            try
            {
                var cameras = GameObject
                    .FindGameObjectsWithTag(cameraTag)
                    .Select(gameObject => gameObject.GetComponent<Camera>())
                    .Where(camera => camera != null)
                    .ToList();

                if (cameras.Count > 1)
                {
                    Debug.LogWarning($"Found more than one camera with tag '{cameraTag}'.");
                }

                return cameras.FirstOrDefault();
            }
            catch (UnityException)
            {
                Debug.LogWarning($"Tag '{cameraTag}' does not exist.");
                return null;
            }
        }
    }
}
