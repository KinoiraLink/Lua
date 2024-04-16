using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Main : MonoBehaviour
{
    [SerializeField]
    //private TextAsset luaScript;
    public static LuaEnv luaEnv = new LuaEnv();//全局唯一
    private LuaTable _luaScriptsEnv;//每个需要调用lua的CS脚本的lua脚本环境

    [CSharpCallLua]
    public delegate void LuaPrint(string s);
    
    [CSharpCallLua]
    public  Action  PrintVariables;


    private void Awake()
    {
        _luaScriptsEnv =  Main.luaEnv.NewTable();
        LuaTable meta = luaEnv.NewTable();
        meta.Set("__index", luaEnv.Global);
        _luaScriptsEnv.SetMetaTable(meta);
        meta.Dispose();
        _luaScriptsEnv.Set("self",this);

    }

    private void Start()
    {
        //luaEnv.DoString(luaScript.text);
        var luaprint = luaEnv.Global.GetInPath<LuaPrint>("print");
        luaprint("lua代码执行:");
        //luaEnv.DoString(luaScript.text,luaScript.name,_luaScriptsEnv);
        //_luaScriptsEnv.Get("printVariables", out PrintVariables);
        
        PrintVariables  = _luaScriptsEnv.Get<Action>("printVariables");
        PrintVariables?.Invoke();
    }

    private void OnDestroy()
    { 
        _luaScriptsEnv.Dispose();
    }
}
