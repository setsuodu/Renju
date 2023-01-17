using UnityEngine;

//[LuaCallCSharp] //不加也可以调用
public class TestLuaCallCS : MonoBehaviour
{
    public int index;

    public int Add(int a, int b)
    {
        return a + b;
    }
}