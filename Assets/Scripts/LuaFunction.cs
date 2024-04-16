using System;
using UnityEngine;
using XLua;

namespace EmmyLua
{
    [CSharpCallLua]
    public class LuaFunction : LuaBehaviour
    {
        [CSharpCallLua]
        public delegate void  FunA(float a, float b);
        [CSharpCallLua]
        public delegate void FunB(int a, int b, int c);

        [CSharpCallLua]
        public delegate string FunC(string a, int b, out int one);

        [CSharpCallLua]
        public Action FunD;
        private int _one;
        private string _oneString;
        
        
        [CSharpCallLua]
        public delegate string FunF(int a, int b, Func<int,int,int> callback);
        private void Start()
        {
            //普通函数 CSharpCallLua
            var funcA = luaScriptsEnv.Get<FunA>("fun_a");
            funcA?.Invoke(0.5f,0.2f);
            //可变 CSharpCallLua
            var funcB = luaScriptsEnv.Get<FunB>("fun_b");
            funcB?.Invoke(1,2,3);
            //多返回函数 CSharpCallLua
            var funcC =  luaScriptsEnv.Get<FunC>("fun_c");
            
            _oneString = funcC?.Invoke("hello", 5, out _one);
            
            Debug.Log(_oneString + _one);
            //Lua 调用 C# LuaCallCSharp
            FunD = luaScriptsEnv.Get<Action>("fun_d");
            FunD?.Invoke();
            //Lua 参数函数，参数是 C# 回调方法  
            //CSharpCallLua、LuaCallCSharp 的区别于此
            FunF funcF = luaScriptsEnv.Get<FunF> ("fun_f");

            funcF?.Invoke(1, 2, OnAdd);
        }

        [LuaCallCSharp]
        private int OnAdd(int a, int b)
        {
            return a + b;
        }
        
    }
}