/*
 *		Description: 给外部调用的类
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: #DATE#
 *
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace guoShuai.AudioHelper
{
    public class AudioMgr : MonoBehaviour
    {
        public static AudioMgr Instance;

        AudioSourceMgr sourceMgr;

        AudioClipMgr clipMgr;

        private void Awake()
        {
            Instance = this;

            sourceMgr = new AudioSourceMgr(gameObject);

            clipMgr = new AudioClipMgr();
        }

        #region 调用测试
      
        private void Start()
        {
            Play("bgm");
        }

        #endregion

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="clipName"></param>
        public void Play(string clipName)
        {
            // 拿到一个空闲的 AudioSource
            AudioSource source = sourceMgr.GetFreeSource();
            // 拿到 AudioClip
            AudioClip clip = clipMgr.GetClip(clipName);
            if(clip != null) 
            {
                // 播放
                source.clip = clip;
                source.Play();
            }
        }


        /// <summary>
        /// 停止播放
        /// </summary>
        /// <param name="clipName"></param>
        public void Stop(string clipName)
        {
            sourceMgr.Stop(clipName);
        }


    }
}
