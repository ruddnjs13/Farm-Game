using Code.Animation;
using Code.Entities;
using Code.Entities.FSM;
using UnityEngine;

namespace Code.Players.States
{
    public class PlayerMoveState : EntityState
    {
        private Player _player;
        private EntityMover _mover;
        public PlayerMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = _player.GetCompo<EntityMover>() as EntityMover;
        }

        public override void Update()
        {
            base.Update();
            Vector3 inputDirection = _player.PlayerInput.InputDirection;
            _mover.SetMovement(inputDirection);
            
            if (inputDirection.magnitude < 0.1f)
                _player.ChangeState("IDLE");
        }
    }
}