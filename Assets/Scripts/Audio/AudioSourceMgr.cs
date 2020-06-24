/*
 *		Description: AudioSource 管理类
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: #DATE#
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace guoShuai.AudioHelper
{
    public class AudioSourceMgr
    {

        private List<AudioSource> sourceList;

        private GameObject ower; // 用来挂载 AudioSource组件的物体

        public AudioSourceMgr(GameObject oo)
        {
            sourceList = new List<AudioSource>();

            this.ower = oo;
            for (int i = 0; i < 3; i++)
            {
                AudioSource tmpSource = oo.AddComponent<AudioSource>(); // oo上可以挂载3个AudioSource组件
                sourceList.Add(tmpSource);
            }
        }


        /// <summary>
        /// 获取空闲的AudioSource
        /// </summary>
        /// <returns></returns>
        public AudioSource GetFreeSource()
        {
            for (int i = 0; i < sourceList.Count; i++)
            {
                if (!sourceList[i].isPlaying)
                    return sourceList[i];
            }

            //Debug.LogWarning("没有空闲的AudioSource");
            //return null;

            // 如果source都在播放,那就再创建一个
            AudioSource tmpSource = ower.AddComponent<AudioSource>();  
            sourceList.Add(tmpSource);
            return tmpSource;
        }


        /// <summary>
        /// 释放多余的 AudioSource
        /// </summary>
        public void DisposeFreeSource()
        {
            int index = 0;
            List<AudioSource> tmpList = new List<AudioSource>();
            for (int i = 0; i < sourceList.Count; i++)
            {
                if (!sourceList[i].isPlaying)
                {
                    index++;

                    if (index > 3)
                        tmpList.Add(sourceList[i]);
                }
            }

            for (int i = 0; i < tmpList.Count; i++)
            {
                AudioSource tmpSource = tmpList[i];
                // 从集合中移除
                sourceList.Remove(tmpSource);
                // 从场景中删除
                GameObject.Destroy(tmpSource);
            }

            tmpList.Clear();
            tmpList = null;

        }


        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="clipName"></param>
        public void Stop(string clipName)
        {
            for (int i = 0; i < sourceList.Count; i++)
            {
                AudioSource source = sourceList[i];
                if(source.isPlaying && source.clip.name == clipName)
                {
                    source.Stop();
                }
            }
        }

    }
}
