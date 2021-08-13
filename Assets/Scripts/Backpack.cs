using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]

public class Backpack
{
	public ArtifactEntity[] artifacts;

	public void deactivateArtifact(string shortName) {
		foreach (ArtifactEntity artifact in artifacts) {
			if(artifact.shortName == shortName && artifact.IsActive()) {
				artifact.Deactivate();
			}
		}		
	}

	public ArtifactEntity[] getArtifacts() {
		return artifacts;
	}

	public float getContentsWeight() {
		float weight = 0f;
		foreach (ArtifactEntity artifact in artifacts) {
			if(artifact.IsActive()) {
				weight += artifact.weight;				
			}
		}

		return weight;
	}

	public string toString() {
		string list = "";

		foreach (ArtifactEntity artifact in artifacts) {
			if(artifact.IsActive()) {
				list+= artifact.name + ";";				
			}
		}

		return list;
	}
}