using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private int _leftMouseButton = 0;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Debug.DrawRay(_camera.ScreenToWorldPoint(Input.mousePosition), _camera.transform.forward * 100, Color.red);

        if (Input.GetMouseButton(_leftMouseButton) == false)
            return;

        Ray cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        Vector3 worldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hitInfo))
        {
            Rigidbody _rigidbody = hitInfo.collider.GetComponent<Rigidbody>();

            if (_rigidbody != null)
            {
                Debug.DrawRay(cameraRay.origin, cameraRay.direction * 100, Color.green);
                _rigidbody.transform.position = new Vector3(worldPosition.x, _rigidbody.transform.position.y, worldPosition.z);
            }
        }
    }
}
