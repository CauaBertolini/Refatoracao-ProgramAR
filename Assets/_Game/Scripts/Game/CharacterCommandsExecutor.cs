using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterCommandsExecutor : MonoBehaviour
{

    private CharacterManager _characterManager;

    void Start()
    {
        _characterManager = GetComponent<CharacterManager>();
    }
    
    public void ExecutorExecuteCommandList(List<CommandType> commandList)
    {
        StartCoroutine(ExecuteCommands(commandList));
    }

    private IEnumerator ExecuteCommands(List<CommandType> commands)
    {
        foreach (var command in commands)
        {
            switch (command)
            {
                case CommandType.WalkFoward:
                    yield return WalkFoward();
                    break;

                case CommandType.RotateLeft:
                    yield return RotateLeft();
                    break;
                
                case CommandType.RotateRight:
                    yield return RotateRight();
                    break;
                
                case CommandType.Interact:
                    yield return Interact();
                    break;

                case CommandType.Wait:
                    yield return Wait();
                    break; 
                    
                case CommandType.Function1:
                    yield return ExecuteCommands(_characterManager.CommandList.Function1);
                    
            }

            yield return new WaitForSeconds(0.25f);
        }

        yield break;
    }

    private IEnumerator WalkFoward()
    {
        if (_characterManager.characterStepsCount == 0)
        {
            Quaternion playerRotation = Quaternion.Euler(0, this.gameObject.transform.eulerAngles.y, 0);

            Vector3 playerForward = playerRotation * Vector3.forward;

            Vector3 playerPosition = this.gameObject.transform.position;
            playerPosition.y += .05f;

            RaycastHit hit;
            
            if (Physics.Raycast(playerPosition, playerForward, out hit, .1f) && hit.transform.gameObject.layer == 6)
            {
                log.Add($"Passo {idCurrentCommand} - Não consegui andar");

                _characterManager.CharacterStepsCount = 0;

                CancelInvoke("Walk");
                yield return null;
            }

            if (!Physics.Raycast(playerPosition + playerForward / 10, playerRotation * -Vector3.up, out hit, .1f))
            {
                log.Add($"Passo {idCurrentCommand} - Não consegui andar");

                _characterManager.CharacterStepsCount = 0;

                CancelInvoke("Walk");
                yield return null;
            }

            this.gameObject.GetComponentInChildren<Animator>().SetBool("Walk", true);
        }

        this.gameObject.transform.Translate(Vector3.forward / 1000, Space.Self);

        if (++_characterManager.CharacterStepsCount == 100)
        {
            _characterManager.CharacterStepsCount = 0;

            this.gameObject.GetComponent<Animator>().SetBool("Walk", false);
            CancelInvoke("Walk");
        }

        yield return null;
    }

    private IEnumerator RotateRight()
    {
        float playerYRot = this.gameObject.transform.rotation.eulerAngles.y;
        this.gameObject.transform.rotation = Quaternion.Euler(0, playerYRot + 90, 0);
        yield return null;        
    }

    private IEnumerator RotateLeft()
    {
        float playerYRot = this.gameObject.transform.rotation.eulerAngles.y;
        this.gameObject.transform.rotation = Quaternion.Euler(0, playerYRot - 90, 0);
        yield return null;
    }

    private IEnumerator Interact()
    {
        Vector3 playerForward = Quaternion.Euler(0, this.gameObject.transform.eulerAngles.y, 0) * Vector3.forward;

        Vector3 playerPosition = this.gameObject.transform.position;
        playerPosition.y += .05f;

        RaycastHit hit;
        if (!Physics.Raycast(playerPosition, playerForward, out hit, .1f))
            yield return null;

        if (hit.transform.tag == "Lever")
        {
            GameObject lever = hit.transform.gameObject;
            lever.GetComponentInChildren<Animator>().enabled = true;

            GameObject relatedDoor = GameObject.Find($"Door{lever.name[5]}");
            relatedDoor.GetComponentInChildren<Animator>().enabled = true;
        }
        else if (hit.transform.tag == "Door")
        {
            if (!_characterManager.haveKey)
            {
                log.Add($"Passo {idCurrentCommand} - Não peguei a chave");

                yield return null;
            }

            hit.transform.parent.GetComponentInChildren<Animator>().enabled = true;
        }
    }

}
