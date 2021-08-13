using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptacleEntity : MonoBehaviour
{
	[SerializeField]
	public string DestinyArtifact;

	private void OnCollisionEnter2D (Collision2D collision)
    {
        Collider2D collider = collision.collider;
        Debug.Log("Collided with receptacle");

        ElfInventory ElfInventory = collider.GetComponent<ElfInventory>();
        
        GameObject TreasureObject = GameObject.FindWithTag("Treasure");

        GameObject Maze = GameObject.FindWithTag("MazeWall");

        if(TreasureObject is GameObject) {
	        Debug.Log("Receptacle collided with " + TreasureObject.name);
	        ElfInventory.removeFromBackpack(DestinyArtifact);
			TreasureObject.GetComponent<Renderer>().enabled = !ElfInventory.hasItem(TreasureObject.name);

            if(Maze is GameObject) {
                Maze.SetActive(ElfInventory.hasItem(TreasureObject.name));
            }
        }
    }
}

