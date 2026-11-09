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
            var entity = entities.FirstOrDefault(e => e.Equals(target));
            if (entity != null) entity.Accept(message); // Unity null check (skips destroyed entities)
        }

        public void Broadcast(T source, IVisitor message, Func<T, bool> predicate = null)
        {
            // Snapshot first: a visitor may cause Register/Deregister while we dispatch.
            var targets = entities
                .Where(target => target != null && source != target && SenderConditionMet(target, predicate) && MediatorConditionMet(target))
                .ToList();

            foreach (var entity in targets)
            {
                if (entity != null) entity.Accept(message);
            }
        }

        bool SenderConditionMet(T target, Func<T, bool> predicate) => predicate == null || predicate(target);
        protected abstract bool MediatorConditionMet(T target);
    }
}
