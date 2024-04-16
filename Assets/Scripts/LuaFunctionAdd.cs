using XLua;

namespace EmmyLua
{
    public class LuaFunctionAdd
    {
        [LuaCallCSharp]
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}