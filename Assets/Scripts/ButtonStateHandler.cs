using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Epic.UI //I'm guessing the namespace covers the different classes into a unified script.
{
    public class ButtonStateHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {   
        [SerializeField] int _state; //What 'state' the button is in.
        [SerializeField] ButtonState[] _states; //The different states the button can use
        [SerializeField] bool _isToggleable;
        [SerializeField] bool _isSelected;
        [SerializeField] TMP_Text _textbox;
        [SerializeField] Image _image;

        /// <summary>
        /// Called on a button being clicked, returns state and value.
        /// </summary>

        public Action<bool, string> ButtonClicked; //Fetches values and places them inside an 'action'. Assumedly, a set of information to use later in the script. 
        /// <summary>
        /// Called when a button is clicked, returns value only.
        /// </summary>
        public Action<string> ButtonToggled; //Toggled buttons are always true when selected.

        private void Start()
        {
            SettingsStateValues(_states[0]); //Start the settingsstatevalues method at 0 the first time loading? Why?
        } 

        public void ButtonSelected() //I think this is the 'Modulu', it won't return a number over 1 less than the right number.
        {
            if (_states.Length == 0) //If there are no states...
            return; //Do nothing.

            ButtonClicked?.Invoke(_isSelected, _states[_state].value); //If the button is clicked, invokve the is Selected state, give state and value.
            ButtonToggled?.Invoke(_states[_state].value); //If the button is toggled, give the button's value?

            if(_isToggleable) //If the button is toggleable.
            {
                _state = (_state + 1) % _states.Length; //I don't know what this means...
                SettingsStateValues(_states[_state]);
            }
            else
            {
                _isSelected = !_isSelected; //The button is turned nto a regular button's function if it isn't a toggle.
            }
        }

        void SettingsStateValues(ButtonState state) //For icons and text editing within a button.
        {
            _image.color = state.normalColour; //For changing configured colours?
            _image.sprite = state.icon; //For changing configured icons?
            _textbox.text = state.text; //For changing configured text?
        }

        public void OnPointerEnter(PointerEventData eventData) //Here are ye Unity interfaces. Help us track where the mouse is and have it interact with this script.
        {
            _image.color = _states[_state].hoverColour; //Changes state to hover colour.
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.color = _states[_state].normalColour;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _image.color = _states[_state].pressedColour;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            //_image.color = _states[_state].normalColour;
            ButtonSelected(); //The button selected script is activated when the button is pressed.
        }
    }

    [Serializable] public class ButtonState //Second class can be viewed and edited in editor.
    {
        public Sprite icon;
        public string text;
        public string value;
        public Color normalColour;
        public Color hoverColour;
        public Color pressedColour;
    }
}

//The two 'endings' refer to the ones in this article: https://medium.com/unity-coder-corner/unity-state-based-buttons-48f88a054d5d