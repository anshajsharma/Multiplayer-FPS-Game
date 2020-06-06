using UnityEngine;
using UnityEngine.Networking;

//-------------------------------------
// Responsible for setting up the player.
// This includes adding/removing him correctly on the network.
//-------------------------------------

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsTodisable;

    Camera sceneCamera ;
    // Disable components that should only be
	// active on the player that we control
    void Start()
    {
        sceneCamera = Camera.main;

        if(!isLocalPlayer)
        {
            for( int i=0;i<componentsTodisable.Length;i++)
            {
                componentsTodisable[i].enabled = false;
            }
        }else{
            // We are the local player: Disable the scene camera
            if(sceneCamera != null)
            {
               sceneCamera.gameObject.SetActive(false);
            }
        }
    } 
    // When we are destroyed
    void OnDisable()
    {
        // Re-enable the scene camera
        if(sceneCamera != null)
        {
            sceneCamera.gameObject.SetActive(true);
        }
    }

}
