using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  一个物体 的 标签
/// </summary>
public class Tag : MonoBehaviour
{
    public List<string> tags = new List<string>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// 添加一个标签
    /// </summary>
    /// <param name="tag">标签名</param>
    /// <returns> 返回是否新添加，如果已经有了的话就返回false </returns>
    public bool AddTag(string tag)
    {
        if (IsTag(tag))
        {
            return false;
        }
        else
        {
            tags.Add(tag);
            return true;
        }
    }
    /// <summary>
    /// 是否有某个标签
    /// </summary>
    /// <param name="tag">标签名</param>
    /// <returns> true or false </returns>
    public bool IsTag(string tag)
    {
        if (tags.IndexOf(tag) != -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// 移除标签
    /// </summary>
    /// <param name="tag">需要移除的标签</param>
    public bool RemoveTag(string tag)
    {
        int flag = tags.IndexOf(tag);
        if (flag != -1)
        {
            tags.Remove(tag);
            return true;
        }
        else
        {
            return false;
        }
    }


}
