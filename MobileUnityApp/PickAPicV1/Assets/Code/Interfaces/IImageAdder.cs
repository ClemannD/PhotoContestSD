using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IImageAdder{

	//List<ImageEntry> GetListOfEntries ();//return the list of ImageEntry objects, which represent the images you wish to display on the screen represented by the class implementing this interface

	void AddImage(IServerImage entry);//the class implementing this interface uses this to set an image onto the screen it represents

	MonoBehaviour GetMyMonoBehavior ();//preferably, return the actual object implementing this interface (it should extend monobehavior)
}
