using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//データを保存するためのプログラム
public static class PlayerPrefsWrapper
{
    private static Dictionary<string, string> mockStorage = new Dictionary<string, string>();

    public static bool HasKey(string key)
    {
        return mockStorage.ContainsKey(key);
    }

    public static string GetString(string key)
    {
        return mockStorage.ContainsKey(key) ? mockStorage[key] : null;
    }

    public static void SetString(string key, string value)
    {
        if (mockStorage.ContainsKey(key))
            mockStorage[key] = value;
        else
            mockStorage.Add(key, value);
    }
}
