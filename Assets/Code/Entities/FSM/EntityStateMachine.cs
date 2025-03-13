using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Entities.FSM
{
    public class EntityStateMachine
    {
        public EntityState CurrentState { get; private set; }

        private Dictionary<string, EntityState> _states;

        public EntityStateMachine(Entity entity, StateListSO stateList)
        {
            _states = new Dictionary<string, EntityState>();

            foreach (StateSO state in stateList.states)
            {
                Type type = Type.GetType(state.stateName);
                Debug.Assert(type != null,$"Finding type is null : {state.className}");
                EntityState entityState = Activator.CreateInstance(type) as EntityState;
                _states.Add(state.stateName, entityState);
            }
        }

        public void ChangeState(EntityState newState)
        {
            CurrentState?.Exit();
            
        }
    }
}