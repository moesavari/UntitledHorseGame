using UnityEngine;

public class BaseEvent : MonoBehaviour
{
    public enum EventType
    {
        NONE,
        SHOW_JUMPING,
        DRESSAGE,
        CROSS_COUNTRY,
        ENDURANCE,
        POLO,
        RACING,
        REINING,
        RODEO,
        SHOWING,
        VAULTING
    }

    [SerializeField] private EventType _eventType = EventType.NONE;
}
