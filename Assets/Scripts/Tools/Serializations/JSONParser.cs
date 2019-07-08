using System;
using System.IO;
using UnityEngine;

public class JSONParser 
{
    private string jsonPath;
    public JSONParser(string fileName)
    {
        jsonPath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (!File.Exists(jsonPath))
        {
            throw new FileNotFoundException("JSONParser can not locate a json file in : " + jsonPath + ". Aborting...");
            //Debug.LogError("JSONParser can not locate a json file in : "+ jsonPath + ". Aborting...");
        }
    }

    public T[] Unmarshall<T>()
    {
        T[] ret = null;
        if (File.Exists(jsonPath))
        {
            string dataAsJson = File.ReadAllText(jsonPath);
            ret = GetJsonArray<T>(dataAsJson);
        }

        Debug.Log("Unmarshall finished for type "+ typeof(T) + " with "+(ret == null ? "NULL" : ret.Length.ToString())+" entries found.");
        return ret;
    }

    private T[] GetJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] array = null;
    }
}
