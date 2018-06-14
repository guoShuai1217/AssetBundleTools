﻿using UnityEngine;
using System.IO;
public class PathUtil
{
    /// <summary>
    /// 获取AssetBundle的输出目录
    /// </summary>
    /// <returns></returns>
    public static string GetAssetBundleOutPath()
    {
        string outPath = GetPlatformPath() + "/" + GetPlatformName();
        if (!Directory.Exists(outPath))
        {
            Directory.CreateDirectory(outPath); 
        }
        return outPath;
    }
    /// <summary>
    /// 自动获取对应平台的路径
    /// </summary>
    /// <returns></returns>
     private  static string GetPlatformPath()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                return Application.streamingAssetsPath;
            case RuntimePlatform.Android:
                return Application.persistentDataPath;
            default:
                return null;
                 
        }
    }
    /// <summary>
    /// 获取对应平台的名字
    /// </summary>
    /// <returns></returns>
   public  static string GetPlatformName()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                return "Windows";
            case RuntimePlatform.Android:
                return "Android";
            default:
                return null;

        }
    }
    /// <summary>
    /// 获取对应平台WWW协议路径
    /// </summary>
    /// <returns></returns>
   public static string GetWWWPath()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.WindowsEditor:
                return "file:///" + GetAssetBundleOutPath();
            case RuntimePlatform.Android:
                return "jar:file//" + GetAssetBundleOutPath();
            default:
                return null;

        }
    }
 
}
