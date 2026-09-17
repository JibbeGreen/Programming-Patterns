using UnityEngine;

namespace Patterns
{
    public interface IVisitor
    {
        void Visit<T>(T p_visitable) where T : Component, IVisitable;
    }

    public interface IVisitable
    {
        void Accept(IVisitor p_visitor);
    }
}
