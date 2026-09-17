using UnityEngine;
using Patterns;

namespace Patterns
{
    public abstract class Payload<TData> : IVisitor
    {
        public abstract TData Content {get;set;}

        public abstract void Visit<T>(T p_visitable) where T : Component, IVisitable;
    }

    public class MessagePayload : Payload<string>
    {
        public GameObject Source { get; set; }
        public override string Content { get; set; }

        private MessagePayload() { }

        public override void Visit<T>(T p_visitable)
        {
            Debug.Log($"{p_visitable.name} received message from {Source.name}: {Content}");
        }

        public class Builder
        {
            MessagePayload _payload = new MessagePayload();

            public Builder(GameObject source) => _payload.Source = source;

            public Builder WithContent(string content)
            {
                _payload.Content = content;
                return this;
            }

            public MessagePayload Build() => _payload;
        }
    }
}
