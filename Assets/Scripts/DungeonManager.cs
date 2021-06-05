using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DungeonManager : MonoBehaviour
{
    void Start()
    {
        GameObject Elf = GameObject.Find("ElfPC");
        // Debug.Log(Elf.GetComponent<ElfMovement>().getDungeonEntryPosition());
		
		Elf.transform.position = Elf.GetComponent<ElfMovement>().getDungeonEntryPosition();
    }

}
