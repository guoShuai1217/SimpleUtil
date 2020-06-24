/*
 *	Description: 
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
using LitJson;

public class JsonUtil 
{

    public static T FromJson<T>(string path) where T : class, new()
    {
        TextAsset ta = Resources.Load<TextAsset>(path);

        return JsonUtility.FromJson<T>(ta.text);

    }

    

}
