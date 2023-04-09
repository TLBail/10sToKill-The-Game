using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventLapinTueur : GameEvent
{

    public GameEventLapinTueur() {
        eventName = "lapin tueur";
    }


    public override void init(EventManager eventManager) {
        SubEvents = new List<SubEvent>()
        {
            new SubEvent()
            {
                Position = new Vector3(0, 0, -470f),
                Action = () =>
                {
                    eventManager.stopRecord();
                    eventManager.fin();
                }
            },
        };
    }
}
