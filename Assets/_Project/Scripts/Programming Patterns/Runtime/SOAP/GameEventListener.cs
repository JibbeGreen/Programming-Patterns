using UnityEngine;
using UnityEngine.Events;

namespace Patterns
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T data);
    }

    public class GameEventListener<T> : MonoBehaviour, IGameEventListener<T>
    {
        [SerializeField] GameEvent<T> gameEvent;
        [SerializeField] UnityEvent<T> response;

        void OnEnable() => gameEvent.RegisterListener(this);
        void OnDisable() => gameEvent.DeregisterListener(this);

        public void OnEventRaised(T data) => response.Invoke(data);
    }
}
