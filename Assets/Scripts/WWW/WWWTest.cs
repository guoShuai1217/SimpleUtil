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
using UnityEngine.UI;
namespace guoShuai.WWWHelper
{

    public class WWWTest : MonoBehaviour
    {

        public RawImage ima;

        private void Start()
        {
            string url1 = "http://192.168.2.141:8090/cms/engineeringimg/add?";
            byte[] postData = File.ReadAllBytes(Application.streamingAssetsPath + "/1.jpg");
            WWWItem tmp1 = new WWWItem(url1, postData);

            tmp1.beginDownload = beginCallback;
            tmp1.downloadProgress = progressCallback;
            tmp1.downloadFinish = finishCallbck;
            tmp1.downloadError = errorCallback;


            WWWHelper.Instance.AddTask(tmp1);


        }

        private void errorCallback(string error)
        {
            Debug.Log("下载出错了");
        }

        private void finishCallbck(WWW www)
        {
            Debug.Log(www.text);

            JsonData data = JsonMapper.ToObject(www.text);
            Debug.Log(data["code"].ToString());

        }

        private void progressCallback(float progress)
        {
            //Debug.Log(progress);
        }

        private void beginCallback()
        {
            //Debug.Log("开始下载: " +);
        }
    }
}