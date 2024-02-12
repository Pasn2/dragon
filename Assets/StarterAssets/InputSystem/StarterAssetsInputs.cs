using Unity.VisualScripting;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool perspectiveSwitch;
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = false;
		public bool cursorInputForLook = true;


		public void OnMove(InputAction.CallbackContext contex)
		{
			MoveInput(contex.ReadValue<Vector2>());
		}

		public void OnLook(InputAction.CallbackContext contex)
		{
			if(cursorInputForLook)
			{
				LookInput(contex.ReadValue<Vector2>());
			}
		}

		public void OnJump(InputAction.CallbackContext contex)
		{
			JumpInput(contex.ReadValue<float>());
		}

		public void OnSprint(InputAction.CallbackContext contex)
		{
			print("contxt spritn works" + contex.ReadValue<float>());
			SprintInput(contex.ReadValue<float>());
		}
		public void OnAim(InputAction.CallbackContext context)
		{
			AimInput(context.ReadValue<float>());
		}

		public void OnPause(InputAction.CallbackContext context )
		{
			SetCursorState(cursorLocked = !cursorLocked);
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(float _buttonValue)
		{
			UtilityConvert.ConvertFloatButtonToBool(_buttonValue,out jump);
		}

		public void SprintInput(float _buttonValue)
		{
			UtilityConvert.ConvertFloatButtonToBool(_buttonValue,out sprint);
		}
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
		public void AimInput(float _buttonValue)
		{
			UtilityConvert.ConvertOneDToBool(_buttonValue,out perspectiveSwitch);
		}
	}
	
}