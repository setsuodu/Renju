using UnityEngine;
using UnityEngine.U2D;

public class Test : MonoBehaviour
{
    SpriteRenderer render;
    public Transform canvas;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        LoadPrefab();
    }

    void LoadSpriteAtlas()
    {
        string filePath = Application.streamingAssetsPath + "/atlas/sp_atlas_1.unity3d"; //ab包路径
        AssetBundle asset = AssetBundle.LoadFromFile(filePath); //从本地加载ab包
        Object[] assets = asset.LoadAllAssets();
        asset.Unload(false);

        SpriteAtlas sa = assets[0] as SpriteAtlas;
        //Debug.Log(sa.spriteCount); //45个
        render.sprite = sa.GetSprite("Red");
    }

    void LoadPrefab()
    {
        string filePath = Application.streamingAssetsPath + "/ui/ui_login.unity3d"; //ab包路径
        AssetBundle asset = AssetBundle.LoadFromFile(filePath); //从本地加载ab包
        Object[] assets = asset.LoadAllAssets();
        asset.Unload(false);

        GameObject go = assets[0] as GameObject;
        Instantiate(go, canvas);
        go.name = "UI_Login";
    }
}