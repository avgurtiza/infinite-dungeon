using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ElfMovement : MonoBehaviour
{
    private ElfActions elfActions;

    private float movementX;
    
    private float movementY;

    private Vector2 currentDirection;

    public float speed = 0.2f;
    
    private float baseSpeed = 0.2f;
    private float elfWeight = 50f;

    public bool isPaused; 

    private GameObject DialogManager;

    private Vector3 lastFoyerPosition;

    private Vector3 dungeonEntryPostion;

    protected ElfInventory elfInventory;

    private Vector2 movement;

    void Awake() { 
        DontDestroyOnLoad(this.gameObject);
        elfActions = new ElfActions();
    }

    void Start() {
        DialogManager = GameObject.Find("DialogManager");        
        elfInventory = GameObject.Find("ElfPC").GetComponent<ElfInventory>();

        if(!elfInventory) {
            Debug.Log("Elf inventory was not found!");
        }
    }

    void Update()
    {
        movement = new Vector2(movementX, movementY);

        transform.Translate(movement * speed, Space.World);
    }

    public void setLastFoyerPostion() {
        lastFoyerPosition = transform.position;
        // Debug.Log("Foyer position set!");
    }

    public Vector3 getLastFoyerPostion() {
        if(lastFoyerPosition == null) {
            setLastFoyerPostion();
        }

        return lastFoyerPosition;
    }

    public void setDungeonEntryPosition(Vector3 position) {
        dungeonEntryPostion = position;
    }

    public Vector3 getDungeonEntryPosition() {
        return dungeonEntryPostion;
    }

    // TODO change to gamepad button convention (XYAB)
    private void OnRespondYes(InputValue input) {
        if(isPaused) {
            setPCResponse("yes");
        }
    }
    
    private void OnRespondNo(InputValue input) {
        if(isPaused) {
            setPCResponse("no");
        }
    }

    // TODO create a dialog service and delegate to that
    private void setPCResponse(string response) {
        DialogManager.GetComponent<DialogManager>().setPCResponse(response);
    }

    // TODO create an abstract class for these
    public void OnMenu(InputValue input) {
        if(!isPaused) {
            doPause();
        } else {
            unPause();
        }
    }

    public void doPause() {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void unPause() {
        Time.timeScale = 1;
        isPaused = false;
    }

    private void OnEnable() {
        elfActions.Enable();
    }
    
    private void OnDisable() {
        elfActions.Disable();
    }

    private void OnMove(InputValue input) {
        Vector2 movementVector = input.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    public void updateSpeed() {
        ElfInventory elfInventory = GameObject.Find("ElfPC").GetComponent<ElfInventory>();
        float inventoryWeight = elfInventory.getInventoryWeight();
        float speedModifier = 1 - ((inventoryWeight / elfWeight) * 1.15f); 
        speed = baseSpeed * speedModifier;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        Collider2D collider = collision.collider;

        // TODO move to its own handler class
        // TODO add handler for other entity-tags

        if(collider.tag == "Receptacle") {            
            updateSpeed();
            Debug.Log("Speed: " + speed.ToString() + ", Inventory: " + elfInventory.getItems());
        }

        if(collider.tag == "Door") {
            GameObject gameObject = collision.gameObject;
            string conversationIndex = gameObject.GetComponent<DoorEntity>().ConversationIndex;

            if(conversationIndex != "") {
                converse(conversationIndex);
                doPause();
            }
        }
    }

    private void converse(string speechIndex) {
        DialogManager.GetComponent<DialogManager>().beginConversation(speechIndex);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // DialogManager.GetComponent<DialogManager>().clearConversation();
    }


}