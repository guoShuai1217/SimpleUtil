/*
 *	Description: 
 *
 *	CreatedBy: guoShuai
 *
 *	DataTime:  
 *
 */
using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
namespace guoShuai.WWWHelper
{

    public class WWWTest : MonoBehaviour
    {

        public string screenShotURL = "http://www.my-server.com/cgi-bin/screenshot.pl";

        // Use this for initialization
        void Start()
        {
            StartCoroutine(UploadPNG());
        }

        IEnumerator UploadPNG()
        {
            // We should only read the screen after all rendering is complete
            yield return new WaitForEndOfFrame();

            // Create a texture the size of the screen, RGB24 format
            int width = Screen.width;
            int height = Screen.height;
            var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

            // Read screen contents into the texture
            tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            tex.Apply();

            // Encode texture into PNG
            byte[] bytes = tex.EncodeToPNG();
            Destroy(tex);

            // Create a Web Form
            WWWForm form = new WWWForm();
            form.AddField("frameCount", Time.frameCount.ToString());
            form.AddBinaryData("fileUpload", bytes, "screenShot.png", "image/png");

            // Upload to a cgi script
            using (var w = UnityWebRequest.Post(screenShotURL, form))
            {
                yield return w.SendWebRequest();
                if (w.isNetworkError || w.isHttpError)
                {
                    print(w.error);
                }
                else
                {
                    print("Finished Uploading Screenshot");
                }
            }
        }


        //public RawImage ima;

        //private void Start()
        //{
        //    string url1 = "http://192.168.2.141:8090/cms/engineeringimg/add?";
        //    byte[] postData = File.ReadAllBytes(Application.streamingAssetsPath + "/1.jpg");
        //    WWWItem tmp1 = new WWWItem(url1, postData);

        //    tmp1.beginDownload = beginCallback;
        //    tmp1.downloadProgress = progressCallback;
        //    tmp1.downloadFinish = finishCallbck;
        //    tmp1.downloadError = errorCallback;


        //    WWWHelper.Instance.AddTask(tmp1);


        //}

        //private void errorCallback(string error)
        //{
        //    Debug.Log("下载出错了");
        //}

        //private void finishCallbck(WWW www)
        //{
        //    Debug.Log(www.text);

        //    JsonData data = JsonMapper.ToObject(www.text);
        //    Debug.Log(data["code"].ToString());

        //}

        //private void progressCallback(float progress)
        //{
        //    //Debug.Log(progress);
        //}

        //private void beginCallback()
        //{
        //    //Debug.Log("开始下载: " +);
        //}
    }
}