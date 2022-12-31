

- [代码生成](https://github.com/Kylelolo/CStoLua.git)
```
cd xLua
mkdir Document
cd Document
git clone https://github.com/Kylelolo/CStoLua.git
```



资源重复引用问题：

1、增大AB包体积，

2、增加运行时内存，增加加载次数、时长，



解决策略：

1、老方法是 PushAssetDependencies、PopAssetDependencies，将公共依赖资源和Main资源分别打包。

2、老的API似乎失效了，现在直接用 ``BuildPipeline.BuildAssetBundles`` 。给公共资源打Label，该API会自动分析引用依赖的资源，将其剔除主包。API通过分析整个项目的Label，打包资源。



AB资源分类：

- Texture2D（png, tga, jpeg, bmp）
- Sprite（SpriteAtlas）
- AudioClip（mp3, ogg, wav）
- Font
- Mesh（prefab）
- TextAsset（bytes）
- Shader
- MovieTexture
- VideoClip
- MonoBehaviour（json）
- Animator
- AnimationClip（FBX）
- Material

