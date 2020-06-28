/*
 *	Description: 发送HTTP请求的数据类
 *
 *	CreatedBy: guoShuai
 *
 *	DataTime:  2020.06.24
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace guoShuai.WWWHelper
{ 
/// <summary>
/// 开始下载
/// </summary>
public delegate void BeginDownLoad();
/// <summary>
/// 下载进度
/// </summary>
/// <param name="progress"></param>
public delegate void DownLoadProgress(float progress);
/// <summary>
/// 下载完成
/// </summary>
/// <param name="www"></param>
public delegate void DownLoadFinish(WWW www);
/// <summary>
/// 下载出错
/// </summary>
/// <param name="error"></param>
public delegate void DownLoadError(string error);

    public class WWWItem
    {
        protected string url;
        public string URL
        {
            get { return url; }
        }


        protected WWWForm wwwForm;

        protected byte[] postData;

        public WWWItem(string url)
        {
            this.url = url;
        }

        public WWWItem(string url, WWWForm form)
        {
            this.url = url;
            this.wwwForm = form;
        }

        public WWWItem(string url, byte[] postData)
        {
            this.url = url;
            this.postData = postData;
        }

        #region Delegate

        public BeginDownLoad beginDownload;
        public DownLoadProgress downloadProgress;
        public DownLoadFinish downloadFinish;
        public DownLoadError downloadError;

        #endregion


        public IEnumerator Download()
        {
            Debug.Log("请求的URL :" + url);
            if (beginDownload != null)
                beginDownload();

            WWW www = null;

            if (wwwForm != null)
            {
                Debug.Log("WWWForm Post Request");
                www = new WWW(url, wwwForm);
            }
            else if (postData != null)
            {
                Debug.Log("Post Request");
                www = new WWW(url, postData);
            }
            else
            {
                Debug.Log("Get Request");
                www = new WWW(url);
            }

            while (!www.isDone)
            {
                if (downloadProgress != null)
                    downloadProgress(www.progress);
            }

            yield return www;

            if (string.IsNullOrEmpty(www.error))
            {
                if (downloadFinish != null)
                    downloadFinish(www);
            }
            else
            {
                if (downloadError != null)
                    downloadError(www.error);
            }
        }

    }
}
