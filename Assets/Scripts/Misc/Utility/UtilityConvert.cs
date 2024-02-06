using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityConvert 
{
    public static bool ConvertFloatButtonToBool(float _value,out bool _checkedValue)
	{
		switch(_value)
		{
			case 1:
			return _checkedValue = true;
				
			case 0:
			return _checkedValue = false;
				
		}
		return _checkedValue = false;
	}
}
