# BackpackSystem
使用MVC框架实现的简单背包系统，使用Lua编写控制层脚本，通过xLua对Lua和C#进行相互访问。

# 总结一下使用xlua时的坑
1. 使用文件保存lua代码时，编码格式使用UTF-8编码；否则可能加载不出来文件内容。   
2. 修改完打了标签的c#代码后，记得重新生成下适配代码   
3. 建议使用":"来调用方法，而不是"."    
当我使用"."调用System.Text.StringBuilder中的方法时会报错，而使用":"时则没问题。
**原因：**
在lua中使用“:”访问的函数会自动向函数中传入一个名为self的变量，这个变量是隐含的，self同c++中的this一样，表示当前对象的指针；而通过“.”访问函数时没有传入self（可以显示的传入）。   
因此如果调用的函数中使用到了 this 指针，那用"."调用时就会报错（如果没有显示的传入self的话）   
4. 若在lua中调用的c#方法的形参为Vector2类型的话，就不能使用Vector3类型的变量作为形参。   
否则报错：invalid userdata for UnityEngine.Vector2   

# 关于泛型函数的调用方法
在xLua的github的FAQ中有提到，可以使用反射来条用泛型方法；   
eg：
``` lua
-- 通过反射获取泛型方法
local loadGeneric = xlua.get_generic_method(CS.UnityEngine.Resources, "Load");
local load = loadGeneric(CS.UnityEngine.Sprite)
--调用获取的泛型方法
local sprite = load("path/...")
```
