using System;
using UnityEngine;

namespace Code.Animation
{
    [CreateAssetMenu(fileName = "AnimParam", menuName = "SO/AnimParam", order = 0)]
    public class AnimParamSO : ScriptableObject
    {
        public string animName;
        public int hashValue;

        private void OnValidate()
        {
            hashValue = Animator.StringToHash(animName);
        }
    }
    
    
}