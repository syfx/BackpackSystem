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
    public class PackManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PackManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 5, 5);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "StoreItem", _m_StoreItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveItem", _m_RemoveItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadItemData", _m_LoadItemData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateLuaScript", _m_UpdateLuaScript);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadLuaScript", _m_LoadLuaScript);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "tooltip", _g_get_tooltip);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DragItem", _g_get_DragItem);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ThePack", _g_get_ThePack);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "AddItem", _g_get_AddItem);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "luaScriptFile", _g_get_luaScriptFile);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "tooltip", _s_set_tooltip);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DragItem", _s_set_DragItem);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ThePack", _s_set_ThePack);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "AddItem", _s_set_AddItem);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "luaScriptFile", _s_set_luaScriptFile);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 1, 0);
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PackManager gen_ret = new PackManager();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PackManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StoreItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _ItemID = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.StoreItem( _ItemID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveItem(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _ItemID = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.RemoveItem( _ItemID );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadItemData(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.LoadItemData(  );
                    
                    
                    
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
            
            
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _g_get_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PackManager.Instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tooltip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tooltip);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DragItem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.DragItem);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ThePack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ThePack);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_AddItem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.AddItem);
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
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.luaScriptFile);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tooltip(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tooltip = (Tooltip)translator.GetObject(L, 2, typeof(Tooltip));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DragItem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DragItem = (DragUI)translator.GetObject(L, 2, typeof(DragUI));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ThePack(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ThePack = (PackPanel)translator.GetObject(L, 2, typeof(PackPanel));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_AddItem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.AddItem = (UnityEngine.UI.Button)translator.GetObject(L, 2, typeof(UnityEngine.UI.Button));
            
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
			
                PackManager gen_to_be_invoked = (PackManager)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.luaScriptFile = (UnityEngine.TextAsset)translator.GetObject(L, 2, typeof(UnityEngine.TextAsset));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
