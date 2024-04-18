using System;
using UnityEngine;
using XLua;

namespace EmmyLua
{
    public class LuaBehaviour : MonoBehaviour
    {
        protected LuaTable luaScriptsEnv;
        [SerializeField]
        private TextAsset luaScript;
        
        private void Awake()
        {

            luaScriptsEnv =  Main.luaEnv.NewTable();
            LuaTable meta = Main.luaEnv.NewTable();
            meta.Set("__index", Main.luaEnv.Global);
            luaScriptsEnv.SetMetaTable(meta);
            meta.Dispose();
            luaScriptsEnv.Set("self",this);
            Main.luaEnv.DoString(luaScript.text,luaScript.name,luaScriptsEnv);
        }

        private void OnDestroy()
        {
            
            luaScriptsEnv.Dispose();
            luaScriptsEnv = null;
        }
    }
}