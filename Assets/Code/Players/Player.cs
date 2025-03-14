using System;
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