using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractiveObject {

	void Interact(Transform hand);

	void Release();

}
