/*
 *	Description: 提供外部调用的功能类,只有一个AddTask方法暴露出来
 *
 *	CreatedBy: guoShuai
 *
 *	DataTime:  
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace guoShuai.WWWHelper
{

    public class WWWHelper : MonoBehaviour
    {
        public static WWWHelper Instance;

        private Queue<WWWItem> wwwQue;

        private bool isLoadFinish = true; // 是否加载完成

        private void Awake()
        {
            Instance = this;

            wwwQue = new Queue<WWWItem>();
        }


        /// <summary>
        /// 添加到请求队列
        /// </summary>
        /// <param name="item"></param>
        public void AddTask(WWWItem item)
        {
            wwwQue.Enqueue(item);

            if (wwwQue.Count == 1 && isLoadFinish)
            {
                isLoadFinish = false;
                StartCoroutine(DownLoadWWWItem());
            }
        }



        IEnumerator DownLoadWWWItem()
        {
            while (wwwQue.Count > 0)
            {
                WWWItem tmpItem = wwwQue.Dequeue();
                yield return tmpItem.Download();
            }

            isLoadFinish = true;
        }


    }

}
