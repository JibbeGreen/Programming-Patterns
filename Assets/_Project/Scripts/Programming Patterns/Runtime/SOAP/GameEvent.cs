using System.Collections. Generic;
using UnityEngine;
using UnityEngine. Events;

namespace Patterns
{
    public class GameEvent<T> : ScriptableObject 
    {
        readonly List<IGameEventListener<T>> listeners = new();

        public void Raise(T data) 
        {
            for (var i = listeners.Count - 1; i >= 0; i -- ) 
            {
                listeners[i]. OnEventRaised(data);
            }
        }

        public void RegisterListener(IGameEventListener<T> listener) => listeners.Add(listener);
        public void DeregisterListener(IGameEventListener<T> listener) => listeners.Remove(listener);
    }

    [CreateAssetMenu(menuName = "Events/Game Event")]
    public class GameEvent : GameEvent<Unit> 
    {
        public void Raise() => Raise(Unit.Default);
    }

    public struct Unit 
    {
        public static Unit Default => default;
    }
}