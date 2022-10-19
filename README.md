# TagManager_Unity
Tags module And Tag Manager library for Unity.
# 本文简介 
为了弥补Unity Tag只能添加一个标签的缺陷，特地写了一个组件Tag，和一个库TagManager用于控制与管理组件Tag。组件与库在同一个仓库内，仓库的下载地址会放在下面，可以自行下载并添加到项目中。就当作普通的脚本使用即可。

# 下载地址 
## TagManager_Unity
GitHub : [https://github.com/MR-XieXuan/TagManager_Unity](https://github.com/MR-XieXuan/TagManager_Unity)

# 使用方法
## 下载组件与库并安装
把``Tag.cs``与``TagManager.cs``放到项目文件夹下。
## 使用Tag 组件
### 直接使用
Tag是一个组件，可以直接拖到物体上挂载组件，使用方法与其他组建类似。直接将Tag.cs拖到物体上即可挂载。挂载后可以点击加号添加新的标签。
![组件图片](https://img-blog.csdnimg.cn/4976213d794f42c3ad07604f34988e90.png)
### C# 中调用Tag API
|API| 描述 |返回值|
|--|--|--|
| AddTag( string tag ) | 传入新的标签名``tag``添加新的标签 | bool 是否是新的标签 | 
| IsTag( string tag ) | 传入标签名``tag`` 查看是否有这个标签 | bool 是否有这个标签 |
| RemoveTag( string tag ) | 传入标签名 ``tag`` 去除这个物体的特定标签 | bool 是否有这个标签 |

**示例代码：**
```cs
/// <summary>
/// 当 粒子 碰到碰撞体后
/// </summary>
/// <param name="other"> 被碰物体 </param>
private void OnParticleCollision(GameObject other)
{
	// 当粒子碰撞到 Tag 为 Enemy 的物体打印该物体被攻击 
    if ( other.TryGetComponent<tag>(out var com) )
    {
    	if( com.IsTag("Enemy") ){
    		Debug.Log("** " + com.name + "被攻击！");
    	} else { }
    } else { }
}
```
### 建议搭配 TagManager Library使用
使用TagManager Library可以更方便的管理 Tag 组件。
## 使用 TagManager Library
### 在 C# 中使用
**``TagManager``** 是一个静态对象，不用挂载到任何一个物体上，只需要挂载在项目下即可。
使用 TagManager 的增方法，会将物体添加到TagManager的缓存中，以方便获取。
### C# 中调用 TagManager API
| API | 描述 | 返回值 |
|--|--|--|
| 增 | | |
| ObjAddTag(GameObject obj, string tag) | 给物体``obj``添加一个标签``tag`` 如果这个物体没有Tag组件，则会自动挂载Tag组件| void |
| 删 | | |
| ObjDelTag(GameObject obj, string tag) | 删除物体``obj``的标签``tag`` 如果这个物体没有Tag组件那么什么都不会发生 | void |
| 查 | | |
|  GetTagObjsInManager(string tag) | 获取在 TagManager 缓存中有这个标签``tag``所有的对象 | List&lt;GameObject&gt; |
| ObjHasTag(GameObject obj, string tag) | 查看这个物体``obj``是否有这个标签``tag``这个方法与TagManager缓存无关 | bool 是否有这个标签 |
| ObjHasTagInManager(GameObject obj, string tag) | 查看这个物体``obj``在TagManager缓存中是是否有这个标签,此方法仅与TagManager缓存有关，与物体本身的标签无关 | bool 在TagManager 缓存中是否有这个标签 |
| Find(List<GameObject> list, List<string> tagS) | 从一个 物体的列表``list``找 拥有多个标签``tagS``符合 的物体 | List<GameObject> 符合的物体列表 |
| Find(List<GameObject> list, string tag) | 从一个 物体的列表``list``找拥有特定标签``tag`` 的物体 | List<GameObject> 符合的物体列表 |

**示例代码**
```cs
/// <summary>
/// 当 粒子 碰到碰撞体后
/// </summary>
/// <param name="other"> 被碰物体 </param>
private void OnParticleCollision(GameObject other)
{
	// 当粒子碰撞到 Tag 为 Enemy 的物体打印该物体被攻击 
    if (TagManager.ObjHasTag(other, "Enemy"))
    {
        Debug.Log("** " + other.name + "被攻击！");
    }
}
```

# 联系作者
#  联系作者
本库还处于 Beta 阶段，如果有更新我会在本博客发布更新说明。如果使用上遇到了困难或者发现了Bug，欢迎联系作者提交你的发现。
<br/>
<center>
E-mail: <a href = "mailto:Mr_Xie_@outlook.com">[ Mr_Xie_@outlook.com ]</a>
<br>
GitHub: <a  href = "https://github.com/MR-XieXuan">[ https://github.com/MR-XieXuan }</a>
<br>
个人私站: <a href = "https://main.mrxie.xyz/">[ https://main.mrxie.xyz/ ]</a>
</center>
<br/>
&emsp;如果本文对您有帮助的话，可以给本文点一个赞👍或者是收藏本文📧。也可以点击关注Follow我。你的每一个赞可以给作者非常大的鼓励。
&emsp;如果遇到困难，欢迎联系作者，你可以私聊作者或者添加作者QQ、发送电子邮件向作者寻求帮助。也可以在下方评论区向大家提问。你的问题如果在评论区被解决也可以给其他遇到同样问题的一个参考。
作者不易，期待你的关注❤。





