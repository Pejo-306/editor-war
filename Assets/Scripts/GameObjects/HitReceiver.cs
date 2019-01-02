using System.Collections.Generic;
using UnityEngine;

public class HitReceiver : MonoBehaviour
{
    public MonoBehaviour affectedComponent;
    public List<MethodStatics.MethodParameter> calledMethodParameters;
    private Dictionary<string, object> calledMethodParametersDictionary; 

    void Awake()
    {
        calledMethodParametersDictionary = new Dictionary<string, object>();
    }
    
    public void ReceiveHit()
    {
        MethodStatics.ParseMethodParametersToDictionary(calledMethodParameters, 
                calledMethodParametersDictionary);
        affectedComponent.BroadcastMessage("ComponentReceiveHit", 
                calledMethodParametersDictionary);
    }

    public void AddCalledMethodParameter(string name, object val)
    {
        calledMethodParameters.Add(new MethodStatics.MethodParameter(name, val));
    }
}

