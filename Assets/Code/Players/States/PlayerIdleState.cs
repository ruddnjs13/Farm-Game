using Code.Animation;
using Code.Entities;
using Code.Entities.FSM;

namespace Code.Players.States
{
    public class PlayerIdleState : EntityState
    {
        private Player _player;
        private EntityMover _mover;
        public PlayerIdleState(Entity entity, AnimParamSO animParam) : base(entity, animParam)
        {
            _player = entity as Player;
            _mover = _player.GetCompo<EntityMover>() as EntityMover;
        }

        public override void Enter()
        {
            base.Enter();
            _mover.StopImmediately();
        }

        public override void Update()
        {
            base.Update();
            if (_player.PlayerInput.InputDirection.magnitude > 0.01f)
                _player.ChangeState("MOVE");
        }
    }
}