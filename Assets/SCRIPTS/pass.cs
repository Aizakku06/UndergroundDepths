using UnityEngine;

public class AdvanceRoundButton : MonoBehaviour
{
    public RoundSystem roundSystem;

    public void OnClick()
    {
        roundSystem.AdvanceRound(true);
    }
}
