using System;
using Code.Animation;
using Code.Entities;
using Code.Entities.FSM;
using Settings.InputSetting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Code.Players
{
    public class Player : Entity
    {
        [field:SerializeField] public InputReaderSO PlayerInput{get;private set;}

        [SerializeField] private StateListSO _stateList;

        [field: SerializeField] public AnimParamSO MOVE_XParam; 
        [field: SerializeField] public AnimParamSO MOVE_YParam; 
        [field: SerializeField] public AnimParamSO DIRECTION_XParam; 
        [field: SerializeField] public AnimParamSO DIRECTION_YParam; 
        
        private EntityStateMachine _stateMachine;
        
        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new EntityStateMachine(this,_stateList);
        }

        private void Start()
        {
            _stateMachine.ChangeState("IDLE");
        }

        private void Update()
        {
            _stateMachine.UpdateStateMachine();
        }

        public void ChangeState(string stateName)
        {
            _stateMachine.ChangeState(stateName);
        }
    }
}