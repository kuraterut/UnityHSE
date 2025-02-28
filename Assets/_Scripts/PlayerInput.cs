using System;
using UnityEngine;

namespace _Scripts
{

    public class PlayerInput : MonoBehaviour
    {
        private GameField _gameField;

        // Переменные для обработки свайпов
        private Vector2 _startTouchPosition;
        private Vector2 _endTouchPosition;
        private bool _isSwiping = false;
        private float _minSwipeDistance = 50f; // Минимальная дистанция для свайпа

        private void Start()
        {
            _gameField = FindFirstObjectByType<GameField>();
            if (_gameField == null)
            {
                Debug.LogError("GameField not found!");
            }
            else
            {
                Debug.Log("Game field found!");
            }
        }

        private void Update()
        {
            HandleKeyboardInput();
            HandleTouchInput();
        }

        private void HandleKeyboardInput()
        {
            bool isLeftButtonPressed = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
            bool isRightButtonPressed = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
            bool isUpButtonPressed = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
            bool isDownButtonPressed = Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S);

            if (isLeftButtonPressed)
            {
                Debug.Log("Left button pressed!");
                _gameField.MoveCells(Vector2.left);
            }

            if (isRightButtonPressed)
            {
                Debug.Log("Right button pressed!");
                _gameField.MoveCells(Vector2.right);
            }

            if (isDownButtonPressed)
            {
                Debug.Log("Down button pressed!");
                _gameField.MoveCells(Vector2.down);
            }

            if (isUpButtonPressed)
            {
                Debug.Log("Up button pressed!");
                _gameField.MoveCells(Vector2.up);
            }
        }

        private void HandleTouchInput()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _startTouchPosition = touch.position;
                        _isSwiping = true;
                        break;

                    case TouchPhase.Ended:
                        if (_isSwiping)
                        {
                            _endTouchPosition = touch.position;
                            DetectSwipe();
                            _isSwiping = false;
                        }

                        break;
                }
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                _startTouchPosition = Input.mousePosition;
                _isSwiping = true;
            }

            if (Input.GetMouseButtonUp(0) && _isSwiping)
            {
                _endTouchPosition = Input.mousePosition;
                DetectSwipe();
                _isSwiping = false;
            }
        }

        private void DetectSwipe()
        {
            Vector2 swipeDelta = _endTouchPosition - _startTouchPosition;
            
            if (swipeDelta.magnitude >= _minSwipeDistance)
            {
                float angle = Mathf.Atan2(swipeDelta.y, swipeDelta.x) * Mathf.Rad2Deg;

                if (angle < 0)
                {
                    angle += 360;
                }

                if (angle >= 45 && angle < 135)
                {
                    Debug.Log("Swipe Up");
                    _gameField.MoveCells(Vector2.up);
                }
                else if (angle >= 135 && angle < 225)
                {
                    Debug.Log("Swipe Left");
                    _gameField.MoveCells(Vector2.left);
                }
                else if (angle >= 225 && angle < 315)
                {
                    Debug.Log("Swipe Down");
                    _gameField.MoveCells(Vector2.down);
                }
                else
                {
                    Debug.Log("Swipe Right");
                    _gameField.MoveCells(Vector2.right);
                }
            }
        }
    }
}