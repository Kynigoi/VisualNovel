using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DIALOGUE {

    
//The box that holds the name text on screen. Part of the dialogue container

    [System.Serializable]
    public class NameContainer
    {
        [SerializeField] private GameObject root;
        [SerializeField] private TextMeshProUGUI nameText;
        public void Show(string nameToShow = "")
        {
            root.SetActive(true);
            
            if(nameToShow != string.Empty)
                nameText.text = nameToShow;
        }

        public void Hide()
        {
            root.SetActive(false);
        }
    }
}
