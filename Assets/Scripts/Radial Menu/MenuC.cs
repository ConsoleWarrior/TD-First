using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuC : MonoBehaviour
{
    public ButtonC buttonPrefab;
    public ButtonC selected;
    private Interactable field;
  

    public void SpawnButtons(Interactable obj){
        field = obj;
        if(obj.turel){

            ButtonC newButton = Instantiate(buttonPrefab) as ButtonC;
            newButton.transform.SetParent (transform, false);
            newButton.transform.localPosition = new Vector3(0f,40f,0f);
            newButton.title = "Rotate";
            newButton.myMeny = this;

            /*ButtonC newButton2 = Instantiate(buttonPrefab) as ButtonC;
            newButton2.transform.SetParent (transform, false);
            newButton2.transform.localPosition = new Vector3(0f,-40f,0f);
            newButton2.icon = newButton2.rotate;
            newButton2.title = "Rotate";
            //newButton2.myMeny = this;*/

        }
        else
        for(int i = 0; i < obj.options.Length; i++){
            ButtonC newButton = Instantiate(buttonPrefab) as ButtonC;
            float theta = (2*Mathf.PI/obj.options.Length)*i;
            float xpos = Mathf.Sin(theta);
            float ypos = Mathf.Cos(theta);
            newButton.transform.SetParent (transform, false);
            newButton.transform.localPosition = new Vector3(xpos, ypos, 0f)*40;
            //newButton.transform.localPosition = new Vector3(0f,30f,0f);
            newButton.circle.color = obj.options[i].color;
            newButton.icon.sprite = obj.options[i].sprite;
            newButton.title = obj.options[i].title;
            newButton.myMeny = this;
            
        }   
    }

    void Update(){
        if(Input.GetMouseButtonUp(0)){
            if(selected) {Debug.Log($"selected: <{selected.title}>");//ЗДЕСЬ НАЗНАЧЕНИЕ БАТТОНА
                switch (selected.title)
                {
                case "Cannon": field.turel = Creator.CreateCannon(Interactable.field); break;
                    // if (field.turel) { field.empty = false; break; } else break;
                    case "Stazis": field.turel = Creator.CreateStazis(Interactable.field); break;
                    // if (field.turel) { field.empty = false; break; } else break;
                    case "BitcoinMine": field.turel = Creator.CreateBitcoinMine(Interactable.field); break;
                    //if (field.turel) { field.empty = false; break; } else break;
                    case "Platform": field.turel = Creator.CreatePlatform(Interactable.field); break;
                    //if (field.turel) { field.empty = false; break; } else break;
                    case "Energized": field.turel = Creator.CreateEnergized(Interactable.field); break;
                    case "Workshop": field.turel = Creator.CreateWorkshop(Interactable.field); break;
                    case "MachineGun": field.turel = Creator.CreateMachineGun(Interactable.field); break;
                    case "Rotate": field.turel.transform.rotation *= Quaternion.Euler(0f, 0f, -90f);; break;
                    case "Destroy": Destroy (field.turel); /*field.empty = true;*/ break;
                
                }
            }
            Destroy (gameObject);
        }
    }
}
//field.turel.transform.up = new Vector2(field.turel.transform.position.x, field.turel.transform.position.y);