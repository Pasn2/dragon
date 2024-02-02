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
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
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
			JumpInput(contex.started);
		}

		public void OnSprint(InputAction.CallbackContext contex)
		{
			SprintInput(contex.started);
		}



		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}