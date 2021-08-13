using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorEntity : MonoBehaviour
{
	[SerializeField]
	public string ConversationIndex;

	[SerializeField]
	public string DestinationScene;

	public float EntryPositionX;
	public float EntryPositionY;

	private GameObject Elf;

	void OnTriggerEnter2D(Collider2D col)
    {
		if(DestinationScene != "") {
			ElfMovement ElfMovement = col.GetComponent<ElfMovement>() as ElfMovement;

			if(SceneManager.GetActiveScene().name == "Foyer") {
				ElfMovement.setLastFoyerPostion();
				ElfMovement.setDungeonEntryPosition(new Vector3(EntryPositionX, EntryPositionY, 0));
			}

	        SceneManager.LoadScene(DestinationScene, LoadSceneMode.Single);
    	}
    }
}