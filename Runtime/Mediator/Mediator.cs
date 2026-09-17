using System;
using System.Collections.Generic;
using System.Linq;
using Patterns;
using UnityEngine;
using UnityUtils;

namespace Patterns
{
    public abstract class Mediator<T> : MonoBehaviour where T : Component, IVisitable
    {
        readonly List<T> entities = new();

        public void Register(T entity)
        {
            if (!entities.Contains(entity))
            {
                entities.Add(entity);
                OnRegistered(entity);
            }
        }

        protected virtual void OnRegistered(T entity)
        {
            // noop
        }

        public void Deregister(T entity)
        {
            if (entities.Contains(entity))
            {
                entities.Remove(entity);
                OnDeregistered(entity);
            }
        }

        protected virtual void OnDeregistered(T entity)
        {
            // noop
        }

        public void Message(T source, T target, IVisitor message)
        {
            entities.FirstOrDefault(entity => entity.Equals(target))?.Accept(message);
        }

        public void Broadcast(T source, IVisitor message, Func<T, bool> predicate = null)
        {
            entities.Where(target => source != target && SenderConditionMet(target, predicate) && MediatorConditionMet(target))
                    .ForEach(entity => entity.Accept(message));
        }

        bool SenderConditionMet(T target, Func<T, bool> predicate) => predicate == null || predicate(target);
        protected abstract bool MediatorConditionMet(T target);
    }
}
