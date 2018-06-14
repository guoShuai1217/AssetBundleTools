using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 04
/// 加载 Manifest文件(记录了 bundle 包的依赖关系和被依赖关系)
/// </summary>
public class ManifestLoader
{

    private static ManifestLoader instance;
    public static ManifestLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ManifestLoader();
            }
            return instance;
        }
    }

    /// <summary>
    /// Manifest 文件
    /// </summary>
    private AssetBundleManifest manifest;

    /// <summary>
    /// 路径
    /// </summary>
    private string manifestPath;

    /// <summary>
    /// Manifest 文件是否加载完成
    /// </summary>
    private bool isFinish;
    public bool IsFinish
    {
        get { return isFinish; }
    }

    /// <summary>
    /// 全局存在的 AssetBundle
    /// </summary>
    private AssetBundle assetBundle;

    //private string asset = "AssetBundleManifest";

        
    public ManifestLoader()
    {
        this.manifestPath = PathUtil.GetWWWPath() + "/" + PathUtil.GetPlatformName();
        this.manifest = null;
        this.assetBundle = null;
        this.isFinish = false;
    }
	 
    /// <summary>
    /// 开始加载 Manifest 文件
    /// </summary>
    /// <returns></returns>
    public IEnumerator Load()
    {
        WWW www = new WWW(manifestPath);
        yield return www;

        if (www.error != null)
        {
            Debug.LogError("加载 Manifest文件出错 : " + www.error);          
        }
        else
        {
            if (www.progress >=1)
            {
                
                this.assetBundle = www.assetBundle;
                this.manifest = assetBundle.LoadAsset("AssetBundleManifest") as AssetBundleManifest ;
                this.isFinish = true;
            }
        }
    }


    /// <summary>
    /// 获取一个 bundle 包的所有依赖关系[最重要]
    /// </summary>
    /// <param name="bundleName"></param>
    /// <returns></returns>
    public string[] GetDependence(string bundleName)
    {
        return manifest.GetAllDependencies(bundleName);
    }


    /// <summary>
    /// 卸载 manifest
    /// </summary>
    public void UnLoad()
    {
        assetBundle.Unload(true);
    }

}

 