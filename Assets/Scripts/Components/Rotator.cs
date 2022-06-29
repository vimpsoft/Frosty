using UnityEngine;

namespace Components
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 5;
        
        private void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
        }
    }
}
