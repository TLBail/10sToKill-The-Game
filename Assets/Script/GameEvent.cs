using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class GameEvent
{
    
    
    public string eventName;
    public string positionImpactName;
    public List<SubEvent> SubEvents;

    public virtual void init(EventManager eventManager) {
        
    }

    public virtual void triggerEvent(EventManager eventManager) {
        
    }
}

public class SubEvent
{
    public Vector3 Position;
    public Action Action;
}
