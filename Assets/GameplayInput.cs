using Fusion;
using UnityEngine;

public struct GameplayInput : INetworkInput
{
    public Vector2 LookDelta; // mouse delta acumulado desde el último tick
    public Vector2 MoveDirection;
    public NetworkButtons Buttons; // fire, jump, etc. (a futuro)
}