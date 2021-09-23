using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ImageCapturer : MonoBehaviour
{
    public int fileCounter;
    public Camera refCam;
    public Text refText;

    public void Capture()
    {
        try
        {
            RenderTexture activeRenderTexture = RenderTexture.active;
            RenderTexture.active = refCam.targetTexture;

            refCam.Render();

            Texture2D image = new Texture2D(refCam.targetTexture.width, refCam.targetTexture.height);
            image.ReadPixels(new Rect(0, 0, refCam.targetTexture.width, refCam.targetTexture.height), 0, 0);
            image.Apply();
            RenderTexture.active = activeRenderTexture;

            byte[] bytes = image.EncodeToPNG();

            var path = Application.persistentDataPath + "/resources/";
            File.WriteAllBytes(path + 0 + ".png", bytes);
            fileCounter++;
            Destroy(image);

            refText.text =
                string.Format("已保存（{0}）", System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second);

        }
        catch(Exception e)
        {
            refText.text = e.StackTrace;
        }
    }
}