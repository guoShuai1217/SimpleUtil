/*
 *		Description: 
 *		
 *		+
 *		1. 我把读取 Resources/Audio 文件夹下所有音频文件 写在里面了 , 这部分代码可以复用 ; 
 *		2. 实际项目使用的话 , 应该是走完1之后,把 音频名字|音频路径 存到字典configDic里 , 不要直接就去Resource里加载(用到的时候再去加载),
 *		加载的时候 : 1) : clipDic里有,就直接返回 ;
 *		            2) : clipDic没有 , 就去configDic里根据key找到value(value就是音频的路径) , 然后去Resource里加载,存到clipDic里
 *		+            
 *
 *		CreatedBy: guoShuai
 *
 *		DataTime: 2020.06.24
 *
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace  guoShuai.AudioHelper
{
    public class AudioClipMgr
    {

        // TextAsset audioTxt = Resources.Load<TextAsset>("AudioConfig.txt");

       
        private Dictionary<string, AudioClip> clipDic;

        public AudioClipMgr()
        {
            clipDic = new Dictionary<string, AudioClip>();

            createAudioConfig();

            readConfig();
        }

        // 读取音频配置文件
        // 配置文件第一行是 音频数量
        //        之后每一行是 音频名字|音频路径
        private void readConfig()
        {
            string clipPath = Application.streamingAssetsPath + "/ClipConfig.txt";
            if (!File.Exists(clipPath))
            {
                Debug.LogError("不存在 ClipConfig.txt 配置文件 " + clipPath);
                return;
            }

            string str = File.ReadAllText(clipPath); // 读取ClipConfig.txt 里 所有内容
            string[] contentArr = str.Split(new string[] { "\r\n"},StringSplitOptions.None);

            //string[] contentArr = File.ReadAllLines(clipPath); // 这一行 等价于 上面两行

            for (int i = 1; i < contentArr.Length; i++) // i从1开始, i=0 是数字
            {
                string oneLine = contentArr[i];
                if (string.IsNullOrEmpty(oneLine)) // 空行的情况
                    continue;

                string[] lineArr = oneLine.Split('|'); // 分割字符串,0是音频名字,1是音频路径
                AudioClip value = loadClip(lineArr[1]); // 根据名字去硬盘里加载 
                clipDic.Add(lineArr[0], value);
            }

        }

        // 从硬盘里加载AudioClip
        AudioClip loadClip(string path)
        {
            return Resources.Load<AudioClip>(path);
        }



        /// <summary>
        /// 获取AudioClip
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public AudioClip GetClip(string key)
        {
            if (!clipDic.ContainsKey(key))
            {
                Debug.LogWarning("字典里不包含该Clip : " + key);
                return null;
            }
            return clipDic[key];
        }


        #region 读取Resources/Audio下所有音频文件,写入到AudioConfig.txt里
   
        void  createAudioConfig()
        {
            // 约定 所有的Auido都放在这个文件夹下
            string rootPath = Application.dataPath + "/Resources/Audio";

            DirectoryInfo rootInfo = new DirectoryInfo(rootPath);

            // key: AudioClip的名字, value: AudioClip在Resources目录下的路径
            Dictionary<string, string> tmpDic = new Dictionary<string, string>();

            EachDirectory(rootInfo, tmpDic);

            foreach (var item in tmpDic)
            {
                Debug.Log(item.Key + "---" + item.Value);
            }

            writeConfig(tmpDic); //写到txt文本里
        }

        void EachDirectory(FileSystemInfo tmpInfo,Dictionary<string,string> dic)
        {

            DirectoryInfo dirInfo = tmpInfo as DirectoryInfo;

            FileSystemInfo[] fileSystemInfoArr = dirInfo.GetFileSystemInfos();
            for (int i = 0; i < fileSystemInfoArr.Length; i++)
            {
                if (fileSystemInfoArr[i].Extension == ".meta")
                    continue;

                FileInfo fileInfo = fileSystemInfoArr[i] as FileInfo;
                if(fileInfo == null)
                {
                    EachDirectory(fileSystemInfoArr[i], dic);
                }
                else
                {
                    string key = fileInfo.Name.Split('.')[0];
                    string value = SubString(fileInfo.FullName);
                    dic.Add(key, value);
                }
            }


        }

        string SubString(string fullPath)
        {
            fullPath = fullPath.Replace("\\", "/");
            int index = fullPath.IndexOf("Audio");
            string result = fullPath.Substring(index);
            return result.Split('.')[0]; // 不要后缀
        }

        void writeConfig(Dictionary<string,string> dic)
        {
            string configPath = Application.streamingAssetsPath + "/ClipConfig.txt";
            using (FileStream fs = new FileStream(configPath,FileMode.Create,FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(dic.Count);
                    foreach (var item in dic)
                    {
                        sw.WriteLine(item.Key + "|" + item.Value);
                    }
                }
            }
        }

        #endregion

    }
}
