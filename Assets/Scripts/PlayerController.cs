using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector3 newPos;
    private Vector3 oldPos;
    Camera mainCamera;
    public Rect windowRect = new Rect(20, 20, 120, 100);
    public Transform selectedTarget;

    private List<Vector3> positions = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                if (hit.collider.CompareTag("Player")) {
                    selectedTarget = hit.transform;
                    oldPos = selectedTarget.position;
                    selectedTarget.GetComponent<Player>().PlayerSelected();
                    return;
                }

                if (selectedTarget == null) return;
                newPos = new Vector3(hit.point.x, selectedTarget.position.y, hit.point.z);
                positions.Add(newPos);
                ICommand command = new MovePlayerCommand(selectedTarget,oldPos,newPos);
                CommandInvoker.AddCommand(command);
                oldPos = newPos;
            }
        }


        if (Input.GetKeyDown(KeyCode.Z)) {
            CommandInvoker.UndoCommand();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {

            CommandInvoker.RedoCommand();
        }



        //if (selectedTarget != null &&selectedTarget.position == newPos) {
        //    positions.RemoveRange(0, positions.Count);  
        //}
    }


    private void OnDrawGizmos()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            Vector3 pos = positions[i];
            if (pos == null) return;
            Gizmos.color = Color.red;
            Gizmos.DrawIcon(pos, "target.png", true);
            if (i < positions.Count - 1) Gizmos.DrawLine(pos, positions[i + 1]);
        }
    }

}
