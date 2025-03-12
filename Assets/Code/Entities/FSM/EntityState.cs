using Code.Animation;
using UnityEngine;

namespace Code.Entities.FSM
{
    public abstract class EntityState
    {
        protected Entity _entity;
        
        protected AnimParamSO _animParam;
        
        protected EntityRenderer _entityRenderer;
        
        public EntityState(Entity entity, AnimParamSO animParam)
        {
            _entity = entity;
            _animParam = animParam;
            _entityRenderer = entity.GetCompo<EntityRenderer>() as EntityRenderer;
        }

        public virtual void EnterState()
        {
            
        }
        public virtual void ExitState()
    }
}