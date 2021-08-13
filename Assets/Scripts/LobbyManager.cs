using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
	public GameObject Elf;
	private GameObject MyElf;
    private Vector3 FoyerPosition;

    void Awake() {
        MyElf = GameObject.Find("ElfPC");

        FoyerPosition = new Vector3(9f, -1f, 0);
        
        if(!MyElf) {
            MyElf = Instantiate(Elf, FoyerPosition, Quaternion.identity);
            MyElf.name = "ElfPC";
        } else {
            FoyerPosition = MyElf.GetComponent<ElfMovement>().getLastFoyerPostion(); // FIXME This should return a Vector 3, not a transform!

            if(FoyerPosition.y > 0) {
                FoyerPosition = new Vector3(FoyerPosition.x, FoyerPosition.y - 0.5f, FoyerPosition.z);
            } else {
                FoyerPosition = new Vector3(FoyerPosition.x, FoyerPosition.y + 0.5f, FoyerPosition.z);
            }
        }        
    }

    void Start() {
		MyElf.transform.position = FoyerPosition;
        MyElf.transform.GetComponent<ElfMovement>().updateSpeed();
    }
}
