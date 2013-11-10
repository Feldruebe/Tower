using UnityEngine;
using System.Collections;

public class LastButtons : MonoBehaviour {

    public int historyLength;
    public GameObject sprite;

    public InputButton[] lastInputs;
    tk2dSprite[] lastInputSprites;

	// Use this for initialization
	void Start () {
        lastInputs = new InputButton[historyLength];
        lastInputSprites = new tk2dSprite[historyLength];

        for (int i = 0; i < historyLength; i++)
			{
                lastInputs[i] = InputButton.Left;
                lastInputSprites[i] = (Instantiate(sprite) as GameObject).GetComponent<tk2dSprite>();
                lastInputSprites[i].transform.parent = Camera.main.transform;
                lastInputSprites[i].transform.localPosition = new Vector3(-30 + i * 4 ,18,15);
                
			}

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddKey(InputButton.Left);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            AddKey(InputButton.Right);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            AddKey(InputButton.Up);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            AddKey(InputButton.Down);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddKey(InputButton.Jump);
        }

        for (int i = 0; i < historyLength; i++)
        {
            switch (lastInputs[i])
            {
                case InputButton.Left:
                    lastInputSprites[i].spriteId = 2;
                    break;
                case InputButton.Right:
                    lastInputSprites[i].spriteId = 3;
                    break;
                case InputButton.Up:
                    lastInputSprites[i].spriteId = 0;
                    break;
                case InputButton.Down:
                    lastInputSprites[i].spriteId = 1;
                    break;
                case InputButton.Jump:
                    lastInputSprites[i].spriteId = 4;
                    break;
                case InputButton.Attack:
                    lastInputSprites[i].spriteId = 5;
                    break;
                case InputButton.Defend:
                    lastInputSprites[i].spriteId = 6;
                    break;
                default:
                    break;
            }
        }
	}

    private void AddKey(InputButton inputButton)
    {
        for (int i = historyLength - 1; i > 0; i--)
            lastInputs[i] = lastInputs[i-1];

        lastInputs[0] = inputButton;
    }
}

public enum InputButton
{
    Up,
    Down,
    Left,
    Right,
    Attack,
    Jump,
    Defend,
}
