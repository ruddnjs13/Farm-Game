using Code.Animation;
using UnityEngine;

namespace Code.Entities.FSM
{
    public abstract class EntityState
    {
        protected Entity _entity;

        protected AnimParamSO _animParam;

        protected EntityRenderer _entityRenderer;

        protected bool _isTriggerCall;

        public EntityState(Entity entity, AnimParamSO animParam)
        {
            _entity = entity;
            _animParam = animParam;
            _entityRenderer = entity.GetCompo<EntityRenderer>() as EntityRenderer;
        }

        public virtual void Enter()
        {
            _entityRenderer.SetParam(_animParam,true);
            _isTriggerCall = false;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Exit()
        {
            _entityRenderer.SetParam(_animParam, false);
        }
        
        public void AnimationEndTrigger() => _isTriggerCall = true;
    }
}