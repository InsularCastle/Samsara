using UnityEngine;
using System.Collections;

public interface IObserber
{
    void ReceiveMessage(object message);
}
