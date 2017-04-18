using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbstractObserver : MonoBehaviour
{
    List<IObserber> servers = new List<IObserber>();

    protected void JoinObserver(IObserber ob)
    {
        servers.Add(ob);
    }

    protected void QuitObserver(IObserber ob)
    {
        servers.Remove(ob);
    }

    protected void Notify(object obj)
    {
        foreach (IObserber o in servers)
        {
            o.ReceiveMessage(obj);
        }
    }
}
