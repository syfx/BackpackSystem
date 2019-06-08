#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PackSystemLuaCallCsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PackSystem.LuaCallCs);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 2, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Start", _m_Start);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateLuaScript", _m_UpdateLuaScript);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadLuaScript", _m_LoadLuaScript);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "injections", _g_get_injections);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "luaScriptFile", _g_get_luaScriptFile);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "injections", _s_set_injections);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "luaScriptFile", _s_set_luaScriptFile);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PackSystem.LuaCallCs gen_ret = new PackSystem.LuaCallCs();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PackSystem.LuaCallCs constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PackSystem.LuaCallCs gen_to_be_invoked = (PackSystem.LuaCallCs)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Start(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateLuaScript(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PackSystem.LuaCallCs gen_to_be_invoked = (PackSystem.LuaCallCs)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _resName = LuaAPI.lua_tostring(L, 2);
                    string _resPath = LuaAPI.lua_tostring(L, 3);
                    string _localPath = LuaAPI.lua_tostring(L, 4);
                    
                        System.Collections.IEnumerator gen_ret = gen_to_be_invoked.UpdateLuaScript( _resName, _resPath, _localPath );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadLuaScript(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PackSystem.LuaCallCs gen_to_be_invoked = (PackSystem.LuaCallCs)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _localPath = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.LoadLuaScript( _localPath );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_injections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackSystem.LuaCallCs gen_to_be_invoked = (PackSystem.LuaCallCs)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.injections);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_luaScriptFile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackSystem.LuaCallCs gen_to_be_invoked = (PackSystem.LuaCallCs)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.luaScriptFile);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_injections(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackSystem.LuaCallCs gen_to_be_invoked = (PackSystem.LuaCallCs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.injections = (PackSystem.LuaCallCs.Injection[])translator.GetObject(L, 2, typeof(PackSystem.LuaCallCs.Injection[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_luaScriptFile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackSystem.LuaCallCs gen_to_be_invoked = (PackSystem.LuaCallCs)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.luaScriptFile = (UnityEngine.TextAsset)translator.GetObject(L, 2, typeof(UnityEngine.TextAsset));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
