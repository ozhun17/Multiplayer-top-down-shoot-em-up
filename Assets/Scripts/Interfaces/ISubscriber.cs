﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public interface ISubscriber
{
    void OnNotify();
}
