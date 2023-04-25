using UnityEngine;

namespace Generic
{
    public class WorldObject : MonoBehaviour
    {
        [field: SerializeField] 
        public ushort Id { get; private set; }
    }
}