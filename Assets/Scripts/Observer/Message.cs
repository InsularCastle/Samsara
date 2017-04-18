using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Message
{
    Dictionary<string, object> table = new Dictionary<string, object>();

    public void SetMessage(string key, object o)
    {
        table.Add(key, o);
    }

    public object GetMsgByKey(string key)
    {
        return table[key];
    }
}
