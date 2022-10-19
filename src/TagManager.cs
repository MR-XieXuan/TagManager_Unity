using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagManager
{
    public static List<string> tagsName = new List<string>();
    public static List<List<GameObject>> tags = new List<List<GameObject>>();

    // *************************************************增****************************************************** //

    /// <summary>
    /// 给物体添加标签 并且添加进 TagManager 的缓存中
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="tag"></param>
    public static void ObjAddTag(GameObject obj, string tag)
    {
        ConfManager(tag);
        ObjAddTagScript(obj);
        TagAddObj(tag, obj);
        obj.GetComponent<Tag>().AddTag(tag);
    }

    // *************************************************删****************************************************** //

    /// <summary>
    ///  删除物体的标签 并清除他在 TagManager 上的缓存
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="tag"></param>
    public static void ObjDelTag(GameObject obj, string tag)
    {
        if (ObjHasTagScript(obj))
        {
            if (obj.GetComponent<Tag>().IsTag(tag))
            {
                obj.GetComponent<Tag>().RemoveTag(tag);
                if (Inspect(tag, obj))
                {
                    TagDelObj(tag, obj);
                }
            }
        }
        else
        {
            return;
        }
    }

    // **************************************************查****************************************************** //

    /// <summary>
    /// 获取 在 TagManager 缓存中 所有的对象
    /// </summary>
    /// <param name="tag"> 标签名 </param>
    /// <returns> 对象列表 </returns>
    public static List<GameObject> GetTagObjsInManager(string tag)
    {
        int flag = tagsName.IndexOf(tag);
        if (flag != -1)
        {
            return tags[flag];
        }
        return null;
    }

    /// <summary>
    /// 查看物体是否有这个标签 此方法与 TagManager 缓存无关
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static bool ObjHasTag(GameObject obj, string tag)
    {
        if (ObjHasTagScript(obj))
        {
            return obj.GetComponent<Tag>().IsTag(tag);
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    ///  查看这个物体在 TagManager 缓存中是是否有这个标签
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static bool ObjHasTagInManager(GameObject obj, string tag)
    {
        if (HasTag(tag))
        {
            if (GetTagObjsInManager(tag).IndexOf(obj) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 从一个 物体的列表 找 拥有多个tag符合 的物体
    /// </summary>
    /// <param name="list"></param>
    /// <param name="tagS"></param>
    /// <returns></returns>
    public static List<GameObject> Find(List<GameObject> list, List<string> tagS)
    {
        List<GameObject> newList = new List<GameObject>(list);
        list.ForEach(i => newList.Add(i));
        foreach (GameObject obj in list)
        {
            foreach (string tag in tagS)
            {
                if (TagManager.ObjHasTag(obj, tag)) { }
                else
                {
                    newList.Remove(obj);
                }
            }
        }
        return newList; //GameObject.Find(tag).GetComponent<Tag>();
    }
    /// <summary>
    /// 从一个 物体的列表 找 拥有tag 的物体
    /// </summary>
    /// <param name="list"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static List<GameObject> Find(List<GameObject> list, string tag)
    {
        List<GameObject> newList = new List<GameObject>(list);
        list.ForEach(i => newList.Add(i));
        foreach (GameObject obj in list)
        {
            if (TagManager.ObjHasTag(obj, tag)) { }
            else
            {
                newList.Remove(obj);
            }
        }
        return newList; //GameObject.Find(tag).GetComponent<Tag>();
    }

    // *************************************************系统***************************************************** //
    /// <summary>
    ///  判断物体是否有Tag脚本
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private static bool ObjHasTagScript(GameObject obj)
    {
        if (obj.GetComponent<Tag>())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 给物体添加Tag脚本
    /// </summary>
    /// <param name="obj"></param>
    private static void ObjAddTagScript(GameObject obj)
    {
        if (!ObjHasTagScript(obj))
        {
            obj.AddComponent<Tag>();
        }
        else { }
    }

    /// <summary>
    /// 检查 TagManager 里面在tag标签下是否有这个obj物体
    /// </summary>
    /// <param name="tag">标签名</param>
    /// <param name="obj">物体</param>
    /// <returns> true or false </returns>
    public static bool Inspect(string tag, GameObject obj)
    {
        List<GameObject> list = GetTagObjsInManager(tag);
        if (list != null)
        {
            if (list.IndexOf(obj) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    ///  为 TagManager 新收入一个 Tag 的对象
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    private static bool TagAddObj(string tag, GameObject obj)
    {
        if (Inspect(tag, obj))
        {
            return false;
        }
        else
        {

            AddTag(tag);
            tags[tagsName.IndexOf(tag)].Add(obj);
            return true;

        }
    }
    /// <summary>
    /// 删除 TagManager tag 的 Obj 存档
    /// </summary>
    /// <param name="tag"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    private static bool TagDelObj(string tag, GameObject obj)
    {
        if (Inspect(tag, obj))
        {
            return false;
        }
        else
        {
            int flag1 = 0;
            for (flag1 = 0; flag1 < tagsName.Count; flag1++)
            {
                if (tagsName[flag1] == tag)
                {
                    break;
                }
                else { }
            }
            int flag2 = 0;
            for (flag2 = 0; flag2 < tags[flag1].Count; flag2++)
            {
                if (tags[flag1][flag2] == obj.GetComponent<Tag>())
                {
                    break;
                }
                else { }
            }
            tags[flag1].RemoveAt(flag2);
            return true;
        }
    }

    /// <summary>
    /// 查看 TagManager 是否存在这个标签
    /// </summary>
    /// <param name="tag"></param>
    /// <returns> true or false </returns>
    private static bool HasTag(string tag)
    {
        if (tagsName.IndexOf(tag) == -1)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 添加 标签 到TagManager
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    private static bool AddTag(string tag)
    {
        if (HasTag(tag))
        {
            return false;
        }
        else
        {
            tagsName.Add(tag);
            return true;
        }
    }
    /// <summary>
    /// 初始化一个 tag 也是 添加新tag的正确调用方法 
    /// </summary>
    /// <param name="tag"></param>
    /// <returns></returns>
    public static bool ConfManager(string tag)
    {
        AddTag(tag);
        int flag = tagsName.IndexOf(tag);
        if (flag != -1)
        {
            if (flag < tags.Count)
            {
                return true;
            }
            else
            {
                tags.Add(new List<GameObject>());
                return true;
            }
        }
        else
        {
            return false;
        }

    }


}
