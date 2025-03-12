using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Entities
{
    public class Entity : MonoBehaviour
    {
        private Dictionary<Type, IEntityComponent> _components;

        private void Awake()
        {
            _components = new Dictionary<Type, IEntityComponent>();
            AddComponentToDictionary();
            ComponentInitialize();
            AfterInitialize();
        }


        private void AddComponentToDictionary()
        {
            GetComponentsInChildren<IEntityComponent>(true).ToList().ForEach(compo => _components.Add(compo.GetType(), compo));
        }

        private void ComponentInitialize()
        {
            _components.Values.ToList().ForEach(compo => compo.Initialize(this));
        }
        private void AfterInitialize()
        {
            _components.Values.OfType<IAfterInit>().ToList().ForEach(compo => compo.AfterInit());
        }

        public IEntityComponent GetCompo<T>() where T : IEntityComponent
        {
            _components.TryGetValue(typeof(T), out IEntityComponent component);

            if (component != null)
                return component;
            else
                return default(T);
        }
    }
}
