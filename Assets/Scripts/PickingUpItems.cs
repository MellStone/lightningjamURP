using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUpItems : MonoBehaviour
{
    [SerializeField, Range(0f, 3f)] private float maxDistance = 1.0f;
    [SerializeField, Range(0.5f, 2.5f)] private float radius = 0.3f;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Transform attachPoint;

    public KeyCode attackKey = KeyCode.E;

    bool isItemAttached = false;

    private void Start()
    {
        Bonfire bonfire = FindObjectOfType<Bonfire>();
        if (bonfire != null)
        {
            bonfire.OnObjectDestroyed += HandleObjectDestroyed;
        }
    }
    private void HandleObjectDestroyed(GameObject destroyedObject)
    {
        // Обработка события удаления объекта
        isItemAttached = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            if (!isItemAttached)
                AttachSelectableObject();
        }
    }
    void AttachSelectableObject()
    {
        Collider closestCollider = null;
        float closestDistance = float.MaxValue;

        // Sphere Cast Overlapping
        Collider[] hitColliders = Physics.OverlapSphere(
            attachPoint.position, // Используем позицию attachPoint вместо позиции игрока
            radius,
            layerMask,
            QueryTriggerInteraction.Collide
        );

        // Searching for Closest Object
        foreach (var hitCollider in hitColliders)
        {
            float distanceToCollider = Vector3.Distance(attachPoint.position, hitCollider.transform.position);

            if (distanceToCollider < closestDistance)
            {
                closestDistance = distanceToCollider;
                closestCollider = hitCollider;
            }
        }
        // Attaching to attachPoint
        if (closestCollider != null)
        {
            Rigidbody itemRigidbody = closestCollider.GetComponent<Rigidbody>();

            if (itemRigidbody != null)
            {   // Turn off RigidBoy
                itemRigidbody.useGravity = false;
                itemRigidbody.isKinematic = true;

                // Attaching to attachPoint
                closestCollider.transform.parent = attachPoint;

                closestCollider.transform.localPosition = Vector3.zero;
                closestCollider.transform.localRotation = Quaternion.identity;

                isItemAttached = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Area to Attach item
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attachPoint.position, radius);
    }
}
