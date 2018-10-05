using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletPoints : MonoBehaviour
{
    [Header("Details")]
    public Text details;
    public string[] detailText;
    [Header("Facts")]
	public Transform factObjParent;
    public List<Text> factObj;
    public string[] factText;
	float startY;
	public float scrollDistance = 40;
    [Header("Select")]
    public RectTransform selecter;
    public int curSelected = 0;
    bool canchangeSelect = true;
    MainManager mainManager;
	public bool[] unlocked;

    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
		factObj.Clear();
		for (int i = 0; i < factObjParent.childCount; i++)
		{
			factObj.Add(factObjParent.GetChild(i).GetComponent<Text>());
		}
		startY = factObjParent.position.y;
    }

    void Update()
    {
        SetDetailText();
        SetFactTexts();
        SetSelecter();
        SetCurSelected();
    }

    void SetDetailText()
    {
		if(unlocked[curSelected] == true){
        details.text = detailText[curSelected];
		} else {
			details.text = "???";
		}
    }

    void SetFactTexts()
    {
        for (int i = 0; i < factObj.Count; i++)
        {
			if(unlocked[i] == true){
            factObj[i].text = factText[i];
			} else {
				factObj[i].text = "???";
			}
			factObjParent.position = new Vector3(factObjParent.position.x,(startY - 450) + curSelected * scrollDistance,factObjParent.position.z);
        }
    }

    void SetSelecter()
    {
        selecter.position = factObj[curSelected].transform.position;
    }

    void SetCurSelected()
    {
        if (mainManager.paused == true)
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (canchangeSelect == true)
                {
                    mainManager.PlaySound(11,0.1f);
					if(Input.GetAxisRaw("Vertical") > 0){
                    curSelected -= Mathf.CeilToInt(Input.GetAxisRaw("Vertical"));
					} else {
						curSelected -= Mathf.FloorToInt(Input.GetAxisRaw("Vertical"));
					}
                    if (curSelected < 0)
                    {
                        curSelected = factObj.Count - 1;
                    }
                    else if (curSelected > factObj.Count - 1)
                    {
                        curSelected = 0;
                    }
                    canchangeSelect = false;
                }
            }
            else
            {
                canchangeSelect = true;
            }
        }
        else
        {
            canchangeSelect = true;
        }
    }
}
