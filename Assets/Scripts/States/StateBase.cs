using F3Lib.Patterns.State;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour, IState<StateChangeTrigger>
{
    public IStateMachine<StateChangeTrigger, IState<StateChangeTrigger>> StateMachine { get; set; }

    public abstract void Execute();
    public abstract void SetData(ITransitionalData data);
}
