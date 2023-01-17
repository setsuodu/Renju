using UnityEngine;

// 注意，这里添加的LuaCallCSharp特性只是为了使xLua为其生成代码，不添加并不影响功能
[XLua.LuaCallCSharp] //不加也可以调用？
[XLua.Hotfix]
public class TestLuaCallCS : MonoBehaviour
{
    public int index;

    public int Add(int a, int b)
    {
        return a + b;
    }
}