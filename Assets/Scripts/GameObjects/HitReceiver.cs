using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Component which provides an interface for receiving hits.
/// </summary>
public abstract class HitReceiver : MonoBehaviour
{
    /// <summary>
    /// Receive a hit.
    /// </summary>
    /// <param name="args">
    /// Variable-length list of parameters to be utilized by subclass implementation.
    /// </param>
    public abstract void ReceiveHit(params object[] args);
}

