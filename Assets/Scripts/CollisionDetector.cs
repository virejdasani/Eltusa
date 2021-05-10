//using System.Collections;
using UnityEngine;
//using UnityEngine.SceneManagement;


public class CollisionDetector : MonoBehaviour
{

    [SerializeField]
    string groundTag;

    [SerializeField]
    float killWhenYLesserThan;

    // This is for the spawn coords of the player
    public Transform PlayerSpawnTransform;

    // OnCollision method
    private void OnCollisionEnter(Collision collision)
    {
        // This will log all collisions with the ground
        // Debug.Log(collision.gameObject.name);

        // If the player hits the ground, player position is reset
        if (collision.collider.tag == groundTag)
        {
            // This resets the players location back to spawn. This means, a 'spawn' empty GameObject has to be added to each level where the player can reset
            transform.position = PlayerSpawnTransform.position;
            transform.rotation = PlayerSpawnTransform.rotation;
        }

    }

    void FixedUpdate()
    {
        // If the player goes below y=10, this means they feel of from the platforms. This is only here because the collision detection above sometimes takes time to work
        if (gameObject.transform.position.y < killWhenYLesserThan)
        {
            transform.position = PlayerSpawnTransform.position;
            transform.rotation = PlayerSpawnTransform.rotation;
        }
    }
}
