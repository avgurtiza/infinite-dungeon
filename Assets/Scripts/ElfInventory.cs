using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfInventory : MonoBehaviour
{
	private Backpack Backpack;

	void Awake() {
		Backpack = new Backpack();
		initializeInventory();
		// ElfMovement elfMovement = GameObject.Find("ElfPC").GetComponent<ElfMovement>();
        // elfMovement.updateSpeed();

	}

	private void initializeInventory() {
		Backpack.artifacts = new ArtifactEntity[6] {
			new ArtifactEntity("Amulet", "amulet", true, 0f , 0f, 0.95f),
			new ArtifactEntity("Sword", "sword", true, 1.5f, 2.0f, 0f),
			new ArtifactEntity("Shield", "shield", true, 4.5f, 0f, 2.0f),
			new ArtifactEntity("Mask", "mask", true, 0.2f, 0f, 0f),
			new ArtifactEntity("GoldBarA", "golda", true, 10.0f, 0f, 0f),
			new ArtifactEntity("GoldBarB", "goldb", true, 10.0f, 0f, 0f),
		};
	}

    public string getItems() {
    	return Backpack.toString();
    }

    public float getInventoryWeight() {
    	return Backpack.getContentsWeight();
    }

    public void removeFromBackpack(string shortName) {
    	Backpack.deactivateArtifact(shortName);
    }

    public void writeInventory() {
    	// TODO implement
    }

    public void readInventory() {
    	// TODO implement
    }
}
