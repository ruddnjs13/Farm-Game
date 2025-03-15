using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

namespace Code.Entities
{
    public class EntityMover : MonoBehaviour, IEntityComponent
    {
        [SerializeField] private float moveSpeed = 5f;
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
            _rigidbody2D.linearVelocity = Movement*moveSpeed;
        }

        public void SetMovementX(float movementX)
        {
            Vector2 movement = new Vector2(movementX, 0);
            Movement = movement;
        }
        public void SetMovementY(float movementY)
        {
            Vector2 movement = new Vector2(0,movementY);
            Movement = movement;
        }

        public void StopImmediately()
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
        }
    }
}