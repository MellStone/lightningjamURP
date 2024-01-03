using UnityEngine;

public class PickingUpItems : MonoBehaviour
{
    [SerializeField, Range(0.5f, 2.5f)] private float radius = 0.3f;
    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Transform attachPoint;

    public KeyCode attackKey = KeyCode.E;

    private Collider attachedObject = null;
    bool isItemAttached = false;

    private void Start()
    {
        Campfire bonfire = FindObjectOfType<Campfire>();
        if (bonfire != null)
        {
            bonfire.OnObjectDestroyed += HandleObjectDestroyed;
        }
    }
    private void HandleObjectDestroyed(GameObject destroyedObject)
    {
        isItemAttached = false; // Event if attached item is destroyed
    }
    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            if (!isItemAttached)
                AttachSelectableObject();
            else
                DetachObject();

        }
    }
    private void AttachSelectableObject()
    {
        Collider closestCollider = null;
        float closestDistance = float.MaxValue;

        // Sphere Cast Overlapping
        Collider[] hitColliders = Physics.OverlapSphere(
            attachPoint.position,
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
        // Attaching to Attach Point in Player
        if (closestCollider != null)
        {
            Rigidbody itemRigidbody = closestCollider.GetComponent<Rigidbody>();

            if (itemRigidbody != null)
            {   // Turn off RigidBoy
                closestCollider.isTrigger = true;
                itemRigidbody.useGravity = false;
                itemRigidbody.isKinematic = true;

                // Attaching to attachPoint
                closestCollider.transform.parent = attachPoint;

                closestCollider.transform.localPosition = Vector3.zero;
                closestCollider.transform.localRotation = Quaternion.identity;

                // For Campfire class, collecting info about where attached items has been picked
                attachedObject = closestCollider;
                attachedObject.GetComponent<SpawnerID>().isPickedFromSpawner = true;
                isItemAttached = true;
            }
        }
    }

    private void DetachObject()
    {
        // Turn on Physic
        attachedObject.isTrigger = false;
        Rigidbody itemRigidbody = attachedObject.GetComponent<Rigidbody>();
        itemRigidbody.useGravity = true;
        itemRigidbody.isKinematic = false;
        

        attachedObject.transform.parent = null;

        attachedObject = null;
        isItemAttached = false;
    }
    private void OnDrawGizmos()
    {
        // Area to Attach item
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attachPoint.position, radius);
    }
}
