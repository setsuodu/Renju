using System.IO;
using UnityEngine;
using UnityEngine.UI;
using XLua;

[LuaCallCSharp]
public class GameManager : MonoBehaviour
{
    public static GameManager Get;
    LuaEnv luaenv = null;

    void Awake()
    {
        Get = this;
        luaenv = new LuaEnv();

        OnInit();
    }

    void Update()
    {
        luaenv?.Tick();
    }

    void OnDestroy()
    {
        //luaenv?.Dispose();
        //luaenv = null;
    }

    void SystemSettings()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void CheckUpdate() { }

    void OnInit()
    {
        luaenv.AddLoader(MyLoader); //加载搜索lua文件的路径
        luaenv.DoString("require 'main'"); //控制权交给Lua
    }

    private byte[] MyLoader(ref string filePath)
    {
        string s = ResManager.LoadTxt($"LuaCode/{filePath}");
        return System.Text.Encoding.UTF8.GetBytes(s); //转字节码
    }
}