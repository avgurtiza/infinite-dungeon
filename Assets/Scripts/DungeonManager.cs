using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DungeonManager : MonoBehaviour
{
    // [SerializeField]
    // public string Treasure;

    private bool treasureVisible = false;

    private GameObject TreasureObject;

    private GameObject Maze;

    private GameObject Elf;

    private ElfMovement ElfMovement;

    private ElfInventory ElfInventory;

    void Start()
    {
        TreasureObject = GameObject.FindWithTag("Treasure");

        Maze = GameObject.FindWithTag("MazeWall");

        Elf = GameObject.Find("ElfPC");

        ElfMovement = Elf.GetComponent<ElfMovement>();
		
		Elf.transform.position = ElfMovement.getDungeonEntryPosition();

        ElfInventory = Elf.GetComponent<ElfInventory>();

        if(TreasureObject is GameObject) {
            Debug.Log("Treasure: " + TreasureObject.name);
            TreasureObject.GetComponent<Renderer>().enabled = !ElfInventory.hasItem(TreasureObject.name);

            if(Maze is GameObject) {
                Maze.SetActive(ElfInventory.hasItem(TreasureObject.name));
            }

            // TreasureObject.SetActive(!ElfInventory.hasItem(Treasure));
        }
    }

    public bool TreasureIsVisible() {
        return treasureVisible;
    }

    private void ShowTreasure() {
        treasureVisible = true;
    }

    private void HideTreasure() {
        treasureVisible = false;
    }

    private void ToggleTreasure() {
        treasureVisible = !treasureVisible;
    }
}
