//using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionDetector : MonoBehaviour
{

    [SerializeField]
    string groundTag;

    [SerializeField]
    string portalButtonTag;

    // To get the y axis value under which the player should be killed
    [SerializeField]
    float killWhenYLesserThan;

    // To ask the user to enter the next scene name so when player collides with portal button, they go to that scene
    [SerializeField]
    string nextLevelSceneName;


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

        // If collide with portal button, go to next level
        if (collision.collider.tag == portalButtonTag)
        {
            SceneManager.LoadScene(nextLevelSceneName);
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
