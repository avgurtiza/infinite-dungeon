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
            FoyerPosition = MyElf.GetComponent<ElfMovement>().getLastFoyerPostion();
        }        
    }

    void Start() {
		MyElf.transform.position = FoyerPosition;
        MyElf.transform.GetComponent<ElfMovement>().updateSpeed();
    }
}
