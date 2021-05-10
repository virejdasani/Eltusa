using UnityEngine;

public class ShortcutHandler : MonoBehaviour
{
    [SerializeField]
    KeyCode restartKey;

    // This is for the spawn coords of the player
    public Transform PlayerSpawnTransform;


    // Update is called once per frame
    void FixedUpdate()
    {
        // If the 'r' or restart key is pressed, the active level will restart
        if (Input.GetKey(restartKey))
        {
            // This resets the players location back to spawn. This means, a 'spawn' empty GameObject has to be added to each level where the player can reset
            transform.position = PlayerSpawnTransform.position;
            transform.rotation = PlayerSpawnTransform.rotation;
        }



        //This restarts the whole scene. This means the soundtrack restarts. Hence, this is not used
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
