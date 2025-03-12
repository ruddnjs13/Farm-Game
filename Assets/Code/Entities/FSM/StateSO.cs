using Code.Animation;
using UnityEngine;

namespace Code.Entities.FSM
{
    [CreateAssetMenu(fileName = "StateSO", menuName = "SO/FSM/State")]
    public class StateSO : ScriptableObject
    {
        public string stateName;
        public string className;
        public AnimParamSO animParam;
        
    }
}