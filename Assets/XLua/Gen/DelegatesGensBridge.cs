#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using System;


namespace XLua
{
    public partial class DelegateBridge_Wrap : DelegateBridge
    {
		public DelegateBridge_Wrap(int reference, LuaEnv luaenv) : base(reference, luaenv){}
		
		public void __Gen_Delegate_Imp0(string p0)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.L;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                
                PCall(L, 1, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp1(float p0, float p1)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.L;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushnumber(L, p0);
                LuaAPI.lua_pushnumber(L, p1);
                
                PCall(L, 2, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public void __Gen_Delegate_Imp2(int p0, int p1, int p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.L;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.xlua_pushinteger(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                LuaAPI.xlua_pushinteger(L, p2);
                
                PCall(L, 3, 0, errFunc);
                
                
                
                LuaAPI.lua_settop(L, errFunc - 1);
                
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public string __Gen_Delegate_Imp3(string p0, int p1, out int p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.L;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                
                LuaAPI.lua_pushstring(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                
                PCall(L, 2, 2, errFunc);
                
                p2 = LuaAPI.xlua_tointeger(L, errFunc + 2);
                
                string __gen_ret = LuaAPI.lua_tostring(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		public string __Gen_Delegate_Imp4(int p0, int p1, System.Func<int, int, int> p2)
		{
#if THREAD_SAFE || HOTFIX_ENABLE
            lock (luaEnv.luaEnvLock)
            {
#endif
                RealStatePtr L = luaEnv.L;
                int errFunc = LuaAPI.pcall_prepare(L, errorFuncRef, luaReference);
                ObjectTranslator translator = luaEnv.translator;
                LuaAPI.xlua_pushinteger(L, p0);
                LuaAPI.xlua_pushinteger(L, p1);
                translator.Push(L, p2);
                
                PCall(L, 3, 1, errFunc);
                
                
                string __gen_ret = LuaAPI.lua_tostring(L, errFunc + 1);
                LuaAPI.lua_settop(L, errFunc - 1);
                return  __gen_ret;
#if THREAD_SAFE || HOTFIX_ENABLE
            }
#endif
		}
        
		
		public override Delegate GetDelegateByType(Type type)
		{
		
		    if (type == typeof(Main.LuaPrint))
			{
			    return new Main.LuaPrint(__Gen_Delegate_Imp0);
			}
		
		    if (type == typeof(EmmyLua.LuaFunction.FunA))
			{
			    return new EmmyLua.LuaFunction.FunA(__Gen_Delegate_Imp1);
			}
		
		    if (type == typeof(EmmyLua.LuaFunction.FunB))
			{
			    return new EmmyLua.LuaFunction.FunB(__Gen_Delegate_Imp2);
			}
		
		    if (type == typeof(EmmyLua.LuaFunction.FunC))
			{
			    return new EmmyLua.LuaFunction.FunC(__Gen_Delegate_Imp3);
			}
		
		    if (type == typeof(EmmyLua.LuaFunction.FunF))
			{
			    return new EmmyLua.LuaFunction.FunF(__Gen_Delegate_Imp4);
			}
		
		    return null;
		}
	}
    
}