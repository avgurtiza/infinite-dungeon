using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfInventory : MonoBehaviour
{
	private Backpack Backpack;

	void Awake() {
		Backpack = new Backpack();
		initializeInventory();
	}

	private void initializeInventory() {
		Backpack.artifacts = new ArtifactEntity[6] {
			new ArtifactEntity("Amulet", "amulet", true, 0f , 0f, 0.95f),
			new ArtifactEntity("Sword", "sword", true, 1.5f, 2.0f, 0f),
			new ArtifactEntity("Shield", "shield", true, 4.5f, 0f, 2.0f),
			new ArtifactEntity("Mask", "mask", true, 0.2f, 0f, 0f),
			new ArtifactEntity("GoldBarA", "goldbara", true, 10.0f, 0f, 0f),
			new ArtifactEntity("GoldBarB", "goldbarb", true, 10.0f, 0f, 0f),
		};
	}

	public bool hasItem(string itemName) {
		ArtifactEntity[] artifacts = Backpack.getArtifacts();

		foreach (ArtifactEntity artifact in artifacts) {

			if(artifact.IsActive() &&  artifact.shortName == itemName.ToLower()) {
				Debug.Log("Artifact active: " + artifact.name);
				return true;
			} 
		}

		return false;
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
