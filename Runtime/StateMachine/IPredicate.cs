using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Patterns {
    public interface IPredicate {
        bool Evaluate();
    }

    [System.Serializable]
    public class And : IPredicate {
        [SerializeReference] List<IPredicate> rules = new List<IPredicate>();
        public And() { }
        public And(params IPredicate[] rules) => this.rules = new List<IPredicate>(rules);
        public bool Evaluate() => rules.All(r => r != null && r.Evaluate());
    }

    [System.Serializable]
    public class Or : IPredicate {
        [SerializeReference] List<IPredicate> rules = new List<IPredicate>();
        public Or() { }
        public Or(params IPredicate[] rules) => this.rules = new List<IPredicate>(rules);
        public bool Evaluate() => rules.Any(r => r != null && r.Evaluate());
    }

    [System.Serializable]
    public class Not : IPredicate {
        [SerializeReference] IPredicate rule;
        public Not() { }
        public Not(IPredicate rule) => this.rule = rule;
        public bool Evaluate() => rule != null && !rule.Evaluate();
    }
}