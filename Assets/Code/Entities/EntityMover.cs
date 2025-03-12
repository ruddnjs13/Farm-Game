using System;
using UnityEngine;

namespace Code.Entities
{
    public class EntityMover : MonoBehaviour, IEntityComponent
    {
        private Entity _entity;
        
        private Rigidbody2D _rigidbody2D;

        public Vector3 Movement{get; private set;}
        
        public void Initialize(Entity entity)
        {
            _entity = entity;
            _rigidbody2D = _entity.GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocity = Movement;
        }

        public void SetMovement(Vector2 movement)
        {
             Movement = movement;
        }

        private void StopImmediately()
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
        }
    }
}