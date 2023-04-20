using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface INarrator
{
    void AddSubscriber(ISubscriber subscriber);
    void RemoveSubscriber(ISubscriber subscriber);
    void NarrateToSubscribers(ISubscriber subscriber);
}
