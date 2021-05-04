using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// This class keep track of command queues and the state of execution
/// </summary>
public class CommandInvoker : MonoBehaviour
{
    //buffer/queue of all commands added
    static Queue<ICommand> commandBuffer;
    //command history of undo and redo commands
    static List<ICommand> commandHistory;
    //help keep track of command index that we are at in commandHistory
    static int counter;
    //the current command that we are processing/executing
    static ICommand commandInProcess;

    private void Awake()
    {
        commandBuffer = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
    }


    public static void AddCommand(ICommand command) {
        //remove any redundant command in history
        while (commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command); 
    }

    public static void UndoCommand() {
        if (commandInProcess != null && commandInProcess.IsExecuting) return;
        //make sure we have some commands
        if (counter > 0) {
            counter--;//to match the index of history list
            commandInProcess = commandHistory[counter];
            commandInProcess.Undo();
        }
    }

    public static void RedoCommand() {

        if (commandInProcess != null && commandInProcess.IsExecuting) return;
        //make sure we dont cross thhe list
        if (counter < commandHistory.Count)
        {
            commandInProcess = commandHistory[counter];
            commandInProcess.Redo();
            counter++;
        }
    }


    private void Update()
    {       
        if (commandBuffer.Count > 0) {

            //wait till the command finish execution
            if (commandInProcess != null && commandInProcess.IsExecuting) return;

            //take the oldest command out of the queue and return it
            commandInProcess = commandBuffer.Dequeue();
            commandInProcess.Execute();

            //add command to history after execution begins
            commandHistory.Add(commandInProcess);
            counter++;
            Debug.Log("commandHistory length: " + commandHistory.Count);
        }
    }
}
