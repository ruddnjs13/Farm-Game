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
        private EntityRenderer _renderer;

        private AnimParamSO _MOVE_XParam;
        private AnimParamSO _MOVE_YParam;
        private AnimParamSO _DIRECTION_XParam;
        private AnimParamSO _DIRECTION_YParam;
        public PlayerMoveState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = _player.GetCompo<EntityMover>() as EntityMover;
            _renderer = _player.GetCompo<EntityRenderer>() as EntityRenderer;

            _MOVE_XParam = _player.MOVE_XParam;
            _MOVE_YParam = _player.MOVE_YParam;
            _DIRECTION_XParam = _player.DIRECTION_XParam;
            _DIRECTION_YParam = _player.DIRECTION_YParam;
        }

        public override void Enter()
        {
            base.Enter();
            _renderer.SetParam(_DIRECTION_XParam,_player.PlayerInput.InputDirection.x);
            _renderer.SetParam(_DIRECTION_YParam,_player.PlayerInput.InputDirection.y);
        }

        public override void Update()
        {
            base.Update();
            Vector3 inputDirection = _player.PlayerInput.InputDirection;

            if (Mathf.Abs(inputDirection.y) <= 0)
            {
                _mover.SetMovementX(inputDirection.x);
                _renderer.SetParam(_MOVE_YParam,0f);

                _renderer.SetParam(_MOVE_XParam,inputDirection.x);
            }
            else if (Mathf.Abs(inputDirection.x) <= 0)
            {
                _mover.SetMovementY(inputDirection.y);
                _renderer.SetParam(_MOVE_XParam,0f);
                _renderer.SetParam(_MOVE_YParam,inputDirection.y);
            }
            if (inputDirection.magnitude < 0.1f)
                _player.ChangeState("IDLE");
        }
    }
}