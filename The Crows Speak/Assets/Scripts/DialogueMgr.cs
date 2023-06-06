using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* For dialogue, anything activated when the game runs in the hierarchy (dialogueholder) will autoplay on program start. Subsequent dialogue holders should be deactivated and activated manually through a call to their respective below functions.
 * 
 */

public class DialogueMgr : MonoBehaviour
{
    public static DialogueMgr inst;

    private void Awake()
    {
        inst = this;
    }

    [SerializeField] private GameObject tomatoCollectDialogue;

    public void ActivateTomatoDialogue()
    {
        tomatoCollectDialogue.SetActive(true);
    }
}
