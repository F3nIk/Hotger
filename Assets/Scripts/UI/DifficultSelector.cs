using F3Lib.Patterns.State;

using UnityEngine;

public class DifficultSelector : MonoBehaviour, ITransitionalData
{
    public LevelDifficult Selected { get; private set; }

    public void ChangeSelectedDifficult(LevelDifficult difficult) => Selected = difficult;
}
