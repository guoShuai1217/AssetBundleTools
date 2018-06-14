﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 07
/// 资源缓存层
/// </summary>
public class AssetCaching
{
    /// <summary>
    /// 已经加载过的资源名字 和资源的映射关系
    /// </summary>
    private Dictionary<string, TempObject> nameAssetDic;

    public AssetCaching()
    {
        nameAssetDic = new Dictionary<string, TempObject>();
    }
	 

    /// <summary>
    /// 添加缓存
    /// </summary>
    /// <param name="assetName"></param>
    /// <param name="asset"></param>
    public void AddAsset(string assetName , TempObject asset)
    {
        if (nameAssetDic.ContainsKey(assetName))
        {
            Debug.LogError("此" + assetName + "资源已经加载!");
            return;
        }

        // 缓存起来
        nameAssetDic.Add(assetName, asset);

    }

    /// <summary>
    /// 获取缓存资源
    /// </summary>
    /// <param name="assetName"></param>
    /// <returns></returns>
    public Object[] GetAsset(string assetName)
    {
        if (nameAssetDic.ContainsKey(assetName))
        {
            return nameAssetDic[assetName].AssetList.ToArray();
        }
        else
        {
            Debug.LogError("此" + assetName + "还没被加载!");
            return null;
        }
        
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    /// <param name="assetName"></param>
    public void UnLoadAsset(string assetName)
    {
        if (nameAssetDic.ContainsKey(assetName))
        {
            nameAssetDic[assetName].UnLoadAsset();
        }
        else
        {
            Debug.LogError("此" + assetName + "还没被加载!");           
        }
    }


    /// <summary>
    /// 卸所有的资源
    /// </summary>
    public void UnLoadAllAsset()
    {
        foreach (string item in nameAssetDic.Keys)
        {
            UnLoadAsset(item);
        }
        nameAssetDic.Clear();
    }


}
