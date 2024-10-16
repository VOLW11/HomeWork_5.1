using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float _upwardsModifier;

    private int _rightMouseButton = 1;

    void Update()
    {
        if (Input.GetMouseButtonDown(_rightMouseButton) == false)
            return;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo))
        {
            Instantiate(_explosion, hitInfo.point, Quaternion.identity, null);

            Collider[] colliders = Physics.OverlapSphere(hitInfo.point, _radius);

            foreach (Collider collider in colliders)
            {
                Rigidbody rigidbody = collider.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_force, hitInfo.point, _radius, _upwardsModifier, ForceMode.Impulse);
                }
            }
        }
    }
}
