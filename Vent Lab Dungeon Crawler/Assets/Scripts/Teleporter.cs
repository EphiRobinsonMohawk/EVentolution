using UnityEngine;

public class Teleporter : MonoBehaviour, EventInterface
{
    public Transform destination;
    private float portalTimer = 0;
    private bool timeToPort = false;
    public float teleportDuration = 1f;
    public float playerSpacing = 1.5f;
    private PlayerController playerr;

    public void OnInteract(PlayerController playah)
    {
        playerr = playah;
        timeToPort = true;
    }

    private void Update()
    {
        if (timeToPort) portalTimer += Time.deltaTime;
        if (portalTimer >= teleportDuration)
        {
                        playerr.gameObject.transform.position = new Vector3
                            (
                            destination.position.x, destination.position.y, destination.position.z
                            );
            timeToPort = false;
            portalTimer = 0;
        }

    }
    
}
